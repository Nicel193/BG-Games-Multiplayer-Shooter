using Code.Runtime.Infrastructure.StateMachines;
using Code.Runtime.Logic;
using Code.Runtime.Logic.PlayerSystem;
using Code.Runtime.Logic.WaveSystem;
using ExitGames.Client.Photon.StructWrapping;
using Fusion;
using UnityEngine;

namespace Code.Runtime.Infrastructure.States.Gameplay
{
    public class LoadState : IPayloadedState<PlayerRef>
    {
        private INetworkPlayersHandler _networkPlayersHandler;
        private IPlayerFactory _playerFactory;
        private GameplayStateMachine _gameplayStateMachine;
        private ICameraFollow _cameraFollow;
        private IWaveHandler _waveHandler;

        public LoadState(INetworkPlayersHandler networkPlayersHandler, IPlayerFactory playerFactory,
            GameplayStateMachine gameplayStateMachine, ICameraFollow cameraFollow, IWaveHandler waveHandler)
        {
            _waveHandler = waveHandler;
            _cameraFollow = cameraFollow;
            _gameplayStateMachine = gameplayStateMachine;
            _playerFactory = playerFactory;
            _networkPlayersHandler = networkPlayersHandler;
        }

        public void Enter(PlayerRef playerRef)
        {
            NetworkObject playerObject = _playerFactory.SpawnPlayer(playerRef);

            _networkPlayersHandler.AddNetworkPlayer(playerRef, playerObject);

            InitializeWaveSystem(playerRef);

            _gameplayStateMachine.Enter<GameLoopState>();
        }

        private void InitializeWaveSystem(PlayerRef playerRef)
        {
            if (playerRef.PlayerId == 1)
                _waveHandler.Initialize();
        }

        public void Exit()
        {
        }
    }
}