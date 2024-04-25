using System;
using System.Collections.Generic;
using System.Linq;
using Code.Runtime.Infrastructure.StateMachines;
using Code.Runtime.Infrastructure.States.Gameplay;
using Fusion;
using UnityEngine;
using Zenject;

namespace Code.Runtime.Logic
{
    public class NetworkPlayersHandler : NetworkBehaviour, IPlayerJoined, IPlayerLeft, INetworkPlayersHandler
    {
        private Dictionary<PlayerRef, NetworkObject> _spawnedCharacters = new Dictionary<PlayerRef, NetworkObject>();

        private GameplayStateMachine _gameplayStateMachine;

        [Inject]
        private void Construct(GameplayStateMachine gameplayStateMachine)
        {
            _gameplayStateMachine = gameplayStateMachine;
        }

        public void AddNetworkPlayer(PlayerRef player, NetworkObject playerObject) =>
            _spawnedCharacters.Add(player, playerObject);

        public List<Transform> GetPlayersTransforms()
        {
            return _spawnedCharacters.Values
                .Select(networkObject => networkObject.transform)
                .ToList();
        }
        
        public void PlayerJoined(PlayerRef player)
        {
            if (!Runner.IsServer) return;

            _gameplayStateMachine.Enter<LoadState, PlayerRef>(player);
        }

        public void PlayerLeft(PlayerRef player)
        {
            if (_spawnedCharacters.TryGetValue(player, out NetworkObject networkObject))
            {
                Runner.Despawn(networkObject);
                _spawnedCharacters.Remove(player);
            }
        }
    }
}