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
			// black magic universally understood by all operating systems
				float4 vertex : POSITION;
				float2 texcoord : TEXCOORD0;
			};
 
			struct v2f {
				float4 vertex : SV_POSITION;
				half2 texcoord : TEXCOORD0;
			};
 
			v2f vert (appdata_t v)
			{
				v2f o; // point where vertex is located
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.texcoord = v.texcoord;
				return o;
			}
 
			fixed4 _Color0, _Color1;
			float4 _Pos;
 
			fixed4 frag (v2f i) : SV_Target // called once for each pixel
			{
				// t calculates distance from given uv coordinate to click point
				//  t initially ranges from 0 to sqrt(2)/2 when center point is center of plane, 
				//  so we standardize by multiplying by sqrt(2) = 1.41...
				// length returns scalar length of Vector
				//  in this case, absolute distance from click point to a given pixel
				float t = length(i.texcoord - float2(_Pos.x, _Pos.y)) * 1.41421356237;
				
				// returns _Color0 when t = 0; returns _Color1 when t = 1
				return lerp(_Color0, _Color1, t);
			}
			ENDCG
         }
     }
 }