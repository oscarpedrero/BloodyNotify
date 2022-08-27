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
using Notify.AutoAnnouncer;
using Notify.Hooks;
using Unity.Entities;
using ProjectM;
using System;
using Notify.Patch;

namespace Notify
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    [BepInDependency("xyz.molenzwiebel.wetstone")]
    [Reloadable]
    public class Plugin : BasePlugin, IRunOnInitialized
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

        private static AutoAnnouncerTimer _autoAnnouncerTimer;

        public override void Load()
        {
            if (!VWorld.IsServer) return;
            Instance = this;
            InitConfig();
            Logger = Log;
            _harmony = new Harmony(PluginInfo.PLUGIN_GUID);
            _harmony.PatchAll(Assembly.GetExecutingAssembly());
            LoadConfigHelper.LoadAllConfig();
            
            Chat.OnChatMessage += ChatCommandHook.Chat_OnChatMessage;
            GameData.OnInitialize += GameDataOnInitialize;
            GameFrame.Initialize();
            Log.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
        }

        public override bool Unload()
        {
            if (!VWorld.IsServer) return true;
            Chat.OnChatMessage -= ChatCommandHook.Chat_OnChatMessage;
            GameData.OnInitialize -= GameDataOnInitialize;
            Config.Clear();
            GameFrame.Uninitialize();
            _autoAnnouncerTimer?.Stop();
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
            DBHelper.setAnnounceOnline(AnnounceOnline.Value);
            DBHelper.setAnnounceOffline(AnnounceeOffline.Value);
            DBHelper.setAnnounceNewUser(AnnounceNewUser.Value);
            DBHelper.setAnnounceVBlood(AnnounceVBlood.Value);
            DBHelper.setVBloodFinalConcatCharacters(VBloodFinalConcatCharacters.Value);
            DBHelper.setAutoAnnouncer(AutoAnnouncerConfig.Value);
            DBHelper.setMessageOfTheDayEnabled(MessageOfTheDay.Value);
            DBHelper.setIntervalAutoAnnouncer(IntervalAutoAnnouncer.Value);

        }

        public static void StartAutoAnnouncer()
        {
            _autoAnnouncerTimer.Start(
                world =>
                {
                    Logger.LogInfo("Starting AutoAnnouncer");
                    AutoAnnouncerFunction.OnTimedAutoAnnouncer();
                },
                input =>
                {
                    if (input is not int secondAutoAnnouncer)
                    {
                        Logger.LogError("AutoAnnouncer timer delay function parameter is not a valid integer");
                        return TimeSpan.MaxValue;
                    }
                    
                    var seconds = DBHelper.getIntervalAutoAnnouncer(); 
                    Logger.LogInfo($"Next AutoAnnouncer will start in {seconds} seconds.");
                    return TimeSpan.FromSeconds(seconds);
                });
        }

        public static void StopAutoAnnouncer()
        {
            _autoAnnouncerTimer?.Stop();
        }

        
        private static void GameDataOnInitialize(World world)
        {
            Logger.LogInfo("GameData Init");
            _autoAnnouncerTimer = new AutoAnnouncerTimer();
            if (AutoAnnouncerConfig.Value)
            {
                StartAutoAnnouncer();
            }
        }

    }
}
