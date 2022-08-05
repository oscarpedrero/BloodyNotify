# Notify - Mod Server for V Rising

A mod that notifies when a user connects or disconnects from the server and when a player kills a VBlood boss.

The notifications are fully customizable both by default and by each player, thos of connecting and disconnecting.

<details>
<summary>Changelog</summary>

`1.2.3`
- Fixed bug that affected the AnnounceVBlood mod configuration parameter not working correctly
- Fixed bug that affected the NewUserOnline mod configuration parameter not working correctly

`1.2.2`
- Fixed error when there was no configuration file, it gave an error when loading it

`1.2.1`
- Fixed bug where when you reload from chat, it didn't reload ignores from VBlood kills

`1.2.0`
- Added that users can enable/disable VBlood kills via chat command.
- Added command to ignore VBlood Announce `!notify ignore vbloodannounce`
- Added command to ignore VBlood Announce `!notify ignore vbloodannounce`
- Added command to unignore VBlood Announce `!notify unignore vbloodannounce`
- Added command to help `!notify help`
- Added VRising.GameData package from adainrivers

`1.1.0`
- Added command to refresh mod settings `!notify realod`

`1.0.1`
- Fixed configuration file paths to get BepInEx configuration path programmatically. By [PhantomGamers](https://github.com/PhantomGamers)
- Commented all the BepInX logger info

`1.0.0`
- Added custom config files for VBlodd boss names

`0.5.0`
- Added notifications when a player kills a VBlodd boss 

`0.4.0`
- Fixed notification when a new player creates a character on the server
- Added custom config files by character name

`0.3.0`
- Added notifications when a user connect to the server 
- Added notifications when a user disconnects from the server

</details>

## Chat Commands

|COMMAND|DESCRIPTION
|-------------------------|-------------------------------|
|`!notify help`| Command that returns all available commands         
|`!notify reload` (Only Admins)    | To reload the configuration of all config files
|`!notify ignore vbloodannounce`| Turn on VBlood death notifications
|`!notify unignore vbloodannounce`| Turn off VBlood death notifications

# Configuration

Once the mod installed, a configuration file will be created in the \BepInEx\config server folder where you can activate or desactivate any of the mod notifications.

**Notify.cfg**

|SECTION|PARAM|DESCRIPTION| DEFAULT
|----------------|-------------------------------|-----------------------------|-----------------------------|
|AnnounceVBlood|`enabled `            |Enable Announce when user/users kill a VBlood Boss            | True
|AnnounceVBlood        |`VBloodFinalConcatCharacters`            |Final string for concat two or more players kill a VBlood Boss.            | and
|NewUserOnline|`enabled `|Enable Announce when new user create in server|true
|UserOffline|`enabled `|Enable Announce when user offline |true
|UserOnline|`enabled `|Enable Announce when user online|true

> To reload the configuration of the user messages online, offline or death of the VBlood boss there is the chat command `!notify reload`

## Default Messages

To configure the default messages in case you do not have personalized messages per player you only have to edit the configuration file that is in **/BepInEx/config/Notify/default_announce.json**
```
{
  "online":"#user# is online!",
  "offline":"#user# has gone offline!",
  "newUser":"Welcome to server new vampire",
  "VBlood":"Congratulations to #user# for kill #vblood#!"
}
```
> The text string #user# is used to overwrite the name of the corresponding player(s)

> The text string #vblood# is used to overwrite the name of the corresponding VBlood boss

> The text string #user# in newUser don't work.


## Customize Player Announce

To configure the customize messages per player connected, you only have to edit the configuration file that is in **/BepInEx/config/Notify/users_online.json**

```
{
   "CharacterName": "#user# The best player of server is online!",
   "OtherCharacterName": "The most wanted #user# is online!"
}
```
> The text string #user# is used to overwrite the name of the corresponding player(s)

To configure the customize messages per player disconnected, you only have to edit the configuration file that is in **/BepInEx/config/Notify/users_offline.json**

```
{
   "CharacterName": "#user# The best player of server is offline!",
   "OtherCharacterName": "The most wanted #user# is offline!"
}
```
> The text string #user# is used to overwrite the name of the corresponding player(s)

## Translate VBlod boss name

To translate the name of VBlood boss, you only have to edit the configuration file that is in **/BepInEx/config/Notify/prefabs_names.json**
```
{
	"CHAR_Wildlife_Wolf_VBlood": "Alpha Wolf" ,
	"CHAR_Bandit_Deadeye_Frostarrow_VBlood": "Keely the Frost Archer" ,
	"CHAR_Bandit_Foreman_VBlood": "Rufus the Foreman" ,
	"CHAR_Bandit_StoneBreaker_VBlood": "Errol the Stonebreaker" ,
	"CHAR_Bandit_Deadeye_Chaosarrow_VBlood": "Lidia the Chaos Archer" ,
	"CHAR_Undead_BishopOfDeath_VBlood": "Goreswine the Ravager" ,
	"CHAR_Bandit_Stalker_VBlood": "Grayson the Armourer" ,
	"CHAR_Vermin_DireRat_VBlood": "Putrid Rat" ,
	"CHAR_Bandit_Bomber_VBlood": "Clive the Firestarter" ,
	"CHAR_Wildlife_Poloma_VBlood": "Polora the Feywalker" ,
	"CHAR_Wildlife_Bear_Dire_Vblood": "Ferocious Bear" ,
	"CHAR_Undead_Priest_VBlood": "Nicholaus the Fallen" ,
	"CHAR_Bandit_Tourok_VBlood": "Quincey the Bandit King" ,
	"CHAR_Villager_Tailor_VBlood": "Beatrice the Tailor" ,
	"CHAR_Militia_Guard_VBlood": "Vincent the Frostbringer" ,
	"CHAR_Farmlands_Nun_VBlood": "Christina the Sun Priestess" ,
	"CHAR_VHunter_Leader_VBlood": "Tristan the Vampire Hunter" ,
	"CHAR_Undead_BishopOfShadows_VBlood": "Leandra the Shadow Priestess" ,
	"CHAR_Geomancer_Human_VBlood": "Terah the Geomancer" ,
	"CHAR_Militia_Longbowman_LightArrow_Vblood": "Meredith the Bright Archer" ,
	"CHAR_Wendigo_VBlood": "Frostmaw the Mountain Terror" ,
	"CHAR_Militia_Leader_VBlood": "Octavian the Militia Captain" ,
	"CHAR_Militia_BishopOfDunley_VBlood": "Raziel the Shepherd" ,
	"CHAR_Spider_Queen_VBlood": "Ungora the Spider Queen" ,
	"CHAR_Cursed_ToadKing_VBlood": "The Duke of Balaton" ,
	"CHAR_VHunter_Jade_VBlood": "Jade the Vampire Hunter" ,
	"CHAR_Undead_ZealousCultist_VBlood": "Foulrot the Soultaker" ,
	"CHAR_WerewolfChieftain_VBlood": "Willfred the Werewolf Chief" ,
	"CHAR_ArchMage_VBlood": "Mairwyn the Elementalist" ,
	"CHAR_Town_Cardinal_VBlood": "Azariel the Sunbringer" ,
	"CHAR_Winter_Yeti_VBlood": "Terrorclaw the Ogre" ,
	"CHAR_Harpy_Matriarch_VBlood": "Morian the Stormwing Matriarch" ,
	"CHAR_Cursed_Witch_VBlood": "Matka the Curse Weaver" ,
	"CHAR_BatVampire_VBlood": "Nightmarshal Styx the Sunderer" ,
	"CHAR_Cursed_MountainBeast_VBlood": "Gorecrusher the Behemoth" ,
	"CHAR_Manticore_VBlood": "The Winged Horror" ,
	"CHAR_Paladin_VBlood": "Solarus the Immaculate" ,
	"NoPrefabName": "VBlood Boss"
}
```

## VBlood Announce Ignore

If you want to do it by hand you just have to edit the **/BepInEx/config/Notify/vbloodannounce_ignore_users.json** file to add or remove players

```
{
   "CharacterName": true,
   "OtherCharacterName": true
}
```


## Credits

For the development of this mod i have used parts of the code of [Kaltharos (RPGMods)](https://github.com/Kaltharos/RPGMods) , [syllabicat (VBloodKills)](https://github.com/syllabicat/VBloodKills) and [adainrivers (VRising.GameData)](https://github.com/adainrivers/VRising.GameData)