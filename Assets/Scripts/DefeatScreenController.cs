using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefeatScreenController : MonoBehaviour
{    
    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        Loader.Load(Loader.Scene.StartScreen);
    }
}
