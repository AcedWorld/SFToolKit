using System;

namespace UnityEngine.UIElements
{
	// Token: 0x020002ED RID: 749
	internal struct LayoutData : IStyleDataGroup<LayoutData>, IEquatable<LayoutData>
	{
		// Token: 0x06001957 RID: 6487 RVA: 0x00061F54 File Offset: 0x00060154
		public LayoutData Copy()
		{
			return this;
		}

		// Token: 0x06001958 RID: 6488 RVA: 0x00061F6C File Offset: 0x0006016C
		public void CopyFrom(ref LayoutData other)
		{
			this = other;
		}

		// Token: 0x06001959 RID: 6489 RVA: 0x00061F7C File Offset: 0x0006017C
		public static bool operator ==(LayoutData lhs, LayoutData rhs)
		{
			return lhs.alignContent == rhs.alignContent && lhs.alignItems == rhs.alignItems && lhs.alignSelf == rhs.alignSelf && lhs.borderBottomWidth == rhs.borderBottomWidth && lhs.borderLeftWidth == rhs.borderLeftWidth && lhs.borderRightWidth == rhs.borderRightWidth && lhs.borderTopWidth == rhs.borderTopWidth && lhs.bottom == rhs.bottom && lhs.display == rhs.display && lhs.flexBasis == rhs.flexBasis && lhs.flexDirection == rhs.flexDirection && lhs.flexGrow == rhs.flexGrow && lhs.flexShrink == rhs.flexShrink && lhs.flexWrap == rhs.flexWrap && lhs.height == rhs.height && lhs.justifyContent == rhs.justifyContent && lhs.left == rhs.left && lhs.marginBottom == rhs.marginBottom && lhs.marginLeft == rhs.marginLeft && lhs.marginRight == rhs.marginRight && lhs.marginTop == rhs.marginTop && lhs.maxHeight == rhs.maxHeight && lhs.maxWidth == rhs.maxWidth && lhs.minHeight == rhs.minHeight && lhs.minWidth == rhs.minWidth && lhs.paddingBottom == rhs.paddingBottom && lhs.paddingLeft == rhs.paddingLeft && lhs.paddingRight == rhs.paddingRight && lhs.paddingTop == rhs.paddingTop && lhs.position == rhs.position && lhs.right == rhs.right && lhs.top == rhs.top && lhs.width == rhs.width;
		}

		// Token: 0x0600195A RID: 6490 RVA: 0x0006220C File Offset: 0x0006040C
		public static bool operator !=(LayoutData lhs, LayoutData rhs)
		{
			return !(lhs == rhs);
		}

		// Token: 0x0600195B RID: 6491 RVA: 0x00062228 File Offset: 0x00060428
		public bool Equals(LayoutData other)
		{
			return other == this;
		}

		// Token: 0x0600195C RID: 6492 RVA: 0x00062248 File Offset: 0x00060448
		public override bool Equals(object obj)
		{
			bool flag = obj == null;
			return !flag && obj is LayoutData && this.Equals((LayoutData)obj);
		}

		// Token: 0x0600195D RID: 6493 RVA: 0x00062280 File Offset: 0x00060480
		public override int GetHashCode()
		{
			int num = (int)this.alignContent;
			num = (num * 397 ^ (int)this.alignItems);
			num = (num * 397 ^ (int)this.alignSelf);
			num = (num * 397 ^ this.borderBottomWidth.GetHashCode());
			num = (num * 397 ^ this.borderLeftWidth.GetHashCode());
			num = (num * 397 ^ this.borderRightWidth.GetHashCode());
			num = (num * 397 ^ this.borderTopWidth.GetHashCode());
			num = (num * 397 ^ this.bottom.GetHashCode());
			num = (num * 397 ^ (int)this.display);
			num = (num * 397 ^ this.flexBasis.GetHashCode());
			num = (num * 397 ^ (int)this.flexDirection);
			num = (num * 397 ^ this.flexGrow.GetHashCode());
			num = (num * 397 ^ this.flexShrink.GetHashCode());
			num = (num * 397 ^ (int)this.flexWrap);
			num = (num * 397 ^ this.height.GetHashCode());
			num = (num * 397 ^ (int)this.justifyContent);
			num = (num * 397 ^ this.left.GetHashCode());
			num = (num * 397 ^ this.marginBottom.GetHashCode());
			num = (num * 397 ^ this.marginLeft.GetHashCode());
			num = (num * 397 ^ this.marginRight.GetHashCode());
			num = (num * 397 ^ this.marginTop.GetHashCode());
			num = (num * 397 ^ this.maxHeight.GetHashCode());
			num = (num * 397 ^ this.maxWidth.GetHashCode());
			num = (num * 397 ^ this.minHeight.GetHashCode());
			num = (num * 397 ^ this.minWidth.GetHashCode());
			num = (num * 397 ^ this.paddingBottom.GetHashCode());
			num = (num * 397 ^ this.paddingLeft.GetHashCode());
			num = (num * 397 ^ this.paddingRight.GetHashCode());
			num = (num * 397 ^ this.paddingTop.GetHashCode());
			num = (num * 397 ^ (int)this.position);
			num = (num * 397 ^ this.right.GetHashCode());
			num = (num * 397 ^ this.top.GetHashCode());
			return num * 397 ^ this.width.GetHashCode();
		}

		// Token: 0x04000A7B RID: 2683
		public Align alignContent;

		// Token: 0x04000A7C RID: 2684
		public Align alignItems;

		// Token: 0x04000A7D RID: 2685
		public Align alignSelf;

		// Token: 0x04000A7E RID: 2686
		public float borderBottomWidth;

		// Token: 0x04000A7F RID: 2687
		public float borderLeftWidth;

		// Token: 0x04000A80 RID: 2688
		public float borderRightWidth;

		// Token: 0x04000A81 RID: 2689
		public float borderTopWidth;

		// Token: 0x04000A82 RID: 2690
		public Length bottom;

		// Token: 0x04000A83 RID: 2691
		public DisplayStyle display;

		// Token: 0x04000A84 RID: 2692
		public Length flexBasis;

		// Token: 0x04000A85 RID: 2693
		public FlexDirection flexDirection;

		// Token: 0x04000A86 RID: 2694
		public float flexGrow;

		// Token: 0x04000A87 RID: 2695
		public float flexShrink;

		// Token: 0x04000A88 RID: 2696
		public Wrap flexWrap;

		// Token: 0x04000A89 RID: 2697
		public Length height;

		// Token: 0x04000A8A RID: 2698
		public Justify justifyContent;

		// Token: 0x04000A8B RID: 2699
		public Length left;

		// Token: 0x04000A8C RID: 2700
		public Length marginBottom;

		// Token: 0x04000A8D RID: 2701
		public Length marginLeft;

		// Token: 0x04000A8E RID: 2702
		public Length marginRight;

		// Token: 0x04000A8F RID: 2703
		public Length marginTop;

		// Token: 0x04000A90 RID: 2704
		public Length maxHeight;

		// Token: 0x04000A91 RID: 2705
		public Length maxWidth;

		// Token: 0x04000A92 RID: 2706
		public Length minHeight;

		// Token: 0x04000A93 RID: 2707
		public Length minWidth;

		// Token: 0x04000A94 RID: 2708
		public Length paddingBottom;

		// Token: 0x04000A95 RID: 2709
		public Length paddingLeft;

		// Token: 0x04000A96 RID: 2710
		public Length paddingRight;

		// Token: 0x04000A97 RID: 2711
		public Length paddingTop;

		// Token: 0x04000A98 RID: 2712
		public Position position;

		// Token: 0x04000A99 RID: 2713
		public Length right;

		// Token: 0x04000A9A RID: 2714
		public Length top;

		// Token: 0x04000A9B RID: 2715
		public Length width;
	}
}
