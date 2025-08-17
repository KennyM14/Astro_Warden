using UnityEngine;

public class Shooter : MonoBehaviour
{
    public Transform firePoint;
    public bool isEnemyShooter = false;

    public void Shoot()
    {
        GameObject bullet;

        if (isEnemyShooter)
        {
            bullet = EnemyBulletPool.Instance.GetBullet();
        }
        else
        {
            bullet = BulletPool.Instance.GetBullet();
        }

        bullet.transform.position = firePoint.position;
        bullet.transform.rotation = firePoint.rotation;

        Bullet bulletScript = bullet.GetComponent<Bullet>();
        if (bulletScript != null)
        {
            bulletScript.Direction();
        }
 
    }

}
