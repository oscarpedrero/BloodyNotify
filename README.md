# Notify - Mod Server for V Rising

## Requirements:

For the correct functioning of this mod you must have the following dependencies installed on your server:

- [BepInExPack V Rising ](https://v-rising.thunderstore.io/package/BepInEx/BepInExPack_V_Rising/) 
- [WetStone 1.1.0](https://v-rising.thunderstore.io/package/molenzwiebel/Wetstone/) 
- [VRising.GameData 0.2.2](https://v-rising.thunderstore.io/package/adainrivers/VRising_GameData/) -- IMPORTANT FROM VERSION 1.4.1

### Actual Features

- [x] Announce User Online
- [x] Announce User Offline
- [x] Announce kill VBlood Boss
- [x] Auto Announcer
- [x] Message Of The Day

### Next Features

- [ ] Announce Admin use console command to another admins online

<details>
<summary>Changelog</summary>

`1.4.2`

- Fixed bugs and improve performance with AutoAnnouncer
- Updated the VRising.GameData framework to version 0.2.2

`1.4.1`

- Fixed bugs and improve performance

`1.4.0`

- Added a system for automatic message of the day (MOTD) to go out to any player who connects to the server.
- Added a configuration file was added to be able to configure Message of the day as you want.
- Added chat command only for admins to enabled MOTD when user online `!notify motd enabled`
- Added chat command only for admins to disabled MOTD when user online `!notify motd disabled`
- Refactor folders of proyect

`1.3.0`

- Added automatic announce system every certain time defined in the configuration file
- Added a configuration file was added to be able to configure as many automatic messages as you want.
- Added chat command only for admins to enabled announce when user online `!notify announceonline enabled`
- Added chat command only for admins to disabled announce when user online `!notify announceonline disabled`
- Added chat command only for admins to enabled announce when user offline `!notify announceoffline enabled`
- Added chat command only for admins to disabled announce when user offline `!notify announceoffline disabled`
- Added chat command only for admins to enabled announce when new user connect to a server `!notify announcenewuser enabled`
- Added chat command only for admins to disabled announce when new user connect to a server `!notify announcenewuser disabled`
- Added chat command only for admins to enabled VBlood Announce `!notify vbloodannounce enabled`
- Added chat command only for admins to disabled VBlood Announce  `!notify vbloodannounce disabled`
- Added chat command only for admins to enabled auto announce `!notify autoannouncer enabled`
- Added chat command only for admins to disabled auto announce `!notify autoannouncer disabled`

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

| COMMAND                                          |DESCRIPTION
|--------------------------------------------------|-------------------------------|
| `!notify help`                                   | Command that returns all available commands         
| `!notify reload` (Only Admins)                   | To reload the configuration of all config files.
| `!notify announceonline enabled` (Only Admins)   | Enabled announceonline System. - NEW -
| `!notify announceonline disabled` (Only Admins)  | Disabled announceonline System. - NEW -
| `!notify announceoffline enabled` (Only Admins)  | Enabled announceoffline System. - NEW -
| `!notify announceoffline disabled` (Only Admins) | Disabled announceoffline System. - NEW -
| `!notify announcenewuser enabled` (Only Admins)  | Enabled announcenewuser System. - NEW -
| `!notify announcenewuser disabled` (Only Admins) |  Disabled announcenewuser System. - NEW -
| `!notify vbloodannounce enabled` (Only Admins)   | Enabled vbloodannounce System. - NEW -
| `!notify vbloodannounce disabled` (Only Admins)  | Disabled vbloodannounce System. - NEW -
| `!notify autoannouncer start` (Only Admins)      | Start AutoAnnouncer System. - NEW -
| `!notify autoannouncer stop` (Only Admins)       | Stop AutoAnnouncer System. - NEW -
| `!notify motd start` (Only Admins)               | Enabled Message of the day System. - NEW -
| `!notify motd stop` (Only Admins)                | Disabled Message of the day System. - NEW -
| `!notify ignore vbloodannounce`                  | Turn on VBlood death notifications
| `!notify unignore vbloodannounce`                | Turn off VBlood death notifications

# Configuration

Once the mod installed, a configuration file will be created in the \BepInEx\config server folder where you can activate or desactivate any of the mod notifications.

**Notify.cfg**

|SECTION|PARAM| DESCRIPTION                                                     | DEFAULT
|----------------|-------------------------------|-----------------------------------------------------------------|-----------------------------|
|AnnounceVBlood|`enabled `            | Enable Announce when user/users kill a VBlood Boss              | true
|AnnounceVBlood        |`VBloodFinalConcatCharacters`            | Final string for concat two or more players kill a VBlood Boss. | and
|NewUserOnline|`enabled `| Enable Announce when new user create in server                  |true
|UserOffline|`enabled `| Enable Announce when user offline                               |true
|UserOnline|`enabled `| Enable Announce when user online                                |true
|AutoAnnouncer|`enabled `| Enable Auto Announcer                                           |false
|AutoAnnouncer|`interval `| Interval seconds for spam AutoAnnouncer.                        |300
|MessageOfTheDay|`enabled `| Enable Message Of The Day                                       |false

> To reload the configuration of the user messages online, offline or death of the VBlood boss there is the chat command `!notify reload`

## Default Messages

To configure the default messages in case you do not have personalized messages per player you only have to edit the configuration file that is in **/BepInEx/config/Notify/default_announce.json**
```json
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

```json
{
   "CharacterName": "#user# The best player of server is online!",
   "OtherCharacterName": "The most wanted #user# is online!"
}
```
> The text string #user# is used to overwrite the name of the corresponding player(s)

To configure the customize messages per player disconnected, you only have to edit the configuration file that is in **/BepInEx/config/Notify/users_offline.json**

```json
{
   "CharacterName": "#user# The best player of server is offline!",
   "OtherCharacterName": "The most wanted #user# is offline!"
}
```
> The text string #user# is used to overwrite the name of the corresponding player(s)

## Translate VBlod boss name

To translate the name of VBlood boss, you only have to edit the configuration file that is in **/BepInEx/config/Notify/prefabs_names.json**
```json
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
## Auto Announcer Messages - NEW

To configure the Auto Announce messages you must edit the configuration file that is in **/BepInEx/config/Notify/auto_announcer_messages.json**
```json
[
    [
        "<color=#FFFFFF> Message 1 Line 1</color>", 
        "<color=#B22222><i>-Message 1 Line 2</i></color>",
        "<color=#00FFFF>Message 1 Line 3</color>",
        "<color=#FFFFFF>Message 1 Line 4</color>"
    ],
    [
        "Message 2 Line 1",
        "Message 2 Line 2",
        "Message 2 Line 3",
        "Message 2 Line 4"
    ]
]
```

> Each element of the array is a line that will paint the message system

> If you configure several messages, the system will go through one by one for each of the configured messages each time the defined interval is met.


## Message of the day ( MOTD ) - NEW

To configure the Message of the day you must edit the configuration file that is in **/BepInEx/config/Notify/message_of_the_day.json**
```json
{
    "<color=#FFFFFF>Hello <i>#user#</i> this is Message of the day Line 1</color>", 
    "<color=#B22222>Message of the day Line 2</color>",
    "<color=#00FFFF>Message of the day Line 3</color>",
    "<color=#FFFFFF>Message of the day Line 4</color>"
}
```

> Each element of the array is a line that will paint the message system

> The text string #user# is used to overwrite the name of the corresponding player(s)


## VBlood Announce Ignore

If you want to do it by hand you just have to edit the **/BepInEx/config/Notify/vbloodannounce_ignore_users.json** file to add or remove players

```json
{
   "CharacterName": true,
   "OtherCharacterName": true
}
```
## Help

If you need assistance you can ask in the discord [V Rising Mod Community](https://discord.gg/vrisingmods)

## Credits

For the development of this mod i have used parts of the code of [Kaltharos (RPGMods)](https://github.com/Kaltharos/RPGMods) , [syllabicat (VBloodKills)](https://github.com/syllabicat/VBloodKills) and [adainrivers (VRising.GameData)](https://github.com/adainrivers/VRising.GameData)
