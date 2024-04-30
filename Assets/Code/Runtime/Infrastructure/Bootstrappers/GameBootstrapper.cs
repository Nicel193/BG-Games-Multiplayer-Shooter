using Code.Runtime.Infrastructure.States.Core;
using UnityEngine;
using Zenject;

namespace Code.Runtime.Infrastructure.Bootstrappers
{
    public class GameBootstrapper : BootstrapperBase
    {
        private const int TargetFrameRate = 60;

        private void Awake()
        {
             InitializeGameStateMachine();

             Application.targetFrameRate = TargetFrameRate;
             
             DontDestroyOnLoad(gameObject);
        }

        private void InitializeGameStateMachine()
        {
            _gameStateMachine.RegisterState(_statesFactory.Create<BootstrapState>());
            _gameStateMachine.RegisterState(_statesFactory.Create<LoadProgressState>());
            _gameStateMachine.RegisterState(_statesFactory.Create<LoadSceneState>());
            _gameStateMachine.RegisterState(_statesFactory.Create<LoadGameplayState>());
            
            _gameStateMachine.Enter<BootstrapState>();
        }

        public class Factory : PlaceholderFactory<GameBootstrapper>
        {
        }
    }
}