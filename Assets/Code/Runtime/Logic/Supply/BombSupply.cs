using Code.Runtime.Logic.Enemies;
using Code.Runtime.Logic.PlayerSystem;
using Fusion;
using UnityEngine;

namespace Code.Runtime.Logic.Supply
{
    public class BombSupply : BaseSupply
    {
        [SerializeField] private CircleCollider2D damageZoneCollider;
        [SerializeField] private DamageZone damageZone;
        [SerializeField] private float damageRadius;
        [SerializeField] private float timeToDespawn;
        [SerializeField] private int damage;

        private bool _isExplode;
        private float _timerToDespawn;
        
        private void Awake()
        {
            damageZoneCollider.radius = damageRadius;
            damageZoneCollider.enabled = false;
            
            damageZone.SetDamage(damage);
        }

        public override void FixedUpdateNetwork()
        {
            if(!_isExplode) return;
            
            _timerToDespawn += Runner.DeltaTime;


            Debug.Log(_timerToDespawn);
            
            if (_timerToDespawn >= timeToDespawn) Despawn();
        }

        protected override void PickUpImplementation(Collider2D other)
        {
            if (other.gameObject.TryGetComponent(out Player player))
            {
                damageZoneCollider.enabled = true;
                
                _isExplode = true;
            }
        }
    }
}