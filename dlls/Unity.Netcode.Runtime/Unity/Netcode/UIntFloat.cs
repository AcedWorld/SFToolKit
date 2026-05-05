using System;
using System.Runtime.InteropServices;

namespace Unity.Netcode
{
	// Token: 0x0200010F RID: 271
	[StructLayout(LayoutKind.Explicit)]
	internal struct UIntFloat
	{
		// Token: 0x0400032A RID: 810
		[FieldOffset(0)]
		public float FloatValue;

		// Token: 0x0400032B RID: 811
		[FieldOffset(0)]
		public uint UIntValue;

		// Token: 0x0400032C RID: 812
		[FieldOffset(0)]
		public double DoubleValue;

		// Token: 0x0400032D RID: 813
		[FieldOffset(0)]
		public ulong ULongValue;
	}
}
