using HarmonyLib;
using Notify.Helpers;
using Notify.Utils;
using ProjectM;
using ProjectM.Network;
using Stunlock.Network;
using Wetstone.API;

namespace Notify.Patch
{
    [HarmonyPatch]
    public class NotifyOffline_Patch
    {
        [HarmonyPatch(typeof(ServerBootstrapSystem), nameof(ServerBootstrapSystem.OnUserDisconnected))]
        [HarmonyPrefix]
        public static void OnUserDisconnected_Prefix(ServerBootstrapSystem __instance, NetConnectionId netConnectionId, ConnectionStatusChangeReason connectionStatusReason, string extraData)
        {
            if (DBHelper.isEnabledAnnounceOnline())
            {
                if (connectionStatusReason != ConnectionStatusChangeReason.IncorrectPassword)
                {
                    var entityManager = VWorld.Server.EntityManager;
                    var userIndex = __instance._NetEndPointToApprovedUserIndex[netConnectionId];
                    var serverClient = __instance._ApprovedUsersLookup[userIndex];
                    var userEntity = serverClient.UserEntity;
                    LoadConfigHelper.LoadUsersConfigOffline();
                    var userNick = PlayerUtils.getCharacterName(userEntity);
                    var _message = DBHelper.getUserOnlineValue(userNick);
                    Plugin.Logger.LogInfo($"User disconnect '{userNick}'");
                    _message = _message.Replace("#user#", $"{FontColorChat.Yellow(userNick)}");
                    ServerChatUtils.SendSystemMessageToAllClients(entityManager, $"{_message}");
                }
            }
        }
    }
}
