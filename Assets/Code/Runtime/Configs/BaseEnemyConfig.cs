using UnityEngine;

namespace Code.Runtime.Configs
{
    [CreateAssetMenu(fileName = "BaseEnemyConfig", menuName = "Configs/BaseEnemyConfig")]
    public class BaseEnemyConfig : ScriptableObject
    {
        [field: SerializeField] public float MoveSpeed { get; private set; }
        [field: SerializeField] public float Health { get; private set; }
        [field: SerializeField] public BaseWeaponConfig EnemyWeapon { get; private set; }
    }
}