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
            NetworkObject playerObject = _networkRunner.Spawn(_playerConfig.PlayerPrefab, Vector3.zero,
                Quaternion.identity, playerRef);

            PlayerData playerData = playerObject.GetComponent<PlayerData>();
            PlayerDeathHandler playerDeathHandler = playerObject.GetComponent<PlayerDeathHandler>();
            playerData.RPC_Initialize(10, 10, playerRef.PlayerId);

            BaseWeapon weapon = _weaponFactory.SpawnWeapon(GetRandomWeaponType(), playerRef, playerData);

            playerDeathHandler.Initialize(_networkPlayersHandler);
            weapon.transform.SetParent(playerObject.transform);

            return playerObject;
        }

        private WeaponType GetRandomWeaponType() =>
            (WeaponType) Random.Range(0, _playerConfig.GetWeaponsConfigs().Count);
    }
}