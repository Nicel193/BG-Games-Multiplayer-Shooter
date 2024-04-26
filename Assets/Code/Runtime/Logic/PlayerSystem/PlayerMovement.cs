using System;
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

        [Inject]
        private void Construct(PlayerConfig playerConfig) =>
            _moveSpeed = playerConfig.MoveSpeed;

        public override void FixedUpdateNetwork()
        {
            if (GetInput(out NetworkInputData data))
            {
                data.MoveDirection.Normalize();
                data.ShootDirection.Normalize();

                float playerRotation = data.ShootDirection.x >= 0 ? 0 : OppositeAngle;
                Vector3 direction = Runner.DeltaTime * 5f * data.MoveDirection;
                
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
