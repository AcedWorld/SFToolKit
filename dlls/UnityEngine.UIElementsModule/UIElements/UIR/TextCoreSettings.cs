using System;

namespace UnityEngine.UIElements.UIR
{
	// Token: 0x0200046A RID: 1130
	internal struct TextCoreSettings : IEquatable<TextCoreSettings>
	{
		// Token: 0x06002317 RID: 8983 RVA: 0x00088204 File Offset: 0x00086404
		public override bool Equals(object obj)
		{
			return obj is TextCoreSettings && this.Equals((TextCoreSettings)obj);
		}

		// Token: 0x06002318 RID: 8984 RVA: 0x00088230 File Offset: 0x00086430
		public bool Equals(TextCoreSettings other)
		{
			return other.faceColor == this.faceColor && other.outlineColor == this.outlineColor && other.outlineWidth == this.outlineWidth && other.underlayColor == this.underlayColor && other.underlayOffset == this.underlayOffset && other.underlaySoftness == this.underlaySoftness;
		}

		// Token: 0x06002319 RID: 8985 RVA: 0x000882B0 File Offset: 0x000864B0
		public override int GetHashCode()
		{
			int num = 75905159;
			num = num * -1521134295 + this.faceColor.GetHashCode();
			num = num * -1521134295 + this.outlineColor.GetHashCode();
			num = num * -1521134295 + this.outlineWidth.GetHashCode();
			num = num * -1521134295 + this.underlayColor.GetHashCode();
			num = num * -1521134295 + this.underlayOffset.x.GetHashCode();
			num = num * -1521134295 + this.underlayOffset.y.GetHashCode();
			return num * -1521134295 + this.underlaySoftness.GetHashCode();
		}

		// Token: 0x0400103A RID: 4154
		public Color faceColor;

		// Token: 0x0400103B RID: 4155
		public Color outlineColor;

		// Token: 0x0400103C RID: 4156
		public float outlineWidth;

		// Token: 0x0400103D RID: 4157
		public Color underlayColor;

		// Token: 0x0400103E RID: 4158
		public Vector2 underlayOffset;

		// Token: 0x0400103F RID: 4159
		public float underlaySoftness;
	}
}
