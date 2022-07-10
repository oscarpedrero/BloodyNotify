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
        private static string VBloodFinalConcatCharacters = "and";

        private static Dictionary<string, string> DefaultAnnounce { get; set; } = new Dictionary<string, string>();

        private static Dictionary<string, string> UsersConfigOnline { get; set; } = new Dictionary<string, string>();

        private static Dictionary<string, string> UsersConfigOffline { get; set; } = new Dictionary<string, string>();

        private static Dictionary<string, string> PrefabToNames { get; set; } = new Dictionary<string, string>();

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
            return AnnounceOnline;
        }

        public static bool isEnabledAnnounceVBlood()
        {
            return AnnounceOnline;
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
    }
}
