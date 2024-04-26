using Code.Runtime.Logic.PlayerSystem;
using Code.Runtime.Logic.WeaponSystem.Types;
using Fusion;

namespace Code.Runtime.Logic.WeaponSystem
{
    public interface IWeaponFactory
    {
        BaseWeapon SpawnWeapon(WeaponType weaponType, PlayerRef playerRef, PlayerData playerData);
    }
}