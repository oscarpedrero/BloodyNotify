using Bloody.Core;
using Bloody.Core.API;
using BloodyNotify.DB;
using System.Linq;
using VampireCommandFramework;

namespace BloodyNotify.Command
{
    [CommandGroup("bn")]
    internal class BloodyNotifyCommand
    {
        [Command("online", "o", description: "To reload the configuration of the user messages online, offline or death of the VBlood boss", adminOnly: false)]
        public static void Online(ChatCommandContext ctx)
        {
            ctx.Reply("Users Online ---------");
            foreach (var user in Core.Users.Online.OrderBy(x => x.IsAdmin))
            {
                if(user.IsAdmin)
                {
                    ctx.Reply($"{FontColorChatSystem.Green("[ADMIN]")} {FontColorChatSystem.Yellow(user.CharacterName)}");
                } else
                {
                    ctx.Reply($"{FontColorChatSystem.Yellow(user.CharacterName)}");
                }
            }
        }


        [Command("reload", "rl", description: "To reload the configuration of the user messages online, offline or death of the VBlood boss", adminOnly: true)]
        public static void RealoadMod(ChatCommandContext ctx)
        {

            if (!Database.EnabledFeatures[NotifyFeature.offline])
            {
                LoadDatabase.LoadUsersConfigOffline();
            }

            if (!Database.EnabledFeatures[NotifyFeature.online])
            {
                LoadDatabase.LoadUsersConfigOnline();
            }

            if (!Database.EnabledFeatures[NotifyFeature.vblood])
            {
                LoadDatabase.LoadPrefabsName();
                LoadDatabase.LoadPrefabsIgnore();
            }

            if (!Database.EnabledFeatures[NotifyFeature.newuser])
            {
                LoadDatabase.LoadDefaultAnnounce();
            }

            if (!Database.EnabledFeatures[NotifyFeature.auto])
            {
                LoadDatabase.LoadAutoAnnouncerMessagesConfig();
            }

            if (!Database.EnabledFeatures[NotifyFeature.motd])
            {
                LoadDatabase.LoadMessageOfTheDayConfig();
            }

            ctx.Reply("Reloaded configuration of BloodyNotify mod.");

        }

        [Command("vblood", "vba", usage: "ignore/unignore", description: "ignore/unignore vblood announce system.", adminOnly: false)]
        public static void Vbloodannounce(ChatCommandContext ctx, string action = "unignore")
        {

            var user = ctx.User;

            switch (action)
            {
                case "ignore":
                    Database.addVBloodNotifyIgnore(user.CharacterName.ToString());
                    ctx.Reply(FontColorChatSystem.Green($"You will not receive any more notifications about the death of the VBlood. To undo this option use the command {FontColorChatSystem.Yellow(".notify vbloodannounce unignore")}"));
                    break;
                case "unignore":
                    Database.removeVBloodNotifyIgnore(user.CharacterName.ToString());
                    ctx.Reply(FontColorChatSystem.Green($"You will receive notifications about the death of the VBlood. To undo this option use the command {FontColorChatSystem.Yellow(".notify vbloodannounce ignore")}"));
                    break;

            }
        }

        [Command("config", "cfg", usage: "[ auto, motd, newuser, online, offline, vblood ] true/false", description: "Enabled / Disabled the features of the mod. [ auto, motd, newuser, online, offline, vblood ]", adminOnly: true)]
        public static void ConfigMod(ChatCommandContext ctx, NotifyFeature feature, bool isEnabled)
        {

            Database.EnabledFeatures[feature] = isEnabled;

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

            var enabled = FontColorChatSystem.Yellow(isEnabled ? "Enabled" : "Disabled");

            ctx.Reply(FontColorChatSystem.Green($"{message} {enabled}"));
        }
    }
}
