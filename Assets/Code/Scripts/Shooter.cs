using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] Transform muzzleTransform;

    [Header("Bullet Data")]
    [SerializeField] int bullets;
    [SerializeField] int maxBullets;
    
    [SerializeField] float bulletForce;

    [SerializeField] GameObject bulletPrefab;

    bool HasAmmo() => bullets > 0;

    void Reload() => bullets = maxBullets;

    void Shoot()
    {
        if (!HasAmmo())
        {
            return;
        }
        GameObject spawnedBullet = SpawnBullet();
        LaunchBullet(spawnedBullet);
    }
    GameObject SpawnBullet()
    {
        return Instantiate(bulletPrefab, transform.position, Quaternion.identity);
    }
    void LaunchBullet(GameObject bullet)
    {
        Vector3 direction = (muzzleTransform.position - transform.position).normalized;
        bullet.GetComponent<Rigidbody>().AddForce(bulletForce * direction, ForceMode.Impulse);
    }
}
