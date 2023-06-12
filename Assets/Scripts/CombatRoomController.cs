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
    [SerializeField] private GameObject pauseMenuObject;
    [SerializeField] private GameObject upgradeMenuObject;
    [SerializeField] private GameObject winScreenObject;
    [SerializeField] private GameObject loseScreenObject;
    private PauseMenuController pauseMenu;
    private float timeSinceDeath;

    private void Start()
    {
        pauseMenu = pauseMenuObject.GetComponent<PauseMenuController>();
    }
    private void Update()
    {
        // Handle pasuing
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseMenu.isPaused)
            {
                pauseMenu.ResumeGame();
            }
            else
            {
                pauseMenu.PauseGame();
            }
        }
    }

    // Player exited current room -> display upgrades.
    // Pass control to the player upgrade controller.
    public void DisplayUpgradeScreen()
    {
        upgradeMenuObject.SetActive(true);
    }

    public void DisplayWinScreen()
    {
        winScreenObject.SetActive(true);
        while (timeSinceDeath <= 5f)
        {
            timeSinceDeath += Time.deltaTime;
        }
        timeSinceDeath = 0;

        Time.timeScale = 1f;
        Loader.Load(Loader.Scene.StartScreen);
    }

    public void DisplayLoseScreen()
    {
        loseScreenObject.SetActive(true);
        while (timeSinceDeath <= 5f)
        {
            timeSinceDeath += Time.deltaTime;
        }

        timeSinceDeath = 0;

        Time.timeScale = 1f;
        Loader.Load(Loader.Scene.StartScreen);
    }
}
