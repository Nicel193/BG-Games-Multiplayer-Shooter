using UnityEngine;

namespace Code.Runtime.Logic.Enemies
{
    public interface IEnemyFactory
    {
        Enemy SpawnEnemy(Enemy enemyPrefab, Vector3 at);
    }
}