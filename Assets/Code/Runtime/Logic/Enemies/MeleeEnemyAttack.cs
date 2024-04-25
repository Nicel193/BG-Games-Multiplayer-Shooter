using UnityEngine;

namespace Code.Runtime.Logic.Enemies
{
    public class MeleeEnemyAttack : EnemyAttack
    {
        [SerializeField] private EnemyAnimator enemyAnimator;
        [SerializeField] private EnemyDamageZone enemyDamageZone;
        
        protected override void AttackImplementation()
        {
            enemyDamageZone.SetDamage(Damage);
            enemyAnimator.PlayAttack();
        }
    }
}