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
                name = s.PrefabDataLookup[hashCode].AssetName.ToString();
                
                Plugin.Logger.LogDebug($"VBlood prefab: {name}");
            }
            catch
            {
                name = "NoPrefabName";
                Plugin.Logger.LogWarning($"VBlood prefab missing: {name}");
            }
            return name;
        }
    }
}
