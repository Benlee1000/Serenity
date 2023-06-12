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
    private PauseMenuController pauseMenu;


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

    // Transitions scene after player picks an upgrade.
    public void Transition()
    {
        /*switch(scene)
        {
            case Loader.Scene.Level1:
                scene = Loader.Scene.Level2;
                Loader.Load(Loader.Scene.Level2);
            case Loader.Scene.Level2:
                scene = Loader.Scene.BossRoom;
                Loader.Load(Loader.Scene.BossRoom);
        }*/
    }
}
