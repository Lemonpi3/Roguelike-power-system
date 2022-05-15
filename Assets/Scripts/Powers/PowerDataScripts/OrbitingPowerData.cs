using UnityEngine;

[CreateAssetMenu(fileName = "New Orbiting Power",menuName ="Powers/New Orbiting Power")]

public class OrbitingPowerData : PowerData
{
    //Orbiting Config
    [field : Header("Orbiting Config")]
    [field : SerializeField] public GameObject orbitingObj {get; private set;}
    [field : SerializeField] public float orbitingObjSizeScale {get; private set;}
    [field : SerializeField,Tooltip("Distance from charecter that the objs will orbitate")] public float rotationDistance {get; private set;}
    [field : SerializeField,Tooltip("Time they will take to do a lap"),Range(0.01f,1)] public float orbitSpeed {get; private set;}
    [field : SerializeField] public int numberOfOrbitingObjs {get; private set;}
    
    [field : SerializeField, Tooltip("Number of objs added per rank")] public int[] numberExtraObjsPerRank {get; private set;}

    //This is just to set the powerType
    [field : SerializeField] public readonly PowerType powerType = PowerType.Orbiting;
}
