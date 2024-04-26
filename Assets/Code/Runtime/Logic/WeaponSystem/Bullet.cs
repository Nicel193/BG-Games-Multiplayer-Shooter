using System;
using Code.Runtime.Logic.PlayerSystem;
using Fusion;
using UnityEngine;

namespace Code.Runtime.Logic.WeaponSystem
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Bullet : NetworkBehaviour, IBullet
    {
        private Rigidbody2D _bulletRigidbody2D;
        private NetworkObject _networkObject;
        private int _damage;
        private Action<bool> _onDamage;

        private void Awake()
        {
            _bulletRigidbody2D = GetComponent<Rigidbody2D>();
            _networkObject = GetComponent<NetworkObject>();
        }

        public void Initialize(int damage)
        {
            _damage = damage;
        }

        public void Launch(Vector2 direction, float force, Action<bool> onDamage = null)
        {
            direction.Normalize();

            _bulletRigidbody2D.AddForce(direction * force, ForceMode2D.Impulse);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.TryGetComponent(out IDamageable damageable))
            {
                damageable.Damage(_damage);
                
                _onDamage?.Invoke(damageable.IsDead());

                Runner.Despawn(_networkObject);
            }
        }
    }
}