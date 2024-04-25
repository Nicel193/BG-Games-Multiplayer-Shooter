using UnityEngine;

namespace Code.Runtime.Logic.PlayerSystem
{
    public class PlayerData
    {
        private readonly int _maxAmmo;
        private readonly int _maxHeath;

        public int Health { get; private set; }
        public int KillsCount { get; private set; }
        public int TotalDamage { get; private set; }
        public int Ammo { get; private set; }

        public PlayerData(int maxAmmo, int maxHeath)
        {
            _maxAmmo = maxAmmo;
            _maxHeath = maxHeath;
        }

        public void RestoreAmmo()
        {
            Ammo = _maxAmmo;
        }

        public void AddHp(int hp)
        {
            if(hp <= 0) return;
            
            Health += hp;

            Health = Mathf.Clamp(Health, 0, _maxHeath);
        }

        public void AddKill()
        {
            KillsCount++;
        }

        public void AddTotalDamage(int damage)
        {
            if(damage <= 0) return;

            TotalDamage += damage;
        }
    }
}