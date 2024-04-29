using Code.Runtime.Infrastructure.StateMachines;
using Code.Runtime.Infrastructure.States.Core;
using Fusion;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.Runtime.UI
{
    public class Menu : MonoBehaviour
    {
        [SerializeField] private TMP_InputField roomNameInputField;
        [SerializeField] private TMP_InputField lobbyNameInputField;
        [SerializeField] private Button joinLobbyButton;
        [SerializeField] private Button createRoomButton;
        
        private GameStateMachine _gameStateMachine;

        [Inject]
        private void Construct(GameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }

        private void Awake()
        {
            joinLobbyButton.onClick.AddListener(JoinLobby);
            createRoomButton.onClick.AddListener(CreateRoom);
        }

        private void OnDestroy()
        {
            joinLobbyButton.onClick.RemoveListener(JoinLobby);
            createRoomButton.onClick.RemoveListener(CreateRoom);
        }

        private void JoinLobby()
        {
            string sessionName = lobbyNameInputField.text;

            _gameStateMachine.Enter<LoadGameplayState, (string sessionName, GameMode gameMode)>
                ((sessionName, GameMode.Client));
        }

        private void CreateRoom()
        {
            string sessionName = roomNameInputField.text;

            _gameStateMachine.Enter<LoadGameplayState, (string sessionName, GameMode gameMode)>
                ((sessionName, GameMode.Host));
        }
    }
}