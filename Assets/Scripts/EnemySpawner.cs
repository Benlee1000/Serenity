using System.Collections.Generic;
using UnityEngine;

/*
 * Creates enemy prefabs with a random number of waves.
 * Makes sure they spawn away from player and on screen.
 */
public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner instance;
    [SerializeField] List<EnemyController> enemyPrefabs;
    [SerializeField] List<GameObject> spawnLocations;
    [SerializeField] int waveMin;
    [SerializeField] int waveMax;
    private int waves;
    [SerializeField] int enemyMin;
    [SerializeField] int enemyMax;
    public int numberOfEnemies;
    [SerializeField] private Vector2 leftBottom;
    [SerializeField] private Vector2 topRight;
    [SerializeField] private Transform ParticlePrefab;
    public Animator anim;

    public int Waves { get => waves; set => waves = value; }

    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        waves = Random.Range(waveMin, waveMax);
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
    }

    public void StartWave()
    {
        //First check location be cause we want to spawn further away from the player
        GameObject closestSpawnPoint = null;
        float minDistance = float.MaxValue;
        for(int i = 0; i < spawnLocations.Count; i++)
        {
            if ((spawnLocations[i].transform.position - PlayerController.instance.transform.position).sqrMagnitude < minDistance)
            {
                closestSpawnPoint = spawnLocations[i];
                minDistance = (spawnLocations[i].transform.position - PlayerController.instance.transform.position).sqrMagnitude;
            }
        }

        spawnLocations.Remove(closestSpawnPoint);

        numberOfEnemies = Random.Range(enemyMin, enemyMax);
        for(int i = 0; i < numberOfEnemies; i++)
        {
            GameObject spawnPoint = spawnLocations[Random.Range(0, spawnLocations.Count - 1)];
            float spawnX = spawnPoint.transform.position.x;
            float spawnY = spawnPoint.transform.position.y;

            EnemyController randEnemy = enemyPrefabs[Random.Range(0, enemyPrefabs.Count)];
            //anim = randEnemy.GetComponentInParent<Animator>();
            //anim.SetTrigger("run");

            EnemyController enemy = Instantiate(randEnemy);
            enemy.transform.position = new Vector2(spawnX, spawnY);
            
            Transform particles = Instantiate(ParticlePrefab);
            particles.position = enemy.transform.position;

        }

        spawnLocations.Add(closestSpawnPoint);

    }
}
