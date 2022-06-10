<h2>Roguelike-power-system</h2>
Generic roguelike powers system for 2D games but can be easily adapted to 3D that has lots of customization to create limitless powers using scriptable objects.

## Structure

I divided the powers into 5 categories:

###  Proyectile based:
Shoots proyectiles from the player into a target direction as default. The proyectile class can be modified further if necesary.
###  Static AoE(or Constant):
An area that deals damage which position its static, relative to player position and will move with the player.
###  Orbit powers:
Areas or GameObjects that orbit around the player in a circunference.The relative position between each object its automaticaly calculated with the number of objects; 
orbit speed and orbit distance from player can be calculated.
### Temporal and Permanent Power categories:
A buff that affects the players and/or enemies stats or the enviroment. Might be merged into a unique category in the future

## Progress:

### UI:
* Power Selection :heavy_check_mark:
* Adquired Powers display :construction: (mostly finished)

### Power System
* Base Power class :heavy_check_mark:
* Base Powers Data classes :heavy_check_mark:
* Proyectile Power Class :heavy_check_mark:
* Static AoE(or Constant) Power Class :heavy_check_mark:
* Orbit Power Class :heavy_check_mark:
* Permanent/Temporal Buff Power Class :heavy_check_mark:
* Smart Power Randomizer for Power Selection :construction:
* Leveling up system :construction:

### Charecters
* Progressive enemy spawner (changes what and how much to spawn overtime) :heavy_check_mark: (still has some small bugs with the spawn cap)
* Some basic enemies :construction:
* Mini Bosses - Bosses :construction:
* Player Class :construction:
