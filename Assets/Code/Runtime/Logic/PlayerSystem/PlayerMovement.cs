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
                Debug.Log(data.MoveDirection);
                
                data.MoveDirection.Normalize();

                Vector3 direction = Runner.DeltaTime * 5f * data.MoveDirection;

                transform.Translate(direction);
            }
        }
    }
}
