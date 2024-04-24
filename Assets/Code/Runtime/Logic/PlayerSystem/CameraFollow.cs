using Code.Runtime.Configs;
using UnityEngine;
using Zenject;

public class CameraFollow : MonoBehaviour
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

    public void SetTarget(Transform target)
    {
        if (_target != null) return;

        _target = target;
    }

    void LateUpdate()
    {
        if (_target == null)
            return;

        Vector3 desiredPosition = _target.position + _cameraOffset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, _cameraSmoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;
    }
}