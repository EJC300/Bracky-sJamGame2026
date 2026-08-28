using System.Collections.Generic;
using UnityEngine;
namespace Gameplay
{
    public class UFODataSelector : MonoBehaviour
    {
        public LayerMask layer;
        public List<UFOData> ufoData = new List<UFOData>();
        [SerializeField] List<GameObject> videos = new List<GameObject>();
        private int currentIndex = 0;
        private int previousIndex;
        public bool chosen;
        private void Start()
        {
            
         
            for (int i = 0; i < ufoData.Count; i++)
            {
                GameObject obj = GameObject.Instantiate( ufoData[i].ufoHolder.gameObject,transform.position,Quaternion.identity);
                obj.layer= layer;
                
                videos.Add(obj);
            }
            for (int j = 0; j < videos.Count; j++)
            {
                int childCount = videos[j].transform.childCount;
                for (int k = 0; k < childCount; k++)
                {
                    videos[j].transform.GetChild(k).gameObject.layer = layer;
                }
            }
            ShuffleData();
            for (int j = 1; j < videos.Count; j++)
            {
                videos[j].SetActive(false); 
            }
        
        }

        private void Update()
        {
         
            if (videos[currentIndex].activeInHierarchy)
            {
                videos[currentIndex].SetActive(true);

            }
            else if (!videos[currentIndex].activeInHierarchy)
            {
                videos[currentIndex].SetActive(false);

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
            if (currentIndex < ufoData.Count-1 && chosen)
            {
                previousIndex -= currentIndex;
                chosen = false;
                currentIndex++;
               
            }

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
