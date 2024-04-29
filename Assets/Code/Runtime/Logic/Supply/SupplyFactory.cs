using Code.Runtime.Configs.Supplies;
using Fusion;
using UnityEngine;

namespace Code.Runtime.Logic.Supply
{
    public class SupplyFactory : ISupplyFactory
    {
        private NetworkRunner _networkRunner;

        public SupplyFactory(NetworkRunner networkRunner)
        {
            _networkRunner = networkRunner;
        }
        
        public BaseSupply SpawnSupply(BaseSupplyConfig baseSupplyConfig, Vector3 at)
        {
            BaseSupply baseSupply = _networkRunner.Spawn(baseSupplyConfig.SupplyPrefab, at, Quaternion.identity);
            
            baseSupply.Initialize(baseSupplyConfig);

            return baseSupply;
        }
    }
}