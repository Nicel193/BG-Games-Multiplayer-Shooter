using Code.Runtime.Repositories;
using UnityEngine;

namespace Code.Runtime.Services.SaveService
{
    public class SaveService : ISaveService
    {
        private const string AvatarIdKey = "AvatarId";
        
        private UserRepository _userRepository;

        private SaveService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void Save()
        {
            PlayerPrefs.SetInt(AvatarIdKey, _userRepository.AvatarId);
        }

        public void Load()
        {
            _userRepository.AvatarId = PlayerPrefs.GetInt(AvatarIdKey);
        }
    }
}