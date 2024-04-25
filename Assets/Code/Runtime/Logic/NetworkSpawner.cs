using System.Collections.Generic;
using Code.Runtime.Logic.PlayerSystem;
using Fusion;
using UnityEngine;
using Zenject;

namespace Code.Runtime.Logic
{
    public class NetworkSpawner : NetworkBehaviour, IPlayerJoined, IPlayerLeft
    {
        [SerializeField] private CameraFollow _cameraFollow;
        
        private Dictionary<PlayerRef, NetworkObject> _spawnedCharacters = new Dictionary<PlayerRef, NetworkObject>();
        private IPlayerFactory _playerFactory;

        [Inject]
        private void Construct(IPlayerFactory playerFactory)
        {
            _playerFactory = playerFactory;
        }
        
        public void PlayerJoined(PlayerRef playerRef)
        {
            if (Runner.IsServer)
            {
                NetworkObject networkPlayerObject = _playerFactory.SpawnPlayer(playerRef);
  
                _spawnedCharacters.Add(playerRef, networkPlayerObject);
                // ememySpawner.Initialize(networkPlayerObject.transform);
            }
        }

        public void PlayerLeft(PlayerRef player)
        {
            // throw new System.NotImplementedException();
        }
    }
}
