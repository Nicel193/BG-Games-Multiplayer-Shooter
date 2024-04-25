using Code.Runtime.Logic.PlayerSystem;
using Code.Runtime.Repositories;
using UnityEngine;

namespace Code.Runtime.Infrastructure.States.Gameplay
{
    public class GameLoopState : IState
    {
        public void Enter()
        {
            Debug.Log("Game loop state");
        }
        
        public void Exit()
        {
            
        }
    }
}