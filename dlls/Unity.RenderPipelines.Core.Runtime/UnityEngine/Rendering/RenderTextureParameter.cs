using System;
using System.Diagnostics;

namespace UnityEngine.Rendering
{
	// Token: 0x02000110 RID: 272
	[DebuggerDisplay("{m_Value} ({m_OverrideState})")]
	[Serializable]
	public class RenderTextureParameter : VolumeParameter<RenderTexture>
	{
		// Token: 0x06000844 RID: 2116 RVA: 0x00026E42 File Offset: 0x00025042
		public RenderTextureParameter(RenderTexture value, bool overrideState = false) : base(value, overrideState)
		{
		}

		// Token: 0x06000845 RID: 2117 RVA: 0x00026E4C File Offset: 0x0002504C
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
