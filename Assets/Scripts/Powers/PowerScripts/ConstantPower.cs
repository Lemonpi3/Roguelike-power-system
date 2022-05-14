using UnityEngine;
using System.Collections.Generic;

public class ConstantPower : Power
{
    private ConstantPowerData powerData;
    private float tickRate = 1;
    Transform area;
    Collider2D col2D;
    Stack<Collider2D> hitted= new Stack<Collider2D>();

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
            col2D = GetComponent<Collider2D>();
        }
    }

    void Update()
    {
        tickRate -= Time.deltaTime;

        if(tickRate > -.1f) return;
        
        tickRate = powerData.baseAttackSpeed;

        if(hitted.Count == 0) return;

        hitted = new Stack<Collider2D>();
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
        if(other.tag == "Enemy" && tickRate <= 0 && !hitted.Contains(other))
        {
            Debug.Log($"Dealt: {damage} to {other.name}");
            hitted.Push(other);
        }
    }
}
