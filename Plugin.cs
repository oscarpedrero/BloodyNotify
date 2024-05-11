using BepInEx;
using BepInEx.Unity.IL2CPP;
using BepInEx.Configuration;
using HarmonyLib;
using System.IO;
using System.Reflection;
using BepInEx.Logging;
using Notify.Helpers;
using VampireCommandFramework;

namespace Notify
{
    [BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
    [BepInDependency("gg.deca.VampireCommandFramework")]
    public class Plugin : BasePlugin
    {

        public static ManualLogSource Logger;

        private Harmony _harmony;

        internal static Plugin Instance { get; private set; }

        public static ConfigEntry<bool> AnnounceOnline;
        public static ConfigEntry<bool> AnnounceeOffline;
        public static ConfigEntry<bool> AnnounceNewUser;
        public static ConfigEntry<bool> AnnounceVBlood;
        public static ConfigEntry<string> VBloodFinalConcatCharacters;
        public static ConfigEntry<bool> AutoAnnouncerConfig;
        public static ConfigEntry<int> IntervalAutoAnnouncer;
        public static ConfigEntry<bool> MessageOfTheDay;

        public static readonly string ConfigPath = Path.Combine(BepInEx.Paths.ConfigPath, "Notify");

        public override void Load()
        {
            //if (!VWorld.IsServer) return;
            Instance = this;
            InitConfig();
            Logger = Log;
            LoadConfigHelper.LoadAllConfig();
            CommandRegistry.RegisterAll();
            //Chat.OnChatMessage += ChatCommandHook.Chat_OnChatMessage;
            //GameData.OnInitialize += GameDataOnInitialize;
            _harmony = new Harmony(MyPluginInfo.PLUGIN_GUID);
            _harmony.PatchAll(Assembly.GetExecutingAssembly());
            Log.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} is loaded!");
        }

        public override bool Unload()
        {
            //if (!VWorld.IsServer) return true;
            //Chat.OnChatMessage -= ChatCommandHook.Chat_OnChatMessage;
            //GameData.OnInitialize -= GameDataOnInitialize;
            Config.Clear();
            
            CommandRegistry.UnregisterAssembly();
            _harmony.UnpatchSelf();

            return true;
        }

        private void InitConfig()
        {

            AnnounceOnline = Config.Bind("UserOnline", "enabled", true, "Enable Announce when user online");
            AnnounceeOffline = Config.Bind("UserOffline", "enabled", true, "Enable Announce when user offline");
            AnnounceNewUser = Config.Bind("NewUserOnline", "enabled", true, "Enable Announce when new user create in server");
            AnnounceVBlood = Config.Bind("AnnounceVBlood", "enabled", true, "Enable Announce when user/users kill a VBlood Boss.");
            VBloodFinalConcatCharacters = Config.Bind("AnnounceVBlood", "VBloodFinalConcatCharacters", "and", "Final string for concat two or more players kill a VBlood Boss.");
            AutoAnnouncerConfig = Config.Bind("AutoAnnouncer", "enabled", false, "Enable AutoAnnouncer.");
            IntervalAutoAnnouncer = Config.Bind("AutoAnnouncer", "interval", 300, "Interval seconds for spam AutoAnnouncer.");
            MessageOfTheDay = Config.Bind("MessageOfTheDay", "enabled", false, "Enable Message Of The Day.");

            if (!Directory.Exists(ConfigPath)) Directory.CreateDirectory(ConfigPath);

            ConfigDefaultHelper.CheckAndCreateConfigs();
            

        }

        

        public void OnGameInitialized()
        {
            

        }

    }
}
