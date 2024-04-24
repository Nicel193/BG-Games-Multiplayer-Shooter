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

        public abstract void Shoot(Vector2 direction);
    }
}