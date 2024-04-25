using System;
using Code.Runtime.Configs;
using Code.Runtime.Logic.PlayerSystem;
using Fusion;
using UnityEngine;

namespace Code.Runtime.Logic.Enemies
{
    [RequireComponent(typeof(EnemyMovement))]
    public class BaseEnemy : NetworkBehaviour, IDamageable
    {
        private EnemyMovement _enemyMovement;
        
        private float _attackInterval;
        private float _health;
        private float _attackTimer;
        private int _damage;

        private void Awake()
        {
            _enemyMovement = GetComponent<EnemyMovement>();
        }

        public void Initialize(BaseEnemyConfig baseEnemyConfig, Transform target)
        {
            _damage = baseEnemyConfig.Damage;
            _health = baseEnemyConfig.MaxHealth;
            _attackInterval = baseEnemyConfig.AttackInterval;
            
            _enemyMovement.Initialize(baseEnemyConfig, target);
        }

        public override void FixedUpdateNetwork()
        {
            if (_attackTimer < _attackInterval)
                _attackTimer += Runner.DeltaTime;
        }

        public void Damage(int damage)
        {
            if(damage <= 0) return;
            
            _health -= damage;

            if (_health <= 0)
            {
                NetworkObject networkObject = GetComponent<NetworkObject>();

                Runner.Despawn(networkObject);
            }
        }

        private void OnCollisionEnter(Collision other)
        {
            Debug.Log(other.transform.name);
        }
    }
}