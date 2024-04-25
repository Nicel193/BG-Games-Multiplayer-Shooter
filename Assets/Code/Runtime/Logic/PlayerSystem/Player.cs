using Fusion;
using UnityEngine;

namespace Code.Runtime.Logic.PlayerSystem
{
    public class Player : NetworkBehaviour
    {
        public override void Spawned()
        {
            if (Object.HasInputAuthority)
            {
                Camera main = Camera.main;

                main.GetComponent<CameraFollow>().SetTarget(transform);
            }
        }

        [Rpc]
        public void RPC_Damage(int damage)
        {
            
        }
    }
}