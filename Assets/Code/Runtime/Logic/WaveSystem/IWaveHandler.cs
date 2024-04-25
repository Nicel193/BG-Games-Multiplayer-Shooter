namespace Code.Runtime.Logic.WaveSystem
{
    public interface IWaveHandler
    {
        void Initialize();
        float? GetCurrentWaveTime();
    }
}