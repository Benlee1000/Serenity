using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Loads start menu when exiting win screen
 */
public class WinScreenController : MonoBehaviour
{    
    public void GoToNextScreen()
    {
        Time.timeScale = 1f;
        Loader.Load((Loader.Scene)(Loader.GetCurrentScene() + 1));
    }
}
