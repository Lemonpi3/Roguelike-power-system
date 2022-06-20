using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }else instance = this;
    }

    [field : SerializeField] public double enemyHPModifier {get;private set;}
    [field : SerializeField] public double enemySpeedModifier {get;private set;}
    [field : SerializeField] public double enemySpawnSpeedModifier {get;private set;}
    [field : SerializeField] public int maxEnemyCount {get; set;}
    [field : SerializeField] public int enemyCount {get; set;}


    ///<summary>Modifies enemy HP modifier in an aditive way</summary>
    public void ModifyEnemy_HPModifier(double amount)
    {
        enemyHPModifier += amount;
        print($"Enemy HP Modifier changed to {enemyHPModifier}");
    }

    ///<summary>Modifies enemy Speed modifier in an aditive way</summary>
    public void ModifyEnemy_SpeedModifier(double amount)
    {
        enemySpeedModifier += amount;
        print($"Enemy Speed Modifier changed to {enemyHPModifier}");
    }
}
