using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Test
{
    /// <summary>
    /// PostEffect用。(!!URPでは使用不可になってます!!)
    /// URPではPostProcessingをインストールし、GlobalValueを設定して表現する模様。
    /// 個別のオブジェクトには流用できるかもしれない。
    /// </summary>
    [ExecuteInEditMode, ImageEffectAllowedInSceneView]
    public class CameraFilter : MonoBehaviour
    {
        [SerializeField]
        private Material filter;

        [SerializeField, Header("FastBlur")]
        private bool isEnableBlur = default;

        [SerializeField, Range(0.0f, 30.0f)]
        private float blurSize = 2.0f;

        [SerializeField, Header("ShakeColor")]
        private bool isEnableShake = default;

        [SerializeField, Range(0.01f, 1.0f)]
        private float intensity = 0.01f;

        private void OnRenderImage(RenderTexture source, RenderTexture destination)
        {
            if (filter == null)
            {
                Graphics.Blit(source, destination);
            }
            else
            {
                if (filter.name == "FastBlur" && isEnableBlur)
                {
                    SetFastBlur(source, destination);
                }
                else if (filter.name == "ShakeColor" && isEnableShake)
                {
                    SetShakeColor(source, destination);
                }
                else
                {
                    Graphics.Blit(source, destination, filter);
                }
            }
        }

        private void SetFastBlur(RenderTexture source, RenderTexture destination)
        {
            filter.SetFloat("_BlurSize", blurSize);

            var temp1 = RenderTexture.GetTemporary(Screen.width / 4, Screen.height / 4, 0, source.format);
            var temp2 = RenderTexture.GetTemporary(Screen.width / 8, Screen.height / 8, 0, source.format);

            Graphics.Blit(source, temp1, filter);
            Graphics.Blit(temp1, temp2, filter);
            Graphics.Blit(temp2, destination, filter);

            RenderTexture.ReleaseTemporary(temp1);
            RenderTexture.ReleaseTemporary(temp2);
        }

        private void SetShakeColor(RenderTexture source, RenderTexture destination)
        {
            int redOffsetPropertyId = Shader.PropertyToID("_RedOffset");
            int greenOffsetPropertyId = Shader.PropertyToID("_GreenOffset");
            int blueOffsetPropertyId = Shader.PropertyToID("_BlueOffset");

            filter.SetVector(redOffsetPropertyId, GenerateRandomOffset(intensity));
            filter.SetVector(greenOffsetPropertyId, GenerateRandomOffset(intensity));
            filter.SetVector(blueOffsetPropertyId, GenerateRandomOffset(intensity));

            Graphics.Blit(source, destination, filter);
        }

        private Vector2 GenerateRandomOffset(float intensity)
        {
            return new Vector2(Random.Range(-intensity, intensity), Random.Range(-intensity, intensity));
        }
    }
}
