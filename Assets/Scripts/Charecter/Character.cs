using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : Stats
{
    protected CharecterData charecterData;

    public override void InitializeStats()
    {
        moveSpeedDefault = charecterData.moveSpeed <= 0 ? 1 : charecterData.moveSpeed;
        hpDefault = charecterData.hp <= 0 ? 1 : charecterData.hp;
        base.InitializeStats();
        gameObject.name=charecterData.charecterName;
        SpriteRenderer charSprite = GetComponent<SpriteRenderer>();
        charSprite.sprite = charecterData.charecterSprite; 
    }
}
