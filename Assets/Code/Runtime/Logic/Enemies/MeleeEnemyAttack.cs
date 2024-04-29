using Fusion;
using Unity.VisualScripting;
using UnityEngine;

namespace Code.Runtime.Logic.Enemies
{
    public class MeleeEnemyAttack : EnemyAttack
    {
        [SerializeField] private EnemyAnimator enemyAnimator;
        [SerializeField] private DamageZone damageZone;
        [SerializeField] private GameObject weapon;

        private void OnEnable() =>
            weapon.SetActive(true);

        private void OnDisable() =>
            weapon.SetActive(false);

        protected override void AttackImplementation()
        {
            damageZone.SetDamage(Damage);
            enemyAnimator.PlayAttack();
        }
    }
}