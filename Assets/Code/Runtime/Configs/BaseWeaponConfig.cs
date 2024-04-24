using Code.Runtime.Logic.WeaponSystem;
using UnityEngine;

namespace Code.Runtime.Configs
{
    [CreateAssetMenu(fileName = "BaseWeaponConfig", menuName = "Configs/BaseWeaponConfig")]
    public class BaseWeaponConfig : ScriptableObject
    {
        [field: SerializeField] public WeaponType WeaponType { get; private set; }
        [field: SerializeField] public BaseWeapon WeaponPrefab { get; private set; }
        [field: SerializeField] public Bullet BulletPrefab { get; private set; }
        [field: SerializeField] public int Damage { get; private set; }
        [field: SerializeField] public int ShootForce { get; private set; }
        [field: SerializeField] public float ShootInterval { get; private set; }
    }
}