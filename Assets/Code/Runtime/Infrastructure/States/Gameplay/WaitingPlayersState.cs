using System.Linq;
using Code.Runtime.Logic;
using Code.Runtime.Logic.WaveSystem;
using Fusion;
using UnityEngine;

namespace Code.Runtime.Infrastructure.States.Gameplay
{
    public class WaitingPlayersState : IPayloadedState<PlayerRef>
    {
        private IWaveHandler _waveHandler;
        private INetworkPlayersHandler _networkPlayersHandler;

        private bool _isStartWave;

        public WaitingPlayersState(IWaveHandler waveHandler, INetworkPlayersHandler networkPlayersHandler)
        {
            _networkPlayersHandler = networkPlayersHandler;
            _waveHandler = waveHandler;
        }

        public void Enter(PlayerRef playerRef)
        {
            if (_networkPlayersHandler.GetPlayersData().Count >= 2)
                InitializeWaveSystem(playerRef);
        }

        public void Exit()
        {
        }

        private void InitializeWaveSystem(PlayerRef playerRef)
        {
            if (_isStartWave) return;

            _waveHandler.Initialize();
            _isStartWave = true;
        }
    }
}