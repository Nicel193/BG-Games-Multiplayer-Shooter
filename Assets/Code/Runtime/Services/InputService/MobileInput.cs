using System;
using SimpleInputNamespace;
using UnityEngine;

namespace Code.Runtime.Services.InputService
{
    public class MobileInput : MonoBehaviour, IInputService
    {
        public Vector3 MoveDirection { get; set; }
        public Vector3 ShootDirection { get; set; }
        public bool IsShoot { get; set; }

        [SerializeField] private Joystick moveJoystick;
        [SerializeField] private Joystick shootJoystick;

        private void Start()
        {
            // gameObject.SetActive(Application.isMobilePlatform);
        }

        public void UpdateInputData()
        {
            MoveDirection = moveJoystick.Value;
            if(!shootJoystick.Value.Equals(Vector2.zero)) ShootDirection = shootJoystick.Value;
            IsShoot = !shootJoystick.Value.Equals(Vector2.zero);
        }
    }
}