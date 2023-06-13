using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScreenController : MonoBehaviour
{    
    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        Loader.Load(Loader.Scene.StartScreen);
    }
}
