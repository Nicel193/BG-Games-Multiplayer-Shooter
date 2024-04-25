using UnityEngine;

namespace Code.Runtime.Logic.WeaponSystem.Types
{
    public abstract class ShootWeapon : BaseWeapon
    {
        protected override void AttackImplementation(Vector2 direction) { }
    }
}