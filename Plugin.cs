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
using ProjectM;
using Notify.Utils;
using VRising.GameData;
using Notify.AutoAnnouncer.Timers;

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
            Chat.OnChatMessage += Chat_OnChatMessage;
        }

        public override bool Unload()
        {
            if (!VWorld.IsServer) return true;
            Chat.OnChatMessage -= Chat_OnChatMessage;
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

            if (!Directory.Exists(ConfigPath)) Directory.CreateDirectory(ConfigPath);

            if (!File.Exists(Path.Combine(ConfigPath, "users_online.json")))
            {
                ConfigDefaultHelper.CreateOnlineDefaultConfig();
            }

            if (!File.Exists(Path.Combine(ConfigPath, "users_offline.json")))
            {
                ConfigDefaultHelper.CreateOfflineDefaultConfig();
            }

            if (!File.Exists(Path.Combine(ConfigPath, "default_announce.json")))
            {
                ConfigDefaultHelper.CreateDefaultNotificationTextConfig();
            }

            if (!File.Exists(Path.Combine(ConfigPath, "prefabs_names.json")))
            {
                ConfigDefaultHelper.CreateLocationVBloodDefaultConfig();
            }

            if (!File.Exists(Path.Combine(ConfigPath, "vbloodannounce_ignore_users.json")))
            {
                ConfigDefaultHelper.CreateVBloodNotifyIgnoreConfig();
            }

            if (!File.Exists(Path.Combine(ConfigPath, "auto_announcer_messages.json")))
            {
                ConfigDefaultHelper.CreateAutoAnnouncerMessagesConfig();
            }

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
            
        }

        internal static void Chat_OnChatMessage(VChatEvent e)
        {
            var message = e.Message.Trim().ToLowerInvariant();
            var entityManager = VWorld.Server.EntityManager;
            var text = string.Empty;

            
            if (!message.StartsWith("!notify"))
            {
                return;
            }

            var command = message.Replace("!notify", string.Empty);
            switch (command)
            {
                case "":
                    ServerChatUtils.SendSystemMessageToClient(entityManager, e.User, "Missing parameters for the !notify command");
                    break;
                case " reload":
                    if (!e.User.IsAdmin)
                    {
                        ServerChatUtils.SendSystemMessageToClient(entityManager, e.User, "You do not have permissions to run this command");
                        break;
                    }
                    if (!DBHelper.isEnabledAnnounceeOffline())
                    {
                        LoadConfigHelper.LoadUsersConfigOffline();
                    }

                    if (!DBHelper.isEnabledAnnounceOnline())
                    {
                        LoadConfigHelper.LoadUsersConfigOnline();
                    }

                    if (!DBHelper.isEnabledAnnounceVBlood())
                    {
                        LoadConfigHelper.LoadPrefabsName();
                    }

                    if (!DBHelper.isEnabledAnnounceNewUser())
                    {
                        LoadConfigHelper.LoadDefaultAnnounce();
                    }

                    if (!DBHelper.isEnabledAutoAnnouncer())
                    {
                        LoadConfigHelper.LoadAutoAnnouncerMessagesConfig();
                    }
                    ServerChatUtils.SendSystemMessageToClient(entityManager, e.User, "Reloaded configuration of Notify mod.");
                    break;
            case " unignore vbloodannounce":
                    DBHelper.removeVBloodNotifyIgnore(e.User.CharacterName.ToString());
                    text = FontColorChat.Green($"You will receive notifications about the death of the VBlood. To undo this option use the command {FontColorChat.Yellow("!notify ignore vbloodannounce")}");
                    ServerChatUtils.SendSystemMessageToClient(entityManager, e.User, text);
                    break;
            case " ignore vbloodannounce":
                    DBHelper.addVBloodNotifyIgnore(e.User.CharacterName.ToString());
                    text = FontColorChat.Green($"You will not receive any more notifications about the death of the VBlood. To undo this option use the command {FontColorChat.Yellow("!notify unignore vbloodannounce")}");
                    ServerChatUtils.SendSystemMessageToClient(entityManager, e.User, text);
                    break;
            case " autoannouncer stop":
                    if (!e.User.IsAdmin)
                    {
                        ServerChatUtils.SendSystemMessageToClient(entityManager, e.User, "You do not have permissions to run this command");
                        break;
                    }
                    DBHelper.setAutoAnnouncer(false);
                    text = FontColorChat.Green($"AutoAnnouncer: {FontColorChat.Yellow("stop")}");
                    AutoAnnouncerTimer.Stop();
                    ServerChatUtils.SendSystemMessageToClient(entityManager, e.User, text);
                    break;
            case " autoannouncer start":
                    if (!e.User.IsAdmin)
                    {
                        ServerChatUtils.SendSystemMessageToClient(entityManager, e.User, "You do not have permissions to run this command");
                        break;
                    }
                    DBHelper.setAutoAnnouncer(true);
                    text = FontColorChat.Green($"AutoAnnouncer: {FontColorChat.Yellow("start")}");
                    AutoAnnouncerTimer.Start();
                    ServerChatUtils.SendSystemMessageToClient(entityManager, e.User, text);
                    break;
            case " announceonline enabled":
                if (!e.User.IsAdmin)
                {
                    ServerChatUtils.SendSystemMessageToClient(entityManager, e.User, "You do not have permissions to run this command");
                    break;
                }
                DBHelper.setAnnounceOnline(true);
                text = FontColorChat.Green($"announceonline: {FontColorChat.Yellow("enable")}");
                ServerChatUtils.SendSystemMessageToClient(entityManager, e.User, text);
                break;
            case " announceonline disabled":
                if (!e.User.IsAdmin)
                {
                    ServerChatUtils.SendSystemMessageToClient(entityManager, e.User, "You do not have permissions to run this command");
                    break;
                }
                DBHelper.setAnnounceOnline(false);
                text = FontColorChat.Green($"announceonline: {FontColorChat.Yellow("disabled")}");
                ServerChatUtils.SendSystemMessageToClient(entityManager, e.User, text);
                break;

            case " announceoffline enabled":
                if (!e.User.IsAdmin)
                {
                    ServerChatUtils.SendSystemMessageToClient(entityManager, e.User, "You do not have permissions to run this command");
                    break;
                }
                DBHelper.setAnnounceOffline(true);
                text = FontColorChat.Green($"announceoffline: {FontColorChat.Yellow("enable")}");
                ServerChatUtils.SendSystemMessageToClient(entityManager, e.User, text);
                break;
            case " announceoffline disabled":
                if (!e.User.IsAdmin)
                {
                    ServerChatUtils.SendSystemMessageToClient(entityManager, e.User, "You do not have permissions to run this command");
                    break;
                }
                DBHelper.setAnnounceOffline(false);
                text = FontColorChat.Green($"announceoffline: {FontColorChat.Yellow("disabled")}");
                ServerChatUtils.SendSystemMessageToClient(entityManager, e.User, text);
                break;

            case " announcenewuser enabled":
                if (!e.User.IsAdmin)
                {
                    ServerChatUtils.SendSystemMessageToClient(entityManager, e.User, "You do not have permissions to run this command");
                    break;
                }
                DBHelper.setAnnounceNewUser(true);
                text = FontColorChat.Green($"announcenewuser: {FontColorChat.Yellow("enable")}");
                ServerChatUtils.SendSystemMessageToClient(entityManager, e.User, text);
                break;
            case " announcenewuser disabled":
                if (!e.User.IsAdmin)
                {
                    ServerChatUtils.SendSystemMessageToClient(entityManager, e.User, "You do not have permissions to run this command");
                    break;
                }
                DBHelper.setAnnounceNewUser(false);
                text = FontColorChat.Green($"announcenewuser: {FontColorChat.Yellow("disabled")}");
                ServerChatUtils.SendSystemMessageToClient(entityManager, e.User, text);
                break;

            case " vbloodannounce enabled":
                if (!e.User.IsAdmin)
                {
                    ServerChatUtils.SendSystemMessageToClient(entityManager, e.User, "You do not have permissions to run this command");
                    break;
                }
                DBHelper.setAnnounceVBlood(true);
                text = FontColorChat.Green($"vbloodannounce: {FontColorChat.Yellow("enable")}");
                ServerChatUtils.SendSystemMessageToClient(entityManager, e.User, text);
                break;
            case " vbloodannounce disabled":
                if (!e.User.IsAdmin)
                {
                    ServerChatUtils.SendSystemMessageToClient(entityManager, e.User, "You do not have permissions to run this command");
                    break;
                }
                DBHelper.setAnnounceVBlood(false);
                text = FontColorChat.Green($"vbloodannounce: {FontColorChat.Yellow("disabled")}");
                ServerChatUtils.SendSystemMessageToClient(entityManager, e.User, text);
                break;
            case " help":
                text = FontColorChat.Green($"{FontColorChat.Yellow("!notify unignore vbloodannounce")} for unignore notifications about the death of the VBlood.");
                ServerChatUtils.SendSystemMessageToClient(entityManager, e.User, text);
                text = FontColorChat.Green($"{FontColorChat.Yellow("!notify ignore vbloodannounce")} for ignore notifications about the death of the VBlood.");
                ServerChatUtils.SendSystemMessageToClient(entityManager, e.User, text);
                if (e.User.IsAdmin)
                {
                    text = FontColorChat.Green($"{FontColorChat.Yellow(FontColorChat.Red("[ADMIN]") + " !notify announceonline enabled")} Enabled announceonline System.");
                    ServerChatUtils.SendSystemMessageToClient(entityManager, e.User, text);
                    text = FontColorChat.Green($"{FontColorChat.Yellow(FontColorChat.Red("[ADMIN]") + " !notify announceonline disabled")} Disabled announceonline System.");
                    ServerChatUtils.SendSystemMessageToClient(entityManager, e.User, text);
                    text = FontColorChat.Green($"{FontColorChat.Yellow(FontColorChat.Red("[ADMIN]") + " !notify announceoffline enabled")} Enabled announceoffline System.");
                    ServerChatUtils.SendSystemMessageToClient(entityManager, e.User, text);
                    text = FontColorChat.Green($"{FontColorChat.Yellow(FontColorChat.Red("[ADMIN]") + " !notify announceoffline disabled")} Disabled announceoffline System.");
                    ServerChatUtils.SendSystemMessageToClient(entityManager, e.User, text);
                    text = FontColorChat.Green($"{FontColorChat.Yellow(FontColorChat.Red("[ADMIN]") + " !notify announcenewuser enabled")} Enabled announcenewuser System.");
                    ServerChatUtils.SendSystemMessageToClient(entityManager, e.User, text);
                    text = FontColorChat.Green($"{FontColorChat.Yellow(FontColorChat.Red("[ADMIN]") + " !notify announcenewuser disabled")} Disabled announcenewuser System.");
                    ServerChatUtils.SendSystemMessageToClient(entityManager, e.User, text);
                    text = FontColorChat.Green($"{FontColorChat.Yellow(FontColorChat.Red("[ADMIN]") + " !notify vbloodannounce enabled")} Enabled vbloodannounce System.");
                    ServerChatUtils.SendSystemMessageToClient(entityManager, e.User, text);
                    text = FontColorChat.Green($"{FontColorChat.Yellow(FontColorChat.Red("[ADMIN]") + " !notify vbloodannounce disabled")} Disabled vbloodannounce System.");
                    ServerChatUtils.SendSystemMessageToClient(entityManager, e.User, text);
                    text = FontColorChat.Green($"{FontColorChat.Yellow(FontColorChat.Red("[ADMIN]")+ " !notify autoannouncer start")} Start AutoAnnouncer System.");
                    ServerChatUtils.SendSystemMessageToClient(entityManager, e.User, text);
                    text = FontColorChat.Green($"{FontColorChat.Yellow(FontColorChat.Red("[ADMIN]")+ " !notify autoannouncer stop")} Stop AutoAnnouncer System.");
                    ServerChatUtils.SendSystemMessageToClient(entityManager, e.User, text);
                    text = FontColorChat.Green($"{FontColorChat.Yellow(FontColorChat.Red("[ADMIN]") + " !notify reload ")} To reload the configuration of the user messages online, offline or death of the VBlood boss.");
                    ServerChatUtils.SendSystemMessageToClient(entityManager, e.User, text);
                    break;
                }
                break;
            default:
                break;
            }
        }
    }
}
