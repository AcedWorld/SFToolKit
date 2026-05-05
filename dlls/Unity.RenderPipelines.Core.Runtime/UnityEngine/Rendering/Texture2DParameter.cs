using System;
using System.Diagnostics;

namespace UnityEngine.Rendering
{
	// Token: 0x0200010E RID: 270
	[DebuggerDisplay("{m_Value} ({m_OverrideState})")]
	[Serializable]
	public class Texture2DParameter : VolumeParameter<Texture>
	{
		// Token: 0x06000840 RID: 2112 RVA: 0x00026DCA File Offset: 0x00024FCA
		public Texture2DParameter(Texture value, bool overrideState = false) : base(value, overrideState)
		{
		}

		// Token: 0x06000841 RID: 2113 RVA: 0x00026DD4 File Offset: 0x00024FD4
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
