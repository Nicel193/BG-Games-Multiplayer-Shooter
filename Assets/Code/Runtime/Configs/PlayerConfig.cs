using Fusion;
using UnityEngine;

namespace Code.Runtime.Configs
{
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "Configs/PlayerConfig")]
    public class PlayerConfig : ScriptableObject
    {
        [field: SerializeField] public float MoveSpeed { get; private set; }
        [field: SerializeField] public NetworkPrefabRef PlayerPrefab { get; private set; }
        
        [field: Header("Camera")]
        [field: SerializeField] public Vector3 CameraOffset  { get; private set; }
        [field: SerializeField] public float CameraSmoothSpeed { get; private set; } = 5f;
    }
}