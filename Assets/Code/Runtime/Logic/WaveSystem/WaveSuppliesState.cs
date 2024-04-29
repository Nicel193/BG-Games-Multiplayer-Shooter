using Code.Runtime.Configs;
using Code.Runtime.Configs.Supplies;
using Code.Runtime.Infrastructure.States;
using Code.Runtime.Logic.Supply;
using Fusion;
using UnityEngine;

namespace Code.Runtime.Logic.WaveSystem
{
    public class WaveSuppliesState : IPayloadedState<WaveConfig>, IUpdatebleState
    {
        private const float MinTimeToSpawnSupply = 10f;
        private const float MaxTimeToSpawnSupply = 20f;

        protected float SpawnRadius;

        private BaseSupplyConfig[] _waveSupplyConfigs;
        private ISupplyFactory _supplyFactory;
        private NetworkRunner _networkRunner;
        private float _timeToSpawn;
        private float _spawnTime;

        protected WaveSuppliesState(ISupplyFactory supplyFactory, WaveHandler waveHandler)
        {
            _networkRunner = waveHandler.Runner;
            _supplyFactory = supplyFactory;
        }

        public virtual void Enter(WaveConfig waveConfig)
        {
            SpawnRadius = waveConfig.SpawnRadius;
            _waveSupplyConfigs = waveConfig.WaveSupplies;
        }

        public virtual void Update()
        {
            _timeToSpawn += _networkRunner.DeltaTime;

            if (_timeToSpawn >= _spawnTime)
            {
                SpawnSupply();

                _timeToSpawn = 0f;
                _spawnTime = GetRandomTime(MinTimeToSpawnSupply, MaxTimeToSpawnSupply);
            }
        }

        public virtual void Exit()
        {
        }

        private void SpawnSupply()
        {
            BaseSupplyConfig supplyConfig = _waveSupplyConfigs[Random.Range(0, _waveSupplyConfigs.Length)];
            Vector2 spawnSupplyPosition = Random.insideUnitCircle * SpawnRadius;

            _supplyFactory.SpawnSupply(supplyConfig, spawnSupplyPosition);
        }

        protected float GetRandomTime(float min, float max) =>
            Random.Range(min, max);
    }
}