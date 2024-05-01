using Code.Runtime.Infrastructure.StateMachines;
using Code.Runtime.Repositories;
using Code.Runtime.Services.SaveService;

namespace Code.Runtime.Infrastructure.States.Core
{
    public class LoadProgressState : IState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly IInteractorContainer _interactorContainer;
        private readonly ISaveService _saveService;

        LoadProgressState(GameStateMachine gameStateMachine, IInteractorContainer interactorContainer, ISaveService saveService)
        {
            _saveService = saveService;
            _gameStateMachine = gameStateMachine;
            _interactorContainer = interactorContainer;
        }

        public void Enter()
        {
            _saveService.Load();
            
            _gameStateMachine.Enter<LoadSceneState, string>(SceneName.Menu.ToString());
        }

        public void Exit()
        {
        }
    }
}