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

## Ben Lee: User Interface

_sprites_ - Nearly all sprites for UI were taken from this free [asset pack](https://assetstore.unity.com/packages/2d/gui/rpg-fantasy-mobile-gui-with-source-files-166086). I made sure that the user interface kept a consistent look and feel to add to the user experience

_menus_ - I created the start menu, pause menu, and options menu. All of these menus have buttons which change sprites when clicking them for a more satisfying user experience. The start menu has a sunset background to set the scene for the game. It has a play button which initiates the opening dialogue screen. Additionally, it has an options button which opens an option menu. Underneath that is a quit button to exit the game. Finally is the help button which opens up a panel, teaching the user how to play. The pause menu has a resume, options, and quit button which returns you to the main menu. It also pauses the entire game by setting the time scale to 0 and creates a white semi-transparent background to indicate the game is paused. Lastly is the options menu. This menu has 2 sliders which are attached to music and sfx volume in our volume mixer so that the user's choices persist across scenes. The volume controller converts these slider values to fit into a log scale so that 1/2 of a volume slider actually represents 1/2 of loudness of that sound. It also has an accept button to go back to the previous menu.

_stats panel_ - I created a stats panel which holds the user's current stats. These stats are stored using PlayerPrefs so they can persist across scenes. The panel also has icons indicating the 3 stats - attack, defense, and speed. Finally, the stats panel has a health bar attached to the player's health.

_upgrade menu_ - I created the upgrade menu, which has an upgrade for attack, defense, or speed. Each of these values is set randomly (min and max were set carefully in gameplay testing). The text is overlayed on an arrow shape pointing to the button to unlock the upgrade to minimize confusion on where to click. Originally, the image behind the text looked like a button as well, leading to user confusion. Finally, the unlock buttons change when you hover over them and when you select them. After selecting the upgrade, it is added to your stats (both visually and in the player controller) and the next level is loaded.

_win and lose screen_ - These screens both have a colored background to indicate the state of the game, red for losing and green for winning. The lose screen is triggered by having 0 health and has an accept button to bring you back to the main menu. The win screen is triggered by beating every wave in the last level and has an accept button to progress the scene to the ending dialgoue scene.

_dialgoue scenes_ - There are two dialogue scenes, one at the start of the game before level 1 and one after the final level. Each has a corresponding background image, with the ending dialogue being bright and sunny to emphasize your win. Both have several scripts attached to allow for the narrative designer to easily input as many dialgoue sentences as desired along with a corresponding name for that dialogue. The dialgoue is shown one letter at a time to emulate speech. Additionally, it can be advanced through clicking anywhere on the screen. The dialgoue can be spam-clicked through in case someone just wants to quickly play the game. After the final line is displayed, the next scene is loaded or the main menu is loaded if we are on the closing dialgoue screen.

_door indicator_ - the door indicator is a semi-transparent spinning triangle that is displayed when all enemies are killed in the level. This minimizes player confusion on where to go once the level is complete.

## Ty Hewitt: Combat System and Enemies

Before I discuss the combat I want to explain that my main role was originally _Input_. However, as a team we felt that Input was heavily tied into the implementation of each gameplay system that required it. For example, the team member working on Movement would not create a movement system, then simply not implement the input leaving themselves no way of testing it. Therefore, my team elected to let me have the Combat and Enemies role, where I implemented a majority of the combat system. The systems I implemented/worked on are: Attack logic, Enemy Logic, Stats, and the Dash System.

While implementing each of these systems, I tried to keep usability and editability at the forefront so it is easy for balancing etc.

_Attack Logic_ -The basic attack for the player works like this: player left clicks the mouse and the character sends out an attack. What actually occurs is that when the player clicks, the gameobject is enabled and then quickly disabled. The gameobject released has a collider which tells the enemycontroller to take damage on impact. The attack is released depending on where the mouse is and not where the player is facing. Coming up with [the logic](https://github.com/Benlee1000/Serenity/blob/547207d73fb542a8ba5a86adbad72beb19096be7/Assets/Scripts/PlayerController.cs#L78) for figuring out where the mouse was and rotating the gameobject properly was the most difficult part of this system. The attack gameobject is tied to another gameobject (both children of the player) which is attached to the center of the player. When the mouse rotates, so does the center object, which rotates the attack. Within the script, I made the center object a [SerializeField](https://github.com/Benlee1000/Serenity/blob/547207d73fb542a8ba5a86adbad72beb19096be7/Assets/Scripts/PlayerController.cs#L18) so it's easy to swap if we wanted to change the attack. Ro later used this logic to add his gameobject that had animations. Lastly, in the PlayerController script, we check for GetButtonDown to make sure the player cannot hold the button for an infinite attack.

_Enemy Logic:_

- _Enemy Behavior_ -The movement system for enemies is extremely simple. The enemy just moves [towards the player](https://github.com/Benlee1000/Serenity/blob/547207d73fb542a8ba5a86adbad72beb19096be7/Assets/Scripts/EnemyController.cs#L36). If I had more time to work on this game, I would have loved to implement a pathfinding system for the enemies. Currently, all the enemies can get stuck on walls and they are very easy to manipulate for the player.

- _Enemy Attacking/Taking damage_ -Enemies have a [collision detector](https://github.com/Benlee1000/Serenity/blob/547207d73fb542a8ba5a86adbad72beb19096be7/Assets/Scripts/EnemyController.cs#L66) which checks to see what is touching the enemy. If it's the player, the player takes damage. If it's the attack gameobject, the enemy takes damage. As a design choice for additional difficulty, our team decided to not include knockback, and focus more on a kiting gameplay loop for facing enemies. As a result, it was very possible that enemies may be on top of the player for periods of time, and to make sure that it's fair and not frustrating for the player, we added a 1 second timer between each damage tick for the player.

- _Enemy Wave System_ -Every level has an EnemyManager which spawns in enemies based on a wave system. Each level has a randomized amount of waves, and a randomized amount of enemies per wave. Although I say it's randomized, the developer has the freedom of selecting the min and max for waves and enemies. Furthermore, I implemented the system so that it is easy to add and remove the types of enemies you want to spawn. The EnemySpawner script takes in a serialized list of enemy prefabs, which are then used to [randomly generate enemies within the list](https://github.com/Benlee1000/Serenity/blob/547207d73fb542a8ba5a86adbad72beb19096be7/Assets/Scripts/EnemySpawner.cs#L72). Lastly, the next wave spawns after every enemy of the previous one is defeated. The way we keep track of that is by having a static instance of the EnemySpawner, and decreasing a "numberOfenemies" counter each time the die method is called for an enemy.

- _Enemy Spawn System_ -Every level has certain spawn points that can be easily added and removed. The EnemySpawner script has a serialized list of gameobjects, which the script randomly selects to use for spawn locations of the enemies. Every gameobject that is used as a spawnpoint is a child of the EnemyManager object for organization. Furthermore, I implemented the spawner in a way so that [enemies cannot spawn on the spawner closest to the player](https://github.com/Benlee1000/Serenity/blob/547207d73fb542a8ba5a86adbad72beb19096be7/Assets/Scripts/EnemySpawner.cs#L51) Lastly, I added small red particles that appear when enemies spawn to bring more life to the game.

_Stats_ -Both the player and enemies have four basic stats: HP, Attack, Defense, and Speed. HP represents hitpoints, if it becomes less than or equal to zero you die. Enemies have their gameobject destroyed, while the player gets a defeat screen. Attack represents the amount of damage you do. If Defense was not accounted for, five attack means five damage is dealt to HP. Defense is based off flat damage reduction. However, Ben refined the calculation to have a [minimum damage dealt](https://github.com/Benlee1000/Serenity/blob/547207d73fb542a8ba5a86adbad72beb19096be7/Assets/Scripts/EnemyController.cs#L72) to prevent the stat from being too overpowered. Lastly, speed represents movementspeed. For enemies, all of these stats are serialized fields so it's easy to edit them for game balance.

_Dash System_ -The dash system was inspired by [this video](https://www.youtube.com/watch?v=VWaiU7W5HdE). I essentially implemented the same dash as this video, with very minor tweaks. When the player presses down on the space bar, the player dashes in the movement they are currently moving in. There is a dash duration, speed, and cooldown all of which are serialized fields. The parts I personally added in was disabling the playerCollider while dashing so that the player can dash through enemies, and dashSlosh which represents the amount of IFrames the player gets. The dash method can be found [here](https://github.com/Benlee1000/Serenity/blob/547207d73fb542a8ba5a86adbad72beb19096be7/Assets/Scripts/PlayerController.cs#L168) in the PlayerController.

## Movement/Physics

**Describe the basics of movement and physics in your game. Is it the standard physics model? What did you change or modify? Did you make your movement scripts that do not use the physics system?**

## Animation and Visuals - Rohith Saravana

**List your assets including their sources and licenses.**

**Describe how your work intersects with game feel, graphic design, and world-building. Include your visual style guide if one exists.**

The game is of the fantasy genre, so we wanted art that matched that. Also we wanted sprites and assets that matched the ominous, dark tone of the game.

_Animating Sprites and hitboxes_ - For the player character and enemies, we got assets through the Unity Store. For the enemies, I created animations using the sprite for their movement, when they take damage, spawn, when they are idle, and their death. I also added hitboxes so that we could register when the enemies collied with the player. For the player, the animations were already created, but I had to add box colliders to the idle, running, take damage, and death animation. The attack animation was only horizontal, so I created a particle effect that would go in the direction that they player attacked in, because the player can attack in any direction. The player and enemies were all made into prefabs which would make it easy to create multiple levels with the same enemies. I also adjusted the size of the enemies to match their power. An increase in size is generally correlated with more strength, but slower while less size usually means less power, but more speed. The sizes of the enemy help to communicate what "type" they are (the small goblins are weak but move fast, while the Knight are easy to avoid but if they hit you they do a lot of damage). (add permalinks and links to youtube tutorials)

_Animator and adding animations to scripts_ - For the player character and the enemy sprites, I used the animator within Unity to create transitions between the animations. Sprites would initially be in an idle animation state and would transition to different animations based on what happens in the game. To trigger these animations, I created Animator objects within the controller and movement scripts of the player and enemies. These animator objects would be linked to the appropriate prefab in each script. Within the animator, I also had to adjust the transition times between animations to make sure that the transitions were smooth and not jittery.

_Enemy healthbars_ - For the enemies, I created healthbars using the slider UI in Unity. Within the enemy controller script if the enemy got attacked by the player, I adjusted the healthbar value to match the HP of the enemy. Healthbars give the player an idea of how close an enemy is to dying and also gives them a feel for how poweful their character is. In the beginning, each attack only takes off a small fraction of an enemy's healthbar. But, if you upgrade your attack, you can see how much more damage you deal with a single attack.

_Asset Credits_ -

## Ahram Ham : Game Logic

General Game Logic:
For general game logic, the majority of my work was determining and implementing how the game should run. Most of this work was determing how scenes should be organized, when certain screens should show up, and implementing state transitions. Since a lot of the main roles intersected with the subroles, I moved past the Game logic role and helped out wherever was needed. This ended up being the form of working on level design and how enemies and players could interact with the world.

State transitions:
For the state transitions, I first determined the possible states that the user could go through. After deciding which ones we needed, I worked on the actual implmentation of our transition system. I initially had an idea of using the state pattern. This would entail abstracting states and having each one do its own task. This turned out to be not as efficient as I thought it would be, and instead I turned to the Unity SceneManager. The SceneManager allowed me to switch through different scenes much easier than a self-implemented state pattern would and each scene could be easily abstracted for clarity. I created a static Loader class which contains an [enum](https://github.com/Benlee1000/Serenity/blob/41572f6091157fa2d15560ae37db370111e3ec03/Assets/Scripts/Loader.cs#L11) of the Scene names, the [current scene](https://github.com/Benlee1000/Serenity/blob/41572f6091157fa2d15560ae37db370111e3ec03/Assets/Scripts/Loader.cs#L8), and a [load function](https://github.com/Benlee1000/Serenity/blob/41572f6091157fa2d15560ae37db370111e3ec03/Assets/Scripts/Loader.cs#L24) that would switch to a specific scene based on the given enum's toString() method. Wherever a state would need to be changed, like on player death, win, or exiting a room, the controller could just simply call the Loader and switch scenes to the next state.

Level Redesign and Enemy/Player Interactions:
Besides the state transitions, I worked on creating levels that fit in with the game narrative and that were also functional. This involved using the tile editor to put individual sprites on a sprite sheet. Initially to get a viewable level, my group and I put random sprites on different layers. This proved to be problematic when it came time to add wall collisions, so I had to overall the old system and abstract each layer separately. I created a ground, obstacle, and floor decor layer. The ground layer obviously holds tiles that were supposed to show the ground, the obstacles were any tiles that I wanted to have colliders for, and the floor decor sprites sat on top of the ground tiles. Each level had a different layout, but once the abstractions were clear, it became much easier to create new levels, since you could build off previous levels and just change the layout.

Once the levels were complete and I did some testing. I found that the enemies and players could move through walls. At first, I thought I could create empty game objects with rigid body components and colliders to block characters from moving through the world, but this didn’t work. After doing some research, I found this [YouTube video](https://www.youtube.com/watch?v=eDOxDJEtE14) and discovered the 2d tile collider which solved my issue. The enemies still could move through the walls however but a simple fix of changing their rigid body, body type to dynamic fixed the issue.

![image](https://github.com/Benlee1000/Serenity/blob/a00862c8de3944fb366ea835154a15ad6d2eaf2c/Docs/Images/Rigidbody.png)

Resolved Issues:
In theory, coding state transitions seemed relatiely simple, however as the game got larger and more complex, putting all the moving pieces together became much more complicated and problems started popping up. Some issues that I ran into was determing the best way to implement my game logic scripts into the scene, fixing certain scene transitions, and making sure screens pop up when needed to and transitioning to the next scene. For the first issue, I needed a way to make sure that each scene could reflect the same game logic. I couldn't directly add a script to the scene, so I had to create an empty game object that had the game logic. The main menu, dialogue scene, and the combat rooms have their own controllers to reflect the state and make decisions as to how the game should progress. To fix the second issue, I was having some problems where certain transition conditions needed to be ironed out further. Certain transitions like when the player's [health reached 0](https://github.com/Benlee1000/Serenity/blob/70b9983425abed70cd225d02e376f5671b510820/Assets/Scripts/CombatRoomController.cs#L41) or [beat the game](https://github.com/Benlee1000/Serenity/blob/70b9983425abed70cd225d02e376f5671b510820/Assets/Scripts/CombatRoomController.cs#L68) were easy to implement, however I had trouble with switching scenes after an upgrade screen. It turns out my conditional was incorrect and that I had to make sure the [player crossed the door threshold before the upgrade screen could be presented](https://github.com/Benlee1000/Serenity/blob/70b9983425abed70cd225d02e376f5671b510820/Assets/Scripts/CombatRoomController.cs#L56). Finally, to fix the last issue, I had to determine when screens should pop up and make sure they would transition to the next scene. In order to do this, I had to create game objects that had their own controllers. After a button was pressed in their respective screens, the scene would call the Loader and then transition the scene.

# Sub-Roles

## Cross-Platform

**Describe the platforms you targeted for your game release. For each, describe the process and unique actions taken for each platform. What obstacles did you overcome? What was easier than expected?**

## Audio

**List your assets including their sources and licenses.**

**Describe the implementation of your audio system.**

**Document the sound style.**

## Ahram Ham : Gameplay Testing

**Add a link to the full results of your gameplay tests.**
[The full results of playtesting can be found here](https://docs.google.com/document/d/1itomTK0TprLcbF0yv7M-vQmB3NAFYdXZ213846b0qp8/edit?usp=sharing)

**Summarize the key findings from your gameplay tests.**
I didn’t have time to interview 10 people to test out the game, however during the game demo, I was able to get a hold of someone to play test and give me feedback of our game. After explaining the basic movement and controls, I let the player go free in playing the game without interrupting. After they finished the game, I asked them a couple of questions in the [game testing pdf](https://docs.google.com/document/d/1itomTK0TprLcbF0yv7M-vQmB3NAFYdXZ213846b0qp8/edit?usp=sharing). The main takeaways were that the gameplay felt good however they wished for a couple of changes. The main one being that there should be an instructional screen to show how to play the game. The game wasn’t complete at this point, as there were only 4 levels and the last couple of levels were bugged but it was still good feedback.

After fixing a lot of the changes and we finalized the game, I had my roommate play test the game and give some feedback. I followed the same process as the first interviewee and let him play the game. After his play through, he gave me some feedback and I noted his observations down in the [game testing pdf](https://docs.google.com/document/d/1itomTK0TprLcbF0yv7M-vQmB3NAFYdXZ213846b0qp8/edit?usp=sharing). His takeaways were that the game felt really polished and complete however he wished that there was a climactic boss fight after beating so many minions. The levels got kinda old fast because they were all the same concept, however he understands that given the time constraint that we didn’t have time.

## Ty Hewitt: Narrative Design

I had originally been very confident that I could weave in the narrative into the game, but throughout the process of creating the game I realized just how restricting be limited to free assets was, as well as having a team of individuals with no art experience. My team gave me essentially full creative freedom for the narrative of the story, and the premise goes like this: Sir Gideon is being executed for treason, and through a stroke of luck finds the royal palace where he is held being under attack by monsters. Through the chaos, he attempts to escape and find peace and happiness. Here are all the aspects of the game where narrative influenced the decision making.

-The enemies consist of Goblins, Skeletons, and Knights. Sir Gideon serves as a third party character that doesn't align with the royal knights nor the monsters. Therefore, I wanted the enemy types to reflect that. It was difficult to find the correct assets, but I wanted us to have atleast 1 monster and 1 royal knight type enemy for the sake of the narrative.

-We chose a tileset that could represent the atmosphere of an underground, somewhat decrepit area as best we could. I designed levels 1,2,3,4 and 6, while overseeing level 5. The walls and black space serve to make the player feel enclosed, and underground. In order to progress, the player must walk upstairs to help make the player feel like they are travelling up and out of the royal palace. Furthermore, the grass decorations serve two purposes. To further enhance a fantastical feel with flora growing underground, and to make the place seem unkept and out of shape. Lastly, there are skulls scattered all across the levels to help give the player a sense of danger, to hopefully make them think "If I don't escape, Sir Gideon will end up like these skeletons."

-I wrote the beginning and end dialogue. With very little context and story, I found it rather difficult to choose a concicse manner of depicting Sir Gideon's thoughts and the situation around him. I focused more on his feelings to give a little look into his mind.

-Sir Gideon starts off as a rather slow character for two reasons. One was for balancing reasons and as an incentive for the player to choose speed as opposed to attack when upgrading. The second was to give a bit of realism to the character. Sir Gideon is a knight captain who has served many years under the empire, and is growing old. His body doesn't move the way it used to, and I wanted the beginning to reflect that (although you can increase his speed to very high levels through the upgrade system).

**Document how the narrative is present in the game via assets, gameplay systems, and gameplay.**

## Press Kit and Trailer - Rohith Saravana

**Include links to your presskit materials and trailer.**

**Describe how you showcased your work. How did you choose what to show in the trailer? Why did you choose your screenshots?**

_Trailer_ -

_Screenshots_ -

## Ben Lee: Game Feel

_gameplay suggestions_ - I provided suggestions to group members managing movement, input, states, map design, sounds, music, game logic, and animation in order to make the game feel fun and effortless to play. I also made suggestions to limit bugs and exploits in the game.

_game balancing_ - I tested out the game as a whole and changed many underlying systems to give players a fair and rewarding challenge that ramped up in difficulty as you progressed in the levels. This took many hours of playing through the game and having others test out which balance changes made the game too hard, too easy, or just the right amount of difficulty. I added a special formula to the random number generator for attack, defense, and speed upgrades that scales with the current level the player is on. These formulas make it so each stat upgrade is desirable. They each offer their own competitive advantage: attack makes it so you break through armor easier and kill enemies in less hits, armor makes it so that taking hits from enemies is less punishing, speed makes it easier to "kite" enemies and handle larger waves of enemies by running around them. Finally, I adjusted how defense works with player's and enemies' health so that each hit must deal a minimum amount of damage. This makes it so that full-on tanking hits by just having high defense is greatly reduced.

_enemy balance_ - I changed all enemy prefab stats to reflect their design, giving each strengths and weaknesses. Goblins move fast, but have little damage and health, with no armor. Skeletons start off moving the same speed as the player and have average health and attack, but have low armor. Knights have incredible damage, high health, and high armor, but significantly lack in the movement department. Additionally, I modified each level to have a custom range of waves, enemies, and also enemy types. The first 3 levels introduce you to a new enemy type on each level. The last 3 levels ramp up the number of waves significantly, with the last level requiring you to utilize your upgrades, knowledge of enemy types, and obstacles in order to emerge victorious.
