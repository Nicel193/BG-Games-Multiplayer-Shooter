using Fusion;

namespace Code.Runtime.Logic.PlayerSystem
{
    public interface IPlayerFactory
    {
        NetworkObject SpawnPlayer(PlayerRef playerRef);
    }
}