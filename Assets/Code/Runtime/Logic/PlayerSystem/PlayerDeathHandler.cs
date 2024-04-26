using Code.Runtime.Logic.WeaponSystem.Types;
using Fusion;
using UnityEngine;

namespace Code.Runtime.Logic.PlayerSystem
{
    [RequireComponent(typeof(SpriteRenderer), typeof(PlayerData))]
    public class PlayerDeathHandler : NetworkBehaviour
    {
        private const float DeadPlayerSpriteAlpha = 0.3f;
        
        private PlayerData _playerData;
        private SpriteRenderer _spriteRenderer;
        private INetworkPlayersHandler _networkPlayersHandler;

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _playerData = GetComponent<PlayerData>();
        }

        private void OnEnable() =>
            _playerData.OnPlayerDead += RPC_PlayerDead;

        private void OnDestroy() =>
            _playerData.OnPlayerDead -= RPC_PlayerDead;

        public void Initialize(INetworkPlayersHandler networkPlayersHandler)
        {
            _networkPlayersHandler = networkPlayersHandler;
        }

        [Rpc]
        private void RPC_PlayerDead()
        {
            DisableWeapon();
            ChangeSpriteAlpha();

            if (!Runner.IsClient) _networkPlayersHandler.RemoveActivePlayer(GetComponent<NetworkObject>());
        }

        private void DisableWeapon()
        {
            BaseWeapon weapon = GetComponentInChildren<BaseWeapon>();

            if(weapon == null) return;
            
            weapon.gameObject.SetActive(false);
        }

        private void ChangeSpriteAlpha()
        {
            Color spriteRendererColor = _spriteRenderer.color;
            spriteRendererColor.a = DeadPlayerSpriteAlpha;
            _spriteRenderer.color = spriteRendererColor;
        }
    }
}