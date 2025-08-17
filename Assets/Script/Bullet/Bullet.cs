using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public float lifeTime = 3f;
    private Rigidbody2D rb;
    private float lifeTimer;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Direction()
    {
        rb.velocity = transform.up * speed; 
        lifeTimer = lifeTime;
    }

    void Update()
    {
        lifeTimer -= Time.deltaTime;
        if (lifeTimer <= 0f)
        {
            ReturnToPool();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (gameObject.layer == LayerMask.NameToLayer("PlayerBullet") && other.CompareTag("Enemy"))
        {
            ReturnToPool();
            EnemyPool.Instance.ReturnEnemy(gameObject); 
        }

        if (gameObject.layer == LayerMask.NameToLayer("EnemyBullet") && other.CompareTag("Player"))
        {
            ReturnToPool();
            //Destroy(other.gameObject);
            Debug.Log("Hit"); 
        }
    }

    public void ReturnToPool()
    {
        rb.velocity = Vector2.zero; // ← CORREGIDO
        BulletPool.Instance.ReturnBullet(gameObject);
    }
}
