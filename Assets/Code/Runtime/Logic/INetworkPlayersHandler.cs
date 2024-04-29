using System;
using System.Collections.Generic;
using Code.Runtime.Logic.PlayerSystem;
using Fusion;
using UnityEngine;

namespace Code.Runtime.Logic
{
    public interface INetworkPlayersHandler
    {
        void AddNetworkPlayer(PlayerRef player, NetworkObject playerObject);
        List<Transform> GetActivePlayersTransforms();
        void RemoveActivePlayer(NetworkObject playerObject);
        List<PlayerData> GetPlayersData();
        event Action OnPlayerJoined;
    }
}