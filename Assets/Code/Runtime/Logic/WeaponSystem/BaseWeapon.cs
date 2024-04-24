using Fusion;
using UnityEngine;

namespace Code.Runtime.Logic.WeaponSystem
{
    public abstract class BaseWeapon : NetworkBehaviour
    {
        [SerializeField] protected Transform spawnBulletPoint;
        
        protected Bullet bulletPrefab;
        protected int damage;
        protected int shootForce;
        protected float shootInterval;
        
        private float _shootTimer;
        
        public override void FixedUpdateNetwork()
        {
            if (_shootTimer < shootInterval)
                _shootTimer += Runner.DeltaTime;
        }

        public void Shoot(Vector2 direction)
        {
            if (_shootTimer >= shootInterval)
            {
                ShootImplementation(direction);
                
                _shootTimer = 0f;
            }
        }
        
        protected abstract void ShootImplementation(Vector2 direction);
    }
}