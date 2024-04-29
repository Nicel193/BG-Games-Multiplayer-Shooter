using Code.Runtime.Logic.Supply;
using UnityEngine;

namespace Code.Runtime.Configs.Supplies
{
    public abstract class BaseSupplyConfig : ScriptableObject
    {
        [field: SerializeField] public BaseSupply SupplyPrefab { get; private set; }
    }
}