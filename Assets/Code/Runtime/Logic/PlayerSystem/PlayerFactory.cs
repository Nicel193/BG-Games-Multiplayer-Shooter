using System;
using Code.Runtime.Configs;
using Code.Runtime.Logic.WeaponSystem;
using Code.Runtime.Logic.WeaponSystem.Types;
using Fusion;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Code.Runtime.Logic.PlayerSystem
{
    public class PlayerFactory : IPlayerFactory
    {
        private NetworkRunner _networkRunner;
        private DiContainer _diContainer;
        private PlayerConfig _playerConfig;
        private IWeaponFactory _weaponFactory;

        PlayerFactory(DiContainer diContainer, NetworkRunner networkRunner, PlayerConfig playerConfig, IWeaponFactory weaponFactory)
        {
            _weaponFactory = weaponFactory;
            _diContainer = diContainer;
            _networkRunner = networkRunner;
            _playerConfig = playerConfig;
        }

        public NetworkObject SpawnPlayer(PlayerRef playerRef)
        {
            NetworkObject playerObject = _networkRunner.Spawn(_playerConfig.PlayerPrefab, Vector3.zero,
                Quaternion.identity, playerRef);

            BaseWeapon weapon = _weaponFactory.SpawnWeapon(GetRandomWeaponType(), playerRef);
            weapon.transform.SetParent(playerObject.transform);

            _diContainer.Inject(playerObject);

            return playerObject;
        }

        private WeaponType GetRandomWeaponType() =>
            (WeaponType)Random.Range(0, _playerConfig.GetWeaponsConfigs().Count);
    }
}