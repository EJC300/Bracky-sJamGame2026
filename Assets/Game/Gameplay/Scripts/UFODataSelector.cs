using System.Collections.Generic;
using UnityEngine;
namespace Gameplay
{
    public class UFODataSelector : MonoBehaviour
    {
        [SerializeField] LayerMask layer;
       public List<UFOData> ufoData = new List<UFOData>();
        [SerializeField] List<GameObject> videos = new List<GameObject>();
        private int currentIndex = 0;
        private int previousIndex;
        public bool chosen;
        private void Start()
        {
            InitializeUFOData();
            ShuffleData();
         
        
        }

        private void Update()
        {
         
        }
        
     
        void IntializeVideos(UFOData ufoData)
        {
          GameObject obj= Instantiate(ufoData.ufoHolder,transform.position,Quaternion.identity).gameObject;
          obj.SetActive(false);
          videos.Add(obj);
        

        }
        void InitializeUFOData()
        {
            for (int i = 0; i < ufoData.Count; i++)
            {
                IntializeVideos(ufoData[i]);
            }
        }
        void ShuffleData()
        {

            int dataCount = ufoData.Count;

            while (dataCount > 1)
            {
                dataCount--;

                int index = Random.Range(0, dataCount + 1);
                (ufoData[index], ufoData[dataCount]) = (ufoData[dataCount], ufoData[index]);
                (videos[index], videos[dataCount]) = (videos[dataCount], videos[index]);
            }

          
        }
       
        public void ChooseNextUFOData()
        {
           
           
     
            videos[currentIndex].SetActive(false);
            currentIndex = (currentIndex + 1) % ufoData.Count;
            videos[currentIndex].SetActive(true);
        }

        public UFOData GetUFOData()
        {
            return ufoData[currentIndex];
        }
        public void SetVideos()
        {
            
        }

    }
}
