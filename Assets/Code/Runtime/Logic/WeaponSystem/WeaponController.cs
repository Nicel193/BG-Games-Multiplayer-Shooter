using Fusion;
using UnityEngine;

namespace Code.Runtime.Logic.WeaponSystem
{
    public class WeaponController : NetworkBehaviour
    {
        [SerializeField] private BaseWeapon baseWeapon;
        
        public override void FixedUpdateNetwork()
        {
            if (GetInput(out NetworkInputData networkData))
            {
                networkData.ShootDirection.Normalize();

                Vector3 direction = Runner.DeltaTime * networkData.ShootDirection;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                
                transform.rotation = Quaternion.Euler(0f, 0f, angle);

                if (networkData.IsShoot) baseWeapon.Shoot(direction);
            }
        }
    }
}