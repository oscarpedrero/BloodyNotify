using ProjectM;
using Wetstone.API;

namespace Notify.Utils
{
    internal class PrefabsUtils
    {
        /**
         * 
         * Original Function By Kaltharos from RPGMods (https://github.com/Kaltharos/RPGMods)
         * 
         **/
        public static string getPrefabName(PrefabGUID hashCode)
        {
            var s = VWorld.Server.GetExistingSystem<PrefabCollectionSystem>();
            string name = "Nonexistent";
            if (hashCode.GuidHash == 0)
            {
                return name;
            }
            try
            {
                name = s.PrefabNameLookupMap[hashCode].ToString();
            }
            catch
            {
                name = "NoPrefabName";
            }
            return name;
        }
    }
}
