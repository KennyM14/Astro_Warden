using UnityEngine;
using UnityEngine.Pool; 

public class EnemyBulletPool : MonoBehaviour
{
    public static EnemyBulletPool Instance;

    [SerializeField] private GameObject bulletPrefab;
    private ObjectPool<GameObject> pool;

    void Awake()
    {
        Instance = this;

        pool = new ObjectPool<GameObject>(
            createFunc: () => Instantiate(bulletPrefab),
            actionOnGet: bullet => bullet.SetActive(true),
            actionOnRelease: bullet => bullet.SetActive(false),
            actionOnDestroy: bullet => Destroy(bullet),
            collectionCheck: false,
            defaultCapacity: 20,
            maxSize: 100
        );
    }

    public GameObject GetBullet()
    {
        return pool.Get();
    }

    public void ReturnBullet(GameObject bullet)
    {
        pool.Release(bullet);
    }

}
