using Bloody.Core;
using Bloody.Core.API.v1;
using Bloody.Core.GameData.v1;
using Bloody.Core.Models.v1;
using BloodyNotify.DB;
using ProjectM;
using ProjectM.Network;
using Stunlock.Network;
using Unity.Entities;

namespace BloodyNotify.Systems
{
    internal class OnlineOfflineSystem
    {
        private static EntityManager entityManager = Plugin.SystemsCore.EntityManager;

        internal static void OnUserOnline(ServerBootstrapSystem sender, NetConnectionId netConnectionId) {

            var userIndex = sender._NetEndPointToApprovedUserIndex[netConnectionId];
            var serverClient = sender._ApprovedUsersLookup[userIndex];
            var userEntity = serverClient.UserEntity;

            UserModel userModel = GameData.Users.FromEntity(userEntity);

            bool isNewPlayer = IsNewUser(userEntity);
            var userNick = userModel.CharacterName;

            Plugin.Logger.LogInfo($"ha conectado {userModel.CharacterName} ");

            if (!isNewPlayer)
            {
                if (Database.EnabledFeatures[NotifyFeature.online])
                {
                    var _message = Database.getUserOnlineValue(userNick);
                    _message = _message.Replace("#user#", $"{FontColorChatSystem.Yellow(userNick)}");
                    ServerChatUtils.SendSystemMessageToAllClients(entityManager, FontColorChatSystem.Green($"{_message}"));
                    
                }
            }
            else
            {
                if (Database.EnabledFeatures[NotifyFeature.newuser])
                {
                    var _message = Database.getUserOnlineValue("");
                    ServerChatUtils.SendSystemMessageToAllClients(entityManager, FontColorChatSystem.Green($"{_message}"));
                }
            }

            if (Database.EnabledFeatures[NotifyFeature.motd])
            {
                var _messageLines = Database.getMessageOfTheDay();
                foreach (string line in _messageLines)
                {
                    string lineReplace = line.Replace("#user#", $"{userNick}");
                    ServerChatUtils.SendSystemMessageToClient(entityManager, userEntity.Read<User>(), lineReplace);
                }

            }
        }

        internal static void OnUserOffline(ServerBootstrapSystem sender, NetConnectionId netConnectionId, ConnectionStatusChangeReason connectionStatusReason, string extraData)
        {
            if (Database.EnabledFeatures[NotifyFeature.offline])
            {
                if (connectionStatusReason != ConnectionStatusChangeReason.IncorrectPassword)
                {
                    var userIndex = sender._NetEndPointToApprovedUserIndex[netConnectionId];
                    var serverClient = sender._ApprovedUsersLookup[userIndex];
                    var userEntity = serverClient.UserEntity;
                    var userModel = GameData.Users.FromEntity(userEntity);
                    var userNick = userModel.CharacterName;
                    var _message = Database.getUserOfflineValue(userNick);
                    _message = _message.Replace("#user#", $"{FontColorChatSystem.Yellow(userNick)}");
                    ServerChatUtils.SendSystemMessageToAllClients(entityManager, $"{_message}");
                }
            }
        }

        public static bool IsNewUser(Entity userEntity)
        {
            var userComponent = userEntity.Read<User>();
            return userComponent.CharacterName.IsEmpty;

        }
    }
}
