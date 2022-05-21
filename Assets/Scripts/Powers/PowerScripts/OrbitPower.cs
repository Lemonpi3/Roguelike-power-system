using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitPower : Power
{
    private List<OrbitObject> orbitObjects = new List<OrbitObject>();

    float orbitDistance = 1;
    float oribitSpeed = 10;

    OrbitingPowerData powerData;

    protected override void Start()
    {
        base.Start();

        powerData = (OrbitingPowerData)_power;

        if(powerData.powerType != PowerType.Orbiting)
        {
            Debug.LogWarning($"PowerType is not PowerType.Orbiting: {powerData.powerName}"); 
            return;
        }

        orbitDistance = powerData.rotationDistance;
        oribitSpeed = powerData.orbitSpeed;

        for (int i = 0; i < powerData.numberOfOrbitingObjs; i++)
        {
            AddNewOrbitObj();
        }

        UpdateObjectsPosition();
    }

    void Update()
    {
        transform.RotateAround(transform.position, Vector3.forward, oribitSpeed);
    }

    private void AddNewOrbitObj()
    {
        OrbitObject orbitObject = Instantiate(powerData.orbitingObj,transform.position,Quaternion.identity,transform).GetComponent<OrbitObject>();
        orbitObject.UpdateAreaStats(damage,attackSpeed,powerData.orbitingObjSizeScale * (float)player.powerSizeModifier,player,default,default,powerData.affectTag);
        orbitObjects.Add(orbitObject);
    }

    public override void RankUP()
    {
        base.RankUP();

        int numOfNewObjs = powerData.numberExtraObjsPerRank.Length >= rank-2 ? powerData.numberExtraObjsPerRank[rank-2] : powerData.numberExtraObjsPerRank[powerData.numberExtraObjsPerRank.Length-1];
        
        for (int i = 0; i < numOfNewObjs; i++)
        {
            AddNewOrbitObj();
        }

        UpdateObjectsPosition();
    }
    
    private void UpdateObjectsPosition()
    {
        int numObjects = orbitObjects.Count;

        if(numObjects <= 0) return;

        for (int i = 0; i < numObjects; ++i)
        {
            float theta = (2 * Mathf.PI / numObjects) * i;
            float x = Mathf.Cos(theta) * orbitDistance;
            float y = Mathf.Sin(theta) * orbitDistance;
            orbitObjects[i].transform.position= new Vector3(x,y, orbitObjects[i].transform.position.z);
        }
    }

    public override void UpdatePower()
    {
        foreach (OrbitObject obj in orbitObjects)
        {
            obj.UpdateAreaStats(damage,attackSpeed,powerData.orbitingObjSizeScale * (float)player.powerSizeModifier,player,default,default,powerData.affectTag);
        }
    }
}
