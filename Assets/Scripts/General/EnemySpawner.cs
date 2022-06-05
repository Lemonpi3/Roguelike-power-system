using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private EnemySpawnerDataSO spawnerData;

    float spawnerLifeTime = 0;
    [SerializeField] float minSpawnRadius = 15;
    [SerializeField] float maxSpawnRadius = 20;
    [SerializeField] int _maxEnemyCount = 10;
    
    Transform enemiesParent;
    [SerializeField] GameObject enemyPrefab;

    void Start()
    {
        enemiesParent = GameObject.Find("Enemies").transform;
    }

    void Update()
    {
        spawnerLifeTime += Time.deltaTime;

        if(GameManager.instance.enemyCount >= _maxEnemyCount) {return;}

        if(spawnerLifeTime >= spawnerData.lateGameTime && spawnerData.enemiesToSpawnLate.Length > 0)
        {
            int rng = Random.Range(0,spawnerData.enemiesToSpawnLate.Length);
            SpawnEnemy(spawnerData.enemiesToSpawnLate[rng]);
            return;
        }

        if(spawnerLifeTime >= spawnerData.midGameTime && spawnerData.enemiesToSpawnMid.Length > 0)
        {
            int rng = Random.Range(0,spawnerData.enemiesToSpawnMid.Length);
            SpawnEnemy(spawnerData.enemiesToSpawnMid[rng]);
            return;
        }

        if(spawnerData.enemiesToSpawnEarly.Length > 0)
        {
            int rng = Random.Range(0,spawnerData.enemiesToSpawnEarly.Length);
            SpawnEnemy(spawnerData.enemiesToSpawnEarly[rng]);
            return;
        }
    }

    void SpawnEnemy(EnemyData enemy)
    {
        int dir = Random.Range(-1, 1);
        if( dir == 0) { dir = 1; }

        float rngX = Random.Range(minSpawnRadius, maxSpawnRadius)*dir; 
        
        dir = Random.Range(-1, 1);
        if (dir == 0) { dir = 1; }

        float rngY = Random.Range(minSpawnRadius, maxSpawnRadius)*dir;

        Vector3 spawnPos = new Vector3(rngX,rngY,1);

        Enemy _enemy = Instantiate(enemyPrefab,spawnPos,Quaternion.identity,enemiesParent).GetComponent<Enemy>();
        _enemy.Initialize(enemy);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, maxSpawnRadius);
        Gizmos.DrawWireSphere(transform.position, minSpawnRadius);
    }
}
