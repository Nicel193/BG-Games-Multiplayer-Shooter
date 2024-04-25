using Code.Runtime.Configs;
using Code.Runtime.Logic.PlayerSystem;
using Fusion;
using UnityEngine;

namespace Code.Runtime.Logic.Enemies
{
    [RequireComponent(typeof(EnemyMovement), typeof(CapsuleCollider2D))]
    public class BaseEnemy : NetworkBehaviour, IDamageable
    {
        [SerializeField] private EnemyAnimator enemyAnimator;
        
        private EnemyMovement _enemyMovement;
        private CapsuleCollider2D _enemyCollider;

        private float _attackInterval;
        private float _health;
        private float _attackTimer;
        private int _damage;

        private void Awake()
        {
            _enemyMovement = GetComponent<EnemyMovement>();
            _enemyCollider = GetComponent<CapsuleCollider2D>();
        }

        public void Initialize(BaseEnemyConfig baseEnemyConfig, Transform target)
        {
            _damage = baseEnemyConfig.Damage;
            _health = baseEnemyConfig.MaxHealth;
            _attackInterval = baseEnemyConfig.AttackInterval;

            _enemyMovement.Initialize(baseEnemyConfig, target, enemyAnimator.transform);
        }

        public override void FixedUpdateNetwork()
        {
            if (_attackTimer < _attackInterval)
            {
                _attackTimer += Runner.DeltaTime;
            }
            else
            {
                if (_enemyMovement.IsAttackPosition)
                {
                    enemyAnimator.PlayAttack();

                    _attackTimer = 0;
                }
            }
        }

        public void Damage(int damage)
        {
            if (damage <= 0) return;

            _health -= damage;

            enemyAnimator.PlayHit();

            if (_health <= 0)
            {
                if (TryGetComponent(out NetworkObject networkObject))
                {
                    enemyAnimator.PlayDeath();
                    _enemyMovement.StopMove();

                    _enemyCollider.enabled = false;
                }
            }
        }
    }
}