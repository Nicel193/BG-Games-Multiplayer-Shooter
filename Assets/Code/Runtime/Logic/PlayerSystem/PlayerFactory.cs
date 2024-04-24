using Code.Runtime.Configs;
using Fusion;
using UnityEngine;
using Zenject;

namespace Code.Runtime.Logic.PlayerSystem
{
    public class PlayerFactory : IPlayerFactory
    {
        private DiContainer _diContainer;
        private PlayerConfig _playerConfig;

        PlayerFactory(DiContainer diContainer, PlayerConfig playerConfig)
        {
            _diContainer = diContainer;
            _playerConfig = playerConfig;
        }

        public NetworkObject SpawnPlayer(NetworkRunner networkRunner)
        {
            NetworkObject player = networkRunner.Spawn(_playerConfig.PlayerPrefab, Vector3.zero, Quaternion.identity);
            
            _diContainer.Inject(player);

            return player;
        }
    }
}