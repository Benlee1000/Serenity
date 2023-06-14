using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Loads start screen on defeat
 */
public class DefeatScreenController : MonoBehaviour
{    
    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        Loader.Load(Loader.Scene.StartScreen);
    }
}
