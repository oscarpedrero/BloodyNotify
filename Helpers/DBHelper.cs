using ProjectM;
using System.Collections.Generic;
using Notify.Utils;

namespace Notify.Helpers
{
    internal class DBHelper
    {
        private static bool AnnounceOnline = false;
        private static bool AnnounceeOffline = false;
        private static bool AnnounceNewUser = false;
        private static bool AnnounceVBlood = false;

        private static Dictionary<string, string> DefaultAnnounce { get; set; }

        private static Dictionary<string, string> UsersConfigOnline { get; set; }

        private static Dictionary<string, string> UsersConfigOffline { get; set; }

        private static Dictionary<string, string> PrefabToNames { get; set; }

        public static void setAnnounceOnline(bool value)
        {
            AnnounceOnline = value;
        }

        public static void setAnnounceeOffline(bool value)
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
            return AnnounceOnline;
        }

        public static bool isEnabledAnnounceVBlood()
        {
            return AnnounceOnline;
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

        public static string getPrefabNameValue(PrefabGUID prefabName)
        {
            if (prefabName == null)
            {
                return "NoPrefabName";
            }

            var _prefabName = PrefabsUtils.getPrefabName(prefabName);

            if (PrefabToNames.ContainsKey(_prefabName))
            {
                return PrefabToNames[_prefabName];
            } else
            {
                return _prefabName;
            }
        }
    }
}
