using Bloodstone.API;
using Bloody.Core;
using Bloody.Core.API.v1;
using Bloody.Core.GameData.v1;
using Bloody.Core.Helper.v1;
using BloodyNotify.DB;
using ProjectM;
using ProjectM.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unity.Collections;
using Unity.Entities;

namespace BloodyNotify.Systems
{
    internal class KillVBloodSystem
    {
        private const double SendMessageDelay = 2;
        public static Dictionary<string, HashSet<string>> vbloodKills = [];
        private static EntityManager _entityManager = Plugin.SystemsCore.EntityManager;
        private static PrefabCollectionSystem _prefabCollectionSystem = Plugin.SystemsCore.PrefabCollectionSystem;
        private static bool checkKiller = false;
        private static Dictionary<string, DateTime> lastKillerUpdate = [];

        public static void OnDetahVblood(VBloodSystem sender, NativeList<VBloodConsumed> deathEvents)
        {

            if(!Database.EnabledFeatures[NotifyFeature.vblood]) { return; }

            if (deathEvents.Length > 0)
            {
                foreach (var event_vblood in deathEvents)
                {
                    if (_entityManager.HasComponent<PlayerCharacter>(event_vblood.Target))
                    {
                        var player = _entityManager.GetComponentData<PlayerCharacter>(event_vblood.Target);
                        var user = _entityManager.GetComponentData<User>(player.UserEntity);
                        var vbloodString = _prefabCollectionSystem.PrefabGuidToNameDictionary[event_vblood.Source];
                        AddKiller(vbloodString.ToString(), user.CharacterName.ToString());
                        lastKillerUpdate[vbloodString.ToString()] = DateTime.Now;
                        checkKiller = true;
                    }
                }
            }
            else if (checkKiller)
            {
                var didSkip = false;
                foreach (KeyValuePair<string, DateTime> kvp in lastKillerUpdate)
                {
                    var lastUpdateTime = kvp.Value;
                    if (DateTime.Now - lastUpdateTime < TimeSpan.FromSeconds(SendMessageDelay))
                    {
                        didSkip = true;
                        continue;
                    }
                    SendAnnouncementMessage(kvp.Key);
                }
                checkKiller = didSkip;
            }
        }

        public static void AddKiller(string vblood, string killerCharacterName)
        {
            if (!vbloodKills.ContainsKey(vblood))
            {
                vbloodKills[vblood] = new HashSet<string>();
            }
            vbloodKills[vblood].Add(killerCharacterName);
        }

        public static void RemoveKillers(string vblood)
        {
            vbloodKills[vblood] = new HashSet<string>();
        }

        public static List<string> GetKillers(string vblood)
        {
            return vbloodKills[vblood].ToList();
        }

        public static void SendAnnouncementMessage(string vblood)
        {
            if (checkifBloodyBoss(vblood))
            {
                RemoveKillers(vblood);
                return;
            }

            var message = GetAnnouncementMessage(vblood);
            if (message == "ignore")
            {
                RemoveKillers(vblood);
                return;
            }
            if (message != null)
            {
                var usersOnline = GameData.Users.Online;
                foreach (var user in usersOnline)
                {
                    var isUserIgnore = Database.getVBloodNotifyIgnore(user.CharacterName);
                    if (!isUserIgnore)
                    {
                        ServerChatUtils.SendSystemMessageToClient(VWorld.Server.EntityManager, user.Internals.User.Value, message);
                    }
                }
                RemoveKillers(vblood);
            }

        }

        private static bool checkifBloodyBoss(string vblood)
        {

            var entitiesQuery = QueryComponents.GetEntitiesByComponentTypes<VBloodUnit, NameableInteractable, LifeTime>(EntityQueryOptions.Default, false);

            foreach (var entity in entitiesQuery)
            {
                try
                {
                    var npc = GameData.Npcs.FromEntity(entity);

                    var vbloodString = _prefabCollectionSystem.PrefabGuidToNameDictionary[npc.PrefabGUID];
                    if (vbloodString == vblood)
                    {


                        NameableInteractable _nameableInteractable = entity.Read<NameableInteractable>();
                        if (_nameableInteractable.Name.Value.Contains("bb"))
                        {
                            var health = entity.Read<Health>();
                            if (health.IsDead)
                            {
                                entitiesQuery.Dispose();
                                return true;
                            }

                            entitiesQuery.Dispose();
                            return false;
                        }
                    }
                } catch {

                    continue;
                }
                
                
            }

            entitiesQuery.Dispose();
            return false;
        }

        public static string GetAnnouncementMessage(string vblood)
        {
            var killers = GetKillers(vblood);
            var vbloodLabel = Database.getPrefabNameValue(vblood);
            var vbloodIgnore = Database.getPrefabIgnoreValue(vblood);
            var sbKillersLabel = new StringBuilder();

            if (vbloodIgnore)
            {
                return "ignore";
            }
            if (killers.Count == 0) return null;
            if (killers.Count == 1)
            {
                sbKillersLabel.Append(FontColorChatSystem.Yellow(killers[0]));
            }
            if (killers.Count == 2)
            {
                sbKillersLabel.Append($"{FontColorChatSystem.Yellow(killers[0])} {Database.getVBloodFinalConcatCharacters()} {FontColorChatSystem.Yellow(killers[1])}");
            }
            if (killers.Count > 2)
            {
                for (int i = 0; i < killers.Count; i++)
                {
                    if (i == killers.Count - 1)
                    {
                        sbKillersLabel.Append($"{Database.getVBloodFinalConcatCharacters()} {FontColorChatSystem.Yellow(killers[i])}");
                    }
                    else
                    {
                        sbKillersLabel.Append($"{FontColorChatSystem.Yellow(killers[i])}, ");
                    }
                }
            }

            var _message = Database.getDefaultAnnounceValue("VBlood");
            _message = _message.Replace("#user#", $"{sbKillersLabel}");
            _message = _message.Replace("#vblood#", $"{FontColorChatSystem.Red(vbloodLabel)}");
            return FontColorChatSystem.Green($"{_message}");
        }
    }
}
