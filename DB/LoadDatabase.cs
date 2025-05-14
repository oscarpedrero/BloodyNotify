using BloodyNotify.AutoAnnouncer.Models;
using BloodyNotify.AutoAnnouncer.Parser;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace BloodyNotify.DB
{
    internal class LoadDatabase
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
            var json = File.ReadAllText(Path.Combine(Config.ConfigPath, "default_announce.json"));
            var dictionary = JsonSerializer.Deserialize<Dictionary<string, string[]>>(json);
            Database.setDefaultAnnounce(dictionary);
        }

        public static void LoadUsersConfigOnline()
        {
            var json = File.ReadAllText(Path.Combine(Config.ConfigPath, "users_online.json"));
            var dictionary = JsonSerializer.Deserialize<Dictionary<string, string>>(json);
            Database.setUsersOnline(dictionary);
        }

        public static void LoadUsersConfigOffline()
        {
            var json = File.ReadAllText(Path.Combine(Config.ConfigPath, "users_offline.json"));
            var dictionary = JsonSerializer.Deserialize<Dictionary<string, string>>(json);
            Database.setUsersOffline(dictionary);
        }

        public static void LoadPrefabsName()
        {
            var json = File.ReadAllText(Path.Combine(Config.ConfigPath, "prefabs_names.json"));
            var dictionary = JsonSerializer.Deserialize<Dictionary<string, string>>(json);
            Database.setPrefabsNames(dictionary);
        }

        public static void LoadPrefabsIgnore()
        {
            var json = File.ReadAllText(Path.Combine(Config.ConfigPath, "prefabs_names_ignore.json"));
            var dictionary = JsonSerializer.Deserialize<Dictionary<string, bool>>(json);
            Database.setPrefabsIgnore(dictionary);
        }

        public static void VBloodNotifyIgnoreConfig()
        {
            var json = File.ReadAllText(Path.Combine(Config.ConfigPath, "vbloodannounce_ignore_users.json"));
            var dictionary = JsonSerializer.Deserialize<Dictionary<string, bool>>(json);
            Database.setVBloodNotifyIgnore(dictionary);
        }

        public static void LoadAutoAnnouncerMessagesConfig()
        {
            var json = File.ReadAllText(Path.Combine(Config.ConfigPath, "auto_announcer_messages.json"));
            var parser = new MessageParser();
            IEnumerable<AutoAnnouncerMessage> messages = parser.Parse(json);

            foreach (AutoAnnouncerMessage message in messages)
            {
                Database.addAutoAnnouncerMessages(message);
            }

        }

        public static void LoadMessageOfTheDayConfig()
        {
            var json = File.ReadAllText(Path.Combine(Config.ConfigPath, "message_of_the_day.json"));
            var dictionary = JsonSerializer.Deserialize<List<string>>(json);
            Database.setMessageOfTheDay(dictionary);
        }
    }
}
