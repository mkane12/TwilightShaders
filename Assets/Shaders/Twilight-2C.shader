Shader "Custom/Twilight-2C"
{
	// Gradient shader between 2 colors
	// Adapted from tutorial: https://www.youtube.com/watch?v=8RsidKEPHTM
    Properties
    {
        _Color0 ("Bottom Color", Color) = (1,1,1,1)
		_Color1 ("Top Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard Lambert

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        sampler2D _MainTex;

        struct Input
        {
            float2 uv_MainTex;
			float4 screenPos;
        };

        fixed4 _Color0;
		fixed4 _Color1;

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            float2 screenUV = IN.screenPos.xy / IN.screenPos.w;
			// Albedo comes from a texture tinted by color
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * lerp(_Color0, _Color1, screenUV.y);
            o.Albedo = c.rgb;
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "VertexLit"
}
