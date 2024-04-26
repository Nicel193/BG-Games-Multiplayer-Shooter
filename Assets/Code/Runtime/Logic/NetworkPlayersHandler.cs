using System;
using System.Collections.Generic;
using System.Linq;
using Code.Runtime.Infrastructure.StateMachines;
using Code.Runtime.Infrastructure.States.Gameplay;
using Code.Runtime.Logic.PlayerSystem;
using Code.Runtime.Logic.WaveSystem;
using Fusion;
using UnityEngine;
using Zenject;

namespace Code.Runtime.Logic
{
    public class NetworkPlayersHandler : NetworkBehaviour, IPlayerJoined, IPlayerLeft, INetworkPlayersHandler
    {
        private Dictionary<PlayerRef, NetworkObject> _spawnedCharacters = new Dictionary<PlayerRef, NetworkObject>();
        private List<NetworkObject> _activePlayers = new List<NetworkObject>();
        
        private WaveStateMachine _waveStateMachine;
        private GameplayStateMachine _gameplayStateMachine;

        [Inject]
        private void Construct(GameplayStateMachine gameplayStateMachine, WaveStateMachine waveStateMachine)
        {
            _gameplayStateMachine = gameplayStateMachine;
            _waveStateMachine = waveStateMachine;
        }

        public void AddNetworkPlayer(PlayerRef player, NetworkObject playerObject)
        {
            _spawnedCharacters.Add(player, playerObject);
            _activePlayers.Add(playerObject);
        }

        public void RemoveActivePlayer(NetworkObject playerObject)
        {
            _activePlayers.Remove(playerObject);

            if (_activePlayers.Count == 0)
                _waveStateMachine.Enter<EndWavesState>();
        }

        public List<Transform> GetActivePlayersTransforms()
        {
            return _activePlayers
                .Select(networkObject => networkObject.transform)
                .ToList();
        }
        
        public List<PlayerData> GetPlayersData()
        {
            return _spawnedCharacters
                .Values
                .Select(networkObject => networkObject.GetComponent<PlayerData>())
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