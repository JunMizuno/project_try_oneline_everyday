Shader "Unlit/ObjectBlur"       // @memo.mizuno BlurObject.csÇ∆ã§ópÇÃÇ±Ç∆ÅB
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
                float3 normal : NORMAL;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float4 _TrailDir;

            v2f vert (appdata v)
            {
                v2f o;

                float weight = clamp(dot(v.normal, _TrailDir), 0, 1);
                fixed4 trail = _TrailDir * weight;
                v.vertex.xyz = float3(v.vertex.x + trail.x, v.vertex.y + trail.y, v.vertex.z + trail.z);

                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);

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
