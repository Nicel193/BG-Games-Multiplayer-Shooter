using Code.Runtime.Logic.WeaponSystem.Types;
using Fusion;
using UnityEngine;
using Zenject;

namespace Code.Runtime.Logic.PlayerSystem
{
    [RequireComponent(typeof(SpriteRenderer), typeof(PlayerData))]
    public class PlayerDeathHandler : NetworkBehaviour
    {
        private const float DeadPlayerSpriteAlpha = 0.3f;
        
        private BaseWeapon _weapon;
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

        public void Initialize(BaseWeapon weapon, INetworkPlayersHandler networkPlayersHandler)
        {
            _networkPlayersHandler = networkPlayersHandler;
            _weapon = weapon;
        }

        [Rpc]
        public void RPC_PlayerDead()
        {
            _weapon.gameObject.SetActive(false);
            ChangeSpriteAlpha();
            _networkPlayersHandler.RemoveActivePlayer(GetComponent<NetworkObject>());
        }

        private void ChangeSpriteAlpha()
        {
            Color spriteRendererColor = _spriteRenderer.color;
            spriteRendererColor.a = DeadPlayerSpriteAlpha;
            _spriteRenderer.color = spriteRendererColor;
        }
    }
}