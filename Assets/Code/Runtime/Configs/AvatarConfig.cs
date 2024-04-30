using System;
using UnityEngine;

namespace Code.Runtime.Configs
{
    [CreateAssetMenu(fileName = "AvatarConfig", menuName = "Configs/AvatarConfig")]
    public class AvatarConfig : ScriptableObject
    {
        [field: SerializeField] public AvatarData[] AvatarsData { get; private set; }

        [Serializable]
        public struct AvatarData 
        {
            [field: SerializeField] public Sprite AvatarSprite { get; private set; }
            [field: SerializeField] public RuntimeAnimatorController AnimatorController { get; private set; }
        }
    }
}