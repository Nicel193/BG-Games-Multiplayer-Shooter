using Code.Runtime.Configs;
using Fusion;
using UnityEngine;
using Zenject;

namespace Code.Runtime.Logic.PlayerSystem
{
    public class PlayerFactory : IPlayerFactory
    {
        private NetworkRunner _networkRunner;
        private DiContainer _diContainer;
        private PlayerConfig _playerConfig;

        PlayerFactory(DiContainer diContainer, NetworkRunner networkRunner, PlayerConfig playerConfig)
        {
            _diContainer = diContainer;
            _networkRunner = networkRunner;
            _playerConfig = playerConfig;
        }

        public NetworkObject SpawnPlayer(PlayerRef playerRef)
        {
            NetworkObject playerObject = _networkRunner.Spawn(_playerConfig.PlayerPrefab, Vector3.zero,
                Quaternion.identity, playerRef);
            
            _diContainer.Inject(playerObject);

            return playerObject;
        }
    }
}