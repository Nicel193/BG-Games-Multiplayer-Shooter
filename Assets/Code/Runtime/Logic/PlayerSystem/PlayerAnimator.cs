using UnityEngine;

namespace Code.Runtime.Logic.PlayerSystem
{
    [RequireComponent(typeof(Animator))]
    public class PlayerAnimator : MonoBehaviour
    {
        private readonly int RunHash = Animator.StringToHash("Run");
        private readonly int DeathHash = Animator.StringToHash("Death");
        
        private Animator _animator;

        private void Awake() =>
            _animator = GetComponent<Animator>();

        public void PlayRun() =>
            _animator.SetBool(RunHash, true);

        public void PlayIdle() =>
            _animator.SetBool(RunHash, false);

        public void PlayDeath() =>
            _animator.SetTrigger(DeathHash);
    }
}