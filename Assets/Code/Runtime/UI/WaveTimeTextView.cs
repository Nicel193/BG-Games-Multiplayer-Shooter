using Code.Runtime.Logic.WaveSystem;
using Fusion;
using TMPro;
using UnityEngine;
using Zenject;

namespace Code.Runtime.UI
{
    public class WaveTimeTextView : NetworkBehaviour
    {
        [SerializeField] private TextMeshProUGUI timerText;

        [Rpc]
        public void RPC_UpdateTimer(float time)
        {
            timerText.text = GetStringTime(time);
        }

        private string GetStringTime(float timeInSeconds)
        {
            int minutes = Mathf.FloorToInt(timeInSeconds / 60);
            int seconds = Mathf.FloorToInt(timeInSeconds % 60);
            
            return $"{minutes:00}:{seconds:00}";
        }
    }
}