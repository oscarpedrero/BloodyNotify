using HarmonyLib;
using ProjectM;
using System;
using Unity.Entities;

namespace Notify.Patch
{

    public delegate void ServerStartupStateChangeEventHandler(LoadPersistenceSystemV2 sender, ServerStartupState.State serverStartupState);
    public delegate void OnUpdateEventHandler(World world);

    [HarmonyPatch]
    public class ServerEvents_Patch
    {

        public static event ServerStartupStateChangeEventHandler OnServerStartupStateChanged;
        public static event OnUpdateEventHandler OnUpdate;

        [HarmonyPatch(typeof(LoadPersistenceSystemV2), nameof(LoadPersistenceSystemV2.SetLoadState))]
        [HarmonyPrefix]
        private static void ServerStartupStateChange_Prefix(ServerStartupState.State loadState, LoadPersistenceSystemV2 __instance)
        {
            try
            {
                OnServerStartupStateChanged?.Invoke(__instance, loadState);
            }
            catch (Exception e)
            {
                Plugin.Logger.LogError(e);
            }
        }

        [HarmonyPatch(typeof(ServerTimeSystem_Server), nameof(ServerTimeSystem_Server.OnUpdate))]
        [HarmonyPostfix]
        private static void ServerTimeSystemOnUpdate_Postfix(ServerTimeSystem_Server __instance)
        {
            try
            {
                OnUpdate?.Invoke(__instance.World);
            }
            catch (Exception e)
            {
                Plugin.Logger.LogError(e);
            }
        }
    }
}
