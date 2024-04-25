using System.Collections.Generic;
using System.Linq;
using Code.Runtime.Logic.WeaponSystem;
using Fusion;
using UnityEngine;

namespace Code.Runtime.Configs
{
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "Configs/PlayerConfig")]
    public class PlayerConfig : ScriptableObject
    {
        [field: Header("Stats")]
        [field: SerializeField] public int MaxAmmo  { get; private set; }
        [field: SerializeField] public int MaxHealth  { get; private set; }
        
        [field: Header("Move")]
        [field: SerializeField] public float MoveSpeed { get; private set; }
        [field: SerializeField] public NetworkPrefabRef PlayerPrefab { get; private set; }

        [field: Header("Camera")]
        [field: SerializeField] public Vector3 CameraOffset  { get; private set; }
        [field: SerializeField] public float CameraSmoothSpeed { get; private set; } = 5f;

        [Header("Weapons")]
        [SerializeField] private BaseWeaponConfig[] weaponConfigs;

        public Dictionary<WeaponType, BaseWeaponConfig> GetWeaponsConfigs() =>
            weaponConfigs.ToDictionary(k => k.WeaponType, v => v);
    }
}