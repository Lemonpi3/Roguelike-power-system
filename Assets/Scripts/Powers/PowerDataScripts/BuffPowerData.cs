using UnityEngine;

[CreateAssetMenu(fileName = "New Buff Power",menuName ="Powers/New Buff Power")]

public class BuffPowerData : PowerData
{
    //Buff Config
    [field :Header("Buffs & Temporal Config")]
    [field : SerializeField] public StatsTypes[] statsToModify {get; private set;}
    [field : SerializeField] public CharacterTypes[] affectsCharacterTypes {get; private set;}

    [field : SerializeField] public bool temporal{get; private set;}
    [field : SerializeField] public float buffTemporalDuration{get; private set;}

    [field : SerializeField] public readonly PowerType powerType = PowerType.Buff;

}
