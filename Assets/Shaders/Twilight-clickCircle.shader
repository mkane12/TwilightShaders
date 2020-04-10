// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/Twilight-clickCircle"
{
	// Gradient shader between 2 colors with clicked position
	Properties
    {
        _Color0 ("Middle Color", Color) = (1,1,1,1)
		_Color1 ("Outer Color", Color) = (1,1,1,1)
		_Pos ("Click Position", Vector) = (0.5, 0.5, 0, 0)
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

		Pass {
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
 
			#include "UnityCG.cginc"
 
			struct appdata_t {
				float4 vertex : POSITION;
				float2 texcoord : TEXCOORD0;
			};
 
			struct v2f {
				float4 vertex : SV_POSITION;
				half2 texcoord : TEXCOORD0;
			};
 
			v2f vert (appdata_t v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.texcoord = v.texcoord;
				return o;
			}
 
			fixed4 _Color0, _Color1;
			float2 _Pos;
 
			fixed4 frag (v2f i) : SV_Target
			{
				// this sure required a lot of futzing around heck
				float t = length(i.texcoord - float2(_Pos.y, 1-_Pos.x)) * 1.41421356237; // 1.141... = sqrt(2)
				return lerp(_Color0, _Color1, t);
			}
			ENDCG
         }
     }
 }