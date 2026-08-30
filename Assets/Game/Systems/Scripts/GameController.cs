using UnityEngine;
using UnityEngine.SceneManagement;
namespace System
{
    public class GameController : MonoBehaviour
    {

        public static GameController instance = null;


       
      
      public enum GameState { Win, Lose ,Exit,StartGame }


        [SerializeField] private String Hanger;
        [SerializeField] private String Bedroom;

        

        private GameState currentGameState;



        public GameState GetGameState()
        {
           
            return currentGameState;
        }
        public void QuiteGame()
        {
            Application.Quit();
        }
        public void LoadGoodEnding()
        {
            SceneManager.LoadScene(Hanger);

        }
        public void LoadBadEnding()
        {
            SceneManager.LoadScene(Bedroom);
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
            else
            {
                Destroy(instance.gameObject);
            }
                DontDestroyOnLoad(instance.gameObject);
        }
    }
}
