using UnityEngine;

public class BuffPower : Power
{
    BuffPowerData powerData;

    StatsTypes[] statsToModify;
    CharacterTypes[] affectsCharacterTypes;

    bool temporal;
    float buffTemporalDuration;
    double amountToModify;

    protected override void Start()
    {
        base.Start();

        powerData = (BuffPowerData)_power;

        if(powerData.powerType != PowerType.Buff)
        {
            Debug.LogWarning($"PowerType is not PowerType.Buff or Temporal: {powerData.powerName}"); 
            return;
        }

        statsToModify = powerData.statsToModify;
        amountToModify = powerData.basePowerModifier;
        affectsCharacterTypes = powerData.affectsCharacterTypes;

        temporal = powerData.temporal;
        buffTemporalDuration = powerData.buffTemporalDuration;

        Modify(amountToModify);
    }

    void Update()
    {
        if(!temporal){return;}

        buffTemporalDuration-=Time.deltaTime;

        if(buffTemporalDuration<=0)
        {
            Modify(-amountToModify);
            Destroy(gameObject);
        }
    }

    void Modify(double amount)
    {
        for (int i = 0; i < affectsCharacterTypes.Length; i++)
        {
            if(affectsCharacterTypes[i]==CharacterTypes.All)
            {
                ModifyPlayerStats(statsToModify,amount);
                ModifyEnemyStats(statsToModify,amount);
                continue;
            }
            if(affectsCharacterTypes[i]==CharacterTypes.Player)
            {
                ModifyPlayerStats(statsToModify,amount);
                continue;
            }
            else
            {
                ModifyEnemyStats(statsToModify,amount,affectsCharacterTypes[i]);
            }
        }
    }

    private void ModifyEnemyStats(StatsTypes[] _stats,double amount,CharacterTypes enemyType=CharacterTypes.All)
    {
        for (int i = 0; i < _stats.Length; i++)
        {
            switch (_stats[i])
            {
                case (StatsTypes.HP):
                    GameManager.instance.ModifyEnemy_HPModifier(amount);
                    break;
                case (StatsTypes.Speed):
                    GameManager.instance.ModifyEnemy_SpeedModifier(amount);
                    break;
                default:
                    Debug.Log("Not a vaild stat to modify");
                    break;
            }
        }
    }

    private void ModifyPlayerStats(StatsTypes[] _stats,double amount)
    {
        for (int i = 0; i < _stats.Length; i++)
        {
            switch (_stats[i])
            {
                case (StatsTypes.HP):
                    player.UpdateMaxHP(amount);
                    break;
                case (StatsTypes.Speed):
                    player.UpdateMoveSpeed(amount);
                    break;
                case (StatsTypes.Amount):
                    player.UpdatePowerAmount(amount);
                    break;
                case (StatsTypes.Damage):
                    player.UpdatePowerDamage(amount);
                    break;
                case (StatsTypes.XPgain):
                    player.UpdateXPGain(amount);
                    break;
                case (StatsTypes.Size):
                    player.UpdatePowerSize(amount);
                    break;
                case (StatsTypes.Cooldown):
                    player.UpdatePowerCoolDown(amount);
                    break;
                case (StatsTypes.Regen):
                    player.UpdateHpRegen(amount);
                    break;
                default:
                    Debug.Log("Not a vaild stat to modify");
                    break;
            }
        }
    }
}
