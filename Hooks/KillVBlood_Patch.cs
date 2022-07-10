using HarmonyLib;
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
namespace Notify.Hooks;

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
        if (__instance._eventList.Length > 0)
        {
            foreach (var event_vblood in __instance._eventList)
            {
                if (entityManager.HasComponent<PlayerCharacter>(event_vblood.Target))
                {
                    var player = entityManager.GetComponentData<PlayerCharacter>(event_vblood.Target);
                    var user = entityManager.GetComponentData<User>(player.UserEntity._Entity);
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
                Utils.VBloodKillers.SendAnnouncementMessage(kvp.Key);
            }
            checkKiller = didSkip;
        }
    }
}
