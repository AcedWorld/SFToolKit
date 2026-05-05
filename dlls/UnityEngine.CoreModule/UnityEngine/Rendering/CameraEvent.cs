using System;

namespace UnityEngine.Rendering
{
	// Token: 0x020003FC RID: 1020
	public enum CameraEvent
	{
		// Token: 0x04000BBA RID: 3002
		BeforeDepthTexture,
		// Token: 0x04000BBB RID: 3003
		AfterDepthTexture,
		// Token: 0x04000BBC RID: 3004
		BeforeDepthNormalsTexture,
		// Token: 0x04000BBD RID: 3005
		AfterDepthNormalsTexture,
		// Token: 0x04000BBE RID: 3006
		BeforeGBuffer,
		// Token: 0x04000BBF RID: 3007
		AfterGBuffer,
		// Token: 0x04000BC0 RID: 3008
		BeforeLighting,
		// Token: 0x04000BC1 RID: 3009
		AfterLighting,
		// Token: 0x04000BC2 RID: 3010
		BeforeFinalPass,
		// Token: 0x04000BC3 RID: 3011
		AfterFinalPass,
		// Token: 0x04000BC4 RID: 3012
		BeforeForwardOpaque,
		// Token: 0x04000BC5 RID: 3013
		AfterForwardOpaque,
		// Token: 0x04000BC6 RID: 3014
		BeforeImageEffectsOpaque,
		// Token: 0x04000BC7 RID: 3015
		AfterImageEffectsOpaque,
		// Token: 0x04000BC8 RID: 3016
		BeforeSkybox,
		// Token: 0x04000BC9 RID: 3017
		AfterSkybox,
		// Token: 0x04000BCA RID: 3018
		BeforeForwardAlpha,
		// Token: 0x04000BCB RID: 3019
		AfterForwardAlpha,
		// Token: 0x04000BCC RID: 3020
		BeforeImageEffects,
		// Token: 0x04000BCD RID: 3021
		AfterImageEffects,
		// Token: 0x04000BCE RID: 3022
		AfterEverything,
		// Token: 0x04000BCF RID: 3023
		BeforeReflections,
		// Token: 0x04000BD0 RID: 3024
		AfterReflections,
		// Token: 0x04000BD1 RID: 3025
		BeforeHaloAndLensFlares,
		// Token: 0x04000BD2 RID: 3026
		AfterHaloAndLensFlares
	}
}
