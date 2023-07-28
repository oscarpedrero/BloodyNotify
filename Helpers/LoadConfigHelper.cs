using Notify.AutoAnnouncer.Models;
using Notify.AutoAnnouncer.Parser;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace Notify.Helpers
{
    internal class LoadConfigHelper
    {

        public static void LoadAllConfig()
        {
            LoadDefaultAnnounce();
            LoadUsersConfigOnline();
            LoadUsersConfigOffline();
            LoadPrefabsName();
            LoadPrefabsIgnore();
            VBloodNotifyIgnoreConfig();
            LoadAutoAnnouncerMessagesConfig();
            LoadMessageOfTheDayConfig();
        }
        public static void LoadDefaultAnnounce()
        {
            var json = File.ReadAllText(Path.Combine(ConfigDefaultHelper.ConfigPath, "default_announce.json"));
            var dictionary = JsonSerializer.Deserialize<Dictionary<string, string>>(json);
            DBHelper.setDefaultAnnounce(dictionary);
        }

        public static void LoadUsersConfigOnline()
        {
            var json = File.ReadAllText(Path.Combine(ConfigDefaultHelper.ConfigPath, "users_online.json"));
            var dictionary = JsonSerializer.Deserialize<Dictionary<string, string>>(json);
            DBHelper.setUsersOnline(dictionary);
        }

        public static void LoadUsersConfigOffline()
        {
            var json = File.ReadAllText(Path.Combine(ConfigDefaultHelper.ConfigPath, "users_offline.json"));
            var dictionary = JsonSerializer.Deserialize<Dictionary<string, string>>(json);
            DBHelper.setUsersOffline(dictionary);
        }

        public static void LoadPrefabsName()
        {
            var json = File.ReadAllText(Path.Combine(ConfigDefaultHelper.ConfigPath, "prefabs_names.json"));
            var dictionary = JsonSerializer.Deserialize<Dictionary<string, string>>(json);
            DBHelper.setPrefabsNames(dictionary);
        }

        public static void LoadPrefabsIgnore()
        {
            var json = File.ReadAllText(Path.Combine(ConfigDefaultHelper.ConfigPath, "prefabs_names_ignore.json"));
            var dictionary = JsonSerializer.Deserialize<Dictionary<string, bool>>(json);
            DBHelper.setPrefabsIgnore(dictionary);
        }

        public static void VBloodNotifyIgnoreConfig()
        {
            var json = File.ReadAllText(Path.Combine(ConfigDefaultHelper.ConfigPath, "vbloodannounce_ignore_users.json"));
            var dictionary = JsonSerializer.Deserialize<Dictionary<string, bool>>(json);
            DBHelper.setVBloodNotifyIgnore(dictionary);
        }

        public static void LoadAutoAnnouncerMessagesConfig()
        {
            var json = File.ReadAllText(Path.Combine(ConfigDefaultHelper.ConfigPath, "auto_announcer_messages.json"));
            var parser = new MessageParser();
            IEnumerable<AutoAnnouncerMessage> messages = parser.Parse(json);

            foreach (AutoAnnouncerMessage message in messages)
            {
                DBHelper.addAutoAnnouncerMessages(message);
            }
            
        }

        public static void LoadMessageOfTheDayConfig()
        {
            var json = File.ReadAllText(Path.Combine(ConfigDefaultHelper.ConfigPath, "message_of_the_day.json"));
            var dictionary = JsonSerializer.Deserialize<List<string>>(json);
            DBHelper.setMessageOfTheDay(dictionary);
        }

    }
}
