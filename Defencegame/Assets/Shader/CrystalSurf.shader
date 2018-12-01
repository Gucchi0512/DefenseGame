Shader "Custom/CrystalSurf" {
	Properties{
		_Color("Color", Color) = (1,1,1,1)
		_AlphaRate("AlphaRate", Float) = 1.0

	}
	SubShader {
		Tags { "RenderType"="Transparent" "Queue"="Transparent" }
		LOD 200
		
		Pass{
			Zwrite On
			ColorMask 0	
		}

		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Standard alpha:fade

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		struct Input {
			float3 worldNormal;
			float3 viewDir;
		};
		
		fixed4 _Color;
		float _AlphaRate;
		void surf (Input IN, inout SurfaceOutputStandard o) {
			o.Albedo = _Color.rgb;
			float alpha = 1 - (abs(dot(IN.viewDir, IN.worldNormal)));
			if (alpha <= 0.3) alpha = 0.3;
			o.Alpha = alpha * _AlphaRate;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
