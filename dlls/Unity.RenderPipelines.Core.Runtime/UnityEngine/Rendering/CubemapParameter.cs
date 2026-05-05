using System;
using System.Diagnostics;

namespace UnityEngine.Rendering
{
	// Token: 0x02000112 RID: 274
	[DebuggerDisplay("{m_Value} ({m_OverrideState})")]
	[Serializable]
	public class CubemapParameter : VolumeParameter<Texture>
	{
		// Token: 0x06000848 RID: 2120 RVA: 0x00026EBA File Offset: 0x000250BA
		public CubemapParameter(Texture value, bool overrideState = false) : base(value, overrideState)
		{
		}

		// Token: 0x06000849 RID: 2121 RVA: 0x00026EC4 File Offset: 0x000250C4
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
