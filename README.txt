# Slash-Out!! by Aaron Oates, Sam Martino, and Logan Janes


All files in this submission file are to be used in Unity Scenes for a game.

The game is a 3D hack-and-slash game where players and enemies can swipe their sword in one of eight directions while also being able to block, move around, and pause the game.
Each character model has a hurt box which, when it detects a collision with a sword's hitbox, will decrease their health bar. Whoever's health bar reaches zero first loses, and the game will display either a defeat or victory screen, and the game ends.
//Instructions for using DirectionalSlashes.cs//

Step1: Create a Unity Project, a 3D game object to represent the player character and a 3D object to represent the sword. The sword should have a hilt object that is a child of the sword to swing around.
(or import them from a 3D design software such as blender like we did.)
Step2: Create a new Script component for the Sword object in the Unity Editor, and assign the character object to the character field, and the hilt object to the centerObject field.
Step3: Adjust the default rotation quaternion in the editor to make it so that the sword is in a neutral orientation. This is the rotation that the sword will be assigned to before and after each swing.
Step4: Adjust the rotation speed to whatever you see fit, for our game we set it to 300, which resulted in a very quick swipe that was still visually noticable.
Step5: Test each of the directional slashes using the keys listed below.
w = up 
a = left
s = down
d = right
q = diagonally up and left
e = diagonally up and right
x = diagonally down and left
c = diagonally down and right

Step6: If necessary, adjust the offsets for each slash if the sword does not swipe from the correct position. During the debugging process, we noticed that sometimes the sword would randomly appear 20 units away from the swingstart position in the x direction for example, so adjusting the offset field to be -20x for that direction provided a simple solution.

//Instructions for using enemyScript.cs //

Step1: Create a Unity Project, a 3D game object to represent the enemy character and a 3D object to represent the sword. The sword should have a hilt object that is a child of the sword to swing around.
(or import them from a 3D design software such as blender like we did.)
Step2: Create a new Script component for the sword object in the Unity Editor, and assign the sword hilt object to the centerObject field.
Step3: Adjust the default rotation quaternion in the editor to make it so that the sword is in a neutral orientation. This is the rotation that the sword will be assigned to before and after each swing.
Step4: Adjust the rotation speed to whatever you see fit, for our game we set it to 300, which resulted in a very quick swipe that was still visually noticable.
Step5: If necessary, adjust the offsets for each slash if the sword does not swipe from the correct position. During the debugging process, we noticed that sometimes the sword would randomly appear 20 units away from the swingstart position in the x direction for example, so adjusting the offset field to be -20x for that direction provided a simple solution.

-Hitbox: This script is intended to serve as a hitbox for the player’s sword. You can attach it to the player and enemy swords along with the unity tool “Collision Box '' in order for the code to register when the sword collides with the enemy. During a collision it will call to the hurtbox script to tell the enemy’s current health and will send the damage data to the healthbar script. Damage sent to the health bar will be halved if the blocking boolean is true.

-Hurtbox: This script is intended to be a hurtbox for the player model. You can attach this script to the player models along with the rigid body unity tool. When a sword collides with the player model, it will give the hitbox the character’s health and confirm that the hitbox collided with a character.


-Health-Bar: This script is intended to manage the player and enemy health bars and reduce the health bar when damage is taken. This script should be attached to a canvas unity with a slider for reducing health. When this script receives damage data from other scripts, it will reduce the slider value for the required health bar and update the character’s health value to match the new slider value. If the health bar is depleted, it will send a boolean value to the victory or defeat screen scripts.

-Victory: This script is intended to create a victory screen when the enemy health bar is depleted. You can attach this script to a victory screen canvas in unity. When the enemy health bar is depleted, a true boolean will be sent from the health bar script to this script. When this occurs, the script will disable the health bar and pause menu UI elements and activate the victory screen image to display. There will be buttons for going to the main menu or continuing to the next fight that will transition to the main menu and next fight scenes. 

-Defeat: This script is intended to create a defeat screen when the player health bar is depleted. You can attach this script to a defeat screen canvas in unity. When the player health bar is depleted, a true boolean will be sent from the health bar script to this script. When this occurs, the script will disable the health bar and pause menu UI elements and activate the defeat screen image to display. There will be buttons for restarting the battle or returning to the main menu that will reset the scene or transition to the main menu scene.

-Projectile: This script is intended to move a projectile in the game. You can attach this script to a projectile 3D element in unity. This script will let the user choose a movement speed and direction for the projectile to move in.

-Bullet Hitbox: This script is intended to act as a hitbox for the projectile. This script acts identical to the Hitbox script however, after a specified time or upon contact with the player, the projectile will be destroyed.

-Projectile Launcher: This script is intended to act as a way to clone projectiles to make continuous projectiles. With a specified firing rate, the projectile prefab will create a new projectile at the prefab’s location and move according to the projectile script and hit objects according to the hitbox bullet script.

-SceneLoader : This script is intended to create a loading scene between scene transitions to allow the game to load. You can attach this script to a loading screen image in the first scene of the project. You can specify which scene to transition to and attach the function to a button using the “onclick” unity component. The script will then deactivate various UI elements to show the loading screen while transitioning to the next scene and allowing it to load.

-Player Movement: This script is intended to allow the player to move within the game. You can attach this script to the player model along with the character controller unity tool. You can specify the direction for the player to move and allow the player model to move freely in the 3D environment.

-Make Green: This script is intended to make an object’s material green. You can attach this script to any object you would like to make green. This script will set the object’s material to the specified colour of green.

-Make Red: This script is intended to make an object’s material red. You can attach this script to any object you would like to make red. This script will set the object’s material to the specified colour of red.

-Make Black: This script is intended to make an object’s material black. You can attach this script to any object you would like to make black. This script will set the object’s material to the specified colour of black.

-Main Menu: This script enables the functionality of buttons present on the main menu, allowing transition from one scene to another. For example, clicking the “Bout Select -> Easy” button sequence will take you to the first fight.

-Pause Menu: This script enables the function of a pause menu that is displayed when the “Z” key is pressed. Similar to the main menu, the pause menu script allows for the functionality of buttons to resume gameplay, restart gameplay, and return to the main menu.

-AudioManager: This script manages audio and its functionality within the code, including methods such as playing sound bytes, defining sound samples into a mutable array, and allowing them to be adjusted in the Unity Inspector.

-Sounds: This script defines the characteristics of sounds and their properties, such as pitch, volume, name and ability to be looped.
for any questions, comments, or concerns, feel free to contact us at:
Aaron Oates: ajoates@mun.ca
Sam Martino: sbmartino@mun.ca
Logan Janes: lmjanes@mun.ca