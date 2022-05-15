using UnityEngine;
using System.Collections.Generic;

public class ConstantPower : Power
{
    private ConstantPowerData powerData;
    private DamageArea area;
    

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
        area.UpdateAreaStats(damage,attackSpeed,powerData.areaSizeScale,powerData.posOffSet,powerData.rotationOffSet,powerData.affectTag);
    }

    public override void RankUP()
    {
        base.RankUP();
        
        float _newSize = powerData.areaSizeRankIncrease.Length >= rank-2 ? powerData.areaSizeRankIncrease[rank-2] : powerData.areaSizeRankIncrease[powerData.areaSizeRankIncrease.Length-1];
        area.UpdateAreaStats(damage,attackSpeed,_newSize,powerData.posOffSet,powerData.rotationOffSet,powerData.affectTag);
    }
}
