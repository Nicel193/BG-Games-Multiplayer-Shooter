
using Fusion;

namespace Code.Runtime.UI.Windows
{
    public interface IEndGameWindow
    {
        [Rpc]
        public void RPC_Open(PlayerStatsPayload[] playersStats);
    }
}