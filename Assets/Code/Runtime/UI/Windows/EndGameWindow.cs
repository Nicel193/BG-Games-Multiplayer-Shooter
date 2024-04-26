using Fusion;
using UnityEngine;

namespace Code.Runtime.UI.Windows
{
    public class EndGameWindow : NetworkBehaviour, IEndGameWindow
    {
        [SerializeField] private PlayerStatsElement playerStatsElementPrefab;
        [SerializeField] private Transform playerStatsContainer;
        
        [Rpc]
        public void RPC_Open(PlayerStatsPayload[] playersStats)
        {
            gameObject.SetActive(true);
            
            foreach (PlayerStatsPayload stats in playersStats)
            {
                PlayerStatsElement playerStatsElement = Instantiate(playerStatsElementPrefab, playerStatsContainer);
                
                playerStatsElement.Initialize(stats.PlayerId, stats.TotalDamage, stats.KillsCount);
            }
        } 
    }
}