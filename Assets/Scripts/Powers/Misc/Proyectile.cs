using UnityEngine;

public class Proyectile : MonoBehaviour
{
    float lifeSpan = 1;
    int damage = 0;
    bool isPircing;
    Rigidbody2D rb;

    public void InitializeProyectile(int _damage,float _lifeSpan,float _speed,float proyectileScale,Vector3 _target)
    {
        transform.localScale = Vector3.one * proyectileScale;
        damage = _damage;
        lifeSpan = _lifeSpan;

        rb = GetComponent<Rigidbody2D>();
        Vector2 direction = _target - transform.position;
        rb.AddForce(direction.normalized * _speed);
    }

    public void Update()
    {
        lifeSpan -= Time.deltaTime;
        if(lifeSpan <= 0){ Destroy(gameObject); }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy")
        {
            // Debug.Log($"Dealt: {damage} to {other.name}");
            if(!isPircing)
            {
                Destroy(gameObject);
            }
        }
    }
}
