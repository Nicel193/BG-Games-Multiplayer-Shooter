using Code.Runtime.Configs.Supplies;
using Code.Runtime.Logic.PlayerSystem;
using UnityEngine;

namespace Code.Runtime.Logic.Supply
{
    public class AmmoSupply : BaseSupply
    {
        private int _ammoCount;

        public override void Initialize(BaseSupplyConfig supplyConfig)
        {
            if (supplyConfig is AmmoSupplyConfig ammoSupplyConfig)
            {
                _ammoCount = ammoSupplyConfig.AmmoCount;
            }
        }

        protected override void PickUpImplementation(Collider2D other)
        {
            if (other.TryGetComponent(out PlayerData playerData))
            {
                playerData.RestoreAmmo(_ammoCount);
                
                Despawn();
            }
        }
    }
}