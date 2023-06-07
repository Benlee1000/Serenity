using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Adds button functionality for the start menu
 * 
 */
public class MainMenuController : MonoBehaviour
{
    public void PlayGame()
    {
        Loader.Load(Loader.Scene.DialogueScreen);
    }

    public void QuitGame()
    {
        Debug.Log("QUIT GAME");
        Application.Quit();
    }
}
