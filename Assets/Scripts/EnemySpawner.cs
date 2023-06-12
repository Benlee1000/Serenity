using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner instance;
    [SerializeField] List<EnemyController> enemyPrefabs;
    private int waves;
    public int numberOfEnemies;
    [SerializeField] private Vector2 leftBottom;
    [SerializeField] private Vector2 topRight;
    [SerializeField] private Transform ParticlePrefab;
    public Animator anim;
    private CombatRoomController combatRoomController;
    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        waves = Random.Range(2, 4);
        StartWave();
    }

    // Update is called once per frame
    void Update()
    {
        // Checks general win condition -> start next wave.
        if (numberOfEnemies == 0 && waves > 0)
        {
            waves--;
            StartWave();
        } 

        // Checks general win condition -> go to upgrades.
        else if (numberOfEnemies == 0 && waves <= 0)
        {
            Time.timeScale = 0f;
            combatRoomController.DisplayUpgradeScreen();
        }
        
        // Checks general win condition + if its last level -> go to start screen.
        else if (numberOfEnemies == 0 && waves <= 0 && Loader.getCurrentScene() == 9)
        {
            Time.timeScale = 0f;
            combatRoomController.DisplayWinScreen();
        }
    }

    public void StartWave()
    {
        numberOfEnemies = Random.Range(4, 8);
        for(int i = 0; i < numberOfEnemies; i++)
        {
            float spawnX = Random.Range(leftBottom.x, topRight.x);
            float spawnY = Random.Range(leftBottom.y, topRight.y);
            EnemyController randEnemy = enemyPrefabs[Random.Range(0, enemyPrefabs.Count)];
            //anim = randEnemy.GetComponentInParent<Animator>();
            //anim.SetTrigger("run");
            EnemyController enemy = Instantiate(randEnemy);
            enemy.transform.position = new Vector2(spawnX, spawnY);
            
            Transform particles = Instantiate(ParticlePrefab);
            particles.position = enemy.transform.position;

        }
    }

}
