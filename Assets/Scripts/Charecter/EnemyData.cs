using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Enemy", menuName = "New Charecter/New Enemy")]
public class EnemyData : CharecterData
{
    [field :SerializeField] public double damage {get; protected set;}
    [field :SerializeField] public int xpDrop {get; protected set;}
}
