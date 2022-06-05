using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Dataclass which determines which enemies and how fast will they be spawned by the enemyspawner.
[CreateAssetMenu(fileName ="Enemy Spawner Data",menuName="Data/Create Enemy Spawner Data")]
public class EnemySpawnerDataSO : ScriptableObject
{
    [field : SerializeField] public EnemyData[] enemiesToSpawnEarly {get; private set;}
    [field : SerializeField] public EnemyData[] enemiesToSpawnMid {get; private set;}
    [field : SerializeField] public EnemyData[] enemiesToSpawnLate {get; private set;}

    [field : SerializeField] public EnemyData[] bossesToSpawn {get; private set;}

    [field : SerializeField] public float spawnRate {get; private set;}
    [field : SerializeField,Tooltip("Time when midgame starts")] public float midGameTime {get; private set;}
    [field : SerializeField,Tooltip("Time when lategame starts")] public float lateGameTime {get; private set;}

    [field : SerializeField,Tooltip("Interval when bosses will spawn (seconds)")] public float bossSpawnTime {get; private set;}
    [field : SerializeField,Tooltip("Random: Spawns a random boss from the list, works until the game ends.\nLinear: Spawns the bosses in sequential order, works until the list its over\nLoop: Spawns bosses in sequential order but loops the list until the game ends.\nContinousSpawnLast: Spawns in sequential order but spawns the last index until the game is over.")] 
    public BossSpawnerType bossSpawnerType {get; private set;}

}
public enum BossSpawnerType {Random,Linear,Loop,ContinousSpawnLast}