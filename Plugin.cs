using BepInEx;
using BepInEx.IL2CPP;
using BepInEx.Configuration;
using HarmonyLib;
using System.IO;
using System.Reflection;
using Wetstone.API;
using BepInEx.Logging;
using Notify.Helpers;
using Wetstone.Hooks;
using VRising.GameData;
using Notify.AutoAnnouncer.Timers;
using Notify.Hooks;

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
        public static ConfigEntry<bool> AutoAnnouncer;
        public static ConfigEntry<int> IntervalAutoAnnouncer;
        public static ConfigEntry<bool> MessageOfTheDay;

        public static readonly string ConfigPath = Path.Combine(BepInEx.Paths.ConfigPath, "Notify");

        public override void Load()
        {
            if (!VWorld.IsServer) return;
            InitConfig();
            Logger = Log;
            _harmony = new Harmony(PluginInfo.PLUGIN_GUID);
            _harmony.PatchAll(Assembly.GetExecutingAssembly());
            LoadConfigHelper.LoadAllConfig();
            Log.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
            Chat.OnChatMessage += ChatCommandHook.Chat_OnChatMessage;
        }

        public override bool Unload()
        {
            if (!VWorld.IsServer) return true;
            Chat.OnChatMessage -= ChatCommandHook.Chat_OnChatMessage;
            Config.Clear();
            _harmony.UnpatchSelf();
            if (AutoAnnouncer.Value)
            {
                AutoAnnouncerTimer.Stop();
            }
            return true;
        }

        private void InitConfig()
        {

            AnnounceOnline = Config.Bind("UserOnline", "enabled", true, "Enable Announce when user online");
            AnnounceeOffline = Config.Bind("UserOffline", "enabled", true, "Enable Announce when user offline");
            AnnounceNewUser = Config.Bind("NewUserOnline", "enabled", true, "Enable Announce when new user create in server");
            AnnounceVBlood = Config.Bind("AnnounceVBlood", "enabled", true, "Enable Announce when user/users kill a VBlood Boss.");
            VBloodFinalConcatCharacters = Config.Bind("AnnounceVBlood", "VBloodFinalConcatCharacters", "and", "Final string for concat two or more players kill a VBlood Boss.");
            AutoAnnouncer = Config.Bind("AutoAnnouncer", "enabled", false, "Enable AutoAnnouncer.");
            IntervalAutoAnnouncer = Config.Bind("AutoAnnouncer", "interval", 300, "Interval seconds for spam AutoAnnouncer.");
            MessageOfTheDay = Config.Bind("MessageOfTheDay", "enabled", false, "Enable Message Of The Day.");

            if (!Directory.Exists(ConfigPath)) Directory.CreateDirectory(ConfigPath);

            ConfigDefaultHelper.CheckAndCreateConfigs();
            

        }

        public void OnGameInitialized()
        {
            GameData.Initialize();
            DBHelper.setAnnounceOnline(AnnounceOnline.Value);
            DBHelper.setAnnounceOffline(AnnounceeOffline.Value);
            DBHelper.setAnnounceNewUser(AnnounceNewUser.Value);
            DBHelper.setAnnounceVBlood(AnnounceVBlood.Value);
            DBHelper.setVBloodFinalConcatCharacters(VBloodFinalConcatCharacters.Value);
            DBHelper.setAutoAnnouncer(AutoAnnouncer.Value);
            if (AutoAnnouncer.Value)
            {
                DBHelper.setIntervalAutoAnnouncer(IntervalAutoAnnouncer.Value);
                AutoAnnouncerTimer.Start();
            }

            DBHelper.setMessageOfTheDayEnabled(MessageOfTheDay.Value);

        }

        
    }
}
