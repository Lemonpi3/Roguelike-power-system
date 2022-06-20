using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
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
        charecterData = (CharecterData)_enemyData;
        
        
        hpModifier = (enemyData.hpModifier + GameManager.instance.enemyHPModifier) < 0 ? 1 : (enemyData.hpModifier + GameManager.instance.enemyHPModifier);
        moveSpeedModifier = (enemyData.moveSpeedModifier + GameManager.instance.enemySpeedModifier) < 0 ? 1 : (enemyData.moveSpeedModifier + GameManager.instance.enemySpeedModifier);
        InitializeStats();

        damage = enemyData.damage;
        xp=enemyData.xpDrop;
        initialazed = true;
        GameManager.instance.enemyCount += 1;
    }

    void Start()
    {
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

    protected override void Die(Player player = null)
    {
        GameManager.instance.enemyCount -= 1;
        
        if(player)
        {
            player.GainXP(xp);
        }

        base.Die(player);
    }

}
