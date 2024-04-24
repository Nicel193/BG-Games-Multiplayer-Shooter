using System;
using Fusion;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code.Runtime.Logic
{
    [RequireComponent(typeof(NetworkRunner))]
    public class NetworkBootstrapper : MonoBehaviour
    {
        private NetworkRunner runner;

        private void Awake() =>
            runner = GetComponent<NetworkRunner>();

        private void OnGUI()
        {
            if (GUI.Button(new Rect(0, 0, 200, 40), "Host"))
            {
                StartGame(GameMode.Host);
            }

            if (GUI.Button(new Rect(0, 40, 200, 40), "Join"))
            {
                StartGame(GameMode.Client);
            }
        }

        private async void StartGame(GameMode mode)
        {
            // Create the Fusion runner and let it know that we will be providing user input
            runner.ProvideInput = true;

            // Create the NetworkSceneInfo from the current scene
            var scene = SceneRef.FromIndex(SceneManager.GetActiveScene().buildIndex);
            var sceneInfo = new NetworkSceneInfo();
            if (scene.IsValid)
            {
                sceneInfo.AddSceneRef(scene, LoadSceneMode.Additive);
            }

            // Start or join (depends on gamemode) a session with a specific name
            await runner.StartGame(new StartGameArgs()
            {
                GameMode = mode,
                SessionName = "TestRoom",
                Scene = scene,
                SceneManager = gameObject.AddComponent<NetworkSceneManagerDefault>()
            });
        }
    }
}