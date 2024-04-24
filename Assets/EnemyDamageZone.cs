using Fusion;
using UnityEngine;

public class EnemyDamageZone : NetworkBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out PlayerHeath playerHeath))
        {
            playerHeath.RPC_Damage(10);
        }
    }
}