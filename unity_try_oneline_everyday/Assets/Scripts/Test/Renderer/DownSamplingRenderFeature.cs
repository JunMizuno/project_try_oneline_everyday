using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Test
{
    public class DownSamplingRenderFeature : ScriptableRendererFeature
    {
        public int sampleValue = 10;

        private DownSamplingRenderPass renderPass;

        /// <summary>
        /// Passの作成
        /// </summary>
        public override void Create() => renderPass = new DownSamplingRenderPass();

        public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
        {
            // @memo.mizuno ScriptableRendererにPassを渡す。
            // @memo.mizuno Passは複数登録もOK。
            renderPass.SetParameter(renderer.cameraColorTarget, sampleValue);
            renderer.EnqueuePass(renderPass);
        }
    }
}
