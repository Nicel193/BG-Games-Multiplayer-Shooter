using Code.Runtime.Infrastructure;
using Code.Runtime.Infrastructure.StateMachines;
using Code.Runtime.Logic.PlayerSystem;
using Fusion;
using UnityEngine;
using Zenject;

namespace Code.Runtime.Installers
{
    public class GameplayInstaller : MonoInstaller
    {
        [SerializeField] private NetworkRunner networkRunner; 
        
        public override void InstallBindings()
        {
            BindGameplayBootstrapper();

            BindStatesFactory();

            Container.BindInstance(networkRunner);

            Container.BindInterfacesTo<PlayerFactory>().AsSingle();
        }
        
        private void BindGameplayBootstrapper()
        {
            Container.Bind<GameplayStateMachine>().AsSingle();
        }
        
        private void BindStatesFactory()
        {
            Container.BindInterfacesTo<StatesFactory>().AsSingle();
        }
    }
}