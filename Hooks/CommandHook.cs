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

            if (!DBHelper.EnabledFeatures[NotifyFeature.offline])
            {
                LoadConfigHelper.LoadUsersConfigOffline();
            }

            if (!DBHelper.EnabledFeatures[NotifyFeature.online])
            {
                LoadConfigHelper.LoadUsersConfigOnline();
            }

            if (!DBHelper.EnabledFeatures[NotifyFeature.vblood])
            {
                LoadConfigHelper.LoadPrefabsName();
                LoadConfigHelper.LoadPrefabsIgnore();
            }

            if (!DBHelper.EnabledFeatures[NotifyFeature.newuser])
            {
                LoadConfigHelper.LoadDefaultAnnounce();
            }

            if (!DBHelper.EnabledFeatures[NotifyFeature.auto])
            {
                LoadConfigHelper.LoadAutoAnnouncerMessagesConfig();
            }

            if (!DBHelper.EnabledFeatures[NotifyFeature.motd])
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

        [Command("config", "cfg", usage: "[ auto, motd, newuser, online, offline, vblood ] true/false", description: "Enabled / Disabled the features of the mod. [ auto, motd, newuser, online, offline, vblood ]", adminOnly: true)]
        public static void ConfigMod(ChatCommandContext ctx, NotifyFeature feature, bool isEnabled)
        {

            Plugin.Logger.LogInfo("Config Parameters");
            Plugin.Logger.LogInfo($"{feature}");
            Plugin.Logger.LogInfo($"{isEnabled}");


            DBHelper.EnabledFeatures[feature] = isEnabled;

            if (feature == NotifyFeature.auto)
            {
                if (isEnabled)
                {
                    OnInitialize.StartAutoAnnouncer();
                }
                else
                {
                    OnInitialize.StopAutoAnnouncer();
                }
            }

            var message = feature switch
            {
                NotifyFeature.motd => $"Message of The Day:",
                NotifyFeature.newuser => $"Announce New User:",
                NotifyFeature.online => $"Announce Online:",
                NotifyFeature.offline => $"Announce Offline:",
                NotifyFeature.vblood => $"VBlood Announcer:",
                NotifyFeature.auto => $"Auto Announcer:",
                _ => throw new System.NotImplementedException(),
            };

            var enabled = FontColorChat.Yellow(isEnabled ? "Enabled" : "Disabled");

            ctx.Reply(FontColorChat.Green($"{message} {enabled}"));
        }

    }

}