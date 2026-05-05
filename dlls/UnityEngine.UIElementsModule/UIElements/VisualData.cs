using System;

namespace UnityEngine.UIElements
{
	// Token: 0x020002F1 RID: 753
	internal struct VisualData : IStyleDataGroup<VisualData>, IEquatable<VisualData>
	{
		// Token: 0x06001973 RID: 6515 RVA: 0x00062B50 File Offset: 0x00060D50
		public VisualData Copy()
		{
			return this;
		}

		// Token: 0x06001974 RID: 6516 RVA: 0x00062B68 File Offset: 0x00060D68
		public void CopyFrom(ref VisualData other)
		{
			this = other;
		}

		// Token: 0x06001975 RID: 6517 RVA: 0x00062B78 File Offset: 0x00060D78
		public static bool operator ==(VisualData lhs, VisualData rhs)
		{
			return lhs.backgroundColor == rhs.backgroundColor && lhs.backgroundImage == rhs.backgroundImage && lhs.backgroundPositionX == rhs.backgroundPositionX && lhs.backgroundPositionY == rhs.backgroundPositionY && lhs.backgroundRepeat == rhs.backgroundRepeat && lhs.backgroundSize == rhs.backgroundSize && lhs.borderBottomColor == rhs.borderBottomColor && lhs.borderBottomLeftRadius == rhs.borderBottomLeftRadius && lhs.borderBottomRightRadius == rhs.borderBottomRightRadius && lhs.borderLeftColor == rhs.borderLeftColor && lhs.borderRightColor == rhs.borderRightColor && lhs.borderTopColor == rhs.borderTopColor && lhs.borderTopLeftRadius == rhs.borderTopLeftRadius && lhs.borderTopRightRadius == rhs.borderTopRightRadius && lhs.opacity == rhs.opacity && lhs.overflow == rhs.overflow;
		}

		// Token: 0x06001976 RID: 6518 RVA: 0x00062CCC File Offset: 0x00060ECC
		public static bool operator !=(VisualData lhs, VisualData rhs)
		{
			return !(lhs == rhs);
		}

		// Token: 0x06001977 RID: 6519 RVA: 0x00062CE8 File Offset: 0x00060EE8
		public bool Equals(VisualData other)
		{
			return other == this;
		}

		// Token: 0x06001978 RID: 6520 RVA: 0x00062D08 File Offset: 0x00060F08
		public override bool Equals(object obj)
		{
			bool flag = obj == null;
			return !flag && obj is VisualData && this.Equals((VisualData)obj);
		}

		// Token: 0x06001979 RID: 6521 RVA: 0x00062D40 File Offset: 0x00060F40
		public override int GetHashCode()
		{
			int num = this.backgroundColor.GetHashCode();
			num = (num * 397 ^ this.backgroundImage.GetHashCode());
			num = (num * 397 ^ this.backgroundPositionX.GetHashCode());
			num = (num * 397 ^ this.backgroundPositionY.GetHashCode());
			num = (num * 397 ^ this.backgroundRepeat.GetHashCode());
			num = (num * 397 ^ this.backgroundSize.GetHashCode());
			num = (num * 397 ^ this.borderBottomColor.GetHashCode());
			num = (num * 397 ^ this.borderBottomLeftRadius.GetHashCode());
			num = (num * 397 ^ this.borderBottomRightRadius.GetHashCode());
			num = (num * 397 ^ this.borderLeftColor.GetHashCode());
			num = (num * 397 ^ this.borderRightColor.GetHashCode());
			num = (num * 397 ^ this.borderTopColor.GetHashCode());
			num = (num * 397 ^ this.borderTopLeftRadius.GetHashCode());
			num = (num * 397 ^ this.borderTopRightRadius.GetHashCode());
			num = (num * 397 ^ this.opacity.GetHashCode());
			return num * 397 ^ (int)this.overflow;
		}

		// Token: 0x04000AAE RID: 2734
		public Color backgroundColor;

		// Token: 0x04000AAF RID: 2735
		public Background backgroundImage;

		// Token: 0x04000AB0 RID: 2736
		public BackgroundPosition backgroundPositionX;

		// Token: 0x04000AB1 RID: 2737
		public BackgroundPosition backgroundPositionY;

		// Token: 0x04000AB2 RID: 2738
		public BackgroundRepeat backgroundRepeat;

		// Token: 0x04000AB3 RID: 2739
		public BackgroundSize backgroundSize;

		// Token: 0x04000AB4 RID: 2740
		public Color borderBottomColor;

		// Token: 0x04000AB5 RID: 2741
		public Length borderBottomLeftRadius;

		// Token: 0x04000AB6 RID: 2742
		public Length borderBottomRightRadius;

		// Token: 0x04000AB7 RID: 2743
		public Color borderLeftColor;

		// Token: 0x04000AB8 RID: 2744
		public Color borderRightColor;

		// Token: 0x04000AB9 RID: 2745
		public Color borderTopColor;

		// Token: 0x04000ABA RID: 2746
		public Length borderTopLeftRadius;

		// Token: 0x04000ABB RID: 2747
		public Length borderTopRightRadius;

		// Token: 0x04000ABC RID: 2748
		public float opacity;

		// Token: 0x04000ABD RID: 2749
		public OverflowInternal overflow;
	}
}
