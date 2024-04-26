using UnityEngine;

namespace Code.Runtime.Logic.Enemies
{
    public class MeleeEnemyAttack : EnemyAttack
    {
        [SerializeField] private EnemyAnimator enemyAnimator;
        [SerializeField] private DamageZone damageZone;
        
        protected override void AttackImplementation()
        {
            damageZone.SetDamage(Damage);
            enemyAnimator.PlayAttack();
        }
    }
}