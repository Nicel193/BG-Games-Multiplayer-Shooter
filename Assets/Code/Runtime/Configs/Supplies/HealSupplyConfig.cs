using UnityEngine;

namespace Code.Runtime.Configs.Supplies
{
    [CreateAssetMenu(fileName = "HealSupplyConfig", menuName = "Configs/HealSupplyConfig")]
    public class HealSupplyConfig : BaseSupplyConfig
    {
        [field: SerializeField] public int Heal { get; private set; }
    }
}