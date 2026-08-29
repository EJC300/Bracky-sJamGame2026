using UnityEngine;
namespace Effects
{
    public class FLIREffectBlit : MonoBehaviour
    {

       
        public RenderTexture flirEffect;
        public RenderTexture inputTexture;
        public Material renderMaterial;
        private void LateUpdate()
        {
            Graphics.Blit(inputTexture, flirEffect, renderMaterial);
        }
    }
}
