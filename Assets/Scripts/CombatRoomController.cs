using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Functional state for regular combat room
 * 
 */
public class CombatRoomController : MonoBehaviour
{
    private PlayerUpgradeController controller;
    private Loader.Scene scene;
    
    // Player exited current room -> display upgrades.
    // Pass control to the player upgrade controller.
    public void DisplayUpgradeScreen()
    {
        controller.DisplayCards();
    }

    // Transitions scene after player picks an upgrade.
    public void Transition()
    {
        /*switch(scene)
        {
            case Loader.Scene.Level1:
                scene = Loader.Scene.Level2;
                Loader.Load(Loader.Scene.Level2);
            case Loader.Scene.Level2:
                scene = Loader.Scene.BossRoom;
                Loader.Load(Loader.Scene.BossRoom);
        }*/
    }
}
