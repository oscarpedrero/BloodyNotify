# BloodyNotify - Mod Server for V Rising

## IMPORTANT NOTE

You must have version 2.0.0 of Bloody.Core installed to be able to use version 4.0.0 or higher of this mod

## [BepInEx 1.733.2 (RC2)](https://github.com/decaprime/VRising-Modding/releases/tag/1.733.2)

## Requirements:

For the correct functioning of this mod you must have the following dependencies installed on your server:

1. [BepInEx 1.733.2 (RC2)](https://github.com/decaprime/VRising-Modding/releases/tag/1.733.2)
2. [VampireCommandFramework](https://thunderstore.io/c/v-rising/p/deca/VampireCommandFramework/)
4. [Bloody.Core](https://thunderstore.io/c/v-rising/p/Trodi/BloodyCore/)


### Actual Features

- [x] Announce User Online
- [x] Announce User Offline
- [x] Announce kill VBlood Boss
- [x] Ignore Announce kill VBlood Boss
- [x] Auto Announcer
- [x] Message Of The Day
- [x] Command for list users online

<details>
<summary>Changelog</summary>

`4.0.0`
- Limited to 3 characters that are announced when a VBlood is killed
- VBlood list updated to Oakveil
- Removed Bloodstone dependency
- Updated the mod to Oakveil

`3.0.10`
- Updated the timer system through Coroutine that brings the new version of Bloody.Core

`3.0.9`
- Update Timer Systems

`3.0.8`
- Fixed bug that did not allow the VBlood death message to appear.

`3.0.7`
- Fixed bug that duplicates VBlood death message

`3.0.6`
- Added compatibility with BloodyBoss so that if it is a BloodyBoss it does not show the death message of a VBlood

`3.0.5`
- Fixed bugs with some VBlood by [Waker](https://github.com/WakerPT)

`3.0.4`
- Bloody.Core dependency removed as dll and added as framework

`3.0.3`
- Fixed incompatibility of the AutoAnnouncer system with other modifications.

`3.0.2`
- Fixed bug that showed "ignore" when VBlood death notifications were disabled

`3.0.1`
- Name change from Notify to BloodyNotify
- Complete refactoring of the mod
- Added command for list users online
- Added new VBloods prefabs from 1.0.

`3.0.0`
- Pre-release for use in VRising version 1.0

`2.3.1`
- Improved mod performance

`2.3`
- Ignore the notification of the death of a VBlood

`2.2`
- Fixed the error that did not identify the VBlood

`2.1`
- Update VCF and prepare zip for thunderstore

`2.0.1`
- Enable / Disable mod features via command .bn config <feature> <enabled/disabled> has been changed to .bn config <feature> <true/false> Refactoring by [deca](https://github.com/decaprime)

`2.0.0`
- Gloomrot update
- Remove Wetstone
- Remove VRising.GameData
- Added new system of chat commands [VampireCommandFramework](https://github.com/decaprime/VampireCommandFramework)

`1.4.8`
- Updated wetstone to version 1.2.0

`1.4.7`
- Updated timer for AutoAnnouncer functionality. Thank you [adainrivers](https://github.com/adainrivers)
- Fixed bug that only repeated the first message of the AutoAnnouncer configuration
- Updated the version of VRising.GameData to version 3.3

`1.4.6`

- Fixed the error that occurred when initializing the VRisingData dependency. Thank you [adainrivers](https://github.com/adainrivers)


`1.4.5`

- Removed dependency GT.Rising.GameData by VRIsing.GameData and include it inside the dll

`1.4.3`

- Updated the GT.VRising.GameData framework to version 0.2.3

`1.4.2`

- Fixed bugs and improve performance with AutoAnnouncer Timer ( use solution from [RandomEncounters](https://github.com/adainrivers/randomencounters))
- Updated the VRising.GameData framework to version 0.2.2

`1.4.1`

- Fixed bugs and improve performance

`1.4.0`

- Added a system for automatic message of the day (MOTD) to go out to any player who connects to the server.
- Added a configuration file was added to be able to configure Message of the day as you want.
- Added chat command only for admins to enabled MOTD when user online `.notify motd enabled`
- Added chat command only for admins to disabled MOTD when user online `.notify motd disabled`
- Refactor folders of proyect

`1.3.0`

- Added automatic announce system every certain time defined in the configuration file
- Added a configuration file was added to be able to configure as many automatic messages as you want.
- Added chat command only for admins to enabled announce when user online `.notify announceonline enabled`
- Added chat command only for admins to disabled announce when user online `.notify announceonline disabled`
- Added chat command only for admins to enabled announce when user offline `.notify announceoffline enabled`
- Added chat command only for admins to disabled announce when user offline `.notify announceoffline disabled`
- Added chat command only for admins to enabled announce when new user connect to a server `.notify announcenewuser enabled`
- Added chat command only for admins to disabled announce when new user connect to a server `.notify announcenewuser disabled`
- Added chat command only for admins to enabled VBlood Announce `.notify vbloodannounce enabled`
- Added chat command only for admins to disabled VBlood Announce  `.notify vbloodannounce disabled`
- Added chat command only for admins to enabled auto announce `.notify autoannouncer enabled`
- Added chat command only for admins to disabled auto announce `.notify autoannouncer disabled`

`1.2.3`
- Fixed bug that affected the AnnounceVBlood mod configuration parameter not working correctly
- Fixed bug that affected the NewUserOnline mod configuration parameter not working correctly

`1.2.2`
- Fixed error when there was no configuration file, it gave an error when loading it

`1.2.1`
- Fixed bug where when you reload from chat, it didn't reload ignores from VBlood kills

`1.2.0`
- Added that users can enable/disable VBlood kills via chat command.
- Added command to ignore VBlood Announce `.notify ignore vbloodannounce`
- Added command to ignore VBlood Announce `.notify ignore vbloodannounce`
- Added command to unignore VBlood Announce `.notify unignore vbloodannounce`
- Added command to help `.notify help`
- Added VRising.GameData package from adainrivers

`1.1.0`
- Added command to refresh mod settings `.notify realod`

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

# Support this project

[![ko-fi](https://ko-fi.com/img/githubbutton_sm.svg)](https://ko-fi.com/K3K8ENRQY)

## Chat Commands

| COMMAND                                          |DESCRIPTION
|--------------------------------------------------|-------------------------------|
| `.help bn`                                   | Command that returns all available commands       
| `.bn online`                                   | Command that returns all user online - NEW -         
| `.bn reload` (Only Admins)                   | To reload the configuration of all config files. 
| `.bn config online true` (Only Admins)   | Enabled announceonline System. 
| `.bn config online false` (Only Admins)  | Disabled announceonline System. 
| `.bn config offline true` (Only Admins)  | Enabled announceoffline System. 
| `.bn config offline false` (Only Admins) | Disabled announceoffline System. 
| `.bn config newuser true` (Only Admins)  | Enabled announcenewuser System. 
| `.bn config newuser false` (Only Admins) |  Disabled announcenewuser System. 
| `.bn config vblood true` (Only Admins)   | Enabled vbloodannounce System. 
| `.bn config vblood false` (Only Admins)  | Disabled vbloodannounce System. 
| `.bn config auto true` (Only Admins)      | Start AutoAnnouncer System. 
| `.bn config auto false` (Only Admins)       | Stop AutoAnnouncer System. 
| `.bn config motd true` (Only Admins)               | Enabled Message of the day System. 
| `.bn config motd false` (Only Admins)                | Disabled Message of the day System. 
| `.bn vblood ignore`                  | Turn on VBlood death notifications 
| `.bn vblood unignore`                | Turn off VBlood death notifications 

# Configuration

Once the mod installed, a configuration file will be created in the \BepInEx\config server folder where you can activate or desactivate any of the mod notifications.

**BloodyNotify.cfg**

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

> To reload the configuration of the user messages online, offline or death of the VBlood boss there is the chat command `.bn reload`

## Default Messages

To configure the default messages in case you do not have personalized messages per player you only have to edit the configuration file that is in **/BepInEx/config/BloodyNotify/default_announce.json**
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

To configure the customize messages per player connected, you only have to edit the configuration file that is in **/BepInEx/config/BloodyNotify/users_online.json**

```json
{
   "CharacterName": "#user# The best player of server is online!",
   "OtherCharacterName": "The most wanted #user# is online!"
}
```
> The text string #user# is used to overwrite the name of the corresponding player(s)

To configure the customize messages per player disconnected, you only have to edit the configuration file that is in **/BepInEx/config/BloodyNotify/users_offline.json**

```json
{
   "CharacterName": "#user# The best player of server is offline!",
   "OtherCharacterName": "The most wanted #user# is offline!"
}
```
> The text string #user# is used to overwrite the name of the corresponding player(s)

## Translate VBlod boss name

To translate the name of VBlood boss, you only have to edit the configuration file that is in **/BepInEx/config/BloodyNotify/prefabs_names.json**
```json
{
  "CHAR_Cursed_Witch_VBlood": "Matka",
  "CHAR_Geomancer_Human_VBlood": "Terah",
  "CHAR_VHunter_Jade_VBlood": "Jade",
  "CHAR_Villager_Tailor_VBlood": "Beatrice",
  "CHAR_Undead_Priest_VBlood": "Nicholaus",
  "CHAR_Bandit_Tourok_VBlood": "Quincey (Quincy)",
  "CHAR_Spider_Queen_VBlood": "Ungora (Spider)",
  "CHAR_Winter_Yeti_VBlood": "Terrorclaw",
  "CHAR_Bandit_Chaosarrow_VBlood": "Lidia",
  "CHAR_Undead_BishopOfDeath_VBlood": "Goreswine",
  "CHAR_Militia_Leader_VBlood": "Octavian",
  "CHAR_Undead_BishopOfShadows_VBlood": "Leandra",
  "CHAR_Bandit_Foreman_VBlood": "Rufus",
  "CHAR_Bandit_Frostarrow_VBlood": "Keely",
  "CHAR_Forest_Bear_Dire_Vblood": "Kodia the Ferocious Bear",
  "CHAR_Militia_Nun_VBlood": "Christina",
  "CHAR_Bandit_Bomber_VBlood": "Clive",
  "CHAR_Cursed_MountainBeast_VBlood": "Gorecrusher the Behemoth",
  "CHAR_Undead_ZealousCultist_VBlood": "Foulrot",
  "CHAR_Poloma_VBlood": "Polora",
  "CHAR_BatVampire_VBlood": "Styx (Bat)",
  "CHAR_ArchMage_VBlood": "Mairwyn the Elementalist",
  "CHAR_Cursed_ToadKing_VBlood": "Albert The Duke of Balaton (Frog)",
  "CHAR_Manticore_VBlood": "Talzur The Winged Horror",
  "CHAR_Militia_Guard_VBlood": "Vincent",
  "CHAR_Militia_BishopOfDunley_VBlood": "Raziel",
  "CHAR_Harpy_Matriarch_VBlood": "Morian",
  "CHAR_ChurchOfLight_Paladin_VBlood": "Solarus",
  "CHAR_VHunter_Leader_VBlood": "Tristan",
  "CHAR_Bandit_StoneBreaker_VBlood": "Errol",
  "CHAR_ChurchOfLight_Cardinal_VBlood": "Azariel",
  "CHAR_WerewolfChieftain_Human": "Willfred (Wilfred)",
  "CHAR_Forest_Wolf_VBlood": "Alpha Wolf",
  "CHAR_Militia_Longbowman_LightArrow_Vblood": "Meredith",
  "CHAR_Vermin_DireRat_VBlood": "Nibbles the Putrid Rat",
  "CHAR_Wendigo_VBlood": "Frostmaw",
  "CHAR_Bandit_Stalker_VBlood": "Grayson",
  "CHAR_Gloomrot_Monster_VBlood": "Adam",
  "CHAR_Gloomrot_RailgunSergeant_VBlood": "Voltatia",
  "CHAR_Gloomrot_Iva_VBlood": "Ziva",
  "CHAR_Gloomrot_Purifier_VBlood": "Angram",
  "CHAR_Gloomrot_TheProfessor_VBlood": "Henry Blackbrew",
  "CHAR_Gloomrot_Voltage_VBlood": "Domina",
  "CHAR_Undead_CursedSmith_VBlood": "Cyril",
  "CHAR_Villager_CursedWanderer_VBlood": "Ben The Old Wanderer",
  "CHAR_ChurchOfLight_Sommelier_VBlood": "Baron du Bouchon",
  "CHAR_ChurchOfLight_Overseer_VBlood": "Sir Magnus the Overseer",
  "CHAR_Militia_Scribe_VBlood": "Maja",
  "CHAR_Undead_Infiltrator_VBlood": "Bane",
  "CHAR_Militia_Glassblower_VBlood": "Grethel the Glassblower",
  "CHAR_Undead_Leader_Vblood": "Kriig",
  "CHAR_Bandit_Fisherman_VBlood": "Finn",
  "CHAR_Vampire_IceRanger_VBlood": "Elena",
  "CHAR_Vampire_BloodKnight_VBlood": "Valencia",
  "CHAR_Vampire_HighLord_VBlood": "Cassius",
  "CHAR_Vampire_Dracula_VBlood": "Dracula",
  "CHAR_VHunter_CastleMan": "Simon Belmont",
  "CHAR_Militia_Fabian_VBlood": "Sir Erwin the Gallant Cavalier",
  "CHAR_Undead_ArenaChampion_VBlood": "Gaius The Cursed Champion",
  "CHAR_Blackfang_Livith_VBlood": "Jakira the Shadow Huntress",
  "CHAR_Blackfang_CarverBoss_VBlood": "Stavros the Carver",
  "CHAR_Blackfang_Lucie_VBlood": "Lucile the Venom Alchemist",
  "CHAR_Blackfang_Valyr_VBlood": "Dantos the Forgebinder",
  "CHAR_Blackfang_Morgana_VBlood": "Megara the Serpent Queen",
  "CHAR_Bandit_Chaosarrow_GateBoss_Minor": "Primal Lidia",
  "CHAR_Bandit_Foreman_VBlood_GateBoss_Minor": "Primal Rufus",
  "CHAR_Bandit_StoneBreaker_VBlood_GateBoss_Minor": "Primal Errol",
  "CHAR_Bandit_Tourok_GateBoss_Minor": "Primal Quincey",
  "CHAR_Frostarrow_GateBoss_Minor": "Primal Keely",
  "CHAR_Gloomrot_Purifier_VBlood_GateBoss_Major": "Primal Angram",
  "CHAR_Gloomrot_Voltage_VBlood_GateBoss_Major": "Primal Domina",
  "CHAR_Militia_Guard_VBlood_GateBoss_Minor": "Primal Vincent",
  "CHAR_Militia_Leader_VBlood_GateBoss_Major": "Primal Octavian",
  "CHAR_Poloma_VBlood_GateBoss_Minor": "Primal Poloma",
  "CHAR_Spider_Queen_VBlood_GateBoss_Major": "Primal Ungora",
  "CHAR_Undead_BishopOfDeath_VBlood_GateBoss_Minor": "Primal Goreswine",
  "CHAR_Undead_BishopOfShadows_VBlood_GateBoss_Major": "Primal Leandra",
  "CHAR_Undead_Infiltrator_VBlood_GateBoss_Major": "Primal Bane",
  "CHAR_Undead_Leader_Vblood_GateBoss_Minor": "Primal Kriig",
  "CHAR_Undead_ZealousCultist_VBlood_GateBoss_Major": "Primal Foulrot",
  "CHAR_VHunter_Jade_VBlood_GateBoss_Major": "Primal Jade",
  "CHAR_VHunter_Leader_GateBoss_Minor": "Primal Tristan",
  "CHAR_Villager_CursedWanderer_VBlood_GateBoss_Major": "Primal Ben",
  "CHAR_Wendigo_GateBoss_Major": "Primal Frostmaw",
  "CHAR_WerewolfChieftain_VBlood_GateBoss_Major": "Primal Willfred",
  "CHAR_Winter_Yeti_VBlood_GateBoss_Major": "Primal Terrorclaw",
  "NoPrefabName": "VBlood Boss"
}
```
## Ignore the notification of the death of a VBlood

To ignore the notification of the death of a VBlood, you only have to edit the configuration file that is in **/BepInEx/config/BloodyNotify/prefabs_names_ignore.json** and set the vblood prefab you want to true. 

For example, to disable "Putrid Rat" look in the configuration file for "CHAR_Vermin_DireRat_VBlood" and set it to true

```json
"CHAR_Vermin_DireRat_VBlood": true,
```

**/BepInEx/config/BloodyNotify/prefabs_names_ignore.json**
```json
{
  "CHAR_Cursed_Witch_VBlood": false,
  "CHAR_Geomancer_Human_VBlood": false,
  "CHAR_VHunter_Jade_VBlood": false,
  "CHAR_Villager_Tailor_VBlood": false,
  "CHAR_Undead_Priest_VBlood": false,
  "CHAR_Bandit_Tourok_VBlood": false,
  "CHAR_Spider_Queen_VBlood": false,
  "CHAR_Winter_Yeti_VBlood": false,
  "CHAR_Bandit_Chaosarrow_VBlood": false,
  "CHAR_Undead_BishopOfDeath_VBlood": false,
  "CHAR_Militia_Leader_VBlood": false,
  "CHAR_Undead_BishopOfShadows_VBlood": false,
  "CHAR_Bandit_Foreman_VBlood": false,
  "CHAR_Bandit_Frostarrow_VBlood": false,
  "CHAR_Forest_Bear_Dire_Vblood": false,
  "CHAR_Militia_Nun_VBlood": false,
  "CHAR_Bandit_Bomber_VBlood": false,
  "CHAR_Cursed_MountainBeast_VBlood": false,
  "CHAR_Undead_ZealousCultist_VBlood": false,
  "CHAR_Poloma_VBlood": false,
  "CHAR_BatVampire_VBlood": false,
  "CHAR_ArchMage_VBlood": false,
  "CHAR_Cursed_ToadKing_VBlood": false,
  "CHAR_Manticore_VBlood": false,
  "CHAR_Militia_Guard_VBlood": false,
  "CHAR_Militia_BishopOfDunley_VBlood": false,
  "CHAR_Harpy_Matriarch_VBlood": false,
  "CHAR_ChurchOfLight_Paladin_VBlood": false,
  "CHAR_VHunter_Leader_VBlood": false,
  "CHAR_Bandit_StoneBreaker_VBlood": false,
  "CHAR_ChurchOfLight_Cardinal_VBlood": false,
  "CHAR_WerewolfChieftain_Human": false,
  "CHAR_Forest_Wolf_VBlood": false,
  "CHAR_Militia_Longbowman_LightArrow_Vblood": false,
  "CHAR_Vermin_DireRat_VBlood": false,
  "CHAR_Wendigo_VBlood": false,
  "CHAR_Bandit_Stalker_VBlood": false,
  "CHAR_Gloomrot_Monster_VBlood": false,
  "CHAR_Gloomrot_RailgunSergeant_VBlood": false,
  "CHAR_Gloomrot_Iva_VBlood": false,
  "CHAR_Gloomrot_Purifier_VBlood": false,
  "CHAR_Gloomrot_TheProfessor_VBlood": false,
  "CHAR_Gloomrot_Voltage_VBlood": false,
  "CHAR_Undead_CursedSmith_VBlood": false,
  "CHAR_Villager_CursedWanderer_VBlood": false,
  "CHAR_ChurchOfLight_Sommelier_VBlood": false,
  "CHAR_ChurchOfLight_Overseer_VBlood": false,
  "CHAR_Militia_Scribe_VBlood": false,
  "CHAR_Undead_Infiltrator_VBlood": false,
  "CHAR_Militia_Glassblower_VBlood": false,
  "CHAR_Undead_Leader_Vblood": false,
  "CHAR_Bandit_Fisherman_VBlood": false,
  "CHAR_Vampire_IceRanger_VBlood": false,
  "CHAR_Vampire_BloodKnight_VBlood": false,
  "CHAR_Vampire_HighLord_VBlood": false,
  "CHAR_Vampire_Dracula_VBlood": false,
  "CHAR_VHunter_CastleMan": false,
  "CHAR_Militia_Fabian_VBlood": false,
  "CHAR_Undead_ArenaChampion_VBlood": false,
  "CHAR_Blackfang_Livith_VBlood": false,
  "CHAR_Blackfang_CarverBoss_VBlood": false,
  "CHAR_Blackfang_Lucie_VBlood": false,
  "CHAR_Blackfang_Valyr_VBlood": false,
  "CHAR_Blackfang_Morgana_VBlood": false,
  "CHAR_Bandit_Chaosarrow_GateBoss_Minor": false,
  "CHAR_Bandit_Foreman_VBlood_GateBoss_Minor": false,
  "CHAR_Bandit_StoneBreaker_VBlood_GateBoss_Minor": false,
  "CHAR_Bandit_Tourok_GateBoss_Minor": false,
  "CHAR_Frostarrow_GateBoss_Minor": false,
  "CHAR_Gloomrot_Purifier_VBlood_GateBoss_Major": false,
  "CHAR_Gloomrot_Voltage_VBlood_GateBoss_Major": false,
  "CHAR_Militia_Guard_VBlood_GateBoss_Minor": false,
  "CHAR_Militia_Leader_VBlood_GateBoss_Major": false,
  "CHAR_Poloma_VBlood_GateBoss_Minor": false,
  "CHAR_Spider_Queen_VBlood_GateBoss_Major": false,
  "CHAR_Undead_BishopOfDeath_VBlood_GateBoss_Minor": false,
  "CHAR_Undead_BishopOfShadows_VBlood_GateBoss_Major": false,
  "CHAR_Undead_Infiltrator_VBlood_GateBoss_Major": false,
  "CHAR_Undead_Leader_Vblood_GateBoss_Minor": false,
  "CHAR_Undead_ZealousCultist_VBlood_GateBoss_Major": false,
  "CHAR_VHunter_Jade_VBlood_GateBoss_Major": false,
  "CHAR_VHunter_Leader_GateBoss_Minor": false,
  "CHAR_Villager_CursedWanderer_VBlood_GateBoss_Major": false,
  "CHAR_Wendigo_GateBoss_Major": false,
  "CHAR_WerewolfChieftain_VBlood_GateBoss_Major": false,
  "CHAR_Winter_Yeti_VBlood_GateBoss_Major": false,
  "NoPrefabName": false
}
```
## Auto Announcer Messages - NEW

To configure the Auto Announce messages you must edit the configuration file that is in **/BepInEx/config/BloodyNotify/auto_announcer_messages.json**
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


## Message of the day ( MOTD )

To configure the Message of the day you must edit the configuration file that is in **/BepInEx/config/BloodyNotify/message_of_the_day.json**
```json
[
    "<color=#FFFFFF>Hello <i>#user#</i> this is Message of the day Line 1</color>", 
    "<color=#B22222>Message of the day Line 2</color>",
    "<color=#00FFFF>Message of the day Line 3</color>",
    "<color=#FFFFFF>Message of the day Line 4</color>"
]
```

> Each element of the array is a line that will paint the message system

> The text string #user# is used to overwrite the name of the corresponding player(s)


## VBlood Announce Ignore

If you want to do it by hand you just have to edit the **/BepInEx/config/BloodyNotify/vbloodannounce_ignore_users.json** file to add or remove players

```json
{
    "CharacterName":true
}
```
## Help

If you need assistance you can ask in the discord [V Rising Mod Community](https://discord.gg/vrisingmods)

## Credits

**Special thanks to the testers and supporters of the project:**

- @Vex, owner & founder of [Vexor RPG](https://discord.gg/JpVsKVvKNR) server, a tester and great supporter who provided his server as a test platform and took care of all the graphics and documentation.
- [Waker](https://github.com/WakerPT) For helping to solve bugs
- [V Rising Mod Community](https://discord.gg/vrisingmods) is the premier community of mods for V Rising.
- [@Deca](https://github.com/decaprime), thank you for the exceptional frameworks [VampireCommandFramework](https://github.com/decaprime/VampireCommandFramework) 

