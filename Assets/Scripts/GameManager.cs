using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [field : SerializeField] public static double enemyHPModifier {get;private set;}
    [field : SerializeField] public static double enemySpeedModifier {get;private set;}
    [field : SerializeField] public static double enemySpawnSpeedModifier {get;private set;}

    ///<summary>Modifies enemy HP modifier in an aditive way</summary>
    public static void ModifyEnemy_HPModifier(double amount)
    {
        enemyHPModifier += amount;
        print($"Enemy HP Modifier changed to {enemyHPModifier}");
    }

    ///<summary>Modifies enemy Speed modifier in an aditive way</summary>
    public static void ModifyEnemy_SpeedModifier(double amount)
    {
        enemySpeedModifier += amount;
        print($"Enemy Speed Modifier changed to {enemyHPModifier}");
    }
}
