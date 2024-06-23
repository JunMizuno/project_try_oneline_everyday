Shader "Unlit/AllRound"
{
    Properties
    {
        _MainTex("Texture", 2D) = "white" {}
        _BackTex("Back Texture", 2D) = "white" {}
        _OutlineColor("Outline Color", Color) = (0, 0, 0, 1)
        _OutlineWidth("Outline Width", Range(0, 0.1)) = 0.02
    }

    SubShader
    {
        Cull Off
        Tags 
        { 
            "RenderType"="Opaque"
            "RenderPipeline" = "UniversalPipeline"
        }
        LOD 100

        HLSLINCLUDE
        #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

        #define MIN 0.0001

        struct appdata
        {
            float4 vertex : POSITION;
            float2 uv : TEXCOORD0;
        };

        struct v2f
        {
            float2 uv : TEXCOORD0;
            float4 vertex : SV_POSITION;
        };

        TEXTURE2D(_MainTex);
        TEXTURE2D(_BackTex);
        SAMPLER(sampler_MainTex);
        SAMPLER(sampler_BackTex);

        CBUFFER_START(UnityPerMaterial)
        half4 _MainTex_ST;
        half4 _BackTex_ST;
        half4 _OutlineColor;
        half _OutlineWidth;
        CBUFFER_END

        ENDHLSL

        // 裏面も描画する
        Pass
        {
            // LightModeはマルチパス実行のために必須
            Tags{ "LightMode" = "UniversalForward" }
            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma target 3.0

            v2f vert(appdata v)
            {
                v2f o;
                o.vertex = TransformObjectToHClip(v.vertex);
                o.vertex.z += MIN;
                o.uv = v.uv;
                return o;
            }

            half4 frag(v2f i, half facing : VFACE) : SV_Target
            {
                // カメラに向いている面によって表裏のテクスチャを切り替え
                return facing > 0 ? SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, i.uv) : SAMPLE_TEXTURE2D(_BackTex, sampler_BackTex, i.uv);
            }
            ENDHLSL
        }

        // アウトラインの描画
        Pass
        {
            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            v2f vert(appdata v)
            {
                v2f o;
                // アウトラインの分だけ拡大
                o.vertex = TransformObjectToHClip(v.vertex * (1 + _OutlineWidth));
                return o;
            }

            half4 frag(v2f i) : SV_Target
            {
                return _OutlineColor;
            }
            ENDHLSL
        }
    }
}
