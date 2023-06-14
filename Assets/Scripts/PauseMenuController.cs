using UnityEngine;

/*
 * Manages the pause menu UI panel
 * Freezes the game on pause
 */
public class PauseMenuController : MonoBehaviour
{
    // Learned how to do a PauseMenu from https://www.youtube.com/watch?v=9dYDBomQpBQ
    [SerializeField] GameObject pauseMenu;
    public bool isPaused;

    public void PauseGame()
    {
        pauseMenu.SetActive(true);

        // Freeze the game and set variable to true
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);

        // Un-freeze the game and set variable to true
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        Loader.Load(Loader.Scene.StartScreen);
    }

}
