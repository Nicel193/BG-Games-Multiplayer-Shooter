using Code.Runtime.Configs.Supplies;
using UnityEngine;

namespace Code.Runtime.Configs
{
    [CreateAssetMenu(fileName = "WaveConfig", menuName = "Configs/WaveConfig")]
    public class WaveConfig : ScriptableObject
    {
        [field: SerializeField] public float SpawnRadius { get; private set; } 
        [field: SerializeField] public int BreakTime { get; private set; }
        [field: SerializeField] public int Duration { get; private set; }
        [field: SerializeField] public BaseEnemyConfig[] WaveEnemies { get; private set; }
        [field: SerializeField] public BaseSupplyConfig[] WaveSupplies { get; private set; }
    }
}