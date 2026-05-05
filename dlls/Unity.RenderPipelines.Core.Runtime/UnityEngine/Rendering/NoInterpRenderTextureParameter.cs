using System;
using System.Diagnostics;

namespace UnityEngine.Rendering
{
	// Token: 0x02000111 RID: 273
	[DebuggerDisplay("{m_Value} ({m_OverrideState})")]
	[Serializable]
	public class NoInterpRenderTextureParameter : VolumeParameter<RenderTexture>
	{
		// Token: 0x06000846 RID: 2118 RVA: 0x00026E7E File Offset: 0x0002507E
		public NoInterpRenderTextureParameter(RenderTexture value, bool overrideState = false) : base(value, overrideState)
		{
		}

		// Token: 0x06000847 RID: 2119 RVA: 0x00026E88 File Offset: 0x00025088
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
