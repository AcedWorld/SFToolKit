using System;
using System.Diagnostics;

namespace UnityEngine.Rendering
{
	// Token: 0x0200010F RID: 271
	[DebuggerDisplay("{m_Value} ({m_OverrideState})")]
	[Serializable]
	public class Texture3DParameter : VolumeParameter<Texture>
	{
		// Token: 0x06000842 RID: 2114 RVA: 0x00026E06 File Offset: 0x00025006
		public Texture3DParameter(Texture value, bool overrideState = false) : base(value, overrideState)
		{
		}

		// Token: 0x06000843 RID: 2115 RVA: 0x00026E10 File Offset: 0x00025010
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
