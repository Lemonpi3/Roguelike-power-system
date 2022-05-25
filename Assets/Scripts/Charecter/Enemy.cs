using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Stats
{
    Transform target;
    EnemyData enemyData;
    double damage;
    int xp;
    // Start is called before the first frame update
    public void Initialize(EnemyData _enemyData)
    {
        enemyData = _enemyData;
        moveSpeed = enemyData.moveSpeed;
        damage = enemyData.damage;
        xp=enemyData.xpDrop;
    }

    void Start()
    {
        Initialize(enemyData); //TEST
        target = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        Vector3 direction =  target.position - transform.position;
        transform.Translate(direction.normalized * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        
    }

}
