using System.Collections.Generic;
using Code.Runtime.Configs;
using Code.Runtime.Logic.WeaponSystem.Types;
using Fusion;
using UnityEngine;
using Zenject;

namespace Code.Runtime.Logic.WeaponSystem
{
    public class WeaponFactory : IWeaponFactory
    {
        private DiContainer _diContainer;
        private NetworkRunner _networkRunner;
        private Dictionary<WeaponType, BaseWeaponConfig> _baseWeaponConfigs;

        WeaponFactory(DiContainer diContainer, NetworkRunner networkRunner, PlayerConfig playerConfig)
        {
            _diContainer = diContainer;
            _networkRunner = networkRunner;
            _baseWeaponConfigs = playerConfig.GetWeaponsConfigs();
        }

        public BaseWeapon SpawnWeapon(WeaponType weaponType, PlayerRef playerRef)
        {
            BaseWeaponConfig baseWeaponConfig = _baseWeaponConfigs[weaponType];
            BaseWeapon baseWeapon = _networkRunner.Spawn(baseWeaponConfig.WeaponPrefab, Vector3.zero,
                Quaternion.identity, playerRef);

            baseWeapon.Initialize(baseWeaponConfig);

            _diContainer.Inject(baseWeapon);

            return baseWeapon;
        }
    }
}