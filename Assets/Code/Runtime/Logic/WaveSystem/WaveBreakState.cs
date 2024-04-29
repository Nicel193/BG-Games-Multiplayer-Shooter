using Code.Runtime.Configs;
using Code.Runtime.Configs.Supplies;
using Code.Runtime.Logic.Supply;
using Fusion;

namespace Code.Runtime.Logic.WaveSystem
{
    public class WaveBreakState : WaveSuppliesState
    {
        private WaveHandler _waveHandler;
        private NetworkRunner _networkRunner;
        private WaveStateMachine _waveStateMachine;
        private WaveConfig _currentWaveConfig;

        private bool _timerIsStart;

        public WaveBreakState(ISupplyFactory supplyFactory, WaveHandler waveHandler, WaveStateMachine waveStateMachine) : base(supplyFactory, waveHandler)
        {
            _waveStateMachine = waveStateMachine;
            _waveHandler = waveHandler;
            _networkRunner = _waveHandler.Runner;
        }
        
        public override void Enter(WaveConfig waveConfig)
        {
            _waveHandler.WaveTimer = TickTimer.CreateFromSeconds(_networkRunner, waveConfig.BreakTime);
            _currentWaveConfig = waveConfig;
            _timerIsStart = true;
            
            base.Enter(waveConfig);
        }

        public override void Exit()
        {
            _timerIsStart = false;
            
            base.Exit();
        }

        public override void Update()
        {
            if (_timerIsStart && _waveHandler.WaveTimer.Expired(_networkRunner))
                _waveStateMachine.Enter<WaveSpawnState, WaveConfig>(_currentWaveConfig);
            
            base.Update();
        }
    }
}