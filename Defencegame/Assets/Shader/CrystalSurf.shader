Shader "Custom/CrystalSurf" {
	Properties{
		_Color("Color", Color) = (1,1,1,1)
		_AlphaRate("AlphaRate", Float) = 1.0
		_EmissionColor("EmissionColor", Color)=(1,1,1,1)
	}
	SubShader {
		Tags { "RenderType"="Transparent" "Queue"="Transparent" }
		LOD 200
		
		Pass{
			Zwrite On
			ColorMask 0

		}
			Cull Off
		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Standard Lambert alpha:fade

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		struct Input {
			float3 worldNormal;
			float3 viewDir;
		};
		
		fixed4 _Color;
		float _AlphaRate;
		half4 _EmissionColor;

		void surf (Input IN, inout SurfaceOutputStandard o) {
			o.Albedo = _Color.rgb;
			float t = ((2 * _SinTime.w*_CosTime.w) + 1.0)*0.5;
			float alpha = 1 - (abs(dot(IN.viewDir, IN.worldNormal)));
			if (alpha <= 0.3) alpha = 0.3 ;
			float e = alpha * t;
			o.Alpha = alpha * _AlphaRate;
			o.Emission = _EmissionColor * e;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
