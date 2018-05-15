// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

Shader "Unlit/NewUnlitShader"
{
//need time and world position
/*a surface shader can include a vertex shader but traditionally a surface shader is a fragment
shader that redners the color to the screen included with unity's lighting  */

	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_Color("Color", Color) = (0,1,0,1)
		_Bias ("Bias", Float) = 0
		_ScanningFrequency("Scanning Frequency", Float) = 100
		_ScanningSpeed("Scanning Speed", Float)  = 100
	}
	SubShader
	{
		Tags { "RenderType"="Alpha" }
		LOD 100
		ZWrite Off //nothing drawn between shader is called
		//Blend SrcAlpha OneMinusSrcAlpha //take source alpha (already rendered content has) 
		Blend SrcAlpha one
		Cull Off //inside object we should see the object


		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			// make fog work
			#pragma 
			#pragma multi_compile_fog
			
			
			#include "UnityCG.cginc"

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
				float4 objVertex : TEXCOORD1;//object vertex
			};

			fixed4 _Color;
			sampler2D _MainTex;
			float4 _MainTex_ST;
			float4 _Bias, _ScanningFreq, _ScanningSpeed;

			v2f vert (appdata v)
			{
				v2f o;
				o.objVertex = mul(unity_ObjectToWorld, v.vertex);
			//	o.objVertex = v.vertex;  //translate object vertex into world space
				///if using object space, shader will move with the object, if using world space, shader will not move if the object is moving 
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				UNITY_TRANSFER_FOG(o,o.vertex);
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				// sample the texture
				fixed4 col = tex2D(_MainTex, i.uv);
				// apply fog
				UNITY_APPLY_FOG(i.fogCoord, col);
				//col = fixed4(cos(i.objVertex.y*100),0,0,1);
				//col = _Color*cos(i.objVertex.y*100);
				//col = _Color * max(0,cos(i.objVertex.y*100));
				col = _Color * max(0,cos(i.objVertex.x * 200 + _Time.y * 10) + 0.001);
				col *= 1 -  max(0,cos(i.objVertex.y * 10 + _Time.x * 50) + 0.9);
								//col *= 1 -  max(0,cos(i.objVertex.y * 100 + _Time.x * 100) + 0.9);

			//	col = _Color * max(0, cos(i.objVertex.y * _ScanningFrequency + _Time.x * _ScanningSpeed) + _Bias);
				return col;
			}
			ENDCG
		}
	}
}
