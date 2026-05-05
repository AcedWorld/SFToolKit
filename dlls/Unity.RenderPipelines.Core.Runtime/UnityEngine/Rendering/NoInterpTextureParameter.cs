using System;
using System.Diagnostics;

namespace UnityEngine.Rendering
{
	// Token: 0x0200010D RID: 269
	[DebuggerDisplay("{m_Value} ({m_OverrideState})")]
	[Serializable]
	public class NoInterpTextureParameter : VolumeParameter<Texture>
	{
		// Token: 0x0600083E RID: 2110 RVA: 0x00026D8E File Offset: 0x00024F8E
		public NoInterpTextureParameter(Texture value, bool overrideState = false) : base(value, overrideState)
		{
		}

		// Token: 0x0600083F RID: 2111 RVA: 0x00026D98 File Offset: 0x00024F98
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
