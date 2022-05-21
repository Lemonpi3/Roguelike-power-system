using System.Collections;
using UnityEngine;

public class ProyectilePower : Power 
{

    private ProyectilePowerData powerData;
    private int numberOfProyectiles;
    private float proyectileScale;
    private float proyectileDuration;
    private float proyectileSpeed;

    private GameObject target;

    [field : SerializeField] public float targetUpdateInterval = 0.3f; //might be better on game manager

    protected override void Start()
    {
        base.Start();

        powerData = (ProyectilePowerData)_power;

        if(powerData.powerType != PowerType.Proyectile)
        {
            Debug.LogWarning($"PowerType is not PowerType.Proyectile: {powerData.powerName}"); 
            return;
        }

        numberOfProyectiles = powerData.proyectilesFired;
        
        proyectileScale = powerData.proyectileScale;
        proyectileDuration = powerData.proyectileDuration;
        proyectileSpeed = powerData.proyectileSpeed;

        StartCoroutine(UpdateTarget());
        StartCoroutine(Shoot());
    }

    public override void RankUP()
    {
        base.RankUP();
        //checks if the lenght of the list is bigger or equal to the rank-2 if its smaller it uses the last member of the list.
        numberOfProyectiles = powerData.proyectilesAddedPerRank.Length >= rank-2 ? numberOfProyectiles + powerData.proyectilesAddedPerRank[rank-2] : numberOfProyectiles + powerData.proyectilesAddedPerRank[powerData.proyectilesAddedPerRank.Length-2];
        
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
            int proyectiles = Mathf.RoundToInt((float)(numberOfProyectiles*player.powerAmountModifier));
            if(target != null)
            {
                for (int i = 0; i < proyectiles; i++)
                {
                    Proyectile proyectile = Instantiate(powerData.proyectile,transform.position,Quaternion.identity,transform).GetComponent<Proyectile>();
                    proyectile.InitializeProyectile(damage,proyectileDuration,proyectileSpeed,proyectileScale,target.transform.position, player);
                    yield return new WaitForSeconds(0.15f);
                }
            }
            yield return new WaitForSeconds(attackSpeed * (float)player.powerCooldownModifier);
        }
    }
}
