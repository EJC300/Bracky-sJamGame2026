using UnityEngine;
namespace Gameplay
{
    //Later Do Intro Controller??
    public class IntroCameraFlyThrough : MonoBehaviour
    {
        [SerializeField] float traversalSpeed;
        [SerializeField] Transform[] waypoints;
        private Transform targetWaypoint;
        private int currentWaypointIndex = 0;
        private float minDistanceToTarget = 0.5f;
        private Vector3 cameraVelocity;
        private bool canLock;
        void TraverseWaypoints()
        {
            canLock = currentWaypointIndex == waypoints.Length - 1;
            targetWaypoint = waypoints[currentWaypointIndex];
            float distanceToTarget = Vector3.Distance(transform.position, targetWaypoint.position);

            if (canLock)
            {

                if (distanceToTarget < minDistanceToTarget && currentWaypointIndex < waypoints.Length - 1)
                {
                    currentWaypointIndex = currentWaypointIndex + 1;
                }



                MoveToWaypoint();
            }
        }

        void EndIntro()
        {
       
            if (canLock)
            {
                //Lock To laptop main game loop start
            }
        }
        void MoveToWaypoint()
        {
            Vector3 target = Vector3.SmoothDamp(transform.position, targetWaypoint.position, ref cameraVelocity, 0.5f);
            Vector3 translation = Vector3.Lerp(transform.position,target,Time.deltaTime * traversalSpeed);
            transform.position = translation;
        }

        private void Update()
        {
            TraverseWaypoints();
            EndIntro();
        }
    }
}
