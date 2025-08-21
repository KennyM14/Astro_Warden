using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header("Player Health Settings")]
    [SerializeField] private int maxHealth = 5;
    [SerializeField] private int currentHealth;

    void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        Debug.Log($"Player recibió {amount} daño. Vida: {currentHealth}/{maxHealth}");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("El Player murió");
        // Aquí puedes desactivar el Player, mostrar GameOver, etc.
        gameObject.SetActive(false);
    }
}
