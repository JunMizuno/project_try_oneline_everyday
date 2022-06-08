using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace Test
{
    public class DownSamplingRenderPass : ScriptableRenderPass
    {
        private const string CommandBufferName = nameof(DownSamplingRenderPass);
        private const int RenderTextureId = 0;

        // 元のカメラ画像を保持しているRenderTarget
        private RenderTargetIdentifier currentTarget;

        private int downSample = 1;

        public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
        {
            // @todo.mizuno 描画処理を実装
            var commandBuffer = CommandBufferPool.Get(CommandBufferName);

            // カメラデータを取得
            var cameraData = renderingData.cameraData;

            // 縮小させる割合を設定
            var width = cameraData.camera.scaledPixelWidth / downSample;
            var height = cameraData.camera.scaledPixelHeight / downSample;

            // RenderTextureを生成
            commandBuffer.GetTemporaryRT(RenderTextureId, width, height, 0, FilterMode.Point, RenderTextureFormat.Default);

            // カメラ画像をRenderTextureにコピー
            commandBuffer.Blit(currentTarget, RenderTextureId);

            // RenderTextureをカメラのRenderTargetにコピー
            commandBuffer.Blit(RenderTextureId, currentTarget);

            context.ExecuteCommandBuffer(commandBuffer);
            context.Submit();

            CommandBufferPool.Release(commandBuffer);
        }

        /// <summary>
        /// コンストラクタ
        /// RenderPassEventで描画タイミングを指定。
        /// </summary>
        public DownSamplingRenderPass() => renderPassEvent = RenderPassEvent.AfterRenderingTransparents;

        public void SetParameter(RenderTargetIdentifier renderTarget, int sampleValue)
        {
            currentTarget = renderTarget;
            downSample = sampleValue;
            if (downSample <= 0)
            {
                downSample = 1;
            }
        }
    }
}
