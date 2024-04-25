using Code.Runtime.Configs;
using Code.Runtime.Logic.WeaponSystem.Types;
using UnityEngine;

namespace Code.Runtime.Logic.WeaponSystem
{
    public class ShotgunWeapon : BaseWeapon
    {
        private int _pelletsCount;
        private float _spreadAngle;

        public override void Initialize(BaseWeaponConfig baseWeaponConfig)
        {
            if (baseWeaponConfig is not ShotgunConfig)
            {
                Debug.LogError("Not valid weapon config");
                
                return;
            }

            ShotgunConfig shotgunConfig = (ShotgunConfig)baseWeaponConfig;

            _pelletsCount = shotgunConfig.PelletsCount;
            _spreadAngle = shotgunConfig.SpreadAngle;
            
            base.Initialize(shotgunConfig);
        }
        
        protected override void AttackImplementation(Vector2 direction)
        {
            for (int i = 0; i < _pelletsCount; i++)
            {
                IBullet bullet = Runner.Spawn(BulletPrefab, spawnBulletPoint.position, Quaternion.identity);
                
                Vector2 randomDirection = Quaternion.Euler(0, 0, Random.Range(-_spreadAngle, _spreadAngle)) * direction;

                bullet.Initialize(Damage);
                bullet.Move(randomDirection, ShootForce);
            }
        }
    }
}