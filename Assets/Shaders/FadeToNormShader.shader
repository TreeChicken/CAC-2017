﻿Shader "Custom/FadeToNormShader"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		timePassed ("Time Passed", Float) = 0
	}
	SubShader
	{
		// No culling or depth
		Cull Off ZWrite Off ZTest Always

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

			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv;
				return o;
			}
			
			sampler2D _MainTex;
			float timePassed;

			fixed4 frag (v2f i) : SV_Target
			{
				fixed4 col = tex2D(_MainTex, i.uv);

				// Convert to grayscale
				float avg = (col.r + col.g + col.b) / 3;
				fixed4 gray = (avg, avg, avg);

				// Fade over time
				col = lerp(gray, col, clamp(timePassed, 0, 1));

				return col;
			}
			ENDCG
		}
	}
}
