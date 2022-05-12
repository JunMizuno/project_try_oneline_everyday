Shader "Unlit/Flags"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
    }

    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
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

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                float add = 0.5f * sin(_Time * 100 + v.vertex.x * 100);
                // Y軸を操作すると波打つ動き。
                //o.vertex.xyz = float3(o.vertex.x, o.vertex.y + add, o.vertex.z);
                // Z軸を操作すると、-3を下回る場合は非表示になる。
                //o.vertex.xyz = float3(o.vertex.x, o.vertex.y, o.vertex.z + add);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.uv);
                return col;
            }

            ENDCG
        }
    }

    FallBack "Diffuse"
}
