using UnityEngine;
using System.Collections.Generic;

// This is the power slot container will need refactor in future
public class PowersAdquiredContainer : MonoBehaviour
{
    [field : SerializeField] public GameObject slotPrefab {get; private set;}
    [field : SerializeField] public Dictionary<PowerData,PowerAdquiredSlot> powerSlots = new Dictionary<PowerData,PowerAdquiredSlot>();
    [field : SerializeField] public Dictionary<PowerData,Power> powers = new Dictionary<PowerData,Power>();
    [field : SerializeField] public PowerSelectionSlot[] selectionSlots {get;private set;}
    [field : SerializeField] public int numberOfPrioritySlots {get;private set;}
    public int numberOfPowersToSelect =0;

    private Transform player;
    PowerRandomizer powerRandomizer;
    [SerializeField] GameObject powerWindow;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform; // ??? Change in future
        powerRandomizer = GetComponent<PowerRandomizer>();
        AddPower(player.GetComponent<Player>().playerClass.startingPower);
        RollPowers();
    }

    public void RollPowers()
    {
        powerWindow.SetActive(true);
        Time.timeScale = 0; //pauses game
        
        //Roll powers;
        PowerData[] powerDatas = powerRandomizer.GetPowers(selectionSlots.Length,numberOfPrioritySlots);
        for (int i = 0; i < selectionSlots.Length; i++)
        {
            if(powerDatas[i]==null){
                selectionSlots[i].gameObject.SetActive(false);
                continue;
            }

            int rank = 0;
            if (powers.ContainsKey(powerDatas[i])) 
            {
               rank = powers[powerDatas[i]].rank;
            }
            selectionSlots[i].gameObject.SetActive(true);
            selectionSlots[i].UpdatePowerSlot(powerDatas[i],rank);
        }
    }

    //1# Checks if the power is already learned.If not, isntantiates the icon and power , else ranks it up.
    public void AddPower(PowerData power)
    {
        if(power is null){return;}

        if(powers.ContainsKey(power))
        {
            print("rank up");
            powers[power].RankUP();
            powerSlots[power].UpdateSlot(power,powers[power]);
            return;
        }
        
        PowerAdquiredSlot slot = Instantiate(slotPrefab,transform.position,Quaternion.identity,transform).GetComponent<PowerAdquiredSlot>();
        slot.Initialize(power);
        powerSlots.Add(power,slot);

        Power powerGO = Instantiate(power.powerPrefab,player.position,Quaternion.identity,player.Find("Powers")).GetComponent<Power>();
        powerGO.Initialize(power);
        powers.Add(power,powerGO);
    }
}