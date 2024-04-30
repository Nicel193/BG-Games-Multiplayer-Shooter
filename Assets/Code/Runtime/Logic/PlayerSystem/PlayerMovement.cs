using Code.Runtime.Configs;
using Fusion;
using UnityEngine;
using Zenject;

namespace Code.Runtime.Logic.PlayerSystem
{
    [RequireComponent(typeof(Rigidbody2D), typeof(PlayerAnimator))]
    public class PlayerMovement : NetworkBehaviour
    {
        private const int OppositeAngle = 180;
        
        private PlayerAnimator _playerAnimator;
        private float _moveSpeed;
        
        private void Awake() =>
            _playerAnimator = GetComponent<PlayerAnimator>();

        public override void Spawned()
        {
            DiContainer diContainer = FindObjectOfType<SceneContext>().Container;
            PlayerConfig playerConfig = diContainer.Resolve<PlayerConfig>();

            _moveSpeed = playerConfig.MoveSpeed;
        }

        public override void FixedUpdateNetwork()
        {
            if (GetInput(out NetworkInputData data))
            {
                data.MoveDirection.Normalize();
                data.ShootDirection.Normalize();

                float playerRotation = data.ShootDirection.x >= 0 ? 0 : OppositeAngle;
                Vector3 direction = Runner.DeltaTime * _moveSpeed * data.MoveDirection;
                
                transform.eulerAngles = new Vector3(0f, playerRotation, 0f);
                transform.position += direction;

                PlayAnimation(data.MoveDirection);
            }
        }

        private void PlayAnimation(Vector3 moveDirection)
        {
            if (moveDirection == Vector3.zero)
                _playerAnimator.PlayIdle();
            else
                _playerAnimator.PlayRun();
        }
    }
}
