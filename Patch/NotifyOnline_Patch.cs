using HarmonyLib;
using ProjectM;
using ProjectM.Network;
using Stunlock.Network;
using Wetstone.API;
using Notify.Helpers;
using Notify.Utils;

namespace Notify.Patch
{
    [HarmonyPatch]
    public class NotifyOnline_Patch
    {

        [HarmonyPatch(typeof(ServerBootstrapSystem), nameof(ServerBootstrapSystem.OnUserConnected))]
        [HarmonyPrefix]
        public static void ServerBootstrapSystem_Online_Postfix(ServerBootstrapSystem __instance, NetConnectionId netConnectionId)
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
                    Plugin.Logger.LogWarning($"Search '{userNick}' in database.");

                    LoadConfigHelper.LoadUsersConfigOnline();

                    var _message = DBHelper.getUserOnlineValue(userNick);

                    Plugin.Logger.LogInfo($"FIND '{userNick}' in database with message {_message}");
                    _message = _message.Replace("#user#", $"{FontColorChat.Yellow(userNick)}");
                    ServerChatUtils.SendSystemMessageToAllClients(entityManager, FontColorChat.Green($"{_message}"));
                        
                }
            }
            else
            {
                if (DBHelper.isEnabledAnnounceNewUser())
                {
                    var _message = DBHelper.getUserOnlineValue("");
                    Plugin.Logger.LogInfo($"New User");
                    ServerChatUtils.SendSystemMessageToAllClients(entityManager, FontColorChat.Green($"{_message}"));
                }
            }
        }
    }
}