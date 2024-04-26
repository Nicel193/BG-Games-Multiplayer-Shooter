using System.Collections.Generic;
using System.Linq;
using Code.Runtime.Logic;
using Code.Runtime.Logic.PlayerSystem;
using Code.Runtime.Logic.WaveSystem;
using Code.Runtime.Repositories;
using Code.Runtime.UI.Windows;
using UnityEngine;

namespace Code.Runtime.Infrastructure.States.Gameplay
{
    public class EndGameState : IState
    {
        private IEndGameWindow _endGameWindow;
        private INetworkPlayersHandler _networkPlayersHandler;

        public EndGameState(IEndGameWindow endGameWindow, INetworkPlayersHandler networkPlayersHandler)
        {
            _networkPlayersHandler = networkPlayersHandler;
            _endGameWindow = endGameWindow;
        }
        
        public void Enter()
        {
            List<PlayerData> playersData = _networkPlayersHandler.GetPlayersData();
  
            PlayerStatsPayload[] playersStats = playersData
                .Select(player => new PlayerStatsPayload {
                    PlayerId = player.PlayerId,
                    TotalDamage = player.TotalDamage,
                    KillsCount = player.KillsCount
                })
                .ToArray();
            
            _endGameWindow.RPC_Open(playersStats);
            
            Debug.Log("End Game");
        }

        public void Exit()
        {
            
        }
    }
}