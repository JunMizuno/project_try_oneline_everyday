using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace Test
{
    public class DownSamplingRenderPass : ScriptableRenderPass
    {
        public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
        {
            // @todo.mizuno 描画処理を実装
        }

        /// <summary>
        /// コンストラクタ
        /// RenderPassEventで描画タイミングを指定。
        /// </summary>
        public DownSamplingRenderPass() => renderPassEvent = RenderPassEvent.AfterRenderingTransparents;
    }
}
