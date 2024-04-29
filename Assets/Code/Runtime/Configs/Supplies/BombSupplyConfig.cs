using UnityEngine;

namespace Code.Runtime.Configs.Supplies
{
    [CreateAssetMenu(fileName = "BombSupplyConfig", menuName = "Configs/BombSupplyConfig")]
    public class BombSupplyConfig : BaseSupplyConfig
    {
        [field:SerializeField] public float DamageRadius { get; private set; }
        [field:SerializeField] public float TimeToDespawn { get; private set; }
        [field:SerializeField] public int Damage { get; private set; }
    }
}