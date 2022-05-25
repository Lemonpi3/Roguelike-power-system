using UnityEngine;

public class OrbitObject : DamageArea
{
    protected override void Update()
    {
        base.Update();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(affectedTag == "All")
        {
            Debug.Log($"Dealt: {DealDamage()} to {other.name} as All");
            other.GetComponent<Stats>().TakeDamage(damage,player);
            return;
        }

        if(other.tag == affectedTag)
        {
            Debug.Log($"Dealt: {DealDamage()} to {other.name} as {affectedTag}");
            other.GetComponent<Stats>().TakeDamage(damage,player);
            return;
        }
    }
}
