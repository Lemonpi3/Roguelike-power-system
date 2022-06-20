<h1>Roguelike-power-system</h1>
Generic roguelike powers system for 2D games but can be easily adapted to 3D that has lots of customization to create limitless powers using scriptable objects. Includes a small minigame demo.

# Structure

## Powers:
I divided the powers into 4 categories:

###  Proyectile based:
Shoots proyectiles from the player into a target direction as default. The proyectile class can be modified further if necesary.
###  Static AoE(or Constant):
An area that deals damage which position its static, relative to player position and will move with the player.
###  Orbit powers:
Areas or GameObjects that orbit around the player in a circunference.The relative position between each object its automaticaly calculated with the number of objects; 
orbit speed and orbit distance from player can be calculated.
### Temporal and Permanent Power categories:
A buff that affects the players and/or enemies stats or the enviroment. (requieres a stat system)

## How to set it up:
Just Drag the PowerSystem prefab into the scene and fill it as so:
 
<img src= "/Assets/Misc/PowerSystemPrefabPic.jpg">

### Powers Adquired Container:
Its in charge of the UI part of the system.
* Slot Prefab:
   Its the prefab gives the visual feedback to the player to track which powers they have.
   Must be filled with PowerSlot prefab.
* Selection Slots:
  This are the UI Buttons where the player gets to choose the powers, you can find them in the UIPowerSelectionSlot prefab.
* Power Window:
  This its the parent object to the power selection slots.
* Number of priority slots: the amount of slots that will be dedicated to previusly adquired powers (so the player has a high chance to rank them up).

### Power Randomizer:
Picks the Powers from All Powers , the Max duplicate Rerolls its there to prevent an infinite loop in the selection (stops it from looping infinetly if there are duplicates in the power selection window).

# Progress:

### UI:
* Power Selection :heavy_check_mark:
* Adquired Powers display  :heavy_check_mark:
* XP Bar :heavy_check_mark:
* HP Bar :heavy_check_mark:

### Power System:
* Base Power class :heavy_check_mark:
* Base Powers Data classes :heavy_check_mark:
* Proyectile Power Class :heavy_check_mark:
* Static AoE(or Constant) Power Class :heavy_check_mark:
* Orbit Power Class :heavy_check_mark:
* Permanent/Temporal Buff Power Class :heavy_check_mark:
* Smart Power Randomizer for Power Selection :heavy_check_mark:
* Leveling up system :heavy_check_mark:

## Demo
### Charecters:
* Progressive enemy spawner (changes what and how much to spawn overtime) :heavy_check_mark: (still has some small bugs with the spawn cap)
* Some basic enemies :heavy_check_mark:
* Player Class :heavy_check_mark:

# To Do:
The system its finished. I might refactor and clean the code in the future.
