using UnityEngine;

namespace Code.Runtime.Logic.WeaponSystem.Types
{
    public class SemiAutomaticWeapon : BaseWeapon
    {
        protected override void AttackImplementation(Vector2 direction)
        {
            IBullet bullet = Runner.Spawn(BulletPrefab, spawnBulletPoint.position, Quaternion.identity);
            
            bullet.Initialize(Damage);
            bullet.Launch(direction, ShootForce, OnDamage);
        }
    }
}