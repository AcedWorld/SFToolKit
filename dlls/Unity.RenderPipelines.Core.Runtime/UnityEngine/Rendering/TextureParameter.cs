using System;
using System.Diagnostics;

namespace UnityEngine.Rendering
{
	// Token: 0x0200010C RID: 268
	[DebuggerDisplay("{m_Value} ({m_OverrideState})")]
	[Serializable]
	public class TextureParameter : VolumeParameter<Texture>
	{
		// Token: 0x0600083B RID: 2107 RVA: 0x00026D3F File Offset: 0x00024F3F
		public TextureParameter(Texture value, bool overrideState = false) : this(value, TextureDimension.Any, overrideState)
		{
		}

		// Token: 0x0600083C RID: 2108 RVA: 0x00026D4A File Offset: 0x00024F4A
		public TextureParameter(Texture value, TextureDimension dimension, bool overrideState = false) : base(value, overrideState)
		{
			this.dimension = dimension;
		}

		// Token: 0x0600083D RID: 2109 RVA: 0x00026D5C File Offset: 0x00024F5C
		public override int GetHashCode()
		{
			int result = base.GetHashCode();
			if (this.value != null)
			{
				result = 23 * CoreUtils.GetTextureHash(this.value);
			}
			return result;
		}

		// Token: 0x040004F7 RID: 1271
		public TextureDimension dimension;
	}
}
