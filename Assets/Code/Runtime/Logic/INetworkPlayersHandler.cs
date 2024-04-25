using System.Collections.Generic;
using Fusion;
using UnityEngine;

namespace Code.Runtime.Logic
{
    public interface INetworkPlayersHandler
    {
        void AddNetworkPlayer(PlayerRef player, NetworkObject playerObject);
        List<Transform> GetPlayersTransforms();
    }
}