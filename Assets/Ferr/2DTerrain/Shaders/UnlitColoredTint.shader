Shader "Ferr/Unlit Tinted Textured Vertex Color" {
	Properties {
		_MainTex("Texture (RGB)", 2D   ) = "white" {}
		_Color  ("Tint",          Color) = (1,1,1,1)
	}
	SubShader {
		Tags {"IgnoreProjector"="True" "RenderType"="Opaque"}
		Blend Off
		
		LOD 100
		Cull      Off
		Lighting  Off
		Fog {Mode Off}
		
		Pass {
			CGPROGRAM
			#pragma vertex         vert
			#pragma fragment       frag
			#pragma fragmentoption ARB_precision_hint_fastest

			#include "UnityCG.cginc"
			#include "Ferr2DTCommon.cginc"
			ENDCG
		}
	}
}
