using System.Collections.Generic;
using Code.Runtime.Configs;
using Code.Runtime.Logic.Enemies;
using Code.Runtime.Logic.Supply;
using Fusion;
using UnityEngine;

namespace Code.Runtime.Logic.WaveSystem
{
    public class WaveSpawnState : WaveSuppliesState
    {
        private const float MinTimeToSpawnEnemy = 3f;
        private const float MaxTimeToSpawnEnemy = 6f;
        
        private WaveHandler _waveHandler;
        private NetworkRunner _networkRunner;

        private INetworkPlayersHandler _networkPlayersHandler;
        private IEnemyFactory _enemyFactory;
        private WaveStateMachine _waveStateMachine;
        private BaseEnemyConfig[] _waveEnemies;
        
        private float _timeToSpawn;
        private float _spawnTime;

        private List<NetworkObject> _enemies = new List<NetworkObject>();

        public WaveSpawnState(ISupplyFactory supplyFactory, WaveHandler waveHandler, IEnemyFactory enemyFactory,
            INetworkPlayersHandler networkPlayersHandler, WaveStateMachine waveStateMachine) : base(supplyFactory, waveHandler)
        {
            _waveStateMachine = waveStateMachine;
            _networkPlayersHandler = networkPlayersHandler;
            _enemyFactory = enemyFactory;
            _waveHandler = waveHandler;
            _networkRunner = _waveHandler.Runner;
        }

        public override void Enter(WaveConfig waveConfig)
        {
            _waveHandler.WaveTimer = TickTimer.CreateFromSeconds(_networkRunner, waveConfig.Duration);

            _waveEnemies = waveConfig.WaveEnemies;
            _spawnTime = GetRandomTime(MinTimeToSpawnEnemy, MaxTimeToSpawnEnemy);
            
            base.Enter(waveConfig);
        }

        public override void Exit()
        {
            foreach (NetworkObject enemy  in _enemies)
                _networkRunner.Despawn(enemy);

            _enemies.Clear();
            
            base.Exit();
        }

        public override void Update()
        {
            if (_waveHandler.WaveTimer.Expired(_networkRunner))
            {
                NextState();

                return;
            }

            _timeToSpawn += _networkRunner.DeltaTime;

            if (_timeToSpawn >= _spawnTime)
            {
                SpawnEnemy();

                _timeToSpawn = 0f;
                _spawnTime = GetRandomTime(MinTimeToSpawnEnemy, MaxTimeToSpawnEnemy);
            }
            
            base.Update();
        }

        private void NextState()
        {
            if (_waveHandler.IsLastWave())
                _waveStateMachine.Enter<EndWavesState>();
            else
                _waveStateMachine.Enter<WaveBreakState, WaveConfig>(_waveHandler.GetNextWaveConfig());
        }

        private void SpawnEnemy()
        {
            Vector3 randomPosition = Random.insideUnitCircle * SpawnRadius;
            BaseEnemyConfig enemyConfig = _waveEnemies[Random.Range(0, _waveEnemies.Length)];

            Enemy enemy = _enemyFactory.SpawnEnemy(enemyConfig.EnemyPrefab, randomPosition);
            _enemies.Add(enemy.GetComponent<NetworkObject>());

            Transform targetPlayer = FindTargetPlayer();
            enemy.Initialize(enemyConfig, targetPlayer);
        }

        private Transform FindTargetPlayer()
        {
            List<Transform> playersTransforms = _networkPlayersHandler.GetActivePlayersTransforms();

            Transform targetPlayer = playersTransforms[Random.Range(0, playersTransforms.Count)];

            return targetPlayer;
        }
    }
}