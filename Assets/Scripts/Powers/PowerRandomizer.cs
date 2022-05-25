using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerRandomizer : MonoBehaviour
{

    [field : SerializeField] public PowerData[] allPowers {get;private set;}

    private PowerData[] priorityPowers;
    List<int> powersSelectedIdxs = new List<int>();

    PowersAdquiredContainer powersAdquiredContainer;

    void Start()
    {
        powersAdquiredContainer = GetComponent<PowersAdquiredContainer>();
    }

    ///<summary> Rolls selected amount of powers, and resets the repeat protection after rolling by default. 
    ///(the repeat protection exists so the player doesn't get the same power twice in the selection.)
    ///</summary>
    public PowerData[] RollRandomPowers(int amount,bool resetRepeat=true)
    {
        PowerData[] powers = new PowerData[amount];
        for (int i = 0; i < amount; i++)
        {
            int rng = Random.Range(0,allPowers.Length);
            while(powersSelectedIdxs.Contains(rng))
            {
                rng = Random.Range(0,allPowers.Length);
            }
            powers[i]=allPowers[rng];
            powersSelectedIdxs.Add(rng);
        }
        if (resetRepeat) { powersSelectedIdxs= new List<int>();}
        return powers;
    }

    ///<summary>Run It in the slots that come before Random powers ones. 
    ///If you want a slot to roll powers that the player already has, so it can rank them up use this method.
    ///Returns: A Random power if the player hasn't chosen any yet or a random power from the previously selected by the player.</summary>
    public PowerData GetPriortyPower()
    {
        if(priorityPowers==null)
        {
            return (RollRandomPowers(1,false)[0]);
        }
        int rng = Random.Range(0,priorityPowers.Length);
        return priorityPowers[rng];
    }
}
