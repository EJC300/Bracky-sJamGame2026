using UnityEngine;
namespace Gameplay
{
    public class QuizController : MonoBehaviour
    {
        [SerializeField] private UFODataSelector ufoDataSelector;

       

        private int score;

        private int correct;

 

        private void Update()
        {
            if (!ufoDataSelector.chosen)
            {
                if (correct > ufoDataSelector.ufoData.Count - 1)
                {
                    correct--;
                }
                else if (correct < 0)
                {
                    correct++;
                }
          
            }
       
        }

        public void SetVideoActive()
        {
            Debug.Log(false);
            ufoDataSelector.SetVideos();
        }
        public void ChooseForgery()
        {
            if (!ufoDataSelector.chosen)
            {
                if (ufoDataSelector.GetUFOData().forged == true)
                {
                    correct++;

                }
                else
                {
                    correct--;
                }
                ufoDataSelector.chosen = true;
            }
         
        }
       
        public void ChooseAircraft()
        {
            if (!ufoDataSelector.chosen)
            {
                if (ufoDataSelector.GetUFOData().aircraft == true)
                {
                    correct++;

                }
                else
                {
                    correct--;
                }
                ufoDataSelector.chosen = true;
            }
        }

        public void ChooseAnomaly()
        {
            if (!ufoDataSelector.chosen)
            {
                if (ufoDataSelector.GetUFOData().anomaly == true)
                {
                    correct++;

                }
                else
                {
                    correct--;
                }

                ufoDataSelector.chosen = true;
            }
        }
    }
}
