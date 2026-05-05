using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x02000185 RID: 389
	[Serializable]
	public sealed class RayTracingModeParameter : VolumeParameter<RayTracingMode>
	{
		// Token: 0x06000C74 RID: 3188 RVA: 0x000683D9 File Offset: 0x000665D9
		public RayTracingModeParameter(RayTracingMode value, bool overrideState = false) : base(value, overrideState)
		{
		}
	}
}
