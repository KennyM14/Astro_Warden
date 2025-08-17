using UnityEngine;

public class EnemyCollisionHandler : MonoBehaviour
{
    [Header("Efecto de impacto")]
    [SerializeField] private GameObject impactVFX;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Bullet bullet = collision.GetComponent<Bullet>();
        if (bullet != null && gameObject.activeSelf)
        {
            if (impactVFX != null)
            {
                GameObject vfxInstance = Instantiate(impactVFX, collision.transform.position, Quaternion.identity);
                Destroy(vfxInstance, 1f);
            }

            bullet.ReturnToPool();
            EnemyPool.Instance.ReturnEnemy(gameObject); 
        }
    }

}
