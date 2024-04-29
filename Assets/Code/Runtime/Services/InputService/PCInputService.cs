using UnityEngine;

namespace Code.Runtime.Services.InputService
{
    public class PCInputService : IInputService
    {
        public Vector3 MoveDirection { get; private set; }
        public Vector3 ShootDirection { get; private set; }
        public bool IsShoot { get; private set; }

        public void UpdateInputData()
        {
            MoveDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            
            Vector3 screenCenter = new Vector3(Screen.width / 2f, Screen.height / 2f, 0f);
            Vector3 mousePosition = Input.mousePosition;
            Vector3 direction = mousePosition - screenCenter;

            ShootDirection = direction;
            
            IsShoot = Input.GetMouseButton(0);
        }
    }
}