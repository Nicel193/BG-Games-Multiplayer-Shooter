using Code.Runtime.Configs;
using Fusion;
using UnityEngine;

namespace Code.Runtime.Logic.Enemies
{
    public class EnemyMovement : NetworkBehaviour
    {
        private Transform _target;
        private float _moveSpeed;
        private float _stoppingDistance;

        public void Initialize(BaseEnemyConfig baseEnemyConfig, Transform target)
        {
            _moveSpeed = baseEnemyConfig.MoveSpeed;
            _stoppingDistance = baseEnemyConfig.StoppingDistance;
            _target = target;
        }

        public override void FixedUpdateNetwork()
        {
            if (_target != null)
            {
                Vector3 direction = (_target.position - transform.position).normalized;
            
                float distanceToPlayer = Vector3.Distance(transform.position, _target.position);

                if (distanceToPlayer > _stoppingDistance)
                {
                    Vector3 movement = direction * _moveSpeed * Time.deltaTime;

                    transform.Translate(movement);
                }
            }
        }
    }
}