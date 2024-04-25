using Fusion;

namespace Code.Runtime.Logic.WeaponSystem
{
    public interface IWeaponFactory
    {
        BaseWeapon SpawnWeapon(WeaponType weaponType, PlayerRef playerRef);
    }
}