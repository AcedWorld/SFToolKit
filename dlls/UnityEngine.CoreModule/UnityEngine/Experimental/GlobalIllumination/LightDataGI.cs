using System;
using UnityEngine.Scripting;

namespace UnityEngine.Experimental.GlobalIllumination
{
	// Token: 0x020004C5 RID: 1221
	[UsedByNativeCode]
	public struct LightDataGI
	{
		// Token: 0x06002ABF RID: 10943 RVA: 0x00047D78 File Offset: 0x00045F78
		public void Init(ref DirectionalLight light, ref Cookie cookie)
		{
			this.instanceID = light.instanceID;
			this.cookieID = cookie.instanceID;
			this.cookieScale = cookie.scale;
			this.color = light.color;
			this.indirectColor = light.indirectColor;
			this.orientation = light.orientation;
			this.position = light.position;
			this.range = 0f;
			this.coneAngle = cookie.sizes.x;
			this.innerConeAngle = cookie.sizes.y;
			this.shape0 = light.penumbraWidthRadian;
			this.shape1 = 0f;
			this.type = LightType.Directional;
			this.mode = light.mode;
			this.shadow = (light.shadow ? 1 : 0);
			this.falloff = FalloffType.Undefined;
		}

		// Token: 0x06002AC0 RID: 10944 RVA: 0x00047E4C File Offset: 0x0004604C
		public void Init(ref PointLight light, ref Cookie cookie)
		{
			this.instanceID = light.instanceID;
			this.cookieID = cookie.instanceID;
			this.cookieScale = cookie.scale;
			this.color = light.color;
			this.indirectColor = light.indirectColor;
			this.orientation = light.orientation;
			this.position = light.position;
			this.range = light.range;
			this.coneAngle = 0f;
			this.innerConeAngle = 0f;
			this.shape0 = light.sphereRadius;
			this.shape1 = 0f;
			this.type = LightType.Point;
			this.mode = light.mode;
			this.shadow = (light.shadow ? 1 : 0);
			this.falloff = light.falloff;
		}

		// Token: 0x06002AC1 RID: 10945 RVA: 0x00047F1C File Offset: 0x0004611C
		public void Init(ref SpotLight light, ref Cookie cookie)
		{
			this.instanceID = light.instanceID;
			this.cookieID = cookie.instanceID;
			this.cookieScale = cookie.scale;
			this.color = light.color;
			this.indirectColor = light.indirectColor;
			this.orientation = light.orientation;
			this.position = light.position;
			this.range = light.range;
			this.coneAngle = light.coneAngle;
			this.innerConeAngle = light.innerConeAngle;
			this.shape0 = light.sphereRadius;
			this.shape1 = (float)light.angularFalloff;
			this.type = LightType.Spot;
			this.mode = light.mode;
			this.shadow = (light.shadow ? 1 : 0);
			this.falloff = light.falloff;
		}

		// Token: 0x06002AC2 RID: 10946 RVA: 0x00047FF0 File Offset: 0x000461F0
		public void Init(ref RectangleLight light, ref Cookie cookie)
		{
			this.instanceID = light.instanceID;
			this.cookieID = cookie.instanceID;
			this.cookieScale = cookie.scale;
			this.color = light.color;
			this.indirectColor = light.indirectColor;
			this.orientation = light.orientation;
			this.position = light.position;
			this.range = light.range;
			this.coneAngle = 0f;
			this.innerConeAngle = 0f;
			this.shape0 = light.width;
			this.shape1 = light.height;
			this.type = LightType.Rectangle;
			this.mode = light.mode;
			this.shadow = (light.shadow ? 1 : 0);
			this.falloff = light.falloff;
		}

		// Token: 0x06002AC3 RID: 10947 RVA: 0x000480C0 File Offset: 0x000462C0
		public void Init(ref DiscLight light, ref Cookie cookie)
		{
			this.instanceID = light.instanceID;
			this.cookieID = cookie.instanceID;
			this.cookieScale = cookie.scale;
			this.color = light.color;
			this.indirectColor = light.indirectColor;
			this.orientation = light.orientation;
			this.position = light.position;
			this.range = light.range;
			this.coneAngle = 0f;
			this.innerConeAngle = 0f;
			this.shape0 = light.radius;
			this.shape1 = 0f;
			this.type = LightType.Disc;
			this.mode = light.mode;
			this.shadow = (light.shadow ? 1 : 0);
			this.falloff = light.falloff;
		}

		// Token: 0x06002AC4 RID: 10948 RVA: 0x00048190 File Offset: 0x00046390
		public void Init(ref SpotLightBoxShape light, ref Cookie cookie)
		{
			this.instanceID = light.instanceID;
			this.cookieID = cookie.instanceID;
			this.cookieScale = cookie.scale;
			this.color = light.color;
			this.indirectColor = light.indirectColor;
			this.orientation = light.orientation;
			this.position = light.position;
			this.range = light.range;
			this.coneAngle = 0f;
			this.innerConeAngle = 0f;
			this.shape0 = light.width;
			this.shape1 = light.height;
			this.type = LightType.SpotBoxShape;
			this.mode = light.mode;
			this.shadow = (light.shadow ? 1 : 0);
			this.falloff = FalloffType.Undefined;
		}

		// Token: 0x06002AC5 RID: 10949 RVA: 0x0004825C File Offset: 0x0004645C
		public void Init(ref SpotLightPyramidShape light, ref Cookie cookie)
		{
			this.instanceID = light.instanceID;
			this.cookieID = cookie.instanceID;
			this.cookieScale = cookie.scale;
			this.color = light.color;
			this.indirectColor = light.indirectColor;
			this.orientation = light.orientation;
			this.position = light.position;
			this.range = light.range;
			this.coneAngle = light.angle;
			this.innerConeAngle = 0f;
			this.shape0 = light.aspectRatio;
			this.shape1 = 0f;
			this.type = LightType.SpotPyramidShape;
			this.mode = light.mode;
			this.shadow = (light.shadow ? 1 : 0);
			this.falloff = light.falloff;
		}

		// Token: 0x06002AC6 RID: 10950 RVA: 0x0004832C File Offset: 0x0004652C
		public void Init(ref DirectionalLight light)
		{
			Cookie cookie = Cookie.Defaults();
			this.Init(ref light, ref cookie);
		}

		// Token: 0x06002AC7 RID: 10951 RVA: 0x0004834C File Offset: 0x0004654C
		public void Init(ref PointLight light)
		{
			Cookie cookie = Cookie.Defaults();
			this.Init(ref light, ref cookie);
		}

		// Token: 0x06002AC8 RID: 10952 RVA: 0x0004836C File Offset: 0x0004656C
		public void Init(ref SpotLight light)
		{
			Cookie cookie = Cookie.Defaults();
			this.Init(ref light, ref cookie);
		}

		// Token: 0x06002AC9 RID: 10953 RVA: 0x0004838C File Offset: 0x0004658C
		public void Init(ref RectangleLight light)
		{
			Cookie cookie = Cookie.Defaults();
			this.Init(ref light, ref cookie);
		}

		// Token: 0x06002ACA RID: 10954 RVA: 0x000483AC File Offset: 0x000465AC
		public void Init(ref DiscLight light)
		{
			Cookie cookie = Cookie.Defaults();
			this.Init(ref light, ref cookie);
		}

		// Token: 0x06002ACB RID: 10955 RVA: 0x000483CC File Offset: 0x000465CC
		public void Init(ref SpotLightBoxShape light)
		{
			Cookie cookie = Cookie.Defaults();
			this.Init(ref light, ref cookie);
		}

		// Token: 0x06002ACC RID: 10956 RVA: 0x000483EC File Offset: 0x000465EC
		public void Init(ref SpotLightPyramidShape light)
		{
			Cookie cookie = Cookie.Defaults();
			this.Init(ref light, ref cookie);
		}

		// Token: 0x06002ACD RID: 10957 RVA: 0x0004840A File Offset: 0x0004660A
		public void InitNoBake(int lightInstanceID)
		{
			this.instanceID = lightInstanceID;
			this.mode = LightMode.Unknown;
		}

		// Token: 0x0400100B RID: 4107
		public int instanceID;

		// Token: 0x0400100C RID: 4108
		public int cookieID;

		// Token: 0x0400100D RID: 4109
		public float cookieScale;

		// Token: 0x0400100E RID: 4110
		public LinearColor color;

		// Token: 0x0400100F RID: 4111
		public LinearColor indirectColor;

		// Token: 0x04001010 RID: 4112
		public Quaternion orientation;

		// Token: 0x04001011 RID: 4113
		public Vector3 position;

		// Token: 0x04001012 RID: 4114
		public float range;

		// Token: 0x04001013 RID: 4115
		public float coneAngle;

		// Token: 0x04001014 RID: 4116
		public float innerConeAngle;

		// Token: 0x04001015 RID: 4117
		public float shape0;

		// Token: 0x04001016 RID: 4118
		public float shape1;

		// Token: 0x04001017 RID: 4119
		public LightType type;

		// Token: 0x04001018 RID: 4120
		public LightMode mode;

		// Token: 0x04001019 RID: 4121
		public byte shadow;

		// Token: 0x0400101A RID: 4122
		public FalloffType falloff;
	}
}
