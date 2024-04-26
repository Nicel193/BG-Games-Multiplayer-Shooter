using System;
using UnityEngine;

namespace Code.Runtime.Logic.WeaponSystem
{
    public interface IBullet
    {
        void Initialize(int damage);
        void Launch(Vector2 direction, float force, Action<bool> onDamage = null);
    }
}