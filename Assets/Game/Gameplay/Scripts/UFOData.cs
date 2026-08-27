using UnityEngine;
using UnityEngine.Video;
namespace Gameplay
{
    [CreateAssetMenu(fileName = "UFOData", menuName = "UFOData")]
    public class UFOData : ScriptableObject
    {
        public string clipName;

        public Transform ufoHolder;

        public bool forged;

        public bool anomaly;

        public bool aircraft;



       
    }
}