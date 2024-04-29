using UnityEngine;

namespace Code.Runtime.Configs.Supplies
{
    [CreateAssetMenu(fileName = "AmmoSupplyConfig", menuName = "Configs/AmmoSupplyConfig")]
    public class AmmoSupplyConfig : BaseSupplyConfig
    {
        [field: SerializeField] public int AmmoCount { get; private set; }
    }
}