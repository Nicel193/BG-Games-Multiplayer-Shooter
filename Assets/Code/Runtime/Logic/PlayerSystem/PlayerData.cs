using System;
using Fusion;
using UnityEngine;

namespace Code.Runtime.Logic.PlayerSystem
{
    public class PlayerData : NetworkBehaviour
    {
        public event Action OnPlayerDead;
        
        [field: HideInInspector] [Networked] public int PlayerId { get; private set;}
        [field: HideInInspector] [Networked] public int MAXAmmo { get; private set;}
        [field: HideInInspector] [Networked] public int MAXHeath { get; private set;}
        [field: HideInInspector] [Networked] public int Health { get; private set; }
        [field: HideInInspector] [Networked] public int KillsCount { get; private set; }
        [field: HideInInspector] [Networked] public int TotalDamage { get; private set; }
        [field: HideInInspector] [Networked] public int Ammo { get; private set; }

        [Rpc]
        public void RPC_Initialize(int maxAmmo, int maxHeath, int playerId)
        {
            MAXAmmo = maxAmmo;
            MAXHeath = maxHeath;
            PlayerId = playerId;

            Ammo = MAXAmmo;
            Health = MAXHeath;
        }

        public void UseAmmo()
        {
            if(Ammo <= 0) return;
            
            Ammo--;
        }

        public void RestoreAmmo(int ammoCount)
        {
            if(ammoCount <= 0) return;
            
            Ammo += ammoCount;
            
            Ammo = Mathf.Clamp(Ammo, 0, MAXAmmo);
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
            
            if(Health == 0) OnPlayerDead?.Invoke();
        }

        public void AddKill() =>
            KillsCount++;

        public void AddTotalDamage(int damage)
        {
            if(damage <= 0) return;

            TotalDamage += damage;
        }

        public bool IsDeath() =>
            Health <= 0;
    }
}