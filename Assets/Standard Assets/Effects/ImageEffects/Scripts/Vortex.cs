using System;
using UnityEngine;

namespace UnityStandardAssets.ImageEffects
{
    [ExecuteInEditMode]
    [AddComponentMenu("Image Effects/Displacement/Vortex")]
    public class Vortex : ImageEffectBase
    {
        private Vector2 radius = new Vector2(0.05f,0.1f);
        private float angle = 0.0f;
        private Vector2 center = new Vector2(0.5f, 0.6f);
		private bool flag = true;
		public static Vector3 firePos = new Vector3 (0.0f,0.0f,0.0f);


		void Update(){

			firePos = TomyoController.screenPos;
			//print (firePos);
			//print (Screen.width);
			//print (Screen.height);
			center.x = 0.5f*firePos.x / Screen.width + 0.05f;
			center.y = 0.25f + ((firePos.y - 500.0f) / Screen.height)/3.0f;
			//print (center);

			if (flag) {
				angle += 1.0f;
				if (angle >= 30.0f){
					flag = false;
				}
			} else {
				angle -= 1.0f;
				if (angle <= -30.0f){
					flag = true;
				}
			}

		}

        // Called by camera to apply image effect
        void OnRenderImage (RenderTexture source, RenderTexture destination)
        {
            ImageEffects.RenderDistortion (material, source, destination, angle, center, radius);
        }
    }
}
