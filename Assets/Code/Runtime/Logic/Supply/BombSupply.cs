using Code.Runtime.Configs.Supplies;
using Code.Runtime.Logic.PlayerSystem;
using UnityEngine;

namespace Code.Runtime.Logic.Supply
{
    public class BombSupply : BaseSupply
    {
        [SerializeField] private CircleCollider2D damageZoneCollider;
        [SerializeField] private DamageZone damageZone;
        
        private float _damageRadius;
        private float _timeToDespawn;
        private int _damage;
        
        private bool _isExplode;
        private float _timerToDespawn;


        private void Awake()
        {
            damageZoneCollider.radius = _damageRadius;
            damageZoneCollider.enabled = false;
            
            damageZone.SetDamage(_damage);
        }

        public override void Initialize(BaseSupplyConfig supplyConfig)
        {
            if (supplyConfig is BombSupplyConfig bombSupplyConfig)
            {
                _damageRadius = bombSupplyConfig.DamageRadius;
                _timeToDespawn = bombSupplyConfig.TimeToDespawn;
                _damage = bombSupplyConfig.Damage;
            }
        }

        public override void FixedUpdateNetwork()
        {
            if(!_isExplode) return;
            
            _timerToDespawn += Runner.DeltaTime;


            Debug.Log(_timerToDespawn);
            
            if (_timerToDespawn >= _timeToDespawn) Despawn();
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