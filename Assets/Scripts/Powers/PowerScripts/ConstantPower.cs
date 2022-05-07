using UnityEngine;

public class ConstantPower : Power
{
    private ConstantPowerData powerData;
    private float tickRate = 1;
    Transform area;
    bool attack;

    void Start()
    {
        powerData = (ConstantPowerData)_power;
        gameObject.name = powerData.powerName;
        
        tickRate = powerData.baseAttackSpeed;
        damage = powerData.basePowerDamage;

        //Incase of custom beheavor areas
        if(powerData.area != null)
        {
            area = Instantiate(powerData.area,transform.position,Quaternion.identity,transform).transform;
            area.localScale = Vector3.one * powerData.areaSizeScale;
            area.position = powerData.posOffSet;
            area.rotation = Quaternion.Euler(powerData.rotationOffSet);
        }
        else
        {
            transform.localScale = Vector3.one * powerData.areaSizeScale;
            transform.position = powerData.posOffSet;
            transform.rotation = Quaternion.Euler(powerData.rotationOffSet);
        }
    }

    void Update()
    {
        tickRate -= Time.deltaTime;
        if(tickRate <= 0)
        {
            attack = true;
            tickRate = powerData.baseAttackSpeed;
            attack = false;
        }
    }

    public override void RankUP()
    {
        base.RankUP();
        if(area != null)
        {
            area.localScale = powerData.areaSizeRankIncrease.Length >= rank-2 ? Vector3.one * powerData.areaSizeRankIncrease[rank-2] : Vector3.one *  powerData.areaSizeRankIncrease[powerData.areaSizeRankIncrease.Length-1];
        }
        else
            transform.localScale = powerData.areaSizeRankIncrease.Length >= rank-2 ? Vector3.one * powerData.areaSizeRankIncrease[rank-2] : Vector3.one *  powerData.areaSizeRankIncrease[powerData.areaSizeRankIncrease.Length-1];
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "Enemy" && attack)
        {
            Debug.Log($"Dealt: {damage} to {other.name}");
        }
    }
}
