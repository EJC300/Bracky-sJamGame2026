using UnityEngine;
using Systems;
namespace Gameplay
{
    public class HangerOpen : MonoBehaviour
    {
        public float liftTime = 5; 
        public float liftSpeed = 500;
        private GameTimer openTimer;

        private void Start()
        {
            openTimer = new GameTimer(liftTime, false);
        }
        private void Update()
        {
            if (!openTimer.CountDown())
            {
                transform.Translate(Vector3.forward * liftSpeed/liftTime* Time.deltaTime);
            }
        }



    }
}
