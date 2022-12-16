Shader "Glass"
{
	Properties
	{
		_MaskTex ("Mask texture", 2D) = "black" {}
		_EmissionMaskTex ("Emission texture", 2D) = "black" {}
		_MainTex1 ("Main texture 1", 2D) = "gray" {}
		_MainTex2 ("Main texture 2", 2D) = "gray" {}
		_MainTex3 ("Main texture 3", 2D) = "gray" {}
		_Color("Emission Color", Color) = (1,1,1,1)
		_VectorParm ("Vector Parameter", Vector) = (1.0, 0.5, 1.0, 0.0)
		_RangeParm ("Intensity", Range(0, 1))= 1
	}
	
	SubShader
	{
		CGPROGRAM
		#pragma surface surf Lambert
		sampler2D _MaskTex, _MainTex1, _MainTex2, _MainTex3;
		fixed3 _Color;
		
		struct Input
		{
			half2 uv_MaskTex;
			half2 uv_MainTex1;
			half2 uv_MainTex2;
			half2 uv_MainTex3;
		};
		
		void surf(Input mytexture, inout SurfaceOutput result)
		{
			fixed3 masks = tex2D(_MaskTex, mytexture.uv_MaskTex);
			fixed3 clr = tex2D(_MainTex1, mytexture.uv_MainTex1) * masks.r;
			clr += tex2D(_MainTex2, mytexture.uv_MainTex2) * masks.g;
			clr += tex2D(_MainTex3, mytexture.uv_MainTex3) * masks.b;
			result.Albedo = clr;
			result.Emission = _Color;
		}
		ENDCG
	}
	
	Fallback "Diffuse"
}
