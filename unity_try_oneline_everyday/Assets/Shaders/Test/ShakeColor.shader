Shader "Unlit/ShakeColor"     // @memo.mizuno CameraFilter.csのOnRenderImageにスクリプト側の処理を実装しています。
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _RedOffset ("RedOffset", Vector) = (0.0, 0.0, 0.0, 0.0)
        _GreenOffset("GreenOffset", Vector) = (0.0, 0.0, 0.0, 0.0)
        _BlueOffset("BlueOffset", Vector) = (0.0, 0.0, 0.0, 0.0)
    }

    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            ZTest Always Cull Off ZWrite Off

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

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

            sampler2D _MainTex;
            float4 _MainTex_ST;
            half4 _RedOffset;
            half4 _GreenOffset;
            half4 _BlueOffset;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                fixed a = tex2D(_MainTex, i.uv).a;
                fixed r = tex2D(_MainTex, i.uv + _RedOffset.xy).r;
                fixed g = tex2D(_MainTex, i.uv + _GreenOffset.xy).g;
                fixed b = tex2D(_MainTex, i.uv + _BlueOffset.xy).b;
                return fixed4(r, g, b, a);
            }

            ENDCG
        }
    }

    Fallback "Diffuse"
}
