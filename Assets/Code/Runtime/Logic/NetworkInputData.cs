using Fusion;
using UnityEngine;

namespace Code.Runtime.Logic
{
    public struct NetworkInputData : INetworkInput
    {
        public Vector3 MoveDirection;
        public Vector3 ShootDirection;
        public bool IsShoot;
    }
}