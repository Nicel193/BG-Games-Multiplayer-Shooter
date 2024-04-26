using Code.Runtime.Logic.PlayerSystem;
using UnityEngine;

namespace Code.Runtime.Logic.Supply
{
    public class HealSupply : BaseSupply
    {
        [SerializeField] private int heal;
        
        protected override void PickUpImplementation(Collider2D other)
        {
            if (other.TryGetComponent(out PlayerData playerData))
            {
                playerData.AddHp(heal);
            }
        }
    }
}