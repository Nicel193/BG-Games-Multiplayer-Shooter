using Fusion;

namespace Code.Runtime.UI.Windows
{
    public struct PlayerStatsPayload : INetworkStruct
    {
        public int PlayerId;
        public int TotalDamage;
        public int KillsCount;
    }
}