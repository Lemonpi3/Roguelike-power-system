using UnityEngine;
using System.Collections.Generic;

public class PowersAdquiredContainer : MonoBehaviour
{
    [field : SerializeField] public GameObject slotPrefab {get; private set;}
    [field : SerializeField] public List<Power> powers;

    private Transform player;

    void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    //1# Checks if the power is already learned.If not, isntantiates the icon and power , else ranks it up.
    public void AddPower(PowerData power)
    {
        if(power is null){return;}

        foreach(Power _power in powers)
        {
            if(power == _power)
            {
                _power.RankUP();
                return;
            }
        }
    
        Instantiate(slotPrefab,transform.position,Quaternion.identity,transform).GetComponent<PowerAdquiredSlot>().Initialize(power);
        Power powerGO = Instantiate(power.powerPrefab,Vector2.zero,Quaternion.identity,player).GetComponent<Power>();
        powerGO.Initialize(power);
        powers.Add(powerGO);
    }
}
