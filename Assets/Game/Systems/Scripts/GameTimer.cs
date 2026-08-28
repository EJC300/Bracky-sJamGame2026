using System.Collections;
using UnityEngine;
namespace Systems
{
    [System.Serializable]
    public class GameTimer
    {
       private float currentTime;

       private float duration;

       private bool repeat;
        


        public GameTimer(float duration,bool repeat)
        {
            this.duration = duration;
            this.repeat = repeat;
            currentTime = duration;

        }
        public void ResetTimer()
        {
            currentTime = duration;
        }
        public bool CountDown()
        {

            if (currentTime > 0)
            {


                currentTime -= Time.deltaTime;
            
            }
          

            else if (currentTime < 0 && repeat)
            {
                currentTime = this.duration;
            }

            return currentTime < 0;

          
        }
     
     


    }
    
}