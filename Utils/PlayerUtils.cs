using Notify.Helpers;
using ProjectM.Network;
using System;
using System.Collections.Generic;
using System.Text;
using Unity.Collections;
using Unity.Entities;
using System.Linq;

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

        public static User getUserComponente(Entity userEntity)
        {
            return entityManager.GetComponentData<User>(userEntity);
        }

        public static IEnumerable<Entity> GetAllUsersOnline()
        {

            NativeArray<Entity> userEntities = VWorld.Server.EntityManager.CreateEntityQuery(ComponentType.ReadOnly<User>()).ToEntityArray(Allocator.Temp);
            int len = userEntities.Length;
            for (int i = 0; i < len; ++i)
            {
                yield return userEntities[i];
            }

        }
    }
}
