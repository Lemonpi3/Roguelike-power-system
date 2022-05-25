using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageArea : MonoBehaviour
{
    protected float tickRate = 1;
    protected float counter;
    protected double damage =1;
    protected string affectedTag;
    protected Player player;

    protected Stack<Collider2D> hitted= new Stack<Collider2D>();

    public virtual void UpdateAreaStats(double newDamage, float newTickRate,float newScale,Player _player = null,Vector3 newPosOffset=default(Vector3),Vector3 newRotationOffset=default(Vector3),string _affectedTag ="Enemy")
    {
        player = _player;
        damage = newDamage;
        tickRate = newTickRate;
        transform.localScale = Vector3.one * newScale;
        transform.localRotation = Quaternion.Euler(newRotationOffset);
        transform.localPosition = newPosOffset;
        affectedTag = _affectedTag;
    }

    protected virtual void Update()
    {
        counter -= Time.deltaTime;

        if(counter > -.1f) return;
        
        counter = tickRate;

        if(hitted.Count == 0) return;

        hitted = new Stack<Collider2D>();
    }

    protected virtual void OnTriggerStay2D(Collider2D other)
    {
        if (tickRate > 0 || hitted.Contains(other)) return;

        if(affectedTag == "All")
        {
            other.GetComponent<Enemy>().TakeDamage(DealDamage(),player);
            Debug.Log($"Dealt: {DealDamage()} to {other.name} as All");
            hitted.Push(other);
            return;
        }
        if(other.tag == affectedTag)
        {
            other.GetComponent<Enemy>().TakeDamage(DealDamage(),player);
            Debug.Log($"Dealt: {DealDamage()} to {other.name} as {affectedTag}");
            hitted.Push(other);
            return;
        }
    }

    protected double DealDamage()
    {
        return player != null ? damage * player.powerDamageModifier : damage;
    }
}
