using HarmonyLib;
using Notify.Helpers;
using Notify.Utils;
using ProjectM;
using ProjectM.Network;
using Stunlock.Network;
using Wetstone.API;

namespace Notify.Hooks;

[HarmonyPatch]
public class ServerBootstrapSystem_Patch
{
    [HarmonyPatch(typeof(ServerBootstrapSystem), nameof(ServerBootstrapSystem.OnUserConnected))]
    [HarmonyPrefix]
    public static void Postfix(ServerBootstrapSystem __instance, NetConnectionId netConnectionId)
    {
        var entityManager = VWorld.Server.EntityManager;
        var userIndex = __instance._NetEndPointToApprovedUserIndex[netConnectionId];
        var serverClient = __instance._ApprovedUsersLookup[userIndex];
        var userEntity = serverClient.UserEntity;


        bool isNewPlayer = PlayerUtils.isNewUser(userEntity);
        if (!isNewPlayer)
        {
            if (DBHelper.isEnabledAnnounceOnline())
            {
                var userNick = PlayerUtils.getCharacterName(userEntity);
                var _message = DBHelper.getUserOnlineValue(userNick);
                _message = _message.Replace("#user#", $"{FontColorChat.Yellow(userNick)}");
                ServerChatUtils.SendSystemMessageToAllClients(entityManager, FontColorChat.Green($"{_message}"));

            }
        }
        else
        {
            if (DBHelper.isEnabledAnnounceNewUser())
            {
                var _message = DBHelper.getUserOnlineValue("");
                ServerChatUtils.SendSystemMessageToAllClients(entityManager, FontColorChat.Green($"{_message}"));
            }
        }
    }

    [HarmonyPatch(typeof(ServerBootstrapSystem), nameof(ServerBootstrapSystem.OnUserDisconnected))]
    [HarmonyPrefix]
    public static void Prefix(ServerBootstrapSystem __instance, NetConnectionId netConnectionId, ConnectionStatusChangeReason connectionStatusReason, string extraData)
    {
        if (DBHelper.isEnabledAnnounceeOffline())
        {
            if (connectionStatusReason != ConnectionStatusChangeReason.IncorrectPassword)
            {
                var entityManager = VWorld.Server.EntityManager;
                var userIndex = __instance._NetEndPointToApprovedUserIndex[netConnectionId];
                var serverClient = __instance._ApprovedUsersLookup[userIndex];
                var userEntity = serverClient.UserEntity;
                var userNick = PlayerUtils.getCharacterName(userEntity);
                var _message = DBHelper.getUserOfflineValue(userNick);
                _message = _message.Replace("#user#", $"{FontColorChat.Yellow(userNick)}");
                ServerChatUtils.SendSystemMessageToAllClients(entityManager, $"{_message}");
            }
        }
    }
}

