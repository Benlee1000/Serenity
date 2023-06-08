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
        if(numberOfEnemies == 0 && waves > 0)
        {
            waves--;
            StartWave();
        } 
    }

    public void StartWave()
    {
        numberOfEnemies = Random.Range(4, 8);
        for(int i = 0; i < numberOfEnemies; i++)
        {
            float spawnX = Random.Range(leftBottom.x, topRight.x);
            float spawnY = Random.Range(leftBottom.y, topRight.y);
            EnemyController enemy = Instantiate(enemyPrefabs[Random.Range(0,enemyPrefabs.Count)]);
            enemy.transform.position = new Vector2(spawnX, spawnY);
            
            Transform particles = Instantiate(ParticlePrefab);
            particles.position = enemy.transform.position;

        }
    }

}
