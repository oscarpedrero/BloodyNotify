using Wetstone.API;
using Notify.Helpers;
using Wetstone.Hooks;
using ProjectM;
using Notify.Utils;
using Notify.AutoAnnouncer.Timers;

namespace Notify.Hooks
{
    public class ChatCommandHook
    {
        public static void Chat_OnChatMessage(VChatEvent e)
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

                    if (!DBHelper.isEnabledMessageOfTheDay())
                    {
                        LoadConfigHelper.LoadMessageOfTheDayConfig();
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
                case " motd enabled":
                    if (!e.User.IsAdmin)
                    {
                        ServerChatUtils.SendSystemMessageToClient(entityManager, e.User, "You do not have permissions to run this command");
                        break;
                    }
                    DBHelper.setMessageOfTheDayEnabled(true);
                    text = FontColorChat.Green($"Message of the Day: {FontColorChat.Yellow("enable")}");
                    ServerChatUtils.SendSystemMessageToClient(entityManager, e.User, text);
                    break;
                case " motd disabled":
                    if (!e.User.IsAdmin)
                    {
                        ServerChatUtils.SendSystemMessageToClient(entityManager, e.User, "You do not have permissions to run this command");
                        break;
                    }
                    DBHelper.setMessageOfTheDayEnabled(false);
                    text = FontColorChat.Green($"Message of the Day: {FontColorChat.Yellow("disabled")}");
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
                        text = FontColorChat.Green($"{FontColorChat.Yellow(FontColorChat.Red("[ADMIN]") + " !notify autoannouncer start")} Start AutoAnnouncer System.");
                        ServerChatUtils.SendSystemMessageToClient(entityManager, e.User, text);
                        text = FontColorChat.Green($"{FontColorChat.Yellow(FontColorChat.Red("[ADMIN]") + " !notify autoannouncer stop")} Stop AutoAnnouncer System.");
                        ServerChatUtils.SendSystemMessageToClient(entityManager, e.User, text);
                        text = FontColorChat.Green($"{FontColorChat.Yellow(FontColorChat.Red("[ADMIN]") + " !notify motd enabled")} Enabled Message of the Day System.");
                        ServerChatUtils.SendSystemMessageToClient(entityManager, e.User, text);
                        text = FontColorChat.Green($"{FontColorChat.Yellow(FontColorChat.Red("[ADMIN]") + " !notify motd disabled")} Disabled Message of the Day System.");
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