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
    
    private Loader.Scene scene;
    [SerializeField] private GameObject pauseMenuObject;
    [SerializeField] private GameObject upgradeMenuObject;
    [SerializeField] private GameObject winScreenObject;
    [SerializeField] private GameObject loseScreenObject;
    private PauseMenuController pauseMenu;
    private PlayerUpgradeController upgradeMenu;
    private float timeSinceDeath;

    private void Start()
    {
        pauseMenu = pauseMenuObject.GetComponent<PauseMenuController>();
        upgradeMenu = upgradeMenuObject.GetComponent<PlayerUpgradeController>();
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
        
        // Checks general win condition -> Pause time -> Go to upgrades.
        if (EnemySpawner.instance.numberOfEnemies == 0 && EnemySpawner.instance.waves <= 0)
        {
            Time.timeScale = 0f;
            upgradeMenu.DisplayUpgradeScreen();
        }

        // Checks general win condition + if its last level -> Pause time -> Go to start screen.
        if (EnemySpawner.instance.numberOfEnemies == 0 && EnemySpawner.instance.waves <= 0 && Loader.getCurrentScene() == 9)
        {
            Time.timeScale = 0f;
            DisplayWinScreen();
        }
    }    

    public void DisplayWinScreen()
    {
        winScreenObject.SetActive(true);
        
        // Using timeSinceDeath as a variable to store time. Player didn't actually die.
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
