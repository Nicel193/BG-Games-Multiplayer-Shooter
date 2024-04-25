using Code.Runtime.Logic.PlayerSystem;
using Fusion;
using UnityEngine;

namespace Code.Runtime.Logic
{
    public class EnemyDamageZone : NetworkBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.TryGetComponent(out Player playerHeath))
            {
                playerHeath.RPC_Damage(10);
            }
        }
    }
}