using Code.Runtime.Logic.WeaponSystem.Types;
using Fusion;
using UnityEngine;

namespace Code.Runtime.Logic.WeaponSystem
{
    public class WeaponController : NetworkBehaviour
    {
        [SerializeField] private BaseWeapon baseWeapon;

        public override void FixedUpdateNetwork()
        {
            if (GetInput(out NetworkInputData inputData))
            {
                inputData.ShootDirection.Normalize();

                Vector3 direction = Runner.DeltaTime * inputData.ShootDirection;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

                Vector3 correctRotation = inputData.ShootDirection.x >= 0
                    ? new Vector3(0f, 0f, angle)
                    : new Vector3(180f, -180f, -angle);

                transform.localRotation = Quaternion.Euler(correctRotation);
                
                if (inputData.IsShoot) baseWeapon.Attack(direction);
            }
        }
    }
}