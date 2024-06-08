using BepInEx;
using BepInEx.Configuration;
using BepInEx.Unity.IL2CPP;
using Bloodstone.API;
using Bloody.Core;
using Bloody.Core.API.v1;
using BloodyNotify.AutoAnnouncer;
using BloodyNotify.DB;
using BloodyNotify.Systems;
using HarmonyLib;
using System.IO;
using Unity.Entities;
using VampireCommandFramework;

namespace BloodyNotify;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
[BepInDependency("gg.deca.VampireCommandFramework")]
[BepInDependency("gg.deca.Bloodstone")]
[BepInDependency("trodi.Bloody.Core")]
[Bloodstone.API.Reloadable]
public class Plugin : BasePlugin, IRunOnInitialized
{
    Harmony _harmony;
    public static Bloody.Core.Helper.v1.Logger Logger;
    public static SystemsCore SystemsCore;

    public static ConfigEntry<bool> AnnounceOnline;
    public static ConfigEntry<bool> AnnounceeOffline;
    public static ConfigEntry<bool> AnnounceNewUser;
    public static ConfigEntry<bool> AnnounceVBlood;
    public static ConfigEntry<string> VBloodFinalConcatCharacters;
    public static ConfigEntry<bool> AutoAnnouncerConfig;
    public static ConfigEntry<int> IntervalAutoAnnouncer;
    public static ConfigEntry<bool> MessageOfTheDay;

    public static readonly string ConfigPath = Path.Combine(Paths.ConfigPath, "BloodyNotify");

    public override void Load()
    {

        Logger = new(Log);


        if (!Core.IsServer)
        {
            Log.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} is only for server!");
            return;
        }

        // Harmony patching
        _harmony = new Harmony(MyPluginInfo.PLUGIN_GUID);

        // Register all commands in the assembly with VCF
        CommandRegistry.RegisterAll();

        EventsHandlerSystem.OnInitialize += GameDataOnInitialize;
        InitConfig();
        LoadDatabase.LoadAllConfig();


        Logger.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} version {MyPluginInfo.PLUGIN_VERSION} is loaded!");
    }

    private void GameDataOnInitialize(World world)
    {
        SystemsCore = Core.SystemsCore;

        Database.EnabledFeatures[NotifyFeature.online] = AnnounceOnline.Value;
        Database.EnabledFeatures[NotifyFeature.offline] = AnnounceeOffline.Value;
        Database.EnabledFeatures[NotifyFeature.newuser] = AnnounceNewUser.Value;
        Database.EnabledFeatures[NotifyFeature.vblood] = AnnounceVBlood.Value;
        Database.EnabledFeatures[NotifyFeature.auto] = AutoAnnouncerConfig.Value;
        Database.EnabledFeatures[NotifyFeature.motd] = MessageOfTheDay.Value;

        Database.setVBloodFinalConcatCharacters(VBloodFinalConcatCharacters.Value);
        Database.setIntervalAutoAnnouncer(IntervalAutoAnnouncer.Value);

        
        EventsHandlerSystem.OnUserConnected += OnlineOfflineSystem.OnUserOnline;
        EventsHandlerSystem.OnUserDisconnected += OnlineOfflineSystem.OnUserOffline;
        EventsHandlerSystem.OnDeathVBlood += KillVBloodSystem.OnDetahVblood;

        
        AutoAnnouncerFunction.StartAutoAnnouncer();

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

        DB.Config.CheckAndCreateConfigs();


    }

    public void OnGameInitialized()
    {
        
    }

    public override bool Unload()
    {
        CommandRegistry.UnregisterAssembly();
        _harmony?.UnpatchSelf();
        return true;
    }

}
