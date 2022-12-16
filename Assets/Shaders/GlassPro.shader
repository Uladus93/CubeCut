Shader "Custom/GlassPro"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Base (RGB)", 2D) = "white" {}
        _Cutoff ("Alpha Cutoff", Range(0,1)) = 0.5
        [KeywordEnum(FRONT, BACK, RIGHT, LEFT, TOP, BOTTOM)] _FACES ("Faces", Float) = 0
    }
    SubShader
    {
        Tags {"Queue"="AlphaTest"
        "RenderType"="TransParentCutout"
        "IgnoreProjector"="True" }
        LOD 200
        Cull Off

        CGPROGRAM
        #pragma shader_feature _FACES_FRONT _FACES_BACK _FACES_RIGHT _FACES_LEFT _FACES_TOP _FACES_BOTTOM
        #pragma surface surf Lambert alphatest:_Cutoff vertex:vert

        sampler2D _MainTex;
        fixed4 _Color;

        struct Input
        {
            float2 customUV;
        };

        void vert (inout appdata_full v, out Input o) 
        {
			UNITY_INITIALIZE_OUTPUT(Input, o);
			
			#if defined(_FACES_FRONT) || defined(_FACES_BACK)
				o.customUV = v.vertex.xy;
            #elif defined(_FACES_RIGHT) || defined(_FACES_LEFT)
				o.customUV = v.vertex.zy;
            #elif defined(_FACES_TOP) || defined(_FACES_BOTTOM)
				o.customUV = v.vertex.xz;
			#endif
		}

        void surf (Input IN, inout SurfaceOutput o)
        {
            fixed4 c = tex2D (_MainTex, IN.customUV) * _Color;
            o.Albedo = c.rgb;
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
