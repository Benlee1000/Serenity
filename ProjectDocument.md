# Game Basic Information

## Summary

Serenity is a 2D top down rogue-like action RPG. You play as Sir Gideon, a disgraced knight that is imprisoned in the king's palace, awaiting his execution. When the palace is invaded by monsters, Sir Gideon escapes his cell in the chaos. You must fight your way out of the palace, defeating monsters and palace soldiers as you go. Defeating enemies will make you stronger, but if you die you pay the ultimate price and must restart from the beginning.

## Gameplay Explanation

**In this section, explain how the game should be played. Treat this as a manual within a game. It is encouraged to explain the button mappings and the most optimal gameplay strategy.**

**If you did work that should be factored in to your grade that does not fit easily into the proscribed roles, add it here! Please include links to resources and descriptions of game-related material that does not fit into roles here.**

### How to play:

Use WASD to move the player and Space allows the player to dash.
Use the mouse to aim and Left click to attack.

# Main Roles

Your goal is to relate the work of your role and sub-role in terms of the content of the course. Please look at the role sections below for specific instructions for each role.

Below is a template for you to highlight items of your work. These provide the evidence needed for your work to be evaluated. Try to have at least 4 such descriptions. They will be assessed on the quality of the underlying system and how they are linked to course content.

_Short Description_ - Long description of your work item that includes how it is relevant to topics discussed in class. [link to evidence in your repository](https://github.com/dr-jam/ECS189L/edit/project-description/ProjectDocumentTemplate.md)

Here is an example:  
_Procedural Terrain_ - The background of the game consists of procedurally-generated terrain that is produced with Perlin noise. This terrain can be modified by the game at run-time via a call to its script methods. The intent is to allow the player to modify the terrain. This system is based on the component design pattern and the procedural content generation portions of the course. [The PCG terrain generation script](https://github.com/dr-jam/CameraControlExercise/blob/513b927e87fc686fe627bf7d4ff6ff841cf34e9f/Obscura/Assets/Scripts/TerrainGenerator.cs#L6).

You should replay any **bold text** with your relevant information. Liberally use the template when necessary and appropriate.

## Producer

**Describe the steps you took in your role as producer. Typical items include group scheduling mechanism, links to meeting notes, descriptions of team logistics problems with their resolution, project organization tools (e.g., timelines, depedency/task tracking, Gantt charts, etc.), and repository management methodology.**

## User Interface
_sprites_ - Nearly all sprites for UI were taken from this free [asset pack](https://assetstore.unity.com/packages/2d/gui/rpg-fantasy-mobile-gui-with-source-files-166086).

_menus_ - I created the start menu, pause menu, and options menu. All of these menus have buttons which change sprites when clicking them for a more satisfying user experience. The start menu has a sunset background to set the scene for the game. It has a play button which initiates the opening dialogue screen. Additionally, it has an options button which opens an option menu. Underneath that is a quit button to exit the game. Finally is the help button which opens up a panel, teaching the user how to play. The pause menu has a resume, options, and quit button which returns you to the main menu. It also pauses the entire game by setting the time scale to 0 and creates a white semi-transparent background to indicate the game is paused. Lastly is the options menu. This menu has 2 sliders which are attached to music and sfx volume in our volume mixer so that the user's choices persist across scenes. The volume controller converts these slider values to fit into a log scale so that 1/2 of a volume slider actually represents 1/2 of loudness of that sound. It also has an accept button to go back to the previous menu.

_stats panel_ - I created a stats panel which holds the user's current stats. These stats are stored using PlayerPrefs so they can persist across scenes. The panel also has icons indicating the 3 stats - attack, defense, and speed. Finally, the stats panel has a health bar attached to the player's health.

_upgrade menu_ - I created the upgrade menu, which has an upgrade for attack, defense, or speed. Each of these values is set randomly (min and max were set carefully in gameplay testing). The text is overlayed on an arrow shape pointing to the button to unlock the upgrade to minimize confusion on where to click. The unlock buttons change when you hover over them and when you select them. After selecting the upgrade, it is added to your stats (both visually and in the player controller) and the next level is loaded.

_win and lose screen_ - These screens both have a colored background to indicate the state of the game, red for losing and green for winning. The lose screen is triggered by having 0 health and has an accept button to bring you back to the main menu. The win screen is triggered by beating every wave in the last level and has an accept button to progress the scene to the ending dialgoue scene.

_dialgoue scenes_ - There are two dialogue scenes, one at the start of the game before level 1 and one after the final level. Each has a corresponding background image, with the ending dialogue being bright and sunny to emphasize your win. Both have several scripts attached to allow for the narrative designer to easily input as many dialgoue sentences as desired along with a corresponding name for that dialogue. The dialgoue is shown one letter at a time to emulate speech. Additionally, it can be advanced through clicking anywhere on the screen. The dialgoue can be spam-clicked through in case someone just wants to quickly play the game. After the final line is displayed, the next scene is loaded or the main menu is loaded if we are on the closing dialgoue screen.

_door indicator_ - the door indicator is a semi-transparent spinning triangle that is displayed when all enemies are killed in the level. This minimizes player confusion on where to go once the level is complete. 



## Movement/Physics

**Describe the basics of movement and physics in your game. Is it the standard physics model? What did you change or modify? Did you make your movement scripts that do not use the physics system?**

## Animation and Visuals

**List your assets including their sources and licenses.**

**Describe how your work intersects with game feel, graphic design, and world-building. Include your visual style guide if one exists.**

_Animating Sprites and hitboxes_ - For the player character and enemies, we got assets through the Unity Store. For the enemies, I created animations using the sprite for their movement, when they take damage, when they are idle, and their death. I also added hitboxes so that we could register when the enemies collied with the player. For the player, the animations were already created, but I had to add box colliders to the idle, running, take damage, and death animation. The attack animation was only horizontal, so I created a particle effect that would go in the direction that they player attacked in, because the player can attack in any direction. (add permalinks and links to youtube tutorials)

_Animator and adding animations to scripts_ -

_Enemy healthbars_ -

_Source Credits_ -

## Input

**Describe the default input configuration.**

**Add an entry for each platform or input style your project supports.**

## Game Logic

General Game Logic:
For general game logic, the majority of my work was determining and implementing how the game should run. Most of this work was determing how scenes should be organized, when certain screens should show up, and implementing state transitions. Since a lot of the main roles intersected with the subroles, I moved past the Game logic role and helped out wherever was needed. This ended up being the form of working on level design and how enemies and players could interact with the world. 

For the state transitions, I first determined the possible states that the user could go through. After deciding which ones we needed, I worked on the actual implmentation of our transition system. I initially had an idea of using the state pattern. This would entail abstracting states and having each one do its own task. This turned out to be not as efficient as I thought it would be, and instead I turned to the Unity SceneManager. The SceneManager allowed me to switch through different scenes much easier than a self-implemented state pattern would and each scene could be easily abstracted for clarity. I created a static Loader class which contains an enum of the Scene names, the current scene, and a load function that would switch to a specific scene based on the given enum's toString() method. Wherever a state would need to be changed, like on player death, win, or exiting a room, the controller could just simply call the Loader and switch scenes to the next state.

In theory, coding state transitions seemed relatiely simple, however as the game got larger and more complex, putting all the moving pieces together became much more complicated and problems started popping up. Some issues that I ran into was determing the best way to implement my game logic scripts into the scene, fixing certain scene transitions, and making sure screens pop up when needed to and transitioning to the next scene. For the first issue, I needed a way to make sure that each scene could reflect the same game logic. I couldn't directly add a script to the scene, so I had to create an empty game object that had the game logic. The main menu, dialogue scene, and the combat rooms have their own controllers to reflect the state and make decisions as to how the game should progress. To fix the second issue, I was having some problems where certain transition conditions needed to be ironed out further. Certain transitions like when the player's health reached 0 or beat the game were easy to implement, however I had trouble with switching scenes after an upgrade screen. It turns out my conditional was incorrect and that I had to make sure the player crossed the door threshold before the upgrade screen could be presented. Finally, to fix the last issue, I had to determine when screens should pop up and make sure they would transition to the next scene. In order to do this, I had to create game objects that had their own controllers. After a button was pressed in their respective screens, the scene would call the Loader and then transition the scene.

# Sub-Roles

## Cross-Platform

**Describe the platforms you targeted for your game release. For each, describe the process and unique actions taken for each platform. What obstacles did you overcome? What was easier than expected?**

## Audio

**List your assets including their sources and licenses.**

**Describe the implementation of your audio system.**

**Document the sound style.**

## Gameplay Testing

**Add a link to the full results of your gameplay tests.**

**Summarize the key findings from your gameplay tests.**

## Narrative Design

**Document how the narrative is present in the game via assets, gameplay systems, and gameplay.**

## Press Kit and Trailer

**Include links to your presskit materials and trailer.**

**Describe how you showcased your work. How did you choose what to show in the trailer? Why did you choose your screenshots?**

## Game Feel

**Document what you added to and how you tweaked your game to improve its game feel.**
