using UnityEngine;

[CreateAssetMenu(fileName = "New Proyectile Power",menuName ="Powers/New Proyectile Power")]

public class ProyectilePowerData : PowerData
{
    //Proyectile Config
    [field : Header("Proyectile Configs")]
    [field : SerializeField] public GameObject proyectile {get; private set;}
    [field : SerializeField] public float proyectileSpeed {get; private set;}
    [field : SerializeField] public float proyectileDuration {get; private set;}

    [field : SerializeField] public float proyectileScale {get; private set;}

    [field : SerializeField] public int proyectilesFired {get; private set;}
    [field : SerializeField] public bool pircing {get; private set;}

    [field : Header("Level-up & Power rank up Configs"),
    Tooltip("Starts at rank 2 (counting from 1) ,if the list range is smaller than max rank number script will use the last index")]
    
    [field : SerializeField] public int[] proyectilesAddedPerRank {get; private set;}
    [field : SerializeField] public float[] proyectileExtraDuration {get; private set;}

    //This is just to set the powerType
    [field : SerializeField] public readonly PowerType powerType = PowerType.Proyectile;
}
