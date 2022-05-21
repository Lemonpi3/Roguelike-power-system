using UnityEngine;
using System.Collections.Generic;

public class ConstantPower : Power
{
    private ConstantPowerData powerData;
    private DamageArea area;
    float size;
    protected override void Start()
    {
        base.Start();
        
        powerData = (ConstantPowerData)_power;

        if(powerData.area == null || powerData.powerType != PowerType.Constant)
        {
            Debug.LogWarning($"No Area prefab in data and/or PowerType is not PowerType.Constant: {powerData.powerName}"); 
            return;
        } 


        area = Instantiate(powerData.area,transform.position,Quaternion.identity,transform).GetComponent<DamageArea>();
        size = powerData.areaSizeScale;
        UpdateArea();
    }

    public override void RankUP()
    {
        base.RankUP();
        
        size = powerData.areaSizeRankIncrease.Length >= rank-2 ? powerData.areaSizeRankIncrease[rank-2] : powerData.areaSizeRankIncrease[powerData.areaSizeRankIncrease.Length-1];
        UpdateArea();
    }

    public void UpdateArea()
    {
        size = size * (float)player.powerSizeModifier;
        area.UpdateAreaStats(damage,attackSpeed,size,player,powerData.posOffSet,powerData.rotationOffSet,powerData.affectTag);
    }
}
