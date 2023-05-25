using Notify.Helpers;
using Notify.Utils;
using VampireCommandFramework;
using Unity.Entities;

namespace Notify.Hooks
{
    [CommandGroup("notify")]
    public class CommandHook
    {

        private static EntityManager entityManager = VWorld.Server.EntityManager;

        [Command("reload", "rl", description: "To reload the configuration of the user messages online, offline or death of the VBlood boss", adminOnly: true)]
        public static void RealoadMod(ChatCommandContext ctx)
        {

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

            if (!DBHelper.isEnabledMessageOfTheDay())
            {
                LoadConfigHelper.LoadMessageOfTheDayConfig();
            }

            ctx.Reply("Reloaded configuration of Notify mod.");

        }

        [Command("vblood", "vba", usage: "ignore/unignore", description: "ignore/unignore vblood announce system.", adminOnly: false)]
        public static void Vbloodannounce(ChatCommandContext ctx, string action = "unignore")
        {

            var user = ctx.User;

            switch (action)
            {
                case "ignore":
                    DBHelper.addVBloodNotifyIgnore(user.CharacterName.ToString());
                    ctx.Reply(FontColorChat.Green($"You will not receive any more notifications about the death of the VBlood. To undo this option use the command {FontColorChat.Yellow(".notify vbloodannounce unignore")}"));
                    break;
                case "unignore":
                    DBHelper.removeVBloodNotifyIgnore(user.CharacterName.ToString());
                    ctx.Reply(FontColorChat.Green($"You will receive notifications about the death of the VBlood. To undo this option use the command {FontColorChat.Yellow(".notify vbloodannounce ignore")}"));
                    break;

            }
        }

        [Command("config", "cfg", usage: "[ auto, motd, newuser, online, offline, vblood ] enabled/disabled", description: "To change mod settings. [ auto, motd, newuser, online, offline, vblood ]", adminOnly: true)]
        public static void ConfigMod(ChatCommandContext ctx, string feature, string action)
        {

            Plugin.Logger.LogInfo("Config Parameters");
            Plugin.Logger.LogInfo($"{feature}");
            Plugin.Logger.LogInfo($"{action}");

            switch (feature)
            {
                case "motd":
                    switch (action)
                    {
                        case "enabled":
                            DBHelper.setMessageOfTheDayEnabled(true);
                            ctx.Reply(FontColorChat.Green($"Message of the Day: {FontColorChat.Yellow("enable")}"));
                            break;
                        case "disabled":
                            DBHelper.setMessageOfTheDayEnabled(false);
                            ctx.Reply(FontColorChat.Green($"Message of the Day: {FontColorChat.Yellow("disabled")}"));
                            break;
                        default:
                            ctx.Reply(FontColorChat.Green($"Command Not found: {FontColorChat.Yellow($".notify {feature} {action}")}"));
                            break;
                    }
                    break;
                case "newuser":
                    switch (action)
                    {
                        case "enabled":
                            DBHelper.setAnnounceNewUser(true);
                            ctx.Reply(FontColorChat.Green($"announcenewuser: {FontColorChat.Yellow("enable")}"));
                            break;
                        case "disabled":
                            DBHelper.setAnnounceNewUser(false);
                            ctx.Reply(FontColorChat.Green($"announcenewuser: {FontColorChat.Yellow("disabled")}"));
                            break;
                        default:
                            ctx.Reply(FontColorChat.Green($"Command Not found: {FontColorChat.Yellow($".notify {feature} {action}")}"));
                            break;
                    }
                    break;
                case "offline":
                    switch (action)
                    {
                        case "enabled":
                            DBHelper.setAnnounceOffline(true);
                            ctx.Reply(FontColorChat.Green($"announceoffline: {FontColorChat.Yellow("enable")}"));
                            break;
                        case "disabled":
                            DBHelper.setAnnounceOffline(false);
                            ctx.Reply(FontColorChat.Green($"announceoffline: {FontColorChat.Yellow("disabled")}"));
                            break;
                        default:
                            ctx.Reply(FontColorChat.Green($"Command Not found: {FontColorChat.Yellow("disabled")}"));
                            break;
                    }
                    break;
                case "online":
                    switch (action)
                    {
                        case "enabled":
                            DBHelper.setAnnounceOnline(true);
                            ctx.Reply(FontColorChat.Green($"announceonline: {FontColorChat.Yellow("enable")}"));
                            break;
                        case "disabled":
                            DBHelper.setAnnounceOnline(false);
                            ctx.Reply(FontColorChat.Green($"announceonline: {FontColorChat.Yellow("disabled")}"));
                            break;
                        default:
                            ctx.Reply(FontColorChat.Green($"Command Not found: {FontColorChat.Yellow($".notify {feature} {action}")}"));
                            break;
                    }
                    break;
                case "auto":
                    switch (action)
                    {
                        case "start":
                            DBHelper.setAutoAnnouncer(true);
                            OnInitialize.StartAutoAnnouncer();
                            ctx.Reply(FontColorChat.Green($"AutoAnnouncer: {FontColorChat.Yellow("start")}"));
                            break;
                        case "stop":
                            DBHelper.setAutoAnnouncer(false);
                            OnInitialize.StopAutoAnnouncer();
                            ctx.Reply(FontColorChat.Green($"AutoAnnouncer: {FontColorChat.Yellow("stop")}"));
                            break;
                        default:
                            ctx.Reply(FontColorChat.Green($"Action Not found: {FontColorChat.Yellow($".notify config {feature} {action}")}"));
                            break;
                    }
                    break;
                case "vblood":
                    switch (action)
                    {
                        case "enabled":
                            DBHelper.setAnnounceVBlood(true);
                            ctx.Reply(FontColorChat.Green($"vbloodannounce: {FontColorChat.Yellow("enable")}"));
                            break;
                        case "disabled":
                            DBHelper.setAnnounceVBlood(false);
                            ctx.Reply(FontColorChat.Green($"vbloodannounce: {FontColorChat.Yellow("disabled")}"));
                            break;
                        default:
                            ctx.Reply(FontColorChat.Green($"Action Not found: {FontColorChat.Yellow($".notify {feature} {action}")}"));
                            break;
                    }
                    break;
                default:
                    ctx.Reply(FontColorChat.Green($"Command Not found: {FontColorChat.Yellow($".notify {feature} {action}")}"));
                    break;
            }
        }

    }

}