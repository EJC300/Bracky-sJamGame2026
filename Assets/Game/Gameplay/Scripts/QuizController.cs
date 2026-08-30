using System;
using UnityEngine;
namespace Gameplay
{
    public class QuizController : MonoBehaviour
    {
        [SerializeField] private UFODataSelector ufoDataSelector;

        private int videoCount = 0;


       public int correct;
        public int incorrect;


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
        private void Start()
        {
            videoCount = ufoDataSelector.ufoData.Count;
        }
        public void SetVideoActive()
        {
            Debug.Log(false);
            //ufoDataSelector.SetVideos();
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
                    incorrect++;
                }
                CalculateScore();
                ufoDataSelector.chosen = true;
            }
            if (ufoDataSelector.chosen)
            {
                ufoDataSelector.chosen = false;
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
                    incorrect++;
                }
                CalculateScore();
                ufoDataSelector.chosen = true;
            }
              if (ufoDataSelector.chosen)
            {
                ufoDataSelector.chosen = false;
            }
        }
        void CalculateScore()
        {
           
       
            if(correct > 2)
            {

                GameController.instance.LoadGoodEnding();
            }
            else if (incorrect > 2)
            {
                GameController.instance.LoadBadEnding();
            }

        }
    }
}
