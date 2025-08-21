using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public float lifeTime = 3f;
    private Rigidbody2D rb;
    private float lifeTimer;
    private bool hasHit; 
    private Collider2D col;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
    }

    void OnEnable()
    {
        // reiniciar cada vez que la bala sale del pool
        hasHit = false;
        if (col != null) col.enabled = true;
        lifeTimer = lifeTime;
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
        if (hasHit) return;

        if (gameObject.layer == LayerMask.NameToLayer("PlayerBullet") && other.CompareTag("Enemy"))
        {
            hasHit = true;
            col.enabled = false;

            var enemy = other.GetComponent<EnemyCollisionHandler>();
            if (enemy != null)
            {
                enemy.TakeDamage(1);
            }

            ReturnToPool();
        }

        if (gameObject.layer == LayerMask.NameToLayer("EnemyBullet") && other.CompareTag("Player"))
        {
            hasHit = true;
            col.enabled = false;

            var player = other.GetComponent<PlayerHealth>();
            if (player != null)
            {
                player.TakeDamage(1);
            }
            ReturnToPool();
        }
    }

    public void ReturnToPool()
    {
        rb.velocity = Vector2.zero; 
        if (col != null) col.enabled = false;
        BulletPool.Instance.ReturnBullet(gameObject);
    }
}
