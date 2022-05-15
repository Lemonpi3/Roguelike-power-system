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
            Debug.Log($"Dealt: {damage} to {other.name} as All");
            return;
        }

        if(other.tag == affectedTag)
        {
            Debug.Log($"Dealt: {damage} to {other.name} as {affectedTag}");
            return;
        }
    }
}