using Code.Runtime.Configs.Supplies;
using UnityEngine;

namespace Code.Runtime.Logic.Supply
{
    public interface ISupplyFactory
    {
        BaseSupply SpawnSupply(BaseSupplyConfig baseSupplyConfig, Vector3 at);
    }
}