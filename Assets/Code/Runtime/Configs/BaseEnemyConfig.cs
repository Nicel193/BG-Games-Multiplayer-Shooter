using Code.Runtime.Logic.Enemies;
using UnityEngine;

namespace Code.Runtime.Configs
{
    [CreateAssetMenu(fileName = "BaseEnemyConfig", menuName = "Configs/BaseEnemyConfig")]
    public class BaseEnemyConfig : ScriptableObject
    {
        [field: SerializeField] public BaseEnemy BaseEnemyPrefab { get; private set; }
        [field: SerializeField] public float MoveSpeed { get; private set; }
        [field: SerializeField] public float StoppingDistance { get; private set; }
        [field: SerializeField] public float MaxHealth { get; private set; }
        [field: SerializeField] public int Damage { get; private set; }
        [field: SerializeField] public float AttackInterval { get; private set; }
    }
}