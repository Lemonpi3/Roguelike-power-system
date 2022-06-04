using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Stats
{
    Transform target;
    public EnemyData enemyData;
    double damage;
    int xp;

    float dmgCd = 1;
    float timer;
    // Start is called before the first frame update
    public void Initialize(EnemyData _enemyData)
    {
        if(initialazed || _enemyData == null) { return; }
        enemyData = _enemyData;

        moveSpeedDefault = enemyData.moveSpeed <= 0 ? 1 : enemyData.moveSpeed;
        hpDefault = enemyData.hp <= 0 ? 1 : enemyData.hp;
        
        hpModifier = (enemyData.hpModifier + GameManager.enemyHPModifier) < 0 ? 1 : (enemyData.hpModifier + GameManager.enemyHPModifier);
        moveSpeedModifier = (enemyData.moveSpeedModifier + GameManager.enemySpeedModifier) < 0 ? 1 : (enemyData.moveSpeedModifier + GameManager.enemySpeedModifier);
        InitializeStats();

        damage = enemyData.damage;
        xp=enemyData.xpDrop;
        initialazed = true;
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

        timer -= Time.deltaTime;

        if(timer > 0) return;
        
        timer = dmgCd;
    }

    public override void InitializeStats()
    {
        base.InitializeStats();
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player" && timer <= 0)
        {
            Player player = target.GetComponent<Player>();
            player.TakeDamage(damage);
        }
    }
    
    
}
