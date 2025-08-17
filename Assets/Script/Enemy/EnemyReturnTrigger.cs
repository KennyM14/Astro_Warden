using UnityEngine;

public class EnemyReturnTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyPool.Instance.ReturnEnemy(other.gameObject);
        }
    }
}
