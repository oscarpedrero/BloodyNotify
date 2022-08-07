using ProjectM;
using System.Collections.Generic;
using Notify.Utils;
using Notify.AutoAnnouncer.Models;

namespace Notify.Helpers
{
    internal class DBHelper
    {
        private static bool AnnounceOnline = false;
        private static bool AnnounceeOffline = false;
        private static bool AnnounceNewUser = false;
        private static bool AnnounceVBlood = false;
        private static string VBloodFinalConcatCharacters = "and";
        private static bool AutoAnnouncer = false;
        private static int IntervalAutoAnnouncer = 0;
        private static List<AutoAnnouncerMessage> AutoAnnouncerMessages = new List<AutoAnnouncerMessage>();

        private static Dictionary<string, string> DefaultAnnounce { get; set; } = new Dictionary<string, string>();

        private static Dictionary<string, string> UsersConfigOnline { get; set; } = new Dictionary<string, string>();

        private static Dictionary<string, string> UsersConfigOffline { get; set; } = new Dictionary<string, string>();

        private static Dictionary<string, string> PrefabToNames { get; set; } = new Dictionary<string, string>();

        private static Dictionary<string, bool> VBloodNotifyIgnore { get; set; } = new Dictionary<string, bool>();

        public static void setAnnounceOnline(bool value)
        {
            AnnounceOnline = value;
        }

        public static void setAnnounceOffline(bool value)
        {
            AnnounceeOffline = value;
        }

        public static void setAnnounceNewUser(bool value)
        {
            AnnounceNewUser = value;
        }

        public static void setAnnounceVBlood(bool value)
        {
            AnnounceVBlood = value;
        }

        public static void setVBloodFinalConcatCharacters(string value)
        {
            VBloodFinalConcatCharacters = value;
        }

        public static bool isEnabledAnnounceOnline()
        {
            return AnnounceOnline;
        }
        public static bool isEnabledAnnounceeOffline()
        {
            return AnnounceeOffline;
        }

        public static bool isEnabledAnnounceNewUser()
        {
            return AnnounceNewUser;
        }

        public static bool isEnabledAnnounceVBlood()
        {
            return AnnounceVBlood;
        }

        public static string getVBloodFinalConcatCharacters()
        {
            return VBloodFinalConcatCharacters;
        }

        public static bool setDefaultAnnounce(Dictionary<string, string> value)
        {
            if (value == null)
                return false;

            DefaultAnnounce = value;
            return true;
        }
        public static bool setUsersOnline(Dictionary<string, string> value)
        {
            if (value == null)
                return false;

            UsersConfigOnline = value;
            return true;
        }
        public static bool setUsersOffline(Dictionary<string, string> value)
        {
            if (value == null)
                return false;

            UsersConfigOffline = value;
            return true;
        }
        public static bool setPrefabsNames(Dictionary<string, string> value)
        {
            if (value == null)
                return false;

            PrefabToNames = value;
            return true;
        }
        public static bool setVBloodNotifyIgnore(Dictionary<string, bool> value)
        {
            if (value == null)
                return false;

            VBloodNotifyIgnore = value;
            return true;
        }

        public static string getDefaultAnnounceValue(string value)
        {
            if (value == null)
                return value;

            if (DefaultAnnounce.ContainsKey(value))
            {
                return DefaultAnnounce[value];
            } else
            {
                return value;
            }
        }

        public static string getUserOnlineValue(string user)
        {
            if (user == null || user == "")
            {
                return getDefaultAnnounceValue("newUser");
            }

            if (UsersConfigOnline.ContainsKey(user))
            {
                return UsersConfigOnline[user];
            } else
            {
                return getDefaultAnnounceValue("online");
            }
        }

        public static string getUserOfflineValue(string user)
        {
            if (user == null || user == "")
            {
                return user;
            }

            if (UsersConfigOffline.ContainsKey(user))
            {
                return UsersConfigOffline[user];
            } else
            {
                return getDefaultAnnounceValue("offline");
            }
        }

        public static string getPrefabNameValue(string prefabName)
        {
            if (prefabName == null)
            {
                return "NoPrefabName";
            }

            if (PrefabToNames.ContainsKey(prefabName))
            {
                return PrefabToNames[prefabName];
            } else
            {
                return PrefabToNames["NoPrefabName"];
            }
        }

        public static bool getVBloodNotifyIgnore(string characterName)
        {
            if (characterName == null)
            {
                return false;
            }

            if (VBloodNotifyIgnore.ContainsKey(characterName))
            {
                return true;
            } else
            {
                return false;
            }
        }

        public static bool addVBloodNotifyIgnore(string characterName)
        {
            
            if (VBloodNotifyIgnore.ContainsKey(characterName))
            {
                return true;
            } else
            {
                VBloodNotifyIgnore.Add(characterName, true);
                SaveConfigHelper.SaveVBloodNotifyIgnoreConfig(VBloodNotifyIgnore);
                return true;
            }
        }

        public static bool removeVBloodNotifyIgnore(string characterName)
        {

            if (VBloodNotifyIgnore.ContainsKey(characterName))
            {
                VBloodNotifyIgnore.Remove(characterName);
                SaveConfigHelper.SaveVBloodNotifyIgnoreConfig(VBloodNotifyIgnore);
                return true;
            }
            else
            {
                return true;
            }
        }

        public static bool isEnabledAutoAnnouncer()
        {
            return AutoAnnouncer;
        }

        public static void setAutoAnnouncer(bool autoAnnouncer)
        {
            AutoAnnouncer = autoAnnouncer;
        }

        public static int getIntervalAutoAnnouncer()
        {
            return IntervalAutoAnnouncer;
        }

        public static void setIntervalAutoAnnouncer(int intervalAutoAnnouncer)
        {
            IntervalAutoAnnouncer = intervalAutoAnnouncer * 1000;
        }

        public static List<AutoAnnouncerMessage> getAutoAnnouncerMessages()
        {
            return AutoAnnouncerMessages;
        }

        public static void addAutoAnnouncerMessages(AutoAnnouncerMessage autoAnnouncerMessages)
        {
            AutoAnnouncerMessages.Add(autoAnnouncerMessages);
        }


    }
}
