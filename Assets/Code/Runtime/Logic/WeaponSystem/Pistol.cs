using UnityEngine;

namespace Code.Runtime.Logic.WeaponSystem
{
    public class Pistol : BaseWeapon
    {
        public override void Shoot(Vector2 direction)
        {
            IBullet bullet = Runner.Spawn(bulletPrefab, spawnBulletPoint.position, Quaternion.identity);
            
            bullet.Initialize(damage);
            bullet.Move(direction, shootForce);
        }
    }
}