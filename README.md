# PermanentEvasion
BattleTech mod (using BTML) that, let's mech keep their evasion pips when beeing fired at.

## Requirements
** Warning: Uses the experimental BTML mod loader that might change, come here again to check for updates **

* install [BattleTechModLoader](https://github.com/Mpstark/BattleTechModLoader/releases) using the [instructions here](https://github.com/Mpstark/BattleTechModLoader)
* install [ModTek](https://github.com/Mpstark/ModTek/releases) using the [instructions here](https://github.com/Mpstark/ModTek)

## Features
- Mechs that get fired at will not lose one pip of evasion.
- Makes light mechs more balanced.

## Settings
Setting | Type | Default | Description
--- | --- | --- | ---
LightLosePip | bool | default false| set this to true if you want light mechs to behave like in the vanilla game.
MediumLosePip | bool | default false| set this to true if you want medium mechs to behave like in the vanilla game.
HeavyLosePip | bool | default false| set this to true if you want heavy mechs to behave like in the vanilla game.
AssaultLosePip | bool | default false| set this to true if you want assault mechs to behave like in the vanilla game.
OnlyAcePilot | bool | default false| set this to true if you want only ace pilots to not lose pips.

OnlyAcePilot is combined with the other options so if every other option is false, acepilot is useless because no mech loses pips anyway. Ace Pilot will only affect anything if atleast one type is set to true.

## Download
Downloads can be found on [github](https://github.com/Morphyum/PermanentEvasion/releases).
    
## Install
- After installing BTML, put  everything into \BATTLETECH\Mods\ folder.
- If you want to change the settings do so in the settings.json
- Start the game.
