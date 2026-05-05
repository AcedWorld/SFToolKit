using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x02000171 RID: 369
	[Serializable]
	public sealed class SkyImportanceSamplingParameter : VolumeParameter<SkyImportanceSamplingMode>
	{
		// Token: 0x06000C2F RID: 3119 RVA: 0x0006494C File Offset: 0x00062B4C
		public SkyImportanceSamplingParameter(SkyImportanceSamplingMode value, bool overrideState = false) : base(value, overrideState)
		{
		}
	}
}
