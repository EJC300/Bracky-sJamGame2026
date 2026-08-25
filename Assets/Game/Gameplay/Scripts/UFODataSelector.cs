using System.Collections.Generic;
using UnityEngine;
namespace Gameplay
{
    public class UFODataSelector : MonoBehaviour
    {
        public List<UFOData> ufoData = new List<UFOData>();

        private int index;
        public bool chosen;
        private void Start()
        {
            ShuffleData();
        }

        void ShuffleData()
        {

            int dataCount = ufoData.Count;

            while (dataCount > 1)
            {
                dataCount--;

                int index = Random.Range(0, dataCount + 1);

                (ufoData[index], ufoData[dataCount]) = (ufoData[dataCount], ufoData[index]);
            }

          
        }
       
        public void ChooseNextUFOData()
        {
            if (index < ufoData.Count-1 && chosen)
            {
                chosen = false;
                index++;
            }
        
        }

        public UFOData GetUFOData()
        {
            return ufoData[index];
        }


    }
}
