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
    Loader.Scene scene;
    
    // Player exited current room -> display upgrades
    public void DisplayUpgradeScreen()
    {
        //Loader.Load(Loader.Scene.DialogueScreen);
        Transition();
    }

    // Transitions scene after player picks an upgrade;
    public void Transition()
    {
        /*switch(scene)
        {
            case Loader.Scene.MainGame:
                scene = Loader.Scene.Level2;
                Loader.Load(Loader.Scene.Level2);
        }*/
    }
}
