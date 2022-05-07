using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectilePower : Power 
{

    private ProyectilePowerData powerData;
    private int numberOfProyectiles;
    private int damage;
    private float attackSpeed;
    private float proyectileScale;
    private float proyectileDuration;
    private float proyectileSpeed;

    private GameObject target;

    [field : SerializeField] public float targetUpdateInterval = 0.3f; //might be better on game manager

    public void Start()
    {
        powerData = (ProyectilePowerData)_power;
        numberOfProyectiles = powerData.proyectilesFired;
        damage = powerData.basePowerDamage;
        attackSpeed = powerData.baseAttackSpeed;
        proyectileScale = powerData.proyectileScale;
        proyectileDuration = powerData.proyectileDuration;
        proyectileSpeed = powerData.proyectileSpeed;
        gameObject.name = _power.powerName;

        rank = 1;
        StartCoroutine(UpdateTarget());
        StartCoroutine(Shoot());
    }

    public override void RankUP()
    {
        //checks if the lenght of the list is bigger or equal to the rank-1 if its smaller it uses the last member of the list.
        numberOfProyectiles = powerData.proyectilesAddedPerRank.Length >= rank-2 ? numberOfProyectiles + powerData.proyectilesAddedPerRank[rank-2] : numberOfProyectiles + powerData.proyectilesAddedPerRank[powerData.proyectilesAddedPerRank.Length-2];
        damage = powerData.dmgUpPerRank.Length >= rank-2 ? damage + powerData.dmgUpPerRank[rank-2] : damage + powerData.dmgUpPerRank[powerData.dmgUpPerRank.Length-2];
        attackSpeed =  powerData.attackSpeedPerRankModifier.Length >= rank-2 ? powerData.baseAttackSpeed / powerData.attackSpeedPerRankModifier[rank-2] : powerData.baseAttackSpeed / powerData.attackSpeedPerRankModifier[powerData.attackSpeedPerRankModifier.Length-2];
        proyectileDuration = powerData.proyectileExtraDuration.Length >= rank-2 ? proyectileDuration + powerData.proyectileExtraDuration[rank-2] : proyectileDuration + powerData.proyectileExtraDuration[powerData.proyectileExtraDuration.Length-2];
    }

    private IEnumerator UpdateTarget()
    {
        while(true){

            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

            if(enemies.Length > 0)
            {
                float distance = Mathf.Infinity;
                GameObject closestEnemy = null;

                foreach(GameObject enemy in enemies)
                {
                    float distanceToEnemy = Vector2.Distance(transform.position,enemy.transform.position);
                    if(distance >  distanceToEnemy)
                    {
                        distance =  distanceToEnemy;
                        closestEnemy = enemy;
                    }
                }
                target = closestEnemy;
            }
            yield return new WaitForSeconds(targetUpdateInterval);
        }
    }

    private IEnumerator Shoot()
    {
        while(true)
        {
            if(target != null)
            {
                for (int i = 0; i < numberOfProyectiles; i++)
                {
                    Proyectile proyectile = Instantiate(powerData.proyectile,transform.position,Quaternion.identity,transform).GetComponent<Proyectile>();
                    proyectile.InitializeProyectile(damage,proyectileDuration,proyectileSpeed,proyectileScale,target.transform);
                }
            }
            yield return new WaitForSeconds(attackSpeed);
        }
    }
}
