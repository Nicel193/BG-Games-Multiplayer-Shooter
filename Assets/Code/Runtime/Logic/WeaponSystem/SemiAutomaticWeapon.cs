using UnityEngine;

namespace Code.Runtime.Logic.WeaponSystem
{
    public class SemiAutomaticWeapon : BaseWeapon
    {
        protected override void ShootImplementation(Vector2 direction)
        {
            IBullet bullet = Runner.Spawn(BulletPrefab, spawnBulletPoint.position, Quaternion.identity);
            
            bullet.Initialize(Damage);
            bullet.Move(direction, ShootForce);
        }
    }
}