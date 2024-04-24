using UnityEngine;

namespace Code.Runtime.Logic.WeaponSystem
{
    public interface IBullet
    {
        void Initialize(int damage);
        void Move(Vector2 direction, int force);
    }
}