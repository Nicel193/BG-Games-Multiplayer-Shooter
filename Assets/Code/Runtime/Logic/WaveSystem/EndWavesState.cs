using Code.Runtime.Infrastructure.StateMachines;
using Code.Runtime.Infrastructure.States;
using Code.Runtime.Infrastructure.States.Gameplay;
using Fusion;

namespace Code.Runtime.Logic.WaveSystem
{
    public class EndWavesState : IState
    {
        private GameplayStateMachine _gameplayStateMachine;
        private WaveHandler _waveHandler;

        public EndWavesState(WaveHandler waveHandler, GameplayStateMachine gameplayStateMachine)
        {
            _waveHandler = waveHandler;
            _gameplayStateMachine = gameplayStateMachine;
        }

        public void Enter()
        {
            _waveHandler.WaveTimer = TickTimer.None;

            _gameplayStateMachine.Enter<EndGameState>();
        }

        public void Exit()
        {
            
        }
    }
}