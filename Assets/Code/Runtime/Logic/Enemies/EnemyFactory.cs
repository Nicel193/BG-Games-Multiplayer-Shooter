using Fusion;
using UnityEngine;
using Zenject;

namespace Code.Runtime.Logic.Enemies
{
    public interface IEnemyFactory
    {
        Enemy SpawnEnemy(Enemy enemyPrefab, Vector3 at);
    }

    public class EnemyFactory : IEnemyFactory
    {
        private DiContainer _diContainer;
        private NetworkRunner _networkRunner;

        public EnemyFactory(DiContainer diContainer, NetworkRunner networkRunner)
        {
            _diContainer = diContainer;
            _networkRunner = networkRunner;
        }
        
        public Enemy SpawnEnemy(Enemy enemyPrefab, Vector3 at)
        {
            Enemy playerObject = _networkRunner.Spawn(enemyPrefab, at, Quaternion.identity);
            
            _diContainer.Inject(playerObject);

            return playerObject;
        }
    }
}