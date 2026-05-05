using System;

namespace UnityEngine.Rendering
{
	// Token: 0x0200009C RID: 156
	public class SphericalHarmonicsL2Utils
	{
		// Token: 0x06000505 RID: 1285 RVA: 0x00018A0C File Offset: 0x00016C0C
		public static void GetL1(SphericalHarmonicsL2 sh, out Vector3 L1_R, out Vector3 L1_G, out Vector3 L1_B)
		{
			L1_R = new Vector3(sh[0, 1], sh[0, 2], sh[0, 3]);
			L1_G = new Vector3(sh[1, 1], sh[1, 2], sh[1, 3]);
			L1_B = new Vector3(sh[2, 1], sh[2, 2], sh[2, 3]);
		}

		// Token: 0x06000506 RID: 1286 RVA: 0x00018A8C File Offset: 0x00016C8C
		public static void GetL2(SphericalHarmonicsL2 sh, out Vector3 L2_0, out Vector3 L2_1, out Vector3 L2_2, out Vector3 L2_3, out Vector3 L2_4)
		{
			L2_0 = new Vector3(sh[0, 4], sh[1, 4], sh[2, 4]);
			L2_1 = new Vector3(sh[0, 5], sh[1, 5], sh[2, 5]);
			L2_2 = new Vector3(sh[0, 6], sh[1, 6], sh[2, 6]);
			L2_3 = new Vector3(sh[0, 7], sh[1, 7], sh[2, 7]);
			L2_4 = new Vector3(sh[0, 8], sh[1, 8], sh[2, 8]);
		}

		// Token: 0x06000507 RID: 1287 RVA: 0x00018B59 File Offset: 0x00016D59
		public static void SetL0(ref SphericalHarmonicsL2 sh, Vector3 L0)
		{
			sh[0, 0] = L0.x;
			sh[1, 0] = L0.y;
			sh[2, 0] = L0.z;
		}

		// Token: 0x06000508 RID: 1288 RVA: 0x00018B85 File Offset: 0x00016D85
		public static void SetL1R(ref SphericalHarmonicsL2 sh, Vector3 L1_R)
		{
			sh[0, 1] = L1_R.x;
			sh[0, 2] = L1_R.y;
			sh[0, 3] = L1_R.z;
		}

		// Token: 0x06000509 RID: 1289 RVA: 0x00018BB1 File Offset: 0x00016DB1
		public static void SetL1G(ref SphericalHarmonicsL2 sh, Vector3 L1_G)
		{
			sh[1, 1] = L1_G.x;
			sh[1, 2] = L1_G.y;
			sh[1, 3] = L1_G.z;
		}

		// Token: 0x0600050A RID: 1290 RVA: 0x00018BDD File Offset: 0x00016DDD
		public static void SetL1B(ref SphericalHarmonicsL2 sh, Vector3 L1_B)
		{
			sh[2, 1] = L1_B.x;
			sh[2, 2] = L1_B.y;
			sh[2, 3] = L1_B.z;
		}

		// Token: 0x0600050B RID: 1291 RVA: 0x00018C09 File Offset: 0x00016E09
		public static void SetL1(ref SphericalHarmonicsL2 sh, Vector3 L1_R, Vector3 L1_G, Vector3 L1_B)
		{
			SphericalHarmonicsL2Utils.SetL1R(ref sh, L1_R);
			SphericalHarmonicsL2Utils.SetL1G(ref sh, L1_G);
			SphericalHarmonicsL2Utils.SetL1B(ref sh, L1_B);
		}

		// Token: 0x0600050C RID: 1292 RVA: 0x00018C20 File Offset: 0x00016E20
		public static void SetCoefficient(ref SphericalHarmonicsL2 sh, int index, Vector3 coefficient)
		{
			sh[0, index] = coefficient.x;
			sh[1, index] = coefficient.y;
			sh[2, index] = coefficient.z;
		}

		// Token: 0x0600050D RID: 1293 RVA: 0x00018C4C File Offset: 0x00016E4C
		public static Vector3 GetCoefficient(SphericalHarmonicsL2 sh, int index)
		{
			return new Vector3(sh[0, index], sh[1, index], sh[2, index]);
		}
	}
}
