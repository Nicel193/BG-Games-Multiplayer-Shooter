using Code.Runtime.Configs;
using Code.Runtime.Logic.WeaponSystem;
using Code.Runtime.Logic.WeaponSystem.Types;
using Fusion;
using UnityEngine;

namespace Code.Runtime.Logic.PlayerSystem
{
    public class PlayerFactory : IPlayerFactory
    {
        private NetworkRunner _networkRunner;
        private PlayerConfig _playerConfig;
        private IWeaponFactory _weaponFactory;

        PlayerFactory(NetworkRunner networkRunner, PlayerConfig playerConfig, IWeaponFactory weaponFactory)
        {
            _weaponFactory = weaponFactory;
            _networkRunner = networkRunner;
            _playerConfig = playerConfig;
        }

        public NetworkObject SpawnPlayer(PlayerRef playerRef)
        {
            NetworkObject playerObject = _networkRunner.Spawn(_playerConfig.PlayerPrefab, Vector3.zero,
                Quaternion.identity, playerRef);

            BaseWeapon weapon = _weaponFactory.SpawnWeapon(GetRandomWeaponType(), playerRef);
            
            weapon.transform.SetParent(playerObject.transform);

            return playerObject;
        }

        private WeaponType GetRandomWeaponType() =>
            (WeaponType)Random.Range(0, _playerConfig.GetWeaponsConfigs().Count);
    }
}