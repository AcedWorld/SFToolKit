using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x0200011B RID: 283
	[Serializable]
	public sealed class BloomResolutionParameter : VolumeParameter<BloomResolution>
	{
		// Token: 0x06000A8A RID: 2698 RVA: 0x0005967A File Offset: 0x0005787A
		public BloomResolutionParameter(BloomResolution value, bool overrideState = false) : base(value, overrideState)
		{
		}
	}
}
