using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x02000151 RID: 337
	internal struct AccelerationStructureSize
	{
		// Token: 0x06000AE3 RID: 2787 RVA: 0x0005AE9C File Offset: 0x0005909C
		public override bool Equals(object obj)
		{
			if (obj != null && obj is AccelerationStructureSize)
			{
				AccelerationStructureSize accelerationStructureSize = (AccelerationStructureSize)obj;
				return this.memUsage == accelerationStructureSize.memUsage && this.instCount == accelerationStructureSize.instCount;
			}
			return false;
		}

		// Token: 0x06000AE4 RID: 2788 RVA: 0x0005AEDD File Offset: 0x000590DD
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		// Token: 0x06000AE5 RID: 2789 RVA: 0x0005AEEF File Offset: 0x000590EF
		public static bool operator ==(AccelerationStructureSize lhs, AccelerationStructureSize rhs)
		{
			return lhs.Equals(rhs);
		}

		// Token: 0x06000AE6 RID: 2790 RVA: 0x0005AF04 File Offset: 0x00059104
		public static bool operator !=(AccelerationStructureSize lhs, AccelerationStructureSize rhs)
		{
			return !(lhs == rhs);
		}

		// Token: 0x04000C1B RID: 3099
		public ulong memUsage;

		// Token: 0x04000C1C RID: 3100
		public uint instCount;
	}
}
