using System.Collections.Generic;
using Code.Runtime.Configs;
using Code.Runtime.Infrastructure.States;
using Code.Runtime.Logic.Enemies;
using Fusion;
using UnityEngine;

namespace Code.Runtime.Logic.WaveSystem
{
    public class WaveSpawnState : IPayloadedState<WaveConfig>, IUpdatebleState
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

        public WaveSpawnState(WaveHandler waveHandler, IEnemyFactory enemyFactory,
            INetworkPlayersHandler networkPlayersHandler, WaveStateMachine waveStateMachine)
        {
            _waveStateMachine = waveStateMachine;
            _networkPlayersHandler = networkPlayersHandler;
            _enemyFactory = enemyFactory;
            _waveHandler = waveHandler;
            _networkRunner = _waveHandler.Runner;
        }

        public void Enter(WaveConfig waveConfig)
        {
            _waveHandler.WaveTimer = TickTimer.CreateFromSeconds(_networkRunner, waveConfig.Duration);

            _waveEnemies = waveConfig.WaveEnemies;
            _spawnTime = GetRandomTime();
        }

        public void Exit()
        {
        }

        public void Update()
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
                _spawnTime = GetRandomTime();
            }
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
            Vector3 randomPosition = new Vector3(Random.Range(0f, 10f), Random.Range(0, 10f));
            BaseEnemyConfig enemyConfig = _waveEnemies[Random.Range(0, _waveEnemies.Length)];

            Enemy enemy = _enemyFactory.SpawnEnemy(enemyConfig.EnemyPrefab, randomPosition);

            Transform targetPlayer = FindTargetPlayer();

            enemy.Initialize(enemyConfig, targetPlayer);
        }

        private Transform FindTargetPlayer()
        {
            List<Transform> playersTransforms = _networkPlayersHandler.GetActivePlayersTransforms();

            Transform targetPlayer = playersTransforms[Random.Range(0, playersTransforms.Count)];

            return targetPlayer;
        }

        private float GetRandomTime()
        {
            return Random.Range(MinTimeToSpawnEnemy, MaxTimeToSpawnEnemy);
        }
    }
}