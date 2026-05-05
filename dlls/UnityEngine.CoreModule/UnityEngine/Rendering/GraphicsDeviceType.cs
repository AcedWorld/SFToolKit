using System;
using UnityEngine.Scripting;

namespace UnityEngine.Rendering
{
	// Token: 0x02000404 RID: 1028
	[UsedByNativeCode]
	public enum GraphicsDeviceType
	{
		// Token: 0x04000C1F RID: 3103
		[Obsolete("OpenGL2 is no longer supported in Unity 5.5+")]
		OpenGL2,
		// Token: 0x04000C20 RID: 3104
		[Obsolete("Direct3D 9 is no longer supported in Unity 2017.2+")]
		Direct3D9,
		// Token: 0x04000C21 RID: 3105
		Direct3D11,
		// Token: 0x04000C22 RID: 3106
		[Obsolete("PS3 is no longer supported in Unity 5.5+")]
		PlayStation3,
		// Token: 0x04000C23 RID: 3107
		Null,
		// Token: 0x04000C24 RID: 3108
		[Obsolete("Xbox360 is no longer supported in Unity 5.5+")]
		Xbox360 = 6,
		// Token: 0x04000C25 RID: 3109
		OpenGLES2 = 8,
		// Token: 0x04000C26 RID: 3110
		OpenGLES3 = 11,
		// Token: 0x04000C27 RID: 3111
		[Obsolete("PVita is no longer supported as of Unity 2018")]
		PlayStationVita,
		// Token: 0x04000C28 RID: 3112
		PlayStation4,
		// Token: 0x04000C29 RID: 3113
		XboxOne,
		// Token: 0x04000C2A RID: 3114
		[Obsolete("PlayStationMobile is no longer supported in Unity 5.3+")]
		PlayStationMobile,
		// Token: 0x04000C2B RID: 3115
		Metal,
		// Token: 0x04000C2C RID: 3116
		OpenGLCore,
		// Token: 0x04000C2D RID: 3117
		Direct3D12,
		// Token: 0x04000C2E RID: 3118
		[Obsolete("Nintendo 3DS support is unavailable since 2018.1")]
		N3DS,
		// Token: 0x04000C2F RID: 3119
		Vulkan = 21,
		// Token: 0x04000C30 RID: 3120
		Switch,
		// Token: 0x04000C31 RID: 3121
		XboxOneD3D12,
		// Token: 0x04000C32 RID: 3122
		GameCoreXboxOne,
		// Token: 0x04000C33 RID: 3123
		[Obsolete("GameCoreScarlett is deprecated, please use GameCoreXboxSeries (UnityUpgradable) -> GameCoreXboxSeries", false)]
		GameCoreScarlett = -1,
		// Token: 0x04000C34 RID: 3124
		GameCoreXboxSeries = 25,
		// Token: 0x04000C35 RID: 3125
		PlayStation5,
		// Token: 0x04000C36 RID: 3126
		PlayStation5NGGC
	}
}
