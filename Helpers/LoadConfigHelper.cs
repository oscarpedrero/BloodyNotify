using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace Notify.Helpers
{
    internal class LoadConfigHelper
    {

        public static void LoadDefaultAnnounce()
        {
            string json = File.ReadAllText("BepInEx/config/Notify/default_announce.json");
            var dictionary = JsonSerializer.Deserialize<Dictionary<string, string>>(json);
            DBHelper.setDefaultAnnounce(dictionary);
            Plugin.Logger.LogInfo("DefaultAnnounce Load OK.");
        }

        public static void LoadUsersConfigOnline()
        {
            string json = File.ReadAllText("BepInEx/config/Notify/users_online.json");
            var dictionary = JsonSerializer.Deserialize<Dictionary<string, string>>(json);
            DBHelper.setUsersOnline(dictionary);
            Plugin.Logger.LogInfo("UsersConfigOnline Load OK.");
        }

        public static void LoadUsersConfigOffline()
        {
            string json = File.ReadAllText("BepInEx/config/Notify/users_offline.json");
            var dictionary = JsonSerializer.Deserialize<Dictionary<string, string>>(json);
            DBHelper.setUsersOffline(dictionary);
            Plugin.Logger.LogInfo("UsersConfigOffline Load OK.");
        }

        public static void LoadPrefabsName()
        {
            string json = File.ReadAllText("BepInEx/config/HBMod/prefabs_names.json");
            var dictionary = JsonSerializer.Deserialize<Dictionary<string, string>>(json);
            DBHelper.setPrefabsNames(dictionary);
            Plugin.Logger.LogInfo("PrefabToNames Load OK.");
        }
    }
}
