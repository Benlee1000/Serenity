using UnityEngine;

/*
 * Functional state for regular combat room
 */
public class CombatRoomController : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuObject;
    [SerializeField] private GameObject upgradeMenuObject;
    [SerializeField] private GameObject winScreenObject;
    [SerializeField] private GameObject loseScreenObject;
    [SerializeField] private GameObject doorMarkerObject;
    private PauseMenuController pauseMenu;
    private PlayerUpgradeController upgradeMenu;
    private bool upgrading;
    private bool doorMarked;

    private void Start()
    {
        Time.timeScale = 1f;
        upgrading = false;
        doorMarked = false;
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
        
        if (PlayerController.instance.Health <= 0)
        {
            Time.timeScale = 0f;
            DisplayLoseScreen();
        }

        // Mark the door when all waves defeated, only set it active once
        if (!doorMarked && EnemySpawner.instance.numberOfEnemies == 0 && EnemySpawner.instance.Waves <= 0)
        {
            doorMarkerObject.SetActive(true);
            doorMarked = true;
        }

        // Checks general win condition -> Pause time -> Go to upgrades.
        // Avoided if last level
        if (EnemySpawner.instance.numberOfEnemies == 0 && EnemySpawner.instance.Waves <= 0 && PlayerController.instance.transform.position.y > 11f)
        {
            Time.timeScale = 0f;
            if(Loader.GetCurrentScene() != 7)
            {
                upgradeMenu.DisplayUpgradeScreen();
                upgrading = true;

            }
        }
        // Checks general win condition + if its last level -> Pause time -> Go to start screen.
        // Timer here to prevent win screen from showing on load of last level
        if (!upgrading && EnemySpawner.instance.numberOfEnemies == 0 && EnemySpawner.instance.Waves <= 0 && Loader.GetCurrentScene() == 7)
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