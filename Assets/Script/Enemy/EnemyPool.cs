using UnityEngine;
using UnityEngine.Pool;

public class EnemyPool : MonoBehaviour
{
    public static EnemyPool Instance;

    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private int defaultCapacity = 50;
    [SerializeField] private int maxSize = 100;

    private ObjectPool<GameObject> pool;

    void Awake()
    {
        Instance = this;

        pool = new ObjectPool<GameObject>(
            CreateEnemy,
            OnGetFromPool,
            OnReleaseToPool,
            OnDestroyPooledObject,
            true,
            defaultCapacity,
            maxSize
        );
    }

    private GameObject CreateEnemy()
    {
        GameObject enemy = Instantiate(enemyPrefab);
        enemy.SetActive(false);
        return enemy;
    }

    private void OnGetFromPool(GameObject enemy)
    {
        enemy.SetActive(true);
    }

    private void OnReleaseToPool(GameObject enemy)
    {
        enemy.SetActive(false);
    }

    private void OnDestroyPooledObject(GameObject enemy)
    {
        Destroy(enemy);
    }

    public GameObject GetEnemy()
    {
        return pool.Get();
    }

    public void ReturnEnemy(GameObject enemy)
    {
        pool.Release(enemy);
    }
}
