using Code.Runtime.Configs;
using Code.Runtime.Logic.PlayerSystem;
using Fusion;
using UnityEngine;

namespace Code.Runtime.Logic.WeaponSystem.Types
{
    public abstract class BaseWeapon : NetworkBehaviour
    {
        [SerializeField] protected Transform spawnBulletPoint;
        
        protected Bullet BulletPrefab;
        protected int Damage;
        protected int ShootForce;

        private PlayerData _playerData;
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

        public void Attack(Vector2 direction)
        {
            if (_shootTimer >= _shootInterval)
            {
                AttackImplementation(direction);
                
                _shootTimer = 0f;
            }
        }
        
        protected abstract void AttackImplementation(Vector2 direction);
    }
}