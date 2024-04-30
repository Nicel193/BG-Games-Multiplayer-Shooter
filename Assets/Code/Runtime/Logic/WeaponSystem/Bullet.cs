using System;
using Code.Runtime.Logic.PlayerSystem;
using Fusion;
using UnityEngine;

namespace Code.Runtime.Logic.WeaponSystem
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Bullet : NetworkBehaviour, IBullet
    {
        private const float TimeToDespawn = 3f;

        [Networked] private TickTimer Timer { set; get; }
        private Rigidbody2D _bulletRigidbody2D;
        private Action<bool> _onDamage;
        private int _damage;

        private void Awake()
        {
            _bulletRigidbody2D = GetComponent<Rigidbody2D>();
        }

        public override void Spawned()
        {
            Timer = TickTimer.CreateFromSeconds(Runner, TimeToDespawn);
        }

        public override void FixedUpdateNetwork()
        {
            if(Timer.Expired(Runner))
            {
                Runner.Despawn(Object);
            }
        }

        public void Initialize(int damage)
        {
            _damage = damage;
        }

        public void Launch(Vector2 direction, float force, Action<bool> onDamage = null)
        {
            direction.Normalize();
            
            _onDamage = onDamage;
            _bulletRigidbody2D.AddForce(direction * force, ForceMode2D.Impulse);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.TryGetComponent(out IDamageable damageable))
            {
                if(damageable.IsDead()) return;
                
                damageable.Damage(_damage);
                
                _onDamage?.Invoke(damageable.IsDead());

                Runner.Despawn(Object);
            }
        }
    }
}