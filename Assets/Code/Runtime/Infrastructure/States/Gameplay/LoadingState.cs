using Code.Runtime.Infrastructure.StateMachines;
using Code.Runtime.Logic;
using Fusion;
using UnityEngine;

namespace Code.Runtime.Infrastructure.States.Gameplay
{
    public class LoadingState : IState
    {
        private INetworkPlayersHandler _networkPlayersHandler;
        private GameplayStateMachine _gameplayStateMachine;
        
        public LoadingState(INetworkPlayersHandler networkPlayersHandler, GameplayStateMachine gameplayStateMachine)
        {
            _gameplayStateMachine = gameplayStateMachine;
            _networkPlayersHandler = networkPlayersHandler;
        }
        
        public void Enter() { }

        public void Exit() { }
    }
}