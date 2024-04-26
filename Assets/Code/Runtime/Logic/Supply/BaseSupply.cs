using Fusion;
using UnityEngine;

namespace Code.Runtime.Logic.Supply
{
    public abstract class BaseSupply : NetworkBehaviour
    {
        [SerializeField] private NetworkObject networkObject;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            PickUpImplementation(other);
        }

        protected abstract void PickUpImplementation(Collider2D other);

        protected void Despawn() =>
            Runner.Despawn(networkObject);
    }
}