using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x02000218 RID: 536
	public struct WaterSpectrumParameters
	{
		// Token: 0x06000FBB RID: 4027 RVA: 0x0007A0C0 File Offset: 0x000782C0
		public static bool operator ==(WaterSpectrumParameters a, WaterSpectrumParameters b)
		{
			return a.numActiveBands == b.numActiveBands && a.patchSizes == b.patchSizes && a.patchWindSpeed == b.patchWindSpeed && a.patchWindDirDampener == b.patchWindDirDampener && a.patchWindOrientation == b.patchWindOrientation;
		}

		// Token: 0x06000FBC RID: 4028 RVA: 0x0007A128 File Offset: 0x00078328
		public static bool operator !=(WaterSpectrumParameters a, WaterSpectrumParameters b)
		{
			return a.numActiveBands != b.numActiveBands || a.patchSizes != b.patchSizes || a.patchWindSpeed != b.patchWindSpeed || a.patchWindDirDampener != b.patchWindDirDampener || a.patchWindOrientation != b.patchWindOrientation;
		}

		// Token: 0x06000FBD RID: 4029 RVA: 0x0007A18F File Offset: 0x0007838F
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		// Token: 0x06000FBE RID: 4030 RVA: 0x0007A1A4 File Offset: 0x000783A4
		public override bool Equals(object o)
		{
			if (o is WaterSpectrumParameters)
			{
				WaterSpectrumParameters b = (WaterSpectrumParameters)o;
				return this == b;
			}
			return false;
		}

		// Token: 0x0400184A RID: 6218
		internal int numActiveBands;

		// Token: 0x0400184B RID: 6219
		internal Vector4 patchSizes;

		// Token: 0x0400184C RID: 6220
		internal Vector4 patchWindSpeed;

		// Token: 0x0400184D RID: 6221
		internal Vector4 patchWindDirDampener;

		// Token: 0x0400184E RID: 6222
		internal Vector4 patchWindOrientation;
	}
}
