using Fusion;
using UnityEngine;
using Code.Runtime.Logic.PlayerSystem;

namespace Code.Runtime.Logic.Enemies
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
            if (other.gameObject.TryGetComponent(out IDamageable damageable))
            {
                damageable.Damage(_damage);
            }
        }
    }
}