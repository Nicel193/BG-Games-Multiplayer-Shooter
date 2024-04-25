using Code.Runtime.Configs;
using Fusion;
using UnityEngine;

namespace Code.Runtime.Logic.Enemies
{
    public abstract class EnemyAttack : NetworkBehaviour
    {
        protected int Damage;
        protected Transform Target;

        private EnemyMovement _enemyMovement;
        private float _attackInterval;
        private float _attackTimer;

        public void Initialize(BaseEnemyConfig baseEnemyConfig, Transform target, EnemyMovement enemyMovement)
        {
            Target = target;
            Damage = baseEnemyConfig.Damage;
            
            _attackInterval = baseEnemyConfig.AttackInterval;
            _enemyMovement = enemyMovement;
        }
        
        public override void FixedUpdateNetwork()
        {
            if(_enemyMovement == null) return;

            if (_attackTimer < _attackInterval)
            {
                _attackTimer += Runner.DeltaTime;
            }
            else
            {
                if (_enemyMovement.IsAttackPosition)
                {
                    AttackImplementation();

                    _attackTimer = 0;
                }
            }
        }

        protected abstract void AttackImplementation();
    }
}