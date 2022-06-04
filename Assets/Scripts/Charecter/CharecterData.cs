using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharecterData : ScriptableObject
{
    [field : SerializeField] public string charecterName {get; protected set;}
    [field : SerializeField] public string charecterDescription {get; protected set;}

    [field : SerializeField] public Sprite charecterSprite {get; protected set;}

    [field : SerializeField] public CharacterTypes characterType {get; protected set;}

    [field : SerializeField] public double hp {get; protected set;}
    [field : SerializeField] public float moveSpeed {get; protected set;}

    [field : Header("Inital Stat Modifiers")]
    [field : SerializeField] public double moveSpeedModifier {get; protected set;}
    [field : SerializeField] public double hpModifier {get; protected set;}
}
