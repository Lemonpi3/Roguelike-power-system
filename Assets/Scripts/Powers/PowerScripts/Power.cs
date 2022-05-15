using UnityEngine;

public abstract class Power : MonoBehaviour
{
    protected PowerData _power;
    protected int damage;
    protected float attackSpeed;

    [field : SerializeField] public int rank {get; protected set;}
    bool initialized;

    public void Initialize(PowerData power)
    {
        _power = !initialized ? power : _power;
        initialized = true;
    }

    protected virtual void Start()
    {
        rank = 1;
        damage = _power.basePowerDamage;
        attackSpeed = _power.baseAttackSpeed;
        gameObject.name = _power.powerName;
    }

    public PowerData CheckPower()
    {
        return _power;
    }

    public virtual void RankUP()
    {
        if(rank <= 0) {rank = 1;}
        if(rank+1 > _power.maxRank){return;}
        rank += 1;
        damage = _power.dmgUpPerRank.Length >= rank-2 ? damage + _power.dmgUpPerRank[rank-2] : damage + _power.dmgUpPerRank[_power.dmgUpPerRank.Length-2];
        attackSpeed =  _power.attackSpeedPerRankModifier.Length >= rank-2 ? _power.baseAttackSpeed / _power.attackSpeedPerRankModifier[rank-2] : _power.baseAttackSpeed / _power.attackSpeedPerRankModifier[_power.attackSpeedPerRankModifier.Length-2];
    }
}
