using UnityEngine;

public class Proyectile : MonoBehaviour
{
    float lifeSpan = 1;
    double damage = 0;
    bool isPircing;
    Rigidbody2D rb;
    Player player;

    public void InitializeProyectile(double _damage,float _lifeSpan,float _speed,float proyectileScale,Vector3 _target,Player _player)
    {
        player = _player;
        transform.localScale = Vector3.one * proyectileScale * (float)player.powerSizeModifier;
        damage = _damage * player.powerDamageModifier;
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
            if(!isPircing)
            {
                Destroy(gameObject);
            }
        }
    }
}
