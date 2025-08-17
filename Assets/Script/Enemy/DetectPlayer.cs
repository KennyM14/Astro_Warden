using UnityEngine;

public class DetectPlayer : MonoBehaviour
{
    [Header("Detection Settings")]
    public Transform player;                  // referencia al Player
    public float detectionRange = 8f;         // rango de visión
    public float detectionAngle = 90f;        // ángulo de visión
    public LayerMask playerLayer;             // capa del Player
    public LayerMask obstacleLayers;

    [Header("Shooting Settings")]
    public float fireRate = 1f;
    private float fireCooldown;
    private Shooter[] shooters;
    
    void Awake()
    {
        player = PlayerController.Instance;
        shooters = GetComponentsInChildren<Shooter>();
    }

    void Update()
    {
        fireCooldown -= Time.deltaTime;

        if (CanSeePlayer() && fireCooldown <= 0f)
        {
            foreach (var shooter in shooters)
            {
                shooter.Shoot();
            }
            fireCooldown = fireRate;
        }
    }

    bool CanSeePlayer()
    {
        if (player == null) return false;

        // dirección y distancia al Player
        Vector3 directionToPlayer = player.position - transform.position;
        float distance = directionToPlayer.magnitude;

        if (distance > detectionRange) return false;

        // chequeo de ángulo
        float angle = Vector3.Angle(transform.up, directionToPlayer.normalized);
        if (angle > detectionAngle / 2f) return false;

        // raycast para línea de visión
        //RaycastHit2D hit = Physics2D.Raycast(transform.position, directionToPlayer.normalized, detectionRange, playerLayer | obstacleLayers);

        return true; //hit.collider != null && hit.collider.CompareTag("Player");
    }

    private void OnDrawGizmosSelected()
    {
        // gizmo de rango
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRange);

        // gizmo de ángulo de visión
        Vector3 leftLimit = Quaternion.Euler(0, 0, -detectionAngle / 2f) * transform.up;
        Vector3 rightLimit = Quaternion.Euler(0, 0, detectionAngle / 2f) * transform.up;
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(transform.position, leftLimit * detectionRange);
        Gizmos.DrawRay(transform.position, rightLimit * detectionRange);
    }
}
