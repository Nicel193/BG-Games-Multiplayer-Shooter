using Code.Runtime.Infrastructure.StateMachines;
using Code.Runtime.Logic;
using Code.Runtime.Logic.PlayerSystem;
using Code.Runtime.Logic.WaveSystem;
using Fusion;

namespace Code.Runtime.Infrastructure.States.Gameplay
{
    public class LoadState : IPayloadedState<PlayerRef>
    {
        private INetworkPlayersHandler _networkPlayersHandler;
        private IPlayerFactory _playerFactory;
        private GameplayStateMachine _gameplayStateMachine;
        private IWaveHandler _waveHandler;

        public LoadState(INetworkPlayersHandler networkPlayersHandler, IPlayerFactory playerFactory,
            GameplayStateMachine gameplayStateMachine, IWaveHandler waveHandler)
        {
            _waveHandler = waveHandler;
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

        public void Exit() { }
    }
}