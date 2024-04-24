using Fusion;
using UnityEngine;

namespace Code.Runtime.Logic.WeaponSystem
{
    public abstract class BaseWeapon : NetworkBehaviour
    {
        [SerializeField] protected Bullet bulletPrefab;
        [SerializeField] protected Transform spawnBulletPoint;
        [SerializeField] protected int damage;
        [SerializeField] protected int shootForce;
        [SerializeField] protected float shootInterval = 0.5f;
        
        private float _shootTimer = 0f;
        
        public override void FixedUpdateNetwork()
        {
            if (_shootTimer < shootInterval)
                _shootTimer += Time.deltaTime;
        }

        public void Shoot(Vector2 direction)
        {
            if (_shootTimer >= shootInterval)
            {
                ShootImplementation(direction);
                
                _shootTimer = 0f;
            }
        }
        
        protected abstract void ShootImplementation(Vector2 direction);
    }
}