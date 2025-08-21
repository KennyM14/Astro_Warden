using UnityEngine;

public class AutoShoot : MonoBehaviour
{
    [Header("Shooting Settings")]
    public float fireRate = 0.5f;
    public float detectionRadius = 5f;
    public LayerMask enemyLayer;

    private float fireCooldown = 0f;
    private ShooterManager shooterManager;

    void Awake()
    {
        shooterManager = GetComponent<ShooterManager>();
    }

    void Update()
    {
        fireCooldown -= Time.deltaTime;

        if (DetectEnemiesNearby() && fireCooldown <= 0f)
        {
            shooterManager.ShootAll(); // Dispara desde todos los Shooter registrados
            fireCooldown = fireRate;
        }
    }

    bool DetectEnemiesNearby()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, detectionRadius, enemyLayer);
        if (enemies.Length > 0)
        {
            return true;
        }
        return false;

    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }

}
