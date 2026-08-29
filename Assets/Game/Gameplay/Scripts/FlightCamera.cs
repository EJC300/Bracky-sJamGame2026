using Systems;
using UnityEngine;
namespace Gameplay
{
    public class FlightCamera : MonoBehaviour
    {
        //Flight Camera leads the target with a lerp for a classic gimbal style camera on a drone or fighter.
        [SerializeField] private float seconds;
        
        [SerializeField] private GameTimer timer;
        
        [SerializeField] private Camera flightCamera;
        [SerializeField] private float maxZoomOut;
        [SerializeField] private float maxZoomIn;
        [SerializeField] private float zoomTime;
        [SerializeField] private float zoomOut;
        [SerializeField] private Transform target;

        [SerializeField] private float lookSpeed;

        private GameTimer zoomInTimer;
        private GameTimer zoomOutTimer;
        private Vector3 prevTargetPosition;
        private Vector3 currentTargetPosition;
        private Vector3 targetVelocity;
        private Vector3 lead;

        private Quaternion lookToLead;
        private float currentZoom;
        private void Start()
        {
            timer = new GameTimer(seconds, true);
            currentZoom = 60;
            zoomOutTimer = new GameTimer(zoomTime, false);
            zoomInTimer = new GameTimer(maxZoomIn, false);

        }

        void ZoomInOnTarget()
        {
            if (zoomInTimer.CountDown())
            {
                currentZoom = Mathf.MoveTowards(currentZoom, maxZoomIn, 1.0f);
            }
            else
            {
              
            }
                flightCamera.fieldOfView = currentZoom;
        }
        void ZoomOutOnTarget()
        {
            if (zoomOutTimer.CountDown())
            {
                currentZoom = Mathf.MoveTowards(currentZoom, maxZoomOut, 1.0f);
            }
            else
            {

            }
            if (timer.CountDown())
            {
                currentZoom = 60;
            }
            flightCamera.fieldOfView = currentZoom;
        }

        private void Update()
        {
            currentTargetPosition = target.position;
            ZoomInOnTarget();
            ZoomOutOnTarget();
          
            targetVelocity = (prevTargetPosition - currentTargetPosition)/Time.deltaTime;

            lead = ((currentTargetPosition) - transform.position).normalized;

            lookToLead = Quaternion.LookRotation(lead);
            transform.rotation = Quaternion.Slerp(transform.rotation,lookToLead, lookSpeed * Time.deltaTime);
            prevTargetPosition = target.position;

        }

    }

}
