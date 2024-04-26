using Fusion;
using UnityEngine;

namespace Code.Runtime.Logic.PlayerSystem
{
    public class PlayerData : NetworkBehaviour
    {
        [Networked] public int MAXAmmo { get; private set;}
        [Networked] public int MAXHeath { get; private set;}
        [Networked] public int Health { get; private set; }
        [Networked] public int KillsCount { get; private set; }
        [Networked] public int TotalDamage { get; private set; }
        [Networked] public int Ammo { get; private set; }

        [Rpc]
        public void RPC_Initialize(int maxAmmo, int maxHeath)
        {
            MAXAmmo = maxAmmo;
            MAXHeath = maxHeath;

            Ammo = MAXAmmo;
            Health = MAXHeath;
            KillsCount = 0;
            TotalDamage = 0;
        }

        public void UseAmmo()
        {
            if(Ammo <= 0) return;
            
            Ammo--;
        }

        public void RestoreAmmo()
        {
            Ammo = MAXAmmo;
        }

        public void AddHp(int hp)
        {
            if(hp <= 0) return;
            
            Health += hp;

            Health = Mathf.Clamp(Health, 0, MAXHeath);
        }
        
        public void Damage(int damage)
        {
            if(damage <= 0) return;
            
            Health -= damage;

            Health = Mathf.Clamp(Health, 0, MAXHeath);
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