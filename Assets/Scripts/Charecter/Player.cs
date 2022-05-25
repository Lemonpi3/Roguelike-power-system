using System.Collections;
using UnityEngine;

public class Player : Stats
{
    [field : SerializeField] public PlayerData playerClass {get; private set;}
    [field : SerializeField] public double powerDamageModifier {get; private set;}
    [field : SerializeField] public double powerCooldownModifier {get; private set;}
    [field : SerializeField] public double powerSizeModifier {get; private set;}
    [field : SerializeField] public double powerAmountModifier {get; private set;}
    [field : SerializeField] public double hpRegenPercent {get; private set;}
    
    [field : SerializeField] public int level {get; private set;}
    [field : SerializeField] public int xpToLevel {get; private set;}
    [field : SerializeField] public int xpCurrent {get; private set;}

    void Start()
    {
        InitializeStats();
        StartCoroutine(HpRegen());
        GainXP(1);
    }
    
    void Update()
    {
        
    }

    //<---Initializers--->

    //For Setting class throght scripting
    public void SetClass(PlayerData playerData)
    {
        playerClass = playerData;
        InitializeStats();
    }
    
    public override void InitializeStats()
    {
        if(initialazed || playerClass == null) { return; }

        moveSpeedDefault = playerClass.moveSpeed <= 0 ? 1 : playerClass.moveSpeed;
        hpDefault = playerClass.hp <= 0 ? 1 : playerClass.hp;

        powerDamageModifier = playerClass.powerDamageModifier < 0 ? 1 : playerClass.powerDamageModifier;
        powerCooldownModifier = playerClass.powerCooldownModifier < 0 ? 1 : playerClass.powerCooldownModifier;
        powerSizeModifier = playerClass.powerSizeModifier == 0 ? 1 : playerClass.powerSizeModifier;
        powerAmountModifier = playerClass.powerAmountModifier == 0 ? 1 : playerClass.powerAmountModifier;
        hpModifier = playerClass.hpModifier < 0 ? 1 : playerClass.hpModifier;
        moveSpeedModifier = playerClass.moveSpeedModifier < 0 ? 1 : playerClass.moveSpeedModifier;
        hpRegenPercent = playerClass.hpRegenPercent < 0 ? 0 : playerClass.hpRegenPercent;

        base.InitializeStats();
    }

    //Modifiers Changes
    public virtual void UpdatePowerDamage(double modifier)
    {
        powerDamageModifier = (powerDamageModifier+modifier) <= 0 ? 0.1: powerDamageModifier+modifier;
    }

    public virtual void UpdatePowerCoolDown(double modifier)
    {
        powerCooldownModifier = (powerCooldownModifier+modifier) <= 0 ? 0.1: powerCooldownModifier+modifier;
    }

    public virtual void UpdatePowerSize(double modifier)
    {
        powerSizeModifier = (powerSizeModifier+modifier) <= 0 ? 0.1: powerSizeModifier+modifier;
    }

    public virtual void UpdatePowerAmount(double modifier)
    {
        powerAmountModifier = (powerAmountModifier+modifier) <= 0 ? 0.1: powerAmountModifier+modifier;
    }

    public virtual void UpdateHpRegen(double modifier)
    {
        hpRegenPercent = (hpRegenPercent+modifier) < 0 ? 0: hpRegenPercent+modifier;
    }

    protected IEnumerator HpRegen()
    {
        while(true)
        {
            Heal((hpCurrent*hpRegenPercent));
            yield return new WaitForSeconds(1);
        }
    }

    public virtual void GainXP(int amount)
    {
        xpCurrent += amount;
        if (xpCurrent >= xpToLevel)
        {
            int remanent = xpCurrent - xpToLevel;
            level++;
            xpToLevel=(int)(0.5*level) <= 0 ? 1 : (int)(0.5*level);
            if(remanent > 0)
            {
                GainXP(remanent);
            }
        }
    }
}
