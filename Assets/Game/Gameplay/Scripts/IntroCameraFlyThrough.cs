using System;
using UnityEngine;
namespace Gameplay
{
    //Later Do Intro Controller??
    public class IntroCameraFlyThrough : MonoBehaviour
    {
        [SerializeField] float traversalSpeed;
        [SerializeField] Transform[] waypoints;
        private Transform targetWaypoint;
        public int currentWaypointIndex = 0;
        private float minDistanceToTarget = 0.5f;
        private Vector3 cameraVelocity;
        public bool canLock;
        void TraverseWaypoints()
        {
            canLock = Vector3.Distance(transform.position, waypoints[waypoints.Length-1].position) < 0.01f;
            targetWaypoint = waypoints[currentWaypointIndex];
            float distanceToTarget = Vector3.Distance(transform.position, targetWaypoint.position);

            if (distanceToTarget < minDistanceToTarget)
            {
                if (currentWaypointIndex < waypoints.Length - 1)
                 {

               
                    currentWaypointIndex = currentWaypointIndex + 1;
                 }
                

            }

        
                MoveToWaypoint();
            
        }

        void EndIntro()
        {
       
            if (canLock)
            {
                GameController.instance.SwitchGameState(GameController.GameState.StartGame);
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
