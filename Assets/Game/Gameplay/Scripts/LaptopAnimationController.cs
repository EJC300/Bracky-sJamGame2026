using System;
using UnityEngine;
namespace Gameplay
{
    public class LaptopAnimationController : MonoBehaviour
    {
        [SerializeField] private float openingSpeed;
        private float targetAngle = 0;
        
        void OpenLaptop()
        {
            Quaternion targetRotation = Quaternion.Euler(transform.localEulerAngles.x,transform.localEulerAngles.y,targetAngle);
            Quaternion newRotation = Quaternion.Slerp(transform.localRotation,targetRotation , Time.deltaTime * openingSpeed);
            transform.localRotation = newRotation;
        }

        private void Update()
        {
            if (GameController.instance.GetGameState() == GameController.GameState.StartGame)
            {
                OpenLaptop();
            
            }

        }


    }

}
