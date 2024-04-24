using Fusion;
using UnityEngine;

namespace Code.Runtime.Configs
{
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "Configs/PlayerConfig")]
    public class PlayerConfig : ScriptableObject
    {
        [field: SerializeField] public float MoveSpeed { get; private set; }
        [field: SerializeField] public NetworkPrefabRef PlayerPrefab { get; private set; }
    }
}