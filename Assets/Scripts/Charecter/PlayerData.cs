using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Player Data Class", menuName ="New Charecter/New Player Class")]
public class PlayerData : CharecterData
{

    [field : SerializeField] public PowerData startingPower {get; private set;}
    
    [field : SerializeField, Tooltip("% Hp regen per second")] public double hpRegenPercent {get; private set;}

    [field : Header("Initial Power Modifier Values")]

    [field : SerializeField] public double powerDamageModifier {get; private set;}
    [field : SerializeField] public double powerCooldownModifier {get; private set;}
    [field : SerializeField] public double powerSizeModifier {get; private set;}
    [field : SerializeField] public double powerAmountModifier {get; private set;}
}
