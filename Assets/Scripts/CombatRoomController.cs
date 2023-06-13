using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Threading;

/*
 * Functional state for regular combat room
 * 
 */
public class CombatRoomController : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuObject;
    [SerializeField] private GameObject upgradeMenuObject;
    [SerializeField] private GameObject winScreenObject;
    [SerializeField] private GameObject loseScreenObject;
    private PauseMenuController pauseMenu;
    private PlayerUpgradeController upgradeMenu;
    public AudioClip DeathNoise;
    public AudioClip WinNoise;
    public AudioSource audioSource;
    private int noisePlayed;
    private void Start()
    {
        Time.timeScale = 1f;
        pauseMenu = pauseMenuObject.GetComponent<PauseMenuController>();
        upgradeMenu = upgradeMenuObject.GetComponent<PlayerUpgradeController>();
         audioSource=GetComponent<AudioSource>();
         noisePlayed=0;
        
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
        
        if (PlayerController.instance.Health <= 0)
        {
            Time.timeScale = 0f;
            DisplayLoseScreen();
            if(noisePlayed==0){
                audioSource.PlayOneShot(DeathNoise);
            }
            noisePlayed=1;
        }

        // Checks general win condition -> Pause time -> Go to upgrades.
        if (EnemySpawner.instance.numberOfEnemies == 0 && EnemySpawner.instance.Waves <= 0 && PlayerController.instance.transform.position.y > 11f)
        {
            Time.timeScale = 0f;
            upgradeMenu.DisplayUpgradeScreen();
            audioSource.PlayOneShot(WinNoise);
            if(noisePlayed==0){
                audioSource.PlayOneShot(WinNoise);
            }
            noisePlayed=1;
        }

        // Checks general win condition + if its last level -> Pause time -> Go to start screen.
        if (EnemySpawner.instance.numberOfEnemies == 0 && EnemySpawner.instance.Waves <= 0 && Loader.getCurrentScene() == 9)
        {
            Time.timeScale = 0f;
            DisplayWinScreen();
        }
    }    

    public void DisplayWinScreen()
    {
        winScreenObject.SetActive(true);
    }

    public void DisplayLoseScreen()
    {
        loseScreenObject.SetActive(true);
    }
}