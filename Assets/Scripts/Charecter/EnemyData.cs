using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Enemy", menuName = "New Charecter/New Enemy")]
public class EnemyData : CharecterData
{
    [field :SerializeField] public double damage {get; private set;}
    [field :SerializeField] public int xpDrop {get; private set;}
}
