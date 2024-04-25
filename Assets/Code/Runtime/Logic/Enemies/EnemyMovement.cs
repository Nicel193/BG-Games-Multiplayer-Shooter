using System;
using Code.Runtime.Configs;
using Fusion;
using UnityEngine;

namespace Code.Runtime.Logic.Enemies
{
    public class EnemyMovement : NetworkBehaviour
    {
        public bool IsAttackPosition { get; private set; }

        private Transform _enemySpriteTransform;
        private Transform _target;
        private float _moveSpeed;
        private float _stoppingDistance;

        public void Initialize(BaseEnemyConfig baseEnemyConfig, Transform target, Transform enemySpriteTransform)
        {
            _enemySpriteTransform = enemySpriteTransform;
            _moveSpeed = baseEnemyConfig.MoveSpeed;
            _stoppingDistance = baseEnemyConfig.StoppingDistance;
            _target = target;
        }

        public void StopMove() =>
            _moveSpeed = 0;

        public override void FixedUpdateNetwork()
        {
            if (_target != null)
            {
                Vector3 direction = (_target.position - transform.position).normalized;
                float distanceToPlayer = Vector3.Distance(transform.position, _target.position);
                
                Rotation(direction);

                IsAttackPosition = distanceToPlayer <= _stoppingDistance;

                if (!IsAttackPosition)
                {
                    Vector3 movement = direction * _moveSpeed * Runner.DeltaTime;

                    transform.Translate(movement);
                }
            }
        }

        private void Rotation(Vector3 direction)
        {
            float playerRotation = direction.x >= 0 ? 0 : 180;

            _enemySpriteTransform.rotation = Quaternion.Euler(new Vector3(0f, playerRotation, 0f));
        }
    }
}