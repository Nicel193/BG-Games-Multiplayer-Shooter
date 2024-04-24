using Code.Runtime.Logic.PlayerSystem;
using Fusion;
using UnityEngine;

namespace Code.Runtime.Logic.WeaponSystem
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Bullet : NetworkBehaviour, IBullet
    {
        private Rigidbody2D _bulletRigidbody2D;
        private int _damage;

        private void Awake() =>
            _bulletRigidbody2D = GetComponent<Rigidbody2D>();

        public void Initialize(int damage) =>
            _damage = damage;

        public void Move(Vector2 direction, int force)
        {
            direction.Normalize();

            _bulletRigidbody2D.AddForce(direction * force, ForceMode2D.Impulse);
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.TryGetComponent(out Player player))
            {
                player.RPC_Damage(_damage);
                
                Destroy(gameObject);
            }
        }
    }
}