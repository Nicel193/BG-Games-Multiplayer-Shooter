using Code.Runtime.Configs;
using Fusion;
using UnityEngine;
using Zenject;

namespace Code.Runtime.Logic.PlayerSystem
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovement : NetworkBehaviour
    {
        private float _moveSpeed;

        [Inject]
        private void Construct(PlayerConfig playerConfig)
        {
            _moveSpeed = playerConfig.MoveSpeed;
        }
        
        public override void FixedUpdateNetwork()
        {
            if (GetInput(out NetworkInputData data))
            {
                data.MoveDirection.Normalize();
                data.ShootDirection.Normalize();

                float playerRotation = data.ShootDirection.x >= 0 ? 0 : 180;
                Vector3 direction = Runner.DeltaTime * 5f * data.MoveDirection;
                
                transform.eulerAngles = new Vector3(0f, playerRotation, 0f);
                transform.position += direction;
            }
        }
    }
}
