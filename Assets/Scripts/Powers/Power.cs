using UnityEngine;

public abstract class Power : MonoBehaviour
{
    protected PowerData _power;

    [field : SerializeField] public int rank {get; protected set;}
    bool initialized;
    public void Initialize(PowerData power)
    {
        _power = !initialized ? power : _power;
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
    }
}
