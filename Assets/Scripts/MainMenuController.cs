using UnityEngine;

/*
 * Adds button functionality for the start menu
 */
public class MainMenuController : MonoBehaviour
{
    public void PlayGame()
    {
        Time.timeScale = 1f;
        Loader.Load(Loader.Scene.DialogueScreen);
    }

    public void QuitGame()
    {
        Debug.Log("QUIT GAME");
        Application.Quit();
    }
}
