using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Notify.Helpers
{
    internal class ConfigDefaultHelper
    {

        public static Dictionary<string, string> DefaultAnnounceDictionary => new Dictionary<string, string>()
        {
            {  "online" , "#user# is online!" },
            {  "offline" , "#user# has gone offline!" },    
            {  "newUser" , "Welcome to server" },
            {  "VBlood" , "Congratulations to #user# for beating #vblood#!" }
        };
        public static Dictionary<string, string> PrefabToNamesDefault => new Dictionary<string, string>()
        {
            { "CHAR_Wildlife_Wolf_VBlood", "Alpha Wolf" },
            { "CHAR_Bandit_Deadeye_Frostarrow_VBlood", "Keely the Frost Archer" },
            { "CHAR_Bandit_Foreman_VBlood", "Rufus the Foreman" },
            { "CHAR_Bandit_StoneBreaker_VBlood", "Errol the Stonebreaker" },
            { "CHAR_Bandit_Deadeye_Chaosarrow_VBlood", "Lidia the Chaos Archer" },
            { "CHAR_Undead_BishopOfDeath_VBlood", "Goreswine the Ravager" },
            { "CHAR_Bandit_Stalker_VBlood", "Grayson the Armourer" },
            { "CHAR_Vermin_DireRat_VBlood", "Putrid Rat" },
            { "CHAR_Bandit_Bomber_VBlood", "Clive the Firestarter" },
            { "CHAR_Wildlife_Poloma_VBlood", "Polora the Feywalker" },
            { "CHAR_Wildlife_Bear_Dire_Vblood", "Ferocious Bear" },
            { "CHAR_Undead_Priest_VBlood", "Nicholaus the Fallen" },
            { "CHAR_Bandit_Tourok_VBlood", "Quincey the Bandit King" },
            { "CHAR_Villager_Tailor_VBlood", "Beatrice the Tailor" },
            { "CHAR_Militia_Guard_VBlood", "Vincent the Frostbringer" },
            { "CHAR_Farmlands_Nun_VBlood", "Christina the Sun Priestess" },
            { "CHAR_VHunter_Leader_VBlood", "Tristan the Vampire Hunter" },
            { "CHAR_Undead_BishopOfShadows_VBlood", "Leandra the Shadow Priestess" },
            { "CHAR_Geomancer_Human_VBlood", "Terah the Geomancer" },
            { "CHAR_Militia_Longbowman_LightArrow_Vblood", "Meredith the Bright Archer" },
            { "CHAR_Wendigo_VBlood", "Frostmaw the Mountain Terror" },
            { "CHAR_Militia_Leader_VBlood", "Octavian the Militia Captain" },
            { "CHAR_Militia_BishopOfDunley_VBlood", "Raziel the Shepherd" },
            { "CHAR_Spider_Queen_VBlood", "Ungora the Spider Queen" },
            { "CHAR_Cursed_ToadKing_VBlood", "The Duke of Balaton" },
            { "CHAR_VHunter_Jade_VBlood", "Jade the Vampire Hunter" },
            { "CHAR_Undead_ZealousCultist_VBlood", "Foulrot the Soultaker" },
            { "CHAR_WerewolfChieftain_VBlood", "Willfred the Werewolf Chief" },
            { "CHAR_ArchMage_VBlood", "Mairwyn the Elementalist" },
            { "CHAR_Town_Cardinal_VBlood", "Azariel the Sunbringer" },
            { "CHAR_Winter_Yeti_VBlood", "Terrorclaw the Ogre" },
            { "CHAR_Harpy_Matriarch_VBlood", "Morian the Stormwing Matriarch" },
            { "CHAR_Cursed_Witch_VBlood", "Matka the Curse Weaver" },
            { "CHAR_BatVampire_VBlood", "Nightmarshal Styx the Sunderer" },
            { "CHAR_Cursed_MountainBeast_VBlood", "Gorecrusher the Behemoth" },
            { "CHAR_Manticore_VBlood", "The Winged Horror" },
            { "CHAR_Paladin_VBlood", "Solarus the Immaculate" },
            { "NoPrefabName", "VBlood Boss" }
        };

        public static Dictionary<string, string> DefaultOnline => new Dictionary<string, string>()
        {
            {  "nick" , "#user# is online!" }
        };


        public static Dictionary<string, string> DefaultOffline => new Dictionary<string, string>()
        {
            {  "nick" , "#user# is ofline!" }
        };

        public static void CreateDefaultNotificationTextConfig()
        {
            var jsonOutPut = System.Text.Json.JsonSerializer.Serialize(DefaultAnnounceDictionary);
            File.WriteAllText("BepInEx/config/Notify/default_announce.json", jsonOutPut);
        }

        public static void CreateOnlineDefaultConfig()
        {
            var jsonOutPut = System.Text.Json.JsonSerializer.Serialize(DefaultOnline);
            File.WriteAllText("BepInEx/config/Notify/users_online.json", jsonOutPut);
        }

        public static void CreateOfflineDefaultConfig()
        {
            var jsonOutPut = System.Text.Json.JsonSerializer.Serialize(DefaultOffline);
            File.WriteAllText("BepInEx/config/Notify/users_offline.json", jsonOutPut);
        }

        public static void CreateLocationVBloodDefaultConfig()
        {
            var jsonOutPut = System.Text.Json.JsonSerializer.Serialize(PrefabToNamesDefault);
            File.WriteAllText("BepInEx/config/Notify/prefabs_names.json", jsonOutPut);
        }

    }
}
