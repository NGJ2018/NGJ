Shader "Custom/BlinkShader"
{
	Properties
	{
		_MainTex ("MainTex", 2D) = "white" {}
		_Progress ("Progress", Range(0,1)) = 0
	}
	SubShader {
		Pass {
			CGPROGRAM
			#pragma vertex vert_img
			#pragma fragment frag

			#include "UnityCG.cginc"

			uniform sampler2D _MainTex;
			uniform float _Progress;


			float4 frag(v2f_img i) : COLOR {
				float4 c = tex2D(_MainTex, i.uv);
				_Progress = 1 - _Progress;
				return _Progress*c;
			}
			ENDCG
		}
	}
}
