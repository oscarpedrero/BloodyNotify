using HarmonyLib;
using Notify.Helpers;
using Notify.Utils;
using ProjectM;
using ProjectM.Network;
using System;
using System.Collections.Generic;
using System.Text;
using Unity.Entities;
using UnityEngine.Rendering.HighDefinition;


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
        if (DBHelper.EnabledFeatures[NotifyFeature.vblood])
        {
            if (__instance.EventList.Length > 0)
            {
                foreach (var event_vblood in __instance.EventList)
                {
                    if (entityManager.HasComponent<PlayerCharacter>(event_vblood.Target))
                    {
                        var player = entityManager.GetComponentData<PlayerCharacter>(event_vblood.Target);
                        var user = entityManager.GetComponentData<User>(player.UserEntity);
                        var vblood = __instance._PrefabCollectionSystem.PrefabDataLookup[event_vblood.Source].AssetName;
                        VBloodKillers.AddKiller(vblood.ToString(), user.CharacterName.ToString());
                        lastKillerUpdate[vblood.ToString()] = DateTime.Now;
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
