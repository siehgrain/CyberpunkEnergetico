Shader "Custom/FogOfWar"
{
    Properties
    {
        _MainTex("Texture", 2D) = "white" {}
        _FogColor("Fog Color", Color) = (0,0,0,1)
        _FogCenter("Fog Center", Vector) = (0,0,0,0)
        _FogRange("Fog Range", Float) = 10.0
    }
        SubShader
        {
            Tags { "RenderType" = "Opaque" }
            LOD 200

            CGPROGRAM
            #pragma surface surf Lambert

            sampler2D _MainTex;
            fixed4 _FogColor;
            float3 _FogCenter;
            float _FogRange;

            struct Input
            {
                float2 uv_MainTex;
                float3 worldPos;
            };

            void surf(Input IN, inout SurfaceOutput o)
            {
                fixed4 c = tex2D(_MainTex, IN.uv_MainTex);
                float dist = distance(IN.worldPos, _FogCenter);
                float fogFactor = smoothstep(_FogRange, _FogRange - 1, dist);
                c.rgb = lerp(_FogColor.rgb, c.rgb, fogFactor);
                o.Albedo = c.rgb;
                o.Alpha = c.a;
            }
            ENDCG
        }
            FallBack "Diffuse"
}
