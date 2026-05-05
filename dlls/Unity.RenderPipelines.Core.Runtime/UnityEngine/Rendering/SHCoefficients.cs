using System;

namespace UnityEngine.Rendering
{
	// Token: 0x020000C5 RID: 197
	[Serializable]
	public struct SHCoefficients : IEquatable<SHCoefficients>
	{
		// Token: 0x0600061E RID: 1566 RVA: 0x0001F06C File Offset: 0x0001D26C
		public SHCoefficients(SphericalHarmonicsL2 sh)
		{
			this.SHAr = SHCoefficients.GetSHA(sh, 0);
			this.SHAg = SHCoefficients.GetSHA(sh, 1);
			this.SHAb = SHCoefficients.GetSHA(sh, 2);
			this.SHBr = SHCoefficients.GetSHB(sh, 0);
			this.SHBg = SHCoefficients.GetSHB(sh, 1);
			this.SHBb = SHCoefficients.GetSHB(sh, 2);
			this.SHC = SHCoefficients.GetSHC(sh);
			this.ProbesOcclusion = Vector4.one;
		}

		// Token: 0x0600061F RID: 1567 RVA: 0x0001F0DE File Offset: 0x0001D2DE
		public SHCoefficients(SphericalHarmonicsL2 sh, Vector4 probesOcclusion)
		{
			this = new SHCoefficients(sh);
			this.ProbesOcclusion = probesOcclusion;
		}

		// Token: 0x06000620 RID: 1568 RVA: 0x0001F0EE File Offset: 0x0001D2EE
		private static Vector4 GetSHA(SphericalHarmonicsL2 sh, int i)
		{
			return new Vector4(sh[i, 3], sh[i, 1], sh[i, 2], sh[i, 0] - sh[i, 6]);
		}

		// Token: 0x06000621 RID: 1569 RVA: 0x0001F123 File Offset: 0x0001D323
		private static Vector4 GetSHB(SphericalHarmonicsL2 sh, int i)
		{
			return new Vector4(sh[i, 4], sh[i, 5], sh[i, 6] * 3f, sh[i, 7]);
		}

		// Token: 0x06000622 RID: 1570 RVA: 0x0001F154 File Offset: 0x0001D354
		private static Vector4 GetSHC(SphericalHarmonicsL2 sh)
		{
			return new Vector4(sh[0, 8], sh[1, 8], sh[2, 8], 1f);
		}

		// Token: 0x06000623 RID: 1571 RVA: 0x0001F17C File Offset: 0x0001D37C
		public bool Equals(SHCoefficients other)
		{
			return this.SHAr.Equals(other.SHAr) && this.SHAg.Equals(other.SHAg) && this.SHAb.Equals(other.SHAb) && this.SHBr.Equals(other.SHBr) && this.SHBg.Equals(other.SHBg) && this.SHBb.Equals(other.SHBb) && this.SHC.Equals(other.SHC) && this.ProbesOcclusion.Equals(other.ProbesOcclusion);
		}

		// Token: 0x06000624 RID: 1572 RVA: 0x0001F224 File Offset: 0x0001D424
		public override bool Equals(object obj)
		{
			if (obj is SHCoefficients)
			{
				SHCoefficients other = (SHCoefficients)obj;
				return this.Equals(other);
			}
			return false;
		}

		// Token: 0x06000625 RID: 1573 RVA: 0x0001F249 File Offset: 0x0001D449
		public override int GetHashCode()
		{
			return HashCode.Combine<Vector4, Vector4, Vector4, Vector4, Vector4, Vector4, Vector4, Vector4>(this.SHAr, this.SHAg, this.SHAb, this.SHBr, this.SHBg, this.SHBb, this.SHC, this.ProbesOcclusion);
		}

		// Token: 0x06000626 RID: 1574 RVA: 0x0001F280 File Offset: 0x0001D480
		public static bool operator ==(SHCoefficients left, SHCoefficients right)
		{
			return left.Equals(right);
		}

		// Token: 0x06000627 RID: 1575 RVA: 0x0001F28A File Offset: 0x0001D48A
		public static bool operator !=(SHCoefficients left, SHCoefficients right)
		{
			return !left.Equals(right);
		}

		// Token: 0x0400045E RID: 1118
		public Vector4 SHAr;

		// Token: 0x0400045F RID: 1119
		public Vector4 SHAg;

		// Token: 0x04000460 RID: 1120
		public Vector4 SHAb;

		// Token: 0x04000461 RID: 1121
		public Vector4 SHBr;

		// Token: 0x04000462 RID: 1122
		public Vector4 SHBg;

		// Token: 0x04000463 RID: 1123
		public Vector4 SHBb;

		// Token: 0x04000464 RID: 1124
		public Vector4 SHC;

		// Token: 0x04000465 RID: 1125
		public Vector4 ProbesOcclusion;
	}
}
