using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Notify.Helpers
{
    internal class ConfigDefaultHelper
    {
        public static readonly string ConfigPath = Path.Combine(BepInEx.Paths.ConfigPath, "Notify");

        public static Dictionary<string, string> DefaultAnnounceDictionary => new Dictionary<string, string>()
        {
            {  "online" , "#user# is online!" },
            {  "offline" , "#user# has gone offline!" },
            {  "newUser" , "Welcome to server" },
            {  "VBlood" , "Congratulations to #user# for beating #vblood#!" }
        };
        public static Dictionary<string, string> PrefabToNamesDefault => new Dictionary<string, string>()
        {
            {"CHAR_Cursed_Witch_VBlood", "Matka"},
            {"CHAR_Geomancer_Human_VBlood", "Terah"},
            //{"CHAR_Geomancer_Golem_VBlood", "Terah "}, //added a space to make the key unique
            {"CHAR_VHunter_Jade_VBlood", "Jade"},
            {"CHAR_Villager_Tailor_VBlood", "Beatrice"},
            {"CHAR_Undead_Priest_VBlood", "Nicholaus"},
            {"CHAR_Bandit_Tourok_VBlood", "Quincey (Quincy)"},
            {"CHAR_Spider_Queen_VBlood", "Ungora (Spider)"},
            {"CHAR_Winter_Yeti_VBlood", "Terrorclaw"},
            //{"CHAR_Bandit_Deadeye_Chaosarrow_VBlood", "Lidia"},
            {"CHAR_Undead_BishopOfDeath_VBlood", "Goreswine"},
            {"CHAR_Militia_Leader_VBlood", "Octavian"},
            {"CHAR_Undead_BishopOfShadows_VBlood", "Leandra"},
            {"CHAR_Bandit_Foreman_VBlood", "Rufus"},
            //{"CHAR_Bandit_Deadeye_Frostarrow_VBlood", "Keely"},
            {"CHAR_Forest_Bear_Dire_VBlood", "Ferocious Bear"},
            {"CHAR_Militia_Nun_VBlood", "Christina"},
            {"CHAR_Bandit_Bomber_VBlood", "Clive"},
            {"CHAR_Cursed_MountainBeast_VBlood", "Gorecrusher the Behemoth"},
            {"CHAR_Undead_ZealousCultist_VBlood", "Foulrot"},
            {"CHAR_Poloma_VBlood", "Polora"},
            {"CHAR_BatVampire_VBlood", "Styx (Bat)"},
            {"CHAR_ArchMage_VBlood", "Mairwyn"},
            {"CHAR_Cursed_ToadKing_VBlood", "The Duke of Balaton (Frog)"},
            {"CHAR_Manticore_VBlood", "The Winged Horror"},
            {"CHAR_Militia_Guard_VBlood", "Vincent"},
            {"CHAR_Militia_BishopOfDunley_VBlood", "Raziel"},
            {"CHAR_Harpy_Matriarch_VBlood", "Morian"},
            {"CHAR_ChurchOfLight_Paladin_VBlood", "Solarus"},
            {"CHAR_VHunter_Leader_VBlood", "Tristan"},
            {"CHAR_Bandit_StoneBreaker_VBlood", "Errol"},
            {"CHAR_ChurchOfLight_Cardinal_VBlood", "Azariel"},
            //{"CHAR_WerewolfChieftain_VBlood", "Wilfred"},
            {"CHAR_Forest_Wolf_VBlood", "Alpha Wolf"},
            {"CHAR_Militia_Longbowman_LightArrow_VBlood", "Meredith"},
            {"CHAR_Vermin_DireRat_VBlood", "Putrid Rat"},
            {"CHAR_Wendigo_VBlood", "Frostmaw"},
            {"CHAR_Bandit_Stalker_VBlood", "Grayson"},
            {"CHAR_Gloomrot_Monster_VBlood", "Adam"},
            {"CHAR_Gloomrot_RailgunSergeant_VBlood", "Voltatia"},
            {"CHAR_Gloomrot_Iva_VBlood", "Ziva"},
            {"CHAR_Gloomrot_Purifier_VBlood", "Angram"},
            {"CHAR_Gloomrot_TheProfessor_VBlood", "Henry Blackbrew"},
            {"CHAR_Gloomrot_Voltage_VBlood", "Domina"},
            {"CHAR_Undead_CursedSmith_VBlood", "Cyril"},
            {"CHAR_Villager_CursedWanderer_VBlood", "The Old Wanderer"},
            {"CHAR_ChurchOfLight_Sommelier_VBlood", "Baron du Bouchon"},
            {"CHAR_ChurchOfLight_Overseer_VBlood", "Sir Magnus the Overseer"},
            {"CHAR_Militia_Scribe_VBlood", "Maja"},
            {"CHAR_Undead_Infiltrator_VBlood", "Bane"},
            {"CHAR_Militia_Glassblower_VBlood", "Grethel the Glassblower"},
            {"CHAR_Undead_Leader_VBlood", "Kriig"},
            {"NoPrefabName", "Unknow VBlood "}
        };

        public static Dictionary<string, bool> PrefabsIgnoreDefaul => new Dictionary<string, bool>()
        {
            {"CHAR_Cursed_Witch_VBlood", false},
            {"CHAR_Geomancer_Human_VBlood", false},
            //{"CHAR_Geomancer_Golem_VBlood", false}, //added a space to make the key unique
            {"CHAR_VHunter_Jade_VBlood", false},
            {"CHAR_Villager_Tailor_VBlood", false},
            {"CHAR_Undead_Priest_VBlood", false},
            {"CHAR_Bandit_Tourok_VBlood", false},
            {"CHAR_Spider_Queen_VBlood", false},
            {"CHAR_Winter_Yeti_VBlood", false},
            //{"CHAR_Bandit_Deadeye_Chaosarrow_VBlood", false},
            {"CHAR_Undead_BishopOfDeath_VBlood", false},
            {"CHAR_Militia_Leader_VBlood", false},
            {"CHAR_Undead_BishopOfShadows_VBlood", false},
            {"CHAR_Bandit_Foreman_VBlood", false},
            //{"CHAR_Bandit_Deadeye_Frostarrow_VBlood", false},
            {"CHAR_Forest_Bear_Dire_VBlood", false},
            {"CHAR_Militia_Nun_VBlood", false},
            {"CHAR_Bandit_Bomber_VBlood", false},
            {"CHAR_Cursed_MountainBeast_VBlood", false},
            {"CHAR_Undead_ZealousCultist_VBlood", false},
            {"CHAR_Poloma_VBlood", false},
            {"CHAR_BatVampire_VBlood", false},
            {"CHAR_ArchMage_VBlood", false},
            {"CHAR_Cursed_ToadKing_VBlood", false},
            {"CHAR_Manticore_VBlood", false},
            {"CHAR_Militia_Guard_VBlood", false},
            {"CHAR_Militia_BishopOfDunley_VBlood", false},
            {"CHAR_Harpy_Matriarch_VBlood", false},
            {"CHAR_ChurchOfLight_Paladin_VBlood", false},
            {"CHAR_VHunter_Leader_VBlood", false},
            {"CHAR_Bandit_StoneBreaker_VBlood", false},
            {"CHAR_ChurchOfLight_Cardinal_VBlood", false},
            //{"CHAR_WerewolfChieftain_VBlood", false},
            {"CHAR_Forest_Wolf_VBlood", false},
            {"CHAR_Militia_Longbowman_LightArrow_VBlood", false},
            {"CHAR_Vermin_DireRat_VBlood", false},
            {"CHAR_Wendigo_VBlood", false},
            {"CHAR_Bandit_Stalker_VBlood", false},
            {"CHAR_Gloomrot_Monster_VBlood", false},
            {"CHAR_Gloomrot_RailgunSergeant_VBlood", false},
            {"CHAR_Gloomrot_Iva_VBlood", false},
            {"CHAR_Gloomrot_Purifier_VBlood", false},
            {"CHAR_Gloomrot_TheProfessor_VBlood", false},
            {"CHAR_Gloomrot_Voltage_VBlood", false},
            {"CHAR_Undead_CursedSmith_VBlood", false},
            {"CHAR_Villager_CursedWanderer_VBlood", false},
            {"CHAR_ChurchOfLight_Sommelier_VBlood", false},
            {"CHAR_ChurchOfLight_Overseer_VBlood", false},
            {"CHAR_Militia_Scribe_VBlood", false},
            {"CHAR_Undead_Infiltrator_VBlood", false},
            {"CHAR_Militia_Glassblower_VBlood", false},
            {"CHAR_Undead_Leader_VBlood", false},
            {"NoPrefabName", false}
        };
        

        public static Dictionary<string, string> DefaultOnline => new Dictionary<string, string>()
        {
            {  "nick" , "#user# is online!" }
        };


        public static Dictionary<string, string> DefaultOffline => new Dictionary<string, string>()
        {
            {  "nick" , "#user# is ofline!" }
        };


        public static Dictionary<string, bool> DefaultVBloodAnnounceIgnoreUsers => new Dictionary<string, bool>()
        {
            {  "nick" , true }
        };

        public static List<string> DefaultMessageOfTheDay => new List<string>()
        {
            {  "#user# this is Message of the day Line 1" },
            {  "Message of the day Line 2" },
            {  "Message of the day Line 3" }
        };


        public static string DefaultAutoAnnounceMessagesConfig = @"[[""Message 1 Line 1"",""Message 1 Line 2""],[""Message 2 Line 1"",""Message 2 Line 2"",""Message 2 Line 3"",""Message 2 Line 4""]]";

        public static void CreateDefaultNotificationTextConfig()
        {
            var jsonOutPut = System.Text.Json.JsonSerializer.Serialize(DefaultAnnounceDictionary);
            File.WriteAllText(Path.Combine(ConfigPath, "default_announce.json"), jsonOutPut);
        }

        public static void CreateOnlineDefaultConfig()
        {
            var jsonOutPut = System.Text.Json.JsonSerializer.Serialize(DefaultOnline);
            File.WriteAllText(Path.Combine(ConfigPath, "users_online.json"), jsonOutPut);
        }

        public static void CreateOfflineDefaultConfig()
        {
            var jsonOutPut = System.Text.Json.JsonSerializer.Serialize(DefaultOffline);
            File.WriteAllText(Path.Combine(ConfigPath, "users_offline.json"), jsonOutPut);
        }

        public static void CreateLocationVBloodDefaultConfig()
        {
            var jsonOutPut = System.Text.Json.JsonSerializer.Serialize(PrefabToNamesDefault);
            File.WriteAllText(Path.Combine(ConfigPath, "prefabs_names.json"), jsonOutPut);
        }

        public static void CreateIgnoreVBloodDefaultConfig()
        {
            var jsonOutPut = System.Text.Json.JsonSerializer.Serialize(PrefabsIgnoreDefaul);
            File.WriteAllText(Path.Combine(ConfigPath, "prefabs_names_ignore.json"), jsonOutPut);
        }

        public static void CreateVBloodNotifyIgnoreConfig()
        {
            var jsonOutPut = System.Text.Json.JsonSerializer.Serialize(DefaultVBloodAnnounceIgnoreUsers);
            File.WriteAllText(Path.Combine(ConfigPath, "vbloodannounce_ignore_users.json"), jsonOutPut);
        }

        public static void CreateAutoAnnouncerMessagesConfig()
        {
            File.WriteAllText(Path.Combine(ConfigPath, "auto_announcer_messages.json"), DefaultAutoAnnounceMessagesConfig);
        }

        public static void CreateMessagesOfTheDayConfig()
        {
            var jsonOutPut = System.Text.Json.JsonSerializer.Serialize(DefaultMessageOfTheDay);
            File.WriteAllText(Path.Combine(ConfigPath, "message_of_the_day.json"), jsonOutPut);
        }

        public static void CheckAndCreateConfigs()
        {
            if (!File.Exists(Path.Combine(ConfigPath, "users_online.json")))
            {
                CreateOnlineDefaultConfig();
            }

            if (!File.Exists(Path.Combine(ConfigPath, "users_offline.json")))
            {
                CreateOfflineDefaultConfig();
            }

            if (!File.Exists(Path.Combine(ConfigPath, "default_announce.json")))
            {
                CreateDefaultNotificationTextConfig();
            }

            if (!File.Exists(Path.Combine(ConfigPath, "prefabs_names.json")))
            {
                CreateLocationVBloodDefaultConfig();
            }

            if (!File.Exists(Path.Combine(ConfigPath, "prefabs_names_ignore.json")))
            {
                CreateIgnoreVBloodDefaultConfig();
            }

            if (!File.Exists(Path.Combine(ConfigPath, "vbloodannounce_ignore_users.json")))
            {
                CreateVBloodNotifyIgnoreConfig();
            }

            if (!File.Exists(Path.Combine(ConfigPath, "auto_announcer_messages.json")))
            {
                CreateAutoAnnouncerMessagesConfig();
            }

            if (!File.Exists(Path.Combine(ConfigPath, "message_of_the_day.json")))
            {
                CreateMessagesOfTheDayConfig();
            }
        }
    }
}
