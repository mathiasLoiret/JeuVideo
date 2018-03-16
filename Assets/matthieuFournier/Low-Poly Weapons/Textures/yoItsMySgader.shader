Shader "Custom/yoItsMySgader" {
	Properties {
		_Color ("Color", Color) = (1,0,0,1)
		_MainTex ("Albedo (RGB)", 2D) = "orange" {}
		_Glossiness ("Smoothness", Range(0,1)) = 0.9
		_Metallic ("Metallic", Range(0,1)) = 0.7
		_AnimationSpped = 0.1f;
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200

		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Standard fullforwardshadows

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		sampler2D _MainTex;
		half4 _Color;

		struct Input {
			float2 uv_MainTex;
		};

		half _Glossiness;
		half _Metallic;
		//fixed4 _Color;

		// Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
		// See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
		// #pragma instancing_options assumeuniformscaling
		UNITY_INSTANCING_BUFFER_START(Props)
			// put more per-instance properties here
		UNITY_INSTANCING_BUFFER_END(Props)

		void surf (Input IN, inout SurfaceOutputStandard o) {

			fixed2 scrolledUV = IN.uv_MainTex;
			fixed yScrollValue = frac(_AnimationSpped * _Time.y);

			// Albedo comes from a texture tinted by color
			if(IN.uv_MainTex.y < 0.35 && IN.uv_MainTex.x < 0.3){
				fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color * 10;
				o.Albedo = c.rgb;
				// Metallic and smoothness come from slider variables
				o.Metallic = _Metallic;
				o.Smoothness = _Glossiness;
				o.Alpha = c.a;
			}else{
				o.Albedo = tex2D(_MainTex, IN.uv_MainTex).rgb;
			}
		}
		ENDCG
	}
	FallBack "Diffuse"
}
