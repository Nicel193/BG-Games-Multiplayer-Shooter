using System.Collections.Generic;
using System.Linq;
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
        private INetworkPlayersHandler _networkPlayersHandler;
        private List<WeaponType> _usedWeapons = new List<WeaponType>();

        PlayerFactory(NetworkRunner networkRunner, PlayerConfig playerConfig,
            IWeaponFactory weaponFactory, INetworkPlayersHandler networkPlayersHandler)
        {
            _networkPlayersHandler = networkPlayersHandler;
            _weaponFactory = weaponFactory;
            _networkRunner = networkRunner;
            _playerConfig = playerConfig;
        }

        public NetworkObject SpawnPlayer(PlayerRef playerRef)
        {
            Player playerObject = _networkRunner.Spawn(_playerConfig.PlayerPrefab, Vector3.zero,
                Quaternion.identity, playerRef);

            PlayerData playerData = playerObject.GetComponent<PlayerData>();
            PlayerDeathHandler playerDeathHandler = playerObject.GetComponent<PlayerDeathHandler>();
            // AvatarSynchronizer avatarSynchronizer = playerObject.GetComponent<AvatarSynchronizer>();
            playerData.RPC_Initialize(_playerConfig.MaxAmmo, _playerConfig.MaxHealth, playerRef.PlayerId);

            BaseWeapon weapon = _weaponFactory.SpawnWeapon(GetRandomWeaponType(), playerRef, playerData);

            weapon.transform.position = playerObject.WeaponPivot.position;
            weapon.transform.SetParent(playerObject.WeaponPivot);
            
            playerDeathHandler.Initialize(_networkPlayersHandler);
            weapon.transform.SetParent(playerObject.transform);

            return playerObject.Object;
        }

        private WeaponType GetRandomWeaponType()
        {
            List<WeaponType> availableWeapons = _playerConfig.GetWeaponsConfigs()
                .Where(weapon => !_usedWeapons.Contains(weapon.Key))
                .Select(weapon => weapon.Key)
                .ToList();

            WeaponType randomWeapon = availableWeapons[Random.Range(0, availableWeapons.Count)];
            _usedWeapons.Add(randomWeapon);
            return randomWeapon;
        }
    }
}