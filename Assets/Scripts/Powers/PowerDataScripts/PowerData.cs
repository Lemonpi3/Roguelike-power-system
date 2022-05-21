using UnityEngine;

[CreateAssetMenu(fileName = "New Power",menuName ="Powers/New Power")]

//Base Powers Data class
public class PowerData : ScriptableObject
{
    //UI Configs
    [field : Header("UI Configs")]

    [field : SerializeField] public string powerName {get; private set;}
    [field : SerializeField, TextArea(4,4), Tooltip("Power Description per rank starts at 0")] public string[] powerDescription {get; private set;}

    [field : SerializeField,] public Sprite icon {get; private set;}
    [field : SerializeField] public Sprite iconBorder {get; private set;}
    [field : SerializeField] public Color powerSelectionColor {get; private set;}
    //Base Power
    [field : Header("Base Power Configs")]
    
    [field : SerializeField] public GameObject powerPrefab {get; private set;}
    [field : SerializeField] public double basePowerDamage {get; private set;}
    [field : SerializeField , Tooltip("For % buffs, how much % you want to modify")] public double basePowerModifier {get; private set;}
    [field : SerializeField, Tooltip("Attack/Buff interval every Xs")] public float baseAttackSpeed {get; private set;}
    [field : SerializeField, Tooltip("Tag that the power will affect/damage (Player,Enemy,All as default Options)")] public string affectTag;
    //Scaleing Configs
    [field : Header("Level-up & Power rank up Configs")]

    [field : SerializeField] public int maxRank {get; private set;}

    [field : SerializeField,Tooltip("% Increase per player level")] 
    public double dmgUpPerLevel {get; private set;}

    [field : SerializeField,Tooltip("+ dmg acoording to rank, starts adding at rank 2 (indx 0 of this list),if max rank > this list lenght,when it reaches the last value,it will keep adding the las value of this list")] 
    public int[] dmgUpPerRank {get; private set;}

    [field : SerializeField, Tooltip("+ modifier acoording to rank, starts adding at rank 2 (indx 0 of this list),if max rank > this list lenght,when it reaches the last value,it will keep adding the las value of this list")] 
    public double[] powerModifierPerRank {get; private set;}

    [field : SerializeField, Tooltip("divides base attack speed by the corresponding item on the list starting at rank 2 (indx 0 of this list)")] 
    public float[] attackSpeedPerRankModifier {get; private set;}
}
public enum PowerType {Proyectile, Constant, Orbiting, Buff, Temporal}
public enum StatsTypes {HP, Regen , XPgain, Damage, Amount, Speed}
public enum CharacterTypes {Player, EnemySmall, EnemyMed, EnemyBig}