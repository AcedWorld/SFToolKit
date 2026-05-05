using System;

namespace UnityEngine.UIElements
{
	// Token: 0x02000376 RID: 886
	public struct TextShadow : IEquatable<TextShadow>
	{
		// Token: 0x06001DEE RID: 7662 RVA: 0x00073E1C File Offset: 0x0007201C
		public override bool Equals(object obj)
		{
			return obj is TextShadow && this.Equals((TextShadow)obj);
		}

		// Token: 0x06001DEF RID: 7663 RVA: 0x00073E48 File Offset: 0x00072048
		public bool Equals(TextShadow other)
		{
			return other.offset == this.offset && other.blurRadius == this.blurRadius && other.color == this.color;
		}

		// Token: 0x06001DF0 RID: 7664 RVA: 0x00073E90 File Offset: 0x00072090
		public override int GetHashCode()
		{
			int num = 1500536833;
			num = num * -1521134295 + this.offset.GetHashCode();
			num = num * -1521134295 + this.blurRadius.GetHashCode();
			return num * -1521134295 + this.color.GetHashCode();
		}

		// Token: 0x06001DF1 RID: 7665 RVA: 0x00073EF4 File Offset: 0x000720F4
		public static bool operator ==(TextShadow style1, TextShadow style2)
		{
			return style1.Equals(style2);
		}

		// Token: 0x06001DF2 RID: 7666 RVA: 0x00073F10 File Offset: 0x00072110
		public static bool operator !=(TextShadow style1, TextShadow style2)
		{
			return !(style1 == style2);
		}

		// Token: 0x06001DF3 RID: 7667 RVA: 0x00073F2C File Offset: 0x0007212C
		public override string ToString()
		{
			return string.Format("offset={0}, blurRadius={1}, color={2}", this.offset, this.blurRadius, this.color);
		}

		// Token: 0x06001DF4 RID: 7668 RVA: 0x00073F6C File Offset: 0x0007216C
		internal static TextShadow LerpUnclamped(TextShadow a, TextShadow b, float t)
		{
			return new TextShadow
			{
				offset = Vector2.LerpUnclamped(a.offset, b.offset, t),
				blurRadius = Mathf.LerpUnclamped(a.blurRadius, b.blurRadius, t),
				color = Color.LerpUnclamped(a.color, b.color, t)
			};
		}

		// Token: 0x04000C7B RID: 3195
		public Vector2 offset;

		// Token: 0x04000C7C RID: 3196
		public float blurRadius;

		// Token: 0x04000C7D RID: 3197
		public Color color;
	}
}
