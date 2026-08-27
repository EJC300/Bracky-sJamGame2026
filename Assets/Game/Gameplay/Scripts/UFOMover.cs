using Systems;
using UnityEngine;
namespace Gameplay
{
    public class UFOMover : MonoBehaviour
    {

        public GameTimer reseTimer = new GameTimer(5f, true);
        public GameTimer rapidAcceleration = new GameTimer(3, false);
        [SerializeField] private float moveSpeed;
        [SerializeField] private float accelerationSpeed;
 
        private Vector3 startPosition;
        private Quaternion startRotation;
        private Vector3 startScale;
        private Vector3 velocity;
        /*
         * Rewrite this whole thing with a timer script
         * 
         * Timers count down and reset if possible 
         * 
         * The UFOs do stuff when a timer is up or for when a timer is counting down
         * 
         * This is what I am doing instead of animation clips cheap but it works
         *


       

         */






        private void Start()
        {
            startPosition = transform.position;
            startRotation = transform.rotation;

            startScale = transform.localScale;

        }
        private void Update()
        {
            MoveUFO();
            Reset();
        }
        void MoveUFO()
        {
            velocity = Vector3.forward;
            if(rapidAcceleration.CountDown())
            {
                velocity *= accelerationSpeed;
            }
            else
            {
                velocity *= moveSpeed;
            }

                transform.Translate(velocity * Time.deltaTime);
        }
        private void Reset()
        {
            if (reseTimer.CountDown())
            {
                rapidAcceleration.ResetTimer();
                transform.localPosition = startPosition;
                transform.localRotation = startRotation;
                transform.localScale = startScale;
                
            }
        }

    }

}