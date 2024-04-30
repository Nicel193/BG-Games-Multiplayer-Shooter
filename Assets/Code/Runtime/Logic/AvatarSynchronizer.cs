using Code.Runtime.Configs;
using Code.Runtime.Logic.PlayerSystem;
using Code.Runtime.Repositories;
using Fusion;
using UnityEngine;
using Zenject;

namespace Code.Runtime.Logic
{
    [RequireComponent(typeof(Animator), typeof(PlayerData))]
    public class AvatarSynchronizer : NetworkBehaviour
    {
        private Animator _animator;
        private UserRepository _userRepository;
        private AvatarConfig _avatarConfig;
        private PlayerData _playerData;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _playerData = GetComponent<PlayerData>();
        }

        public override void Spawned()
        {
            DiContainer diContainer = FindObjectOfType<SceneContext>().Container;

            _userRepository = diContainer.Resolve<UserRepository>();
            _avatarConfig = diContainer.Resolve<AvatarConfig>();
            
            RPC_SyncAvatars(_userRepository.AvatarId, Runner.LocalPlayer.PlayerId);
        }

        // [Rpc]
        // public void RPC_Initialize()
        // {
        //     RPC_SyncAvatars(_userRepository.AvatarId, Runner.LocalPlayer.PlayerId);
        // }

        [Rpc]
        private void RPC_SyncAvatars(int avatarId, int playerId)
        {
            if (_playerData.PlayerId == playerId)
            {
                RuntimeAnimatorController runtimeAnimatorController =
                    _avatarConfig.AvatarsData[avatarId].AnimatorController;

                _animator.runtimeAnimatorController = runtimeAnimatorController;
            }
        }
    }
}