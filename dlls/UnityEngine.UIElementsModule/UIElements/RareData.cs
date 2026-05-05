using System;

namespace UnityEngine.UIElements
{
	// Token: 0x020002EE RID: 750
	internal struct RareData : IStyleDataGroup<RareData>, IEquatable<RareData>
	{
		// Token: 0x0600195E RID: 6494 RVA: 0x0006256C File Offset: 0x0006076C
		public RareData Copy()
		{
			return this;
		}

		// Token: 0x0600195F RID: 6495 RVA: 0x00062584 File Offset: 0x00060784
		public void CopyFrom(ref RareData other)
		{
			this = other;
		}

		// Token: 0x06001960 RID: 6496 RVA: 0x00062594 File Offset: 0x00060794
		public static bool operator ==(RareData lhs, RareData rhs)
		{
			return lhs.cursor == rhs.cursor && lhs.textOverflow == rhs.textOverflow && lhs.unityBackgroundImageTintColor == rhs.unityBackgroundImageTintColor && lhs.unityOverflowClipBox == rhs.unityOverflowClipBox && lhs.unitySliceBottom == rhs.unitySliceBottom && lhs.unitySliceLeft == rhs.unitySliceLeft && lhs.unitySliceRight == rhs.unitySliceRight && lhs.unitySliceScale == rhs.unitySliceScale && lhs.unitySliceTop == rhs.unitySliceTop && lhs.unityTextOverflowPosition == rhs.unityTextOverflowPosition;
		}

		// Token: 0x06001961 RID: 6497 RVA: 0x00062644 File Offset: 0x00060844
		public static bool operator !=(RareData lhs, RareData rhs)
		{
			return !(lhs == rhs);
		}

		// Token: 0x06001962 RID: 6498 RVA: 0x00062660 File Offset: 0x00060860
		public bool Equals(RareData other)
		{
			return other == this;
		}

		// Token: 0x06001963 RID: 6499 RVA: 0x00062680 File Offset: 0x00060880
		public override bool Equals(object obj)
		{
			bool flag = obj == null;
			return !flag && obj is RareData && this.Equals((RareData)obj);
		}

		// Token: 0x06001964 RID: 6500 RVA: 0x000626B8 File Offset: 0x000608B8
		public override int GetHashCode()
		{
			int num = this.cursor.GetHashCode();
			num = (num * 397 ^ (int)this.textOverflow);
			num = (num * 397 ^ this.unityBackgroundImageTintColor.GetHashCode());
			num = (num * 397 ^ (int)this.unityOverflowClipBox);
			num = (num * 397 ^ this.unitySliceBottom);
			num = (num * 397 ^ this.unitySliceLeft);
			num = (num * 397 ^ this.unitySliceRight);
			num = (num * 397 ^ this.unitySliceScale.GetHashCode());
			num = (num * 397 ^ this.unitySliceTop);
			return num * 397 ^ (int)this.unityTextOverflowPosition;
		}

		// Token: 0x04000A9C RID: 2716
		public Cursor cursor;

		// Token: 0x04000A9D RID: 2717
		public TextOverflow textOverflow;

		// Token: 0x04000A9E RID: 2718
		public Color unityBackgroundImageTintColor;

		// Token: 0x04000A9F RID: 2719
		public OverflowClipBox unityOverflowClipBox;

		// Token: 0x04000AA0 RID: 2720
		public int unitySliceBottom;

		// Token: 0x04000AA1 RID: 2721
		public int unitySliceLeft;

		// Token: 0x04000AA2 RID: 2722
		public int unitySliceRight;

		// Token: 0x04000AA3 RID: 2723
		public float unitySliceScale;

		// Token: 0x04000AA4 RID: 2724
		public int unitySliceTop;

		// Token: 0x04000AA5 RID: 2725
		public TextOverflowPosition unityTextOverflowPosition;
	}
}
