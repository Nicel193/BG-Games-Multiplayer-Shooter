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

        public LoadState(INetworkPlayersHandler networkPlayersHandler, IPlayerFactory playerFactory,
            GameplayStateMachine gameplayStateMachine)
        {
            _gameplayStateMachine = gameplayStateMachine;
            _playerFactory = playerFactory;
            _networkPlayersHandler = networkPlayersHandler;
        }

        public void Enter(PlayerRef playerRef)
        {
            NetworkObject playerObject = _playerFactory.SpawnPlayer(playerRef);

            _networkPlayersHandler.AddNetworkPlayer(playerRef, playerObject);
            _gameplayStateMachine.Enter<WaitingPlayersState, PlayerRef>(playerRef);
        }

        public void Exit() { }
    }
}