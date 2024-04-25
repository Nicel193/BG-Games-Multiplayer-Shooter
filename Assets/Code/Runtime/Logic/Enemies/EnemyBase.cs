using Code.Runtime.Logic.WeaponSystem.Types;
using Fusion;
using UnityEngine;

namespace Code.Runtime.Logic.Enemies
{
    public class EnemyBase : NetworkBehaviour
    {
        private BaseWeapon _enemyWeapon;
        
        public override void FixedUpdateNetwork()
        {
            _enemyWeapon.Attack(Vector2.zero);
        }
    }
}