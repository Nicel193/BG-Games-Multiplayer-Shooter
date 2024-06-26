using Code.Runtime.Logic.WeaponSystem;
using UnityEngine;

namespace Code.Runtime.Logic.Enemies
{
    public class ShootEnemyAttack : EnemyAttack
    {
        [SerializeField] private Bullet bulletPrefab;
        [SerializeField] private float shootForce;
        
        protected override void AttackImplementation()
        {
            Vector3 direction = (Target.position - transform.position).normalized;
            IBullet bullet = Runner.Spawn(bulletPrefab, transform.position, Quaternion.identity);
            
            bullet.Initialize(Damage);
            bullet.Launch(direction, shootForce);
        }
    }
}