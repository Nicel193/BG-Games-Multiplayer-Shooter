using UnityEngine;
using UnityEngine.UI;

namespace Code.Runtime.UI
{
    public class AvatarView : MonoBehaviour
    {
        [field:SerializeField] public Outline Outline { get; private set; }
        [field:SerializeField] public Button Button { get; private set; }
        [field:SerializeField] public Image Image { get; private set; }
    }
}