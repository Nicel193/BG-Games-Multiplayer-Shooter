using Fusion;
using TMPro;
using UnityEngine;

namespace Code.Runtime.UI
{
    public class LoadingScreenView : NetworkBehaviour
    {
        [SerializeField] private TextMeshProUGUI loadingText;

        public override void Spawned()
        {
            loadingText.gameObject.SetActive(false);
        }
    }
}