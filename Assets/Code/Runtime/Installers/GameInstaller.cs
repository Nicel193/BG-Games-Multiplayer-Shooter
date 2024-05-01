using Code.Runtime.Infrastructure;
using Code.Runtime.Infrastructure.Bootstrappers;
using Code.Runtime.Infrastructure.StateMachines;
using Code.Runtime.Interactors;
using Code.Runtime.Repositories;
using Code.Runtime.Services.SaveService;
using Fusion;
using UnityEngine;
using Zenject;

namespace Code.Runtime.Installers
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private NetworkRunner networkRunner;
        
        public override void InstallBindings()
        {
            BindGameBootstrapperFactory();
            
            BindGameStateMachine();
            
            BindCoroutineRunner();
            
            BindStatesFactory();
            
            BindSceneLoader();

            BindInteractorContainer();

            BindNetworkRunner();

            Container.Bind<UserRepository>().AsSingle();

            BindSaveService();
        }

        private void BindSaveService()
        {
            Container.BindInterfacesTo<SaveService>().AsSingle();
        }

        private void BindNetworkRunner()
        {
            Container.BindInstance(networkRunner);
        }

        private void BindInteractorContainer()
        {
            Container.BindInterfacesTo<InteractorContainer>().AsSingle();
        }
        
        private void BindSceneLoader()
        {
            Container.BindInterfacesTo<SceneLoader>().AsSingle();
        }
        
        private void BindStatesFactory()
        {
            Container.BindInterfacesTo<StatesFactory>().AsSingle();
        }
        
        private void BindGameStateMachine()
        {
            Container.Bind<GameStateMachine>().AsSingle();
        }
    
        private void BindCoroutineRunner()
        {
            Container
                .Bind<ICoroutineRunner>()
                .To<CoroutineRunner>()
                .FromComponentInNewPrefabResource(InfrastructureAssetPath.CoroutineRunnerPath)
                .AsSingle();
        }
        
        private void BindGameBootstrapperFactory()
        {
            Container
                .BindFactory<GameBootstrapper, GameBootstrapper.Factory>()
                .FromComponentInNewPrefabResource(InfrastructureAssetPath.GameBootstrapperPath);
        }
    }
}