using System;
using System.Diagnostics;

namespace UnityEngine.Rendering
{
	// Token: 0x02000113 RID: 275
	[DebuggerDisplay("{m_Value} ({m_OverrideState})")]
	[Serializable]
	public class NoInterpCubemapParameter : VolumeParameter<Cubemap>
	{
		// Token: 0x0600084A RID: 2122 RVA: 0x00026EF6 File Offset: 0x000250F6
		public NoInterpCubemapParameter(Cubemap value, bool overrideState = false) : base(value, overrideState)
		{
		}

		// Token: 0x0600084B RID: 2123 RVA: 0x00026F00 File Offset: 0x00025100
		public override int GetHashCode()
		{
			int result = base.GetHashCode();
			if (this.value != null)
			{
				result = 23 * CoreUtils.GetTextureHash(this.value);
			}
			return result;
		}
	}
}
