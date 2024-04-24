using Fusion;

namespace Code.Runtime.Logic.PlayerSystem
{
    public class Player : NetworkBehaviour
    {
        [Rpc]
        public void RPC_Damage(int damage)
        {
            
        }
    }
}