using Code.Runtime.Configs;
using Code.Runtime.Logic.PlayerSystem;
using Fusion;
using UnityEngine;

namespace Code.Runtime.Logic.Enemies
{
    [RequireComponent(typeof(EnemyMovement), typeof(CapsuleCollider2D))]
    public class Enemy : NetworkBehaviour, IDamageable
    {
        [SerializeField] private EnemyAnimator enemyAnimator;
        [SerializeField] private EnemyAttack enemyAttack;

        private EnemyMovement _enemyMovement;
        private CapsuleCollider2D _enemyCollider;
        private float _health;
        
        private void Awake()
        {
            _enemyMovement = GetComponent<EnemyMovement>();
            _enemyCollider = GetComponent<CapsuleCollider2D>();
        }

        public void Initialize(BaseEnemyConfig baseEnemyConfig, Transform target)
        {
            _enemyMovement.Initialize(baseEnemyConfig, target, enemyAnimator.transform);
            enemyAttack.Initialize(baseEnemyConfig, target, _enemyMovement);

            _health = baseEnemyConfig.MaxHealth;
        }
        
        public void Damage(int damage)
        {
            if (damage <= 0) return;

            _health -= damage;

            enemyAnimator.PlayHit();

            if (IsDead())
            {
                if (TryGetComponent(out NetworkObject networkObject))
                {
                    enemyAnimator.PlayDeath();
                    _enemyMovement.StopMove();

                    _enemyCollider.enabled = false;
                }
            }
        }

        public bool IsDead() => _health <= 0;
    }
}