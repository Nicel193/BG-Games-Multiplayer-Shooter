using Code.Runtime.Configs;
using Fusion;
using UnityEngine;
using Zenject;

namespace Code.Runtime.Logic.PlayerSystem
{
    public class CameraFollow : MonoBehaviour, ICameraFollow
    {
        private Transform _target;
        private Vector3 _cameraOffset;
        private float _cameraSmoothSpeed;

        [Inject]
        public void Construct(PlayerConfig playerConfig)
        {
            _cameraOffset = playerConfig.CameraOffset;
            _cameraSmoothSpeed = playerConfig.CameraSmoothSpeed;
        }
        
        public void SetTarget(Transform target) =>
            _target = target;

        void LateUpdate()
        {
            if (_target == null)
                return;

            Vector3 desiredPosition = _target.position + _cameraOffset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, _cameraSmoothSpeed * Time.deltaTime);
            transform.position = smoothedPosition;
        }
    }
}