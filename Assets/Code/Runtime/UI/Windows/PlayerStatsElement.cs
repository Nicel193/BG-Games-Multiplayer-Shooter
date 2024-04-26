using TMPro;
using UnityEngine;

namespace Code.Runtime.UI.Windows
{
    public class PlayerStatsElement : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI playerIdTest;
        [SerializeField] private TextMeshProUGUI playerTotalDamageText;
        [SerializeField] private TextMeshProUGUI playerKillsCountText;

        public void Initialize(int playerId, int playerTotalDamage, int playerKillsCount)
        {
            playerIdTest.text = $"Player {playerId}";
            playerTotalDamageText.text = $"Total damage {playerTotalDamage}";
            playerKillsCountText.text = $"Kills {playerKillsCount}";
        }
    }
}