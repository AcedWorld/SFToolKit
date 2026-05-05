using System;

namespace UnityEngine.Rendering
{
	// Token: 0x0200009B RID: 155
	[Serializable]
	public struct SphericalHarmonicsL1
	{
		// Token: 0x060004FC RID: 1276 RVA: 0x000187B8 File Offset: 0x000169B8
		public static SphericalHarmonicsL1 operator +(SphericalHarmonicsL1 lhs, SphericalHarmonicsL1 rhs)
		{
			return new SphericalHarmonicsL1
			{
				shAr = lhs.shAr + rhs.shAr,
				shAg = lhs.shAg + rhs.shAg,
				shAb = lhs.shAb + rhs.shAb
			};
		}

		// Token: 0x060004FD RID: 1277 RVA: 0x00018818 File Offset: 0x00016A18
		public static SphericalHarmonicsL1 operator -(SphericalHarmonicsL1 lhs, SphericalHarmonicsL1 rhs)
		{
			return new SphericalHarmonicsL1
			{
				shAr = lhs.shAr - rhs.shAr,
				shAg = lhs.shAg - rhs.shAg,
				shAb = lhs.shAb - rhs.shAb
			};
		}

		// Token: 0x060004FE RID: 1278 RVA: 0x00018878 File Offset: 0x00016A78
		public static SphericalHarmonicsL1 operator *(SphericalHarmonicsL1 lhs, float rhs)
		{
			return new SphericalHarmonicsL1
			{
				shAr = lhs.shAr * rhs,
				shAg = lhs.shAg * rhs,
				shAb = lhs.shAb * rhs
			};
		}

		// Token: 0x060004FF RID: 1279 RVA: 0x000188C8 File Offset: 0x00016AC8
		public static SphericalHarmonicsL1 operator /(SphericalHarmonicsL1 lhs, float rhs)
		{
			return new SphericalHarmonicsL1
			{
				shAr = lhs.shAr / rhs,
				shAg = lhs.shAg / rhs,
				shAb = lhs.shAb / rhs
			};
		}

		// Token: 0x06000500 RID: 1280 RVA: 0x00018917 File Offset: 0x00016B17
		public static bool operator ==(SphericalHarmonicsL1 lhs, SphericalHarmonicsL1 rhs)
		{
			return lhs.shAr == rhs.shAr && lhs.shAg == rhs.shAg && lhs.shAb == rhs.shAb;
		}

		// Token: 0x06000501 RID: 1281 RVA: 0x00018952 File Offset: 0x00016B52
		public static bool operator !=(SphericalHarmonicsL1 lhs, SphericalHarmonicsL1 rhs)
		{
			return !(lhs == rhs);
		}

		// Token: 0x06000502 RID: 1282 RVA: 0x0001895E File Offset: 0x00016B5E
		public override bool Equals(object other)
		{
			return other is SphericalHarmonicsL1 && this == (SphericalHarmonicsL1)other;
		}

		// Token: 0x06000503 RID: 1283 RVA: 0x0001897C File Offset: 0x00016B7C
		public override int GetHashCode()
		{
			return ((391 + this.shAr.GetHashCode()) * 23 + this.shAg.GetHashCode()) * 23 + this.shAb.GetHashCode();
		}

		// Token: 0x04000362 RID: 866
		public Vector4 shAr;

		// Token: 0x04000363 RID: 867
		public Vector4 shAg;

		// Token: 0x04000364 RID: 868
		public Vector4 shAb;

		// Token: 0x04000365 RID: 869
		public static readonly SphericalHarmonicsL1 zero = new SphericalHarmonicsL1
		{
			shAr = Vector4.zero,
			shAg = Vector4.zero,
			shAb = Vector4.zero
		};
	}
}
