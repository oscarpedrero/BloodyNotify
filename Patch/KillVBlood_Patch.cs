using HarmonyLib;
using Notify.Helpers;
using Notify.Utils;
using ProjectM;
using ProjectM.Network;
using System;
using System.Collections.Generic;
using System.Text;
using Unity.Entities;
using Wetstone.API;


/**
 * 
 * Based in Code By syllabicat from VBloodKills (https://github.com/syllabicat/VBloodKills)
 * 
**/
namespace Notify.Patch;

[HarmonyPatch]
public class VBloodSystem_Patch
{

    private const double SendMessageDelay = 2;
    private static bool checkKiller = false;
    private static Dictionary<string, DateTime> lastKillerUpdate = new();
    private static EntityManager entityManager = VWorld.Server.EntityManager;

    [HarmonyPatch(typeof(VBloodSystem), nameof(VBloodSystem.OnUpdate))]
    [HarmonyPrefix]
    public static void OnUpdate_Prefix(VBloodSystem __instance)
    {
        if (DBHelper.isEnabledAnnounceVBlood())
        {
            if (__instance.EventList.Length > 0)
            {
                foreach (var event_vblood in __instance.EventList)
                {
                    if (entityManager.HasComponent<PlayerCharacter>(event_vblood.Target))
                    {
                        var player = entityManager.GetComponentData<PlayerCharacter>(event_vblood.Target);
                        var user = entityManager.GetComponentData<User>(player.UserEntity);
                        // Modify from original code for get PrefabName(string) and not GuidHash(int)
                        var vblood = PrefabsUtils.getPrefabName(event_vblood.Source);
                        VBloodKillers.AddKiller(vblood, user.CharacterName.ToString());
                        lastKillerUpdate[vblood] = DateTime.Now;
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
                    VBloodKillers.SendAnnouncementMessage(kvp.Key);
                }
                checkKiller = didSkip;
            }
        }
    }
}
