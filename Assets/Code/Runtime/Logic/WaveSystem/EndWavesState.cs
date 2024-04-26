using Code.Runtime.Infrastructure.StateMachines;
using Code.Runtime.Infrastructure.States;
using Code.Runtime.Infrastructure.States.Gameplay;

namespace Code.Runtime.Logic.WaveSystem
{
    public class EndWavesState : IState
    {
        private GameplayStateMachine _gameplayStateMachine;

        public EndWavesState(GameplayStateMachine gameplayStateMachine)
        {
            _gameplayStateMachine = gameplayStateMachine;
        }

        public void Enter()
        {
            _gameplayStateMachine.Enter<EndGameState>();
        }

        public void Exit()
        {
            
        }
    }
}