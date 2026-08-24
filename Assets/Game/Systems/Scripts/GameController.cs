using UnityEngine;
namespace System
{
    public class GameController : MonoBehaviour
    {

        public static GameController instance = null;

      
      public enum GameState { Win, Lose ,Exit,StartGame }


        private GameState currentGameState;

        public GameState GetGameState()
        {
           
            return currentGameState;
        }
        public void SwitchGameState(GameState newState)
        {
            if (!currentGameState.Equals(newState))
            {

                currentGameState = newState;
            }
        }

        private void Start()
        {
            if (instance == null)
            {
                instance = this;
            }
        }
    }
}
