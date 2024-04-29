using UnityEngine;

namespace Code.Runtime.Services.InputService
{
    public interface IInputService
    {
        Vector3 MoveDirection { get; }
        Vector3 ShootDirection { get; }
        bool IsShoot { get; }
        void UpdateInputData();
    }
}