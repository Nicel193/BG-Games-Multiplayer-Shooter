using System.Collections.Generic;
using Code.Runtime.Configs;
using Code.Runtime.Repositories;
using Code.Runtime.Services.SaveService;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.Runtime.UI
{
    public class AvatarChooseField : MonoBehaviour
    {
        [SerializeField] private AvatarView avatarPrefab;
        [SerializeField] private Transform avatarsContainer;
        
        private AvatarConfig _avatarConfig;
        private UserRepository _userRepository;
        private ISaveService _saveService;
        private List<AvatarView> _avatarViews = new List<AvatarView>();

        [Inject]
        public void Construct(AvatarConfig avatarConfig, UserRepository userRepository, ISaveService saveService)
        {
            _saveService = saveService;
            _userRepository = userRepository;
            _avatarConfig = avatarConfig;
        }

        private void Start()
        {
            AvatarConfig.AvatarData[] avatarsData = _avatarConfig.AvatarsData;

            for (int i = 0; i < avatarsData.Length; i++)
            {
                AvatarView avatarView = Instantiate(avatarPrefab, avatarsContainer);
                Button button = avatarView.GetComponent<Button>();
                int id = i;

                avatarView.Image.sprite = avatarsData[i].AvatarSprite;
                button.onClick.AddListener(() => { ChooseAvatar(avatarView, id);});
                _avatarViews.Add(avatarView); 
            }

            _avatarViews[_userRepository.AvatarId].Outline.enabled = true;
        }

        private void OnDestroy()
        {
            foreach (AvatarView avatarView in _avatarViews)
                avatarView.Button.onClick.RemoveAllListeners();
        }

        private void ChooseAvatar(AvatarView chooseAvatarView, int id)
        {
            foreach (AvatarView avatarView in _avatarViews)
                avatarView.Outline.enabled = false;

            chooseAvatarView.Outline.enabled = true;
            
            _userRepository.AvatarId = id;
            _saveService.Save();
        }
    }
}