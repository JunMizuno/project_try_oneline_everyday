using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public enum PostprocessTiming
{
    AfterOpaque,
    BeforePostprocess,
    AfterPostprocess
}

public class SamplePostEffectProcessRenderPass : ScriptableRenderPass
{
    private const string RenderPassName = nameof(SamplePostEffectProcessRenderPass);
    private const string ProfilingSamplerName = "SrcToDest";

    private readonly bool _applyToSceneView;
    private readonly int _mainTexPropertyId = Shader.PropertyToID("_MainTex");
    private readonly Material _material;
    private readonly ProfilingSampler _profilingSampler;
    private readonly int _tintColorPropertyId = Shader.PropertyToID("_TintColor");

    // @todo.mizuno 2022以降からRenderTargetHandleが非推奨になったのでRTHandleに置き換える。
    // @todo.mizuno エラー解消のためただ置き換えただけなので、運用方法など要確認。
    private RTHandle _afterPostProcessTexture;
    private RTHandle _tempRenderTargetHandle;
    private RenderTargetIdentifier _cameraColorTarget;
    private SamplePostEffectVolume _volume;

    public SamplePostEffectProcessRenderPass(bool applyToSceneView, Shader shader)
    {
        if (shader == null)
        {
            return;
        }

        _applyToSceneView = applyToSceneView;
        _profilingSampler = new ProfilingSampler(ProfilingSamplerName);
        _tempRenderTargetHandle = RTHandles.Alloc("_TempRT");

        // マテリアルを作成
        _material = CoreUtils.CreateEngineMaterial(shader);

        // RenderPassEvent.AfterRenderingではポストエフェクトを掛けた後のカラーテクスチャがこの名前で取得できる
        _afterPostProcessTexture = RTHandles.Alloc("_AfterPostProcessTexture");
    }

    public void Setup(RenderTargetIdentifier cameraColorTarget, PostprocessTiming timing)
    {
        _cameraColorTarget = cameraColorTarget;

        renderPassEvent = GetRenderPassEvent(timing);

        // Volumeコンポーネントを取得
        var volumeStack = VolumeManager.instance.stack;
        _volume = volumeStack.GetComponent<SamplePostEffectVolume>();
    }

    public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
    {
        if (_material == null)
        {
            return;
        }

        // カメラのポストプロセス設定が無効になっていたら何もしない
        if (!renderingData.cameraData.postProcessEnabled)
        {
            return;
        }

        // カメラがシーンビューカメラかつシーンビューに適用しない場合には何もしない
        if (!_applyToSceneView && renderingData.cameraData.cameraType == CameraType.SceneView)
        {
            return;
        }

        if (!_volume.IsActive())
        {
            return;
        }

        // renderPassEventがAfterRenderingの場合、カメラのカラーターゲットではなく_AfterPostProcessTextureを使う
        var source = renderPassEvent == RenderPassEvent.AfterRendering && renderingData.cameraData.resolveFinalTarget
            ? _afterPostProcessTexture
            : _cameraColorTarget;

        // コマンドバッファを作成
        var cmd = CommandBufferPool.Get(RenderPassName);
        cmd.Clear();

        // Cameraのターゲットと同じDescription（Depthは無し）のRenderTextureを取得する
        var tempTargetDescriptor = renderingData.cameraData.cameraTargetDescriptor;
        tempTargetDescriptor.depthBufferBits = 0;
        // @todo.mizuno エラー解消のため一時的にコメントアウト。
        //cmd.GetTemporaryRT(_tempRenderTargetHandle, tempTargetDescriptor);

        using (new ProfilingScope(cmd, _profilingSampler))
        {
            // VolumeからTintColorを取得して反映
            _material.SetColor(_tintColorPropertyId, _volume.tintColor.value);
            cmd.SetGlobalTexture(_mainTexPropertyId, source);

            // @todo.mizuno エラー解消のため一時的にコメントアウト。
            // 元のテクスチャから一時的なテクスチャにエフェクトを適用しつつ描画
            //Blit(cmd, source, _tempRenderTargetHandle, _material);
        }

        // @todo.mizuno エラー解消のため一時的にコメントアウト。
        // 一時的なテクスチャから元のテクスチャに結果を書き戻す
        //Blit(cmd, _tempRenderTargetHandle, source);

        // @todo.mizuno エラー解消のため一時的にコメントアウト。
        // 一時的なRenderTextureを解放する
        //cmd.ReleaseTemporaryRT(_tempRenderTargetHandle);

        context.ExecuteCommandBuffer(cmd);
        CommandBufferPool.Release(cmd);
    }

    private static RenderPassEvent GetRenderPassEvent(PostprocessTiming postprocessTiming)
    {
        switch (postprocessTiming)
        {
            case PostprocessTiming.AfterOpaque:
                return RenderPassEvent.AfterRenderingSkybox;
            case PostprocessTiming.BeforePostprocess:
                return RenderPassEvent.BeforeRenderingPostProcessing;
            case PostprocessTiming.AfterPostprocess:
                return RenderPassEvent.AfterRendering;
            default:
                throw new ArgumentOutOfRangeException(nameof(postprocessTiming), postprocessTiming, null);
        }
    }
}
