using Fusion;

public class PlayerHeath : NetworkBehaviour
{
     public int heath;
     
     public void RPC_Damage(int damage)
     {
          if(damage <= 0) return;

          heath -= damage;
     }
}