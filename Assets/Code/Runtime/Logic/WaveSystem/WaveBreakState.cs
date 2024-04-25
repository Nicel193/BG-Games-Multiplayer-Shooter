using Code.Runtime.Configs;
using Code.Runtime.Infrastructure.States;
using Fusion;

namespace Code.Runtime.Logic.WaveSystem
{
    public class WaveBreakState : IPayloadedState<WaveConfig>, IUpdatebleState
    {
        private WaveHandler _waveHandler;
        private NetworkRunner _networkRunner;
        private WaveStateMachine _waveStateMachine;
        private WaveConfig _currentWaveConfig;

        private bool _timerIsStart;

        public WaveBreakState(WaveHandler waveHandler, WaveStateMachine waveStateMachine)
        {
            _waveStateMachine = waveStateMachine;
            _waveHandler = waveHandler;
            _networkRunner = _waveHandler.Runner;
        }
        
        public void Enter(WaveConfig waveConfig)
        {
            _waveHandler.WaveTimer = TickTimer.CreateFromSeconds(_networkRunner, waveConfig.BreakTime);
            _currentWaveConfig = waveConfig;
            _timerIsStart = true;
        }

        public void Exit()
        {
            _timerIsStart = false;
        }

        public void Update()
        {
            if (_timerIsStart && _waveHandler.WaveTimer.Expired(_networkRunner))
                _waveStateMachine.Enter<WaveSpawnState, WaveConfig>(_currentWaveConfig);
        }
    }
}