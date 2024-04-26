using Code.Runtime.Logic.WaveSystem;
using Code.Runtime.Repositories;
using UnityEngine;

namespace Code.Runtime.Infrastructure.States.Gameplay
{
    public class EndGameState : IState
    {
        public EndGameState()
        {
      
        }
        
        public void Enter()
        {
            Debug.Log("End Game");
        }

        public void Exit()
        {
            
        }
    }
}