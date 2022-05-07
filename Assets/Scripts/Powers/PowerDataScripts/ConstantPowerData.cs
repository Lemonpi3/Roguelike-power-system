using UnityEngine;

[CreateAssetMenu(fileName = "New Constant Power",menuName ="Powers/New Constant Power")]
public class ConstantPowerData : PowerData
{
    //Constant Config
    [field : Header("Constant Configs")]
    [field : SerializeField] public GameObject area {get; private set;}
    [field : SerializeField] public float areaSizeScale {get; private set;}
    [field : SerializeField,Tooltip("Area position offset, by default is centered on charecter")] public Vector3 posOffSet {get; private set;}
    [field : SerializeField,Tooltip("Area rotation offset")] public Vector3 rotationOffSet {get; private set;}

    [field : Header("Level-up & Power rank up Configs")]

    [field : SerializeField, Tooltip("Adds : areaSizeScale * this  to the area size")] public float[] areaSizeRankIncrease {get; private set;}

    //This is just to set the powerType
    [field : SerializeField] public readonly PowerType powerType = PowerType.Constant;
}
