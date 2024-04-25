using System.Collections.Generic;
using Code.Runtime.Configs;
using Code.Runtime.Logic.Enemies;
using Code.Runtime.UI;
using Fusion;
using UnityEngine;
using Zenject;

namespace Code.Runtime.Logic.WaveSystem
{
    public class WaveHandler : NetworkBehaviour, IWaveHandler
    {
        [SerializeField] private BaseEnemyConfig[] enemyConfigs;
        [SerializeField] private float waveSeconds;
        [SerializeField] private WaveTimeTextView _waveTimeTextView;

        [Networked] TickTimer WaveTimer { get; set; }

        private IEnemyFactory _enemyFactory;
        private INetworkPlayersHandler _networkPlayersHandler;
        private bool _isSpawn;
        private float _timeToSpawn;
        private float _spawnTime;

        [Inject]
        private void Construct(IEnemyFactory enemyFactory, INetworkPlayersHandler networkPlayersHandler)
        {
            _networkPlayersHandler = networkPlayersHandler;
            _enemyFactory = enemyFactory;
        }

        public void Initialize()
        {
            WaveTimer = TickTimer.CreateFromSeconds(Runner, waveSeconds);

            _spawnTime = GetRandomTime();
        }

        public float? GetCurrentWaveTime() =>
            WaveTimer.RemainingTime(Runner);

        public override void FixedUpdateNetwork()
        {
            float? remainingTime = WaveTimer.RemainingTime(Runner);

            if (remainingTime != null)
                _waveTimeTextView.RPC_UpdateTimer(remainingTime.Value);

            if (WaveTimer.ExpiredOrNotRunning(Runner)) return;

            _timeToSpawn += Runner.DeltaTime;

            if (_timeToSpawn >= _spawnTime)
            {
                SpawnEnemy();

                _timeToSpawn = 0f;
                _spawnTime = GetRandomTime();
            }
        }

        private void SpawnEnemy()
        {
            Vector3 randomPosition = new Vector3(Random.Range(0f, 10f), Random.Range(0, 10f));
            BaseEnemyConfig enemyConfig = enemyConfigs[Random.Range(0, enemyConfigs.Length)];

            Enemy enemy = _enemyFactory.SpawnEnemy(enemyConfig.EnemyPrefab, randomPosition);
            Transform targetPlayer = FindTargetPlayer();

            enemy.Initialize(enemyConfig, targetPlayer);
        }

        private Transform FindTargetPlayer()
        {
            List<Transform> playersTransforms = _networkPlayersHandler.GetPlayersTransforms();

            Transform targetPlayer = playersTransforms[Random.Range(0, playersTransforms.Count)];

            return targetPlayer;
        }

        private float GetRandomTime()
        {
            return Random.Range(3f, 6f);
        }
    }
}