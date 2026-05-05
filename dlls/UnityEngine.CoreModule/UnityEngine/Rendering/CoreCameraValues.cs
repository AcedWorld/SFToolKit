using System;
using UnityEngine.Scripting;

namespace UnityEngine.Rendering
{
	// Token: 0x0200044A RID: 1098
	[UsedByNativeCode]
	internal struct CoreCameraValues : IEquatable<CoreCameraValues>
	{
		// Token: 0x060024D6 RID: 9430 RVA: 0x0003DF08 File Offset: 0x0003C108
		public bool Equals(CoreCameraValues other)
		{
			return this.filterMode == other.filterMode && this.cullingMask == other.cullingMask && this.instanceID == other.instanceID;
		}

		// Token: 0x060024D7 RID: 9431 RVA: 0x0003DF48 File Offset: 0x0003C148
		public override bool Equals(object obj)
		{
			bool flag = obj == null;
			return !flag && obj is CoreCameraValues && this.Equals((CoreCameraValues)obj);
		}

		// Token: 0x060024D8 RID: 9432 RVA: 0x0003DF80 File Offset: 0x0003C180
		public override int GetHashCode()
		{
			int num = this.filterMode;
			num = (num * 397 ^ (int)this.cullingMask);
			return num * 397 ^ this.instanceID;
		}

		// Token: 0x060024D9 RID: 9433 RVA: 0x0003DFBC File Offset: 0x0003C1BC
		public static bool operator ==(CoreCameraValues left, CoreCameraValues right)
		{
			return left.Equals(right);
		}

		// Token: 0x060024DA RID: 9434 RVA: 0x0003DFD8 File Offset: 0x0003C1D8
		public static bool operator !=(CoreCameraValues left, CoreCameraValues right)
		{
			return !left.Equals(right);
		}

		// Token: 0x04000DAE RID: 3502
		private int filterMode;

		// Token: 0x04000DAF RID: 3503
		private uint cullingMask;

		// Token: 0x04000DB0 RID: 3504
		private int instanceID;
	}
}
