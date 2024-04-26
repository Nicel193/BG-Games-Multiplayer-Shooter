using System;
using Code.Runtime.Logic.PlayerSystem;
using Fusion;
using UnityEngine;

namespace Code.Runtime.Logic.Supply
{
    public abstract class BaseSupply : NetworkBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            PickUpImplementation(other);
        }

        protected abstract void PickUpImplementation(Collider2D other);
    }
}