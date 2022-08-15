using ProjectM.Network;
using System;
using System.Collections.Generic;
using System.Text;
using Unity.Collections;
using Unity.Entities;
using GT.VRising.GameData;
using Wetstone.API;

namespace Notify.Utils
{
    internal class PlayerUtils
    {
        private static EntityManager entityManager = VWorld.Server.EntityManager;


        public static bool isNewUser(Entity userEntity)
        {

            var userComponent = getUserComponente(userEntity);
            return userComponent.CharacterName.IsEmpty;

        }

        public static string getCharacterName(Entity userEntity)
        {

            return getUserComponente(userEntity).CharacterName.ToString();

        }

        private static User getUserComponente(Entity userEntity)
        {
            return entityManager.GetComponentData<User>(userEntity);
        }

        public IEnumerable<string> GetAllUsersOnline()
        {

            var users = GameData.Users.Online;
            foreach (var user in users)
            {
                yield return user.CharacterName;
            }

        }
    }
}
