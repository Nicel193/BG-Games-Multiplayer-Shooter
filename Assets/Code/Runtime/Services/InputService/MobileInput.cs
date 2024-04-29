using Fusion;
using SimpleInputNamespace;
using UnityEngine;

namespace Code.Runtime.Services.InputService
{
    public class MobileInput : NetworkBehaviour, IInputService
    {
        public Vector3 MoveDirection { get; set; }
        public Vector3 ShootDirection { get; set; }
        public bool IsShoot { get; set; }

        [SerializeField] private Joystick moveJoystick;
        [SerializeField] private Joystick shootJoystick;
        [SerializeField] private GameObject mobileInputField;

        private void Awake()
        {
            mobileInputField.SetActive(false);
        }

        public override void Spawned()
        {
            if (Application.isMobilePlatform)
                mobileInputField.SetActive(true);
        }

        public void UpdateInputData()
        {
            MoveDirection = moveJoystick.Value;
            if (!shootJoystick.Value.Equals(Vector2.zero)) ShootDirection = shootJoystick.Value;
            IsShoot = !shootJoystick.Value.Equals(Vector2.zero);
        }
    }
}