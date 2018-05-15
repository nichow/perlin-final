// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'


/**

the VERTEX SHADER  is a program that runs on each vertex 

*/


/*Shader "name" { [Properties] Subshaders [Fallback] [CustomeEditor] }*/

Shader "Unlit/Basic"
{
	Properties
	{//insert a propery here 	
	//_Color("color",Color) = (1,0,0,1)
		_MainTex ("Texture", 2D) = "white" {}
		_Colort("Main Color",Color) = (1,1,1,1)
	}
	SubShader
	{//a shader can contain one or more subshaders that are mainly used to implements shaders for different GPU capabilities
		Pass
		{//each subShader is composed of a number of passes 
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag


			     // vertex shader
            // this time instead of using "appdata" struct, just spell inputs manually,
            // and instead of returning v2f struct, also just return a single output
            // float4 clip position
			#include "UnityCG.cginc"
/*
			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				UNITY_FOG_COORDS(1)
				float4 vertex : SV_POSITION;
			};
*/
			
			float4 vert (appdata v)
			{
			//"clip space" is used by the GPU to rasterize the object on screen
			//UnityObjectToClipPos transforms the vertex from object space to the screen	
				return UnityObjectToClipPos(vertex);
			}

			//color from the material
			fixed4 _Color;
			
			fixed4 frag () : SV_Target
			{
				return _Color;
			}
			ENDCG
		}
	}
}
