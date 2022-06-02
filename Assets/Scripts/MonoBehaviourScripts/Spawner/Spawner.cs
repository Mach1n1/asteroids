using UnityEngine;

public class Spawner : ObjectPool
{
    [SerializeField] private GameObject[] enemyTemplates;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private float secondBetweenSpawn;

    private float elapsedTime = 0;

    private void Start()
    {
        Initialize(enemyTemplates);
    }

    private void FixedUpdate()
    {
        SetRealSeconds();

        if(elapsedTime >= secondBetweenSpawn)
        {
            SpawnEnemy();
        }
    }
   
    private void SpawnEnemy()
    {
        if (TryGetObject(out GameObject enemies))
        {
            ResetTime();

            int spawnPointNumber = Random.Range(0, spawnPoints.Length);

            SetEnemy(enemies, spawnPoints[spawnPointNumber].position);
        }
    }

    private void SetRealSeconds()
    {
        elapsedTime += Time.deltaTime;
    }

    private void ResetTime()
    {
        elapsedTime = 0;
    }

    private void SetEnemy(GameObject enemies, Vector3 spawnPoint)
    {
        enemies.SetActive(true);
        enemies.transform.position = spawnPoint;
    }
}
