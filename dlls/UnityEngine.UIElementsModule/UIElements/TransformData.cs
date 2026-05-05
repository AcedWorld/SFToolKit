using System;

namespace UnityEngine.UIElements
{
	// Token: 0x020002EF RID: 751
	internal struct TransformData : IStyleDataGroup<TransformData>, IEquatable<TransformData>
	{
		// Token: 0x06001965 RID: 6501 RVA: 0x00062778 File Offset: 0x00060978
		public TransformData Copy()
		{
			return this;
		}

		// Token: 0x06001966 RID: 6502 RVA: 0x00062790 File Offset: 0x00060990
		public void CopyFrom(ref TransformData other)
		{
			this = other;
		}

		// Token: 0x06001967 RID: 6503 RVA: 0x000627A0 File Offset: 0x000609A0
		public static bool operator ==(TransformData lhs, TransformData rhs)
		{
			return lhs.rotate == rhs.rotate && lhs.scale == rhs.scale && lhs.transformOrigin == rhs.transformOrigin && lhs.translate == rhs.translate;
		}

		// Token: 0x06001968 RID: 6504 RVA: 0x00062800 File Offset: 0x00060A00
		public static bool operator !=(TransformData lhs, TransformData rhs)
		{
			return !(lhs == rhs);
		}

		// Token: 0x06001969 RID: 6505 RVA: 0x0006281C File Offset: 0x00060A1C
		public bool Equals(TransformData other)
		{
			return other == this;
		}

		// Token: 0x0600196A RID: 6506 RVA: 0x0006283C File Offset: 0x00060A3C
		public override bool Equals(object obj)
		{
			bool flag = obj == null;
			return !flag && obj is TransformData && this.Equals((TransformData)obj);
		}

		// Token: 0x0600196B RID: 6507 RVA: 0x00062874 File Offset: 0x00060A74
		public override int GetHashCode()
		{
			int num = this.rotate.GetHashCode();
			num = (num * 397 ^ this.scale.GetHashCode());
			num = (num * 397 ^ this.transformOrigin.GetHashCode());
			return num * 397 ^ this.translate.GetHashCode();
		}

		// Token: 0x04000AA6 RID: 2726
		public Rotate rotate;

		// Token: 0x04000AA7 RID: 2727
		public Scale scale;

		// Token: 0x04000AA8 RID: 2728
		public TransformOrigin transformOrigin;

		// Token: 0x04000AA9 RID: 2729
		public Translate translate;
	}
}
