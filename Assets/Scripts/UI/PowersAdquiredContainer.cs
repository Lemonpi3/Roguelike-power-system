using UnityEngine;
using System.Collections.Generic;

public class PowersAdquiredContainer : MonoBehaviour
{
    [field : SerializeField] public GameObject slotPrefab {get; private set;}
    [field : SerializeField] public Dictionary<PowerData,PowerAdquiredSlot> powerSlots = new Dictionary<PowerData,PowerAdquiredSlot>();
    [field : SerializeField] public Dictionary<PowerData,Power> powers = new Dictionary<PowerData,Power>();

    private Transform player;

    void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    //1# Checks if the power is already learned.If not, isntantiates the icon and power , else ranks it up.
    public void AddPower(PowerData power)
    {
        if(power is null){return;}

        if(powers.ContainsKey(power))
        {
            powers[power].RankUP();
            powerSlots[power].UpdateSlot(power,powers[power]);
        }
        
        PowerAdquiredSlot slot = Instantiate(slotPrefab,transform.position,Quaternion.identity,transform).GetComponent<PowerAdquiredSlot>();
        slot.Initialize(power);
        powerSlots.Add(power,slot);

        Power powerGO = Instantiate(power.powerPrefab,Vector2.zero,Quaternion.identity,player).GetComponent<Power>();
        powerGO.Initialize(power);
        powers.Add(power,powerGO);
    }
}