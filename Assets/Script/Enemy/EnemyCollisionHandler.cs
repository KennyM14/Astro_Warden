using UnityEngine;

public class EnemyCollisionHandler : MonoBehaviour
{
    [Header("Efecto de impacto")]
    [SerializeField] private GameObject impactVFX;

    [Header("Enemy Health Settings")]
    [SerializeField] private int health = 1;

    public void TakeDamage(int amount)
    {
        health -= amount;

        if (impactVFX != null)
        {
            GameObject vfxInstance = Instantiate(impactVFX, transform.position, Quaternion.identity);
            Destroy(vfxInstance, 1f);
        }

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        EnemyPool.Instance.ReturnEnemy(gameObject);
        health = 1;
    }

}
