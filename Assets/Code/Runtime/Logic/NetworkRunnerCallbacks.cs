using System;
using System.Collections.Generic;
using Code.Runtime.Infrastructure.StateMachines;
using Code.Runtime.Infrastructure.States;
using Code.Runtime.Infrastructure.States.Core;
using Code.Runtime.Services.InputService;
using Fusion;
using Fusion.Sockets;
using UnityEngine;
using Zenject;

namespace Code.Runtime.Logic
{
    public class NetworkRunnerCallbacks : MonoBehaviour, INetworkRunnerCallbacks
    {
        private NetworkRunner _networkRunner;
        private IInputService _inputService;
        private GameStateMachine _gameStateMachine;

        private void OnEnable()
        {
            if (_networkRunner != null)
            {
                _networkRunner.AddCallbacks(this);
            }
        }

        private void OnDisable()
        {
            if (_networkRunner != null)
            {
                _networkRunner.RemoveCallbacks(this);
            }
        }

        [Inject]
        public void Construct(IInputService inputService, NetworkRunner networkRunner, GameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
            _networkRunner = networkRunner;
            _inputService = inputService;
        }

        public void OnPlayerJoined(NetworkRunner runner, PlayerRef player)
        {
        }

        public void OnPlayerLeft(NetworkRunner runner, PlayerRef player)
        {
        }

        public void OnInput(NetworkRunner runner, NetworkInput input)
        {
            NetworkInputData data = new NetworkInputData();

            _inputService.UpdateInputData();

            data.MoveDirection = _inputService.MoveDirection;
            data.ShootDirection = _inputService.ShootDirection;
            data.IsShoot = _inputService.IsShoot;

            input.Set(data);
        }

        public void OnInputMissing(NetworkRunner runner, PlayerRef player, NetworkInput input)
        {
        }

        public void OnShutdown(NetworkRunner runner, ShutdownReason shutdownReason)
        {
        }

        public void OnConnectedToServer(NetworkRunner runner)
        {
        }

        public void OnDisconnectedFromServer(NetworkRunner runner, NetDisconnectReason reason)
        {
        }

        public void OnConnectRequest(NetworkRunner runner, NetworkRunnerCallbackArgs.ConnectRequest request,
            byte[] token)
        {
        }

        public void OnConnectFailed(NetworkRunner runner, NetAddress remoteAddress, NetConnectFailedReason reason)
        {

        }

        public void OnUserSimulationMessage(NetworkRunner runner, SimulationMessagePtr message)
        {
        }

        public void OnSessionListUpdated(NetworkRunner runner, List<SessionInfo> sessionList)
        {
        }

        public void OnCustomAuthenticationResponse(NetworkRunner runner, Dictionary<string, object> data)
        {
        }

        public void OnHostMigration(NetworkRunner runner, HostMigrationToken hostMigrationToken)
        {
        }

        public void OnSceneLoadDone(NetworkRunner runner)
        {
        }

        public void OnSceneLoadStart(NetworkRunner runner)
        {
        }

        public void OnObjectExitAOI(NetworkRunner runner, NetworkObject obj, PlayerRef player)
        {
        }

        public void OnObjectEnterAOI(NetworkRunner runner, NetworkObject obj, PlayerRef player)
        {
        }

        public void OnReliableDataReceived(NetworkRunner runner, PlayerRef player, ReliableKey key,
            ArraySegment<byte> data)
        {
        }

        public void OnReliableDataProgress(NetworkRunner runner, PlayerRef player, ReliableKey key, float progress)
        {
        }
    }
}