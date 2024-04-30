using System;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Runtime.UI
{
    [RequireComponent(typeof(Button))]
    public class ExitGameButton : MonoBehaviour
    {
        private Button _exitButton;

        private void Awake()
        {
            _exitButton = GetComponent<Button>();
        }

        private void OnEnable()
        {
            _exitButton.onClick.AddListener(ExitGame);
        }

        private void OnDisable()
        {
            _exitButton.onClick.RemoveListener(ExitGame);
        }

        private void ExitGame()
        {
            Application.Quit();
        }
    }
}