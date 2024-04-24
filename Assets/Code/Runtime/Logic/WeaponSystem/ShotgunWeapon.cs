using UnityEngine;

namespace Code.Runtime.Logic.WeaponSystem
{
    public class ShotgunWeapon : BaseWeapon
    {
        [SerializeField] private int pelletsCount = 5;
        [SerializeField] private float spreadAngle = 30f;

        protected override void ShootImplementation(Vector2 direction)
        {
            for (int i = 0; i < pelletsCount; i++)
            {
                IBullet bullet = Runner.Spawn(bulletPrefab, spawnBulletPoint.position, Quaternion.identity);
                
                Vector2 randomDirection = Quaternion.Euler(0, 0, Random.Range(-spreadAngle, spreadAngle)) * direction;

                bullet.Initialize(damage);
                bullet.Move(randomDirection, shootForce);
            }
        }
    }
}