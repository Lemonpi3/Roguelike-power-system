using UnityEngine;
using System.Collections.Generic;

public class PowersAdquiredContainer : MonoBehaviour
{
    [field : SerializeField] public GameObject slotPrefab {get; private set;}
    [field : SerializeField] public Dictionary<PowerData,PowerAdquiredSlot> powerSlots = new Dictionary<PowerData,PowerAdquiredSlot>();
    [field : SerializeField] public Dictionary<PowerData,Power> powers = new Dictionary<PowerData,Power>();
    [field : SerializeField] public PowerSelectionSlot[] selectionSlots {get;private set;}
    [field : SerializeField] public int numberOfPrioritySlots {get;private set;}
    private Transform player;
    PowerRandomizer powerRandomizer;
    [SerializeField] GameObject powerWindow;

    void Start()
    {
        player = GameObject.Find("Player").transform;
        powerRandomizer = GetComponent<PowerRandomizer>();
        RollPowers();
    }

    public void RollPowers()
    {
        powerWindow.SetActive(true);
        Time.timeScale = 0; //pauses game
        
        //Set Priority Slots.
        for (int i = 0; i < numberOfPrioritySlots; i++)
        {
            PowerData powerData = powerRandomizer.GetPriortyPower();
            int rank = 0;
            if (powers.ContainsKey(powerData)) 
            {
               rank = powers[powerData].rank;
            }
            selectionSlots[i].UpdatePowerSlot(powerData,rank);
        }
        //Set Random Slots
        PowerData[] powerDatas = powerRandomizer.RollRandomPowers(selectionSlots.Length-numberOfPrioritySlots);
        for (int i = numberOfPrioritySlots; i < selectionSlots.Length; i++)
        {
            int rank = 0;
            if (powers.ContainsKey(powerDatas[i-numberOfPrioritySlots])) 
            {
               rank = powers[powerDatas[i-numberOfPrioritySlots]].rank;
            }
            selectionSlots[i].UpdatePowerSlot(powerDatas[i-numberOfPrioritySlots],rank);
        }
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