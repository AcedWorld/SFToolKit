using System;

namespace UnityEngine.UIElements
{
	// Token: 0x020002EC RID: 748
	internal struct InheritedData : IStyleDataGroup<InheritedData>, IEquatable<InheritedData>
	{
		// Token: 0x06001950 RID: 6480 RVA: 0x00061C50 File Offset: 0x0005FE50
		public InheritedData Copy()
		{
			return this;
		}

		// Token: 0x06001951 RID: 6481 RVA: 0x00061C68 File Offset: 0x0005FE68
		public void CopyFrom(ref InheritedData other)
		{
			this = other;
		}

		// Token: 0x06001952 RID: 6482 RVA: 0x00061C78 File Offset: 0x0005FE78
		public static bool operator ==(InheritedData lhs, InheritedData rhs)
		{
			return lhs.color == rhs.color && lhs.fontSize == rhs.fontSize && lhs.letterSpacing == rhs.letterSpacing && lhs.textShadow == rhs.textShadow && lhs.unityFont == rhs.unityFont && lhs.unityFontDefinition == rhs.unityFontDefinition && lhs.unityFontStyleAndWeight == rhs.unityFontStyleAndWeight && lhs.unityParagraphSpacing == rhs.unityParagraphSpacing && lhs.unityTextAlign == rhs.unityTextAlign && lhs.unityTextOutlineColor == rhs.unityTextOutlineColor && lhs.unityTextOutlineWidth == rhs.unityTextOutlineWidth && lhs.visibility == rhs.visibility && lhs.whiteSpace == rhs.whiteSpace && lhs.wordSpacing == rhs.wordSpacing;
		}

		// Token: 0x06001953 RID: 6483 RVA: 0x00061D8C File Offset: 0x0005FF8C
		public static bool operator !=(InheritedData lhs, InheritedData rhs)
		{
			return !(lhs == rhs);
		}

		// Token: 0x06001954 RID: 6484 RVA: 0x00061DA8 File Offset: 0x0005FFA8
		public bool Equals(InheritedData other)
		{
			return other == this;
		}

		// Token: 0x06001955 RID: 6485 RVA: 0x00061DC8 File Offset: 0x0005FFC8
		public override bool Equals(object obj)
		{
			bool flag = obj == null;
			return !flag && obj is InheritedData && this.Equals((InheritedData)obj);
		}

		// Token: 0x06001956 RID: 6486 RVA: 0x00061E00 File Offset: 0x00060000
		public override int GetHashCode()
		{
			int num = this.color.GetHashCode();
			num = (num * 397 ^ this.fontSize.GetHashCode());
			num = (num * 397 ^ this.letterSpacing.GetHashCode());
			num = (num * 397 ^ this.textShadow.GetHashCode());
			num = (num * 397 ^ ((this.unityFont == null) ? 0 : this.unityFont.GetHashCode()));
			num = (num * 397 ^ this.unityFontDefinition.GetHashCode());
			num = (num * 397 ^ (int)this.unityFontStyleAndWeight);
			num = (num * 397 ^ this.unityParagraphSpacing.GetHashCode());
			num = (num * 397 ^ (int)this.unityTextAlign);
			num = (num * 397 ^ this.unityTextOutlineColor.GetHashCode());
			num = (num * 397 ^ this.unityTextOutlineWidth.GetHashCode());
			num = (num * 397 ^ (int)this.visibility);
			num = (num * 397 ^ (int)this.whiteSpace);
			return num * 397 ^ this.wordSpacing.GetHashCode();
		}

		// Token: 0x04000A6D RID: 2669
		public Color color;

		// Token: 0x04000A6E RID: 2670
		public Length fontSize;

		// Token: 0x04000A6F RID: 2671
		public Length letterSpacing;

		// Token: 0x04000A70 RID: 2672
		public TextShadow textShadow;

		// Token: 0x04000A71 RID: 2673
		public Font unityFont;

		// Token: 0x04000A72 RID: 2674
		public FontDefinition unityFontDefinition;

		// Token: 0x04000A73 RID: 2675
		public FontStyle unityFontStyleAndWeight;

		// Token: 0x04000A74 RID: 2676
		public Length unityParagraphSpacing;

		// Token: 0x04000A75 RID: 2677
		public TextAnchor unityTextAlign;

		// Token: 0x04000A76 RID: 2678
		public Color unityTextOutlineColor;

		// Token: 0x04000A77 RID: 2679
		public float unityTextOutlineWidth;

		// Token: 0x04000A78 RID: 2680
		public Visibility visibility;

		// Token: 0x04000A79 RID: 2681
		public WhiteSpace whiteSpace;

		// Token: 0x04000A7A RID: 2682
		public Length wordSpacing;
	}
}
