using BepInEx;
using BepInEx.IL2CPP;
using BepInEx.Configuration;
using HarmonyLib;
using System.IO;
using System.Reflection;
using Wetstone.API;
using BepInEx.Logging;
using Notify.Helpers;

namespace Notify
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    [BepInDependency("xyz.molenzwiebel.wetstone")]
    [Reloadable]
    public class Plugin : BasePlugin, IRunOnInitialized
    {
        public static ManualLogSource Logger;

        private Harmony _harmony;

        public static ConfigEntry<bool> AnnounceOnline;
        public static ConfigEntry<bool> AnnounceeOffline;
        public static ConfigEntry<bool> AnnounceNewUser;
        public static ConfigEntry<bool> AnnounceVBlood;
        public static ConfigEntry<string> VBloodFinalConcatCharacters;

        public override void Load()
        {
            if (!VWorld.IsServer) return;
            InitConfig();
            Logger = Log;
            _harmony = new Harmony(PluginInfo.PLUGIN_GUID);
            _harmony.PatchAll(Assembly.GetExecutingAssembly());
            LoadConfigHelper.LoadAllConfig();
            Log.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
        }

        public override bool Unload()
        {
            if (!VWorld.IsServer) return true;
            Config.Clear();
            _harmony.UnpatchSelf();
            return true;
        }

        private void InitConfig()
        {

            AnnounceOnline = Config.Bind("UserOnline", "enabled", true, "Enable Announce when user online");
            AnnounceeOffline = Config.Bind("UserOffline", "enabled", true, "Enable Announce when user offline");
            AnnounceNewUser = Config.Bind("NewUserOnline", "enabled", true, "Enable Announce when new user create in server");
            AnnounceVBlood = Config.Bind("AnnounceVBlood", "enabled", true, "Enable Announce when new user/users kill a VBlood Boss.");
            VBloodFinalConcatCharacters = Config.Bind("AnnounceVBlood", "VBloodFinalConcatCharacters", "and", "Final string for concat all players kill a VBlood Boss.");

            if (!File.Exists("BepInEx/config/Notify/users_online.json"))
            {
                if (!Directory.Exists("BepInEx/config/Notify")) Directory.CreateDirectory("BepInEx/config/Notify");
                ConfigDefaultHelper.CreateOnlineDefaultConfig();
            }

            if (!File.Exists("BepInEx/config/Notify/users_offline.json"))
            {
                if (!Directory.Exists("BepInEx/config/Notify")) Directory.CreateDirectory("BepInEx/config/Notify");
                ConfigDefaultHelper.CreateOfflineDefaultConfig();
            }

            if (!File.Exists("BepInEx/config/Notify/default_announce.json"))
            {
                if (!Directory.Exists("BepInEx/config/Notify")) Directory.CreateDirectory("BepInEx/config/Notify");
                ConfigDefaultHelper.CreateDefaultNotificationTextConfig();
            }

            if (!File.Exists("BepInEx/config/Notify/prefabs_names.json"))
            {
                if (!Directory.Exists("BepInEx/config/Notify")) Directory.CreateDirectory("BepInEx/config/Notify");
                ConfigDefaultHelper.CreateLocationVBloodDefaultConfig();
            }

        }

        public void OnGameInitialized()
        {
            DBHelper.setAnnounceOnline(AnnounceOnline.Value);
            DBHelper.setAnnounceOffline(AnnounceeOffline.Value);
            DBHelper.setAnnounceNewUser(AnnounceNewUser.Value);
            DBHelper.setAnnounceVBlood(AnnounceVBlood.Value);
            DBHelper.setVBloodFinalConcatCharacters(VBloodFinalConcatCharacters.Value);
        }
    }
}
