using System;
using System.Runtime.CompilerServices;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

namespace UnityEngine
{
	// Token: 0x02000136 RID: 310
	[PreventReadOnlyInstanceModification]
	[NativeHeader("Runtime/Graphics/LightingSettings.h")]
	public sealed class LightingSettings : Object
	{
		// Token: 0x06000862 RID: 2146 RVA: 0x00002669 File Offset: 0x00000869
		[RequiredByNativeCode]
		internal void LightingSettingsDontStripMe()
		{
		}

		// Token: 0x06000863 RID: 2147 RVA: 0x0000DAC2 File Offset: 0x0000BCC2
		public LightingSettings()
		{
			LightingSettings.Internal_Create(this);
		}

		// Token: 0x06000864 RID: 2148
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Internal_Create([Writable] LightingSettings self);

		// Token: 0x170001D7 RID: 471
		// (get) Token: 0x06000865 RID: 2149
		// (set) Token: 0x06000866 RID: 2150
		[NativeName("EnableBakedLightmaps")]
		public extern bool bakedGI { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x170001D8 RID: 472
		// (get) Token: 0x06000867 RID: 2151
		// (set) Token: 0x06000868 RID: 2152
		[NativeName("EnableRealtimeLightmaps")]
		public extern bool realtimeGI { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x170001D9 RID: 473
		// (get) Token: 0x06000869 RID: 2153
		// (set) Token: 0x0600086A RID: 2154
		[NativeName("RealtimeEnvironmentLighting")]
		public extern bool realtimeEnvironmentLighting { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }
	}
}
