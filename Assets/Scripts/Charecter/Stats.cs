using UnityEngine;

public class Stats : MonoBehaviour
{
    [field : SerializeField] public float moveSpeedDefault {get; protected set;}
    [field : SerializeField] public double hpDefault {get; protected set;}

    [field : SerializeField] public double hpMax {get; protected set;}
    [field : SerializeField] public double hpCurrent {get; protected set;}
    [field : SerializeField] public float moveSpeed {get; protected set;}

    [field : SerializeField] public double moveSpeedModifier {get; protected set;}
    [field : SerializeField] public double hpModifier {get; protected set;}

    protected bool initialazed;

    public virtual void InitializeStats()
    {
        moveSpeedModifier = moveSpeedModifier < 0 ? 1 : moveSpeedModifier;
        hpModifier = hpModifier < 0 ? 1 : hpModifier;
        hpMax = hpDefault > 0 ? (double)(hpDefault * hpModifier) : 1;
        hpCurrent = hpMax;

        moveSpeed = moveSpeedDefault > 0 ? moveSpeedDefault * (float)moveSpeedModifier : 1;
    }

    public virtual void TakeDamage(double amount, Player player=null)
    {
        hpCurrent =- amount;
        if(hpCurrent > 0) { return;}
        Die();
    }

    public virtual void Heal(double amount)
    {
        hpCurrent = hpCurrent+amount > hpMax ? hpMax : hpCurrent+amount;
    }

    protected virtual void Die(Player player = null)
    {
        Destroy(gameObject);
    }

    public virtual void UpdateMoveSpeed(double modifier)
    {
        moveSpeedModifier = (moveSpeedModifier+modifier) <= 0 ? 0.1: moveSpeedModifier+modifier;
        moveSpeed = moveSpeedDefault * (float)moveSpeedModifier;
    }

    public virtual void UpdateMaxHP(double modifier)
    {
        hpModifier = (hpModifier+modifier) == 0 ? 0.1: hpModifier+modifier;
        hpMax = (double)(hpDefault * hpModifier);
        Heal(0);
    }
}
