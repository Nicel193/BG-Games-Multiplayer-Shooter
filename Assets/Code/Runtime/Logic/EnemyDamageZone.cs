using Code.Runtime.Logic.PlayerSystem;
using Fusion;
using UnityEngine;

namespace Code.Runtime.Logic
{
    public class EnemyDamageZone : NetworkBehaviour
    {
        private int _damage;

        public void SetDamage(int damage)
        {
            _damage = damage;
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.TryGetComponent(out Player playerHeath))
            {
                playerHeath.RPC_Damage(_damage);
            }
        }
    }
}