using System;
using UnityEngine;
using UnityEngine.TextCore;

namespace TMPro
{
	// Token: 0x02000056 RID: 86
	[Serializable]
	public class TMP_SpriteGlyph : Glyph
	{
		// Token: 0x060003C7 RID: 967 RVA: 0x000268B6 File Offset: 0x00024AB6
		public TMP_SpriteGlyph()
		{
		}

		// Token: 0x060003C8 RID: 968 RVA: 0x000268BE File Offset: 0x00024ABE
		public TMP_SpriteGlyph(uint index, GlyphMetrics metrics, GlyphRect glyphRect, float scale, int atlasIndex)
		{
			base.index = index;
			base.metrics = metrics;
			base.glyphRect = glyphRect;
			base.scale = scale;
			base.atlasIndex = atlasIndex;
		}

		// Token: 0x060003C9 RID: 969 RVA: 0x000268EB File Offset: 0x00024AEB
		public TMP_SpriteGlyph(uint index, GlyphMetrics metrics, GlyphRect glyphRect, float scale, int atlasIndex, Sprite sprite)
		{
			base.index = index;
			base.metrics = metrics;
			base.glyphRect = glyphRect;
			base.scale = scale;
			base.atlasIndex = atlasIndex;
			this.sprite = sprite;
		}

		// Token: 0x040003A9 RID: 937
		public Sprite sprite;
	}
}
