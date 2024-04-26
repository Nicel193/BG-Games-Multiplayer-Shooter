using Code.Runtime.Logic.PlayerSystem;
using TMPro;
using UnityEngine;

public class PlayerDataView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI killsText;
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private TextMeshProUGUI ammoText;

    private PlayerData _playerData;

    public void Initialize(PlayerData playerData)
    {
        _playerData = playerData;
    }

    private void Update()
    {
        if(_playerData == null) return;
        
        killsText.text = $"Kills {_playerData.KillsCount}";
        healthText.text = $"HP {_playerData.Health}/{_playerData.MAXHeath}";
        ammoText.text = $"Ammo {_playerData.Ammo}/{_playerData.MAXAmmo}";
    }
}
