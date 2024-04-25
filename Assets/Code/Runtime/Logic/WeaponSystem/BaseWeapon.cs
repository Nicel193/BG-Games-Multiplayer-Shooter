using Code.Runtime.Configs;
using Fusion;
using UnityEngine;

namespace Code.Runtime.Logic.WeaponSystem
{
    public abstract class BaseWeapon : NetworkBehaviour
    {
        [SerializeField] protected Transform spawnBulletPoint;
        
        protected Bullet BulletPrefab;
        protected int Damage;
        protected int ShootForce;

        private float _shootInterval;
        private float _shootTimer;
        
        public virtual void Initialize(BaseWeaponConfig baseWeaponConfig)
        {
            BulletPrefab = baseWeaponConfig.BulletPrefab;
            Damage = baseWeaponConfig.Damage;
            ShootForce = baseWeaponConfig.ShootForce;
            
            _shootInterval = baseWeaponConfig.ShootInterval;
        }
        
        public override void FixedUpdateNetwork()
        {
            if (_shootTimer < _shootInterval)
                _shootTimer += Runner.DeltaTime;
        }

        public void Shoot(Vector2 direction)
        {
            if (_shootTimer >= _shootInterval)
            {
                ShootImplementation(direction);
                
                _shootTimer = 0f;
            }
        }
        
        protected abstract void ShootImplementation(Vector2 direction);
    }
}