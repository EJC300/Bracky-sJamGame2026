using System.Threading;
using UnityEngine;
using Systems;
namespace Gameplay
{
    public class UFOResetTransformByTime : MonoBehaviour
    {
        public GameTimer reseTimer = new GameTimer(5f, true);
  
        private Vector3 startPosition;
        private Quaternion startRotation;
        private Vector3 startScale;
        

      

        
        private void Start()
        {
            startPosition = transform.position;
            startRotation = transform.rotation;

            startScale = transform.localScale;

        }
        private void Update()
        {
          
            if (reseTimer.CountDown())
            {
                transform.position = startPosition;
                transform.localScale = startScale;
                transform.rotation = startRotation;
            }
        }
    }
}
