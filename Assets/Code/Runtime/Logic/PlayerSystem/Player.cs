using Fusion;
using UnityEngine;

namespace Code.Runtime.Logic.PlayerSystem
{
    [RequireComponent(typeof(PlayerData))]
    public class Player : NetworkBehaviour, IDamageable
    {
        private PlayerData PlayerData { get; set; }

        private void Awake()
        {
            PlayerData = GetComponent<PlayerData>();
        }

        public override void Spawned()
        {
            if (Object.HasInputAuthority)
            {
                FindObjectOfType<CameraFollow>()?.SetTarget(transform);
                FindObjectOfType<PlayerDataView>()?.Initialize(PlayerData);
            }
        }
        
        [Rpc]
        private void RPC_Damage(int damage) =>
            PlayerData.Damage(damage);

        public void Damage(int damage) =>
            RPC_Damage(damage);

        public bool IsDead() =>
            PlayerData.Health == 0;
    }
}