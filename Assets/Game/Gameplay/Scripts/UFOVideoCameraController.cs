using UnityEngine;
namespace Gameplay
{
    public class UFOVideoCameraController : MonoBehaviour
    {



        [SerializeField] Transform[] UFOParents;
        
        private Transform currentUFOParent;
        public Transform pastUFOParent;
        private int videoIndex = 0;


        public void IncreaseIndex()
        {
            if (videoIndex < UFOParents.Length - 1)
            {
                videoIndex += 1;
            }
        }

        void SetActiveUFOParent()
        {
            currentUFOParent = UFOParents[videoIndex];

        
            currentUFOParent.gameObject.SetActive(true);
            
           // pastUFOParent = currentUFOParent;

        }

        private void Update()
        {
            SetActiveUFOParent();
        }



    }
}
