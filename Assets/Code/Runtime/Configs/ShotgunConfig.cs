using UnityEngine;

namespace Code.Runtime.Configs
{
    [CreateAssetMenu(fileName = "ShotgunConfig", menuName = "Configs/ShotgunConfig")]
    public class ShotgunConfig : BaseWeaponConfig
    {
        [field:SerializeField] public int PelletsCount { get; private set; } = 5;
        [field:SerializeField] public float SpreadAngle { get; private set; } = 30f;
    }
}