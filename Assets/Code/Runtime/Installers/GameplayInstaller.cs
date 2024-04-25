using Code.Runtime.Infrastructure;
using Code.Runtime.Infrastructure.StateMachines;
using Code.Runtime.Logic;
using Code.Runtime.Logic.Enemies;
using Code.Runtime.Logic.PlayerSystem;
using Code.Runtime.Logic.WaveSystem;
using Code.Runtime.Logic.WeaponSystem;
using Fusion;
using UnityEngine;
using Zenject;

namespace Code.Runtime.Installers
{
    public class GameplayInstaller : MonoInstaller
    {
        [SerializeField] private NetworkRunner networkRunner; 
        [SerializeField] private NetworkPlayersHandler networkPlayersHandler; 
        [SerializeField] private CameraFollow cameraFollow; 
        [SerializeField] private WaveHandler waveHandler; 
        
        public override void InstallBindings()
        {
            BindGameplayBootstrapper();

            BindStatesFactory();

            Container.BindInstance(networkRunner);

            BindPlayerFactory();
            
            BindWeaponFactory();

            BindNetworkPlayersHandler();
            
            BindCameraFollow();

            BindWaveHandler();

            BindEnemyFactory();
        }

        private void BindEnemyFactory()
        {
            Container.BindInterfacesTo<EnemyFactory>().AsSingle();
        }

        private void BindWaveHandler()
        {
            Container.BindInterfacesTo<WaveHandler>().FromInstance(waveHandler).AsSingle();
        }

        private void BindCameraFollow()
        {
            Container.Bind<ICameraFollow>().FromInstance(cameraFollow).AsSingle();
        }

        private void BindNetworkPlayersHandler()
        {
            Container.Bind<INetworkPlayersHandler>().FromInstance(networkPlayersHandler);
        }

        private void BindPlayerFactory()
        {
            Container.BindInterfacesTo<PlayerFactory>().AsSingle();
        }

        private void BindWeaponFactory()
        {
            Container.BindInterfacesTo<WeaponFactory>().AsSingle();
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