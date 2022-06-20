using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerRandomizer : MonoBehaviour
{
    [field : SerializeField] public PowerData[] allPowers {get;private set;}
    private PowerData[] priorityPowers;

    PowerData[] powers;

    public int maxDuplicateRerolls = 30; // to prevent an endless loop of rolling powers
    int duplicateRerolls = 0;

    int totalWeight = -1;
    public int TotalWeight {
        get{
            if(totalWeight == -1){
                CalculateTotalWeight();
            }
            return totalWeight;
        }
    }

    PowersAdquiredContainer powersAdquiredContainer;


    void Start()
    {
        powersAdquiredContainer = GetComponent<PowersAdquiredContainer>();
    }

    public PowerData[] GetPowers(int amount,int numPriorityPowers = 0)
    {
        powers = new PowerData[amount];

        for(int i=0; i < numPriorityPowers; i++)
        {
            powers[i]=GetPriortyPower();
        }
        for (int i = numPriorityPowers; i < amount; i++)
        {
            powers[i]=RollRandomPower();
        }
        return powers;
    }

    ///<summary> Rolls selected amount of powers, first value is the total amount of powers to roll, second value is how many would be rolled as priority (priority powers are powers</summary>
    public PowerData RollRandomPower()
    {
        int roll = Random.Range(0,TotalWeight);
        PowerData power = null;

        for(int i =0; i < allPowers.Length; i++)
        {
            roll -= allPowers[i].dropWeight;
            if(roll < 0)
            {
               power = CheckForDuplicates(powers,allPowers[i]);
               break;
            }
        }
        return power;
    }

    ///<summary>Run It in the slots that come before Random powers ones. 
    ///If you want a slot to roll powers that the player already has, so it can rank them up use this method.
    ///Returns: A Random power if the player hasn't chosen any yet or a random power from the previously selected by the player.</summary>
    public PowerData GetPriortyPower()
    {
        if(priorityPowers==null)
        {
            return (RollRandomPower());
        }
        
        int rng = Random.Range(0,priorityPowers.Length);
        return priorityPowers[rng];
    }

    ///<summary> Prevents duplicate rolls on the same list </summary>
    PowerData CheckForDuplicates(PowerData[] powerList, PowerData _power){
        for (int i = 0; i < powerList.Length; i++)
        {
            if(powerList[i] == _power){
                duplicateRerolls +=1;
                if(duplicateRerolls > maxDuplicateRerolls) {return null;}

                return RollRandomPower();
            }
        }
        return _power;
    }

    int CalculateTotalWeight(){
        totalWeight = 0;

        for (int i = 0; i < allPowers.Length; i++)
        {
            totalWeight += allPowers[i].dropWeight;
        }

        return totalWeight;
    }
}
