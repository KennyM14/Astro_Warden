using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [HideInInspector]
    public EnemyConfig enemyConfig;
    [SerializeField] private SpriteRenderer _spriteRenderer; 
    private Move move;

    private void Start()
    {
        move = GetComponent<Move>();
        if (move != null && enemyConfig != null)
        {
            move.speed = enemyConfig.moveSpeed;
        }

        if (_spriteRenderer != null)
        {
            _spriteRenderer.sprite = enemyConfig.sprite; 
        }
    }
}
