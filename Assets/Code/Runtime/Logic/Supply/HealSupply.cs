using Code.Runtime.Configs.Supplies;
using Code.Runtime.Logic.PlayerSystem;
using UnityEngine;

namespace Code.Runtime.Logic.Supply
{
    public class HealSupply : BaseSupply
    {
        private int _heal;
        
        public override void Initialize(BaseSupplyConfig supplyConfig)
        {
            if (supplyConfig is HealSupplyConfig healSupplyConfig)
            {
                _heal = healSupplyConfig.Heal;
            }
        }

        protected override void PickUpImplementation(Collider2D other)
        {
            if (other.TryGetComponent(out PlayerData playerData))
            {
                playerData.AddHp(_heal);
                
                Despawn();
            }
        }
    }
}