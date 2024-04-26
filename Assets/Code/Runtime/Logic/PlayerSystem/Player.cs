using Fusion;
using UnityEngine;

namespace Code.Runtime.Logic.PlayerSystem
{
    [RequireComponent(typeof(PlayerData))]
    public class Player : NetworkBehaviour, IDamageable
    {
        private PlayerData _playerData;
        
        private void Awake()
        {
            _playerData = GetComponent<PlayerData>();
        }

        public override void Spawned()
        {
            if (Object.HasInputAuthority)
            {
                FindObjectOfType<CameraFollow>()?.SetTarget(transform);
                FindObjectOfType<PlayerDataView>()?.Initialize(_playerData);
            }
        }
        
        [Rpc]
        private void RPC_Damage(int damage) =>
            _playerData.Damage(damage);

        public void Damage(int damage) =>
            RPC_Damage(damage);

        public bool IsDead() =>
            _playerData.IsDeath();
    }
}