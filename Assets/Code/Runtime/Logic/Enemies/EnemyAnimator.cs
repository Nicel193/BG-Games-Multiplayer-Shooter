using UnityEngine;

namespace Code.Runtime.Logic.Enemies
{
    public class EnemyAnimator : MonoBehaviour
    {
        private readonly int HitHash = Animator.StringToHash("Hit");
        private readonly int DeathHash = Animator.StringToHash("Dead");
        private readonly int AttackHash = Animator.StringToHash("Attack");
 
        private Animator _animator;

        private void Awake() =>
            _animator = GetComponent<Animator>();

        public void PlayHit() =>
            _animator.SetTrigger(HitHash);

        public void PlayAttack() =>
            _animator.SetTrigger(AttackHash);

        public void PlayDeath() =>
            _animator.SetBool(DeathHash, true);
    }
}