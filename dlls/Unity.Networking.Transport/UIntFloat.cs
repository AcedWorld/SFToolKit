using System;
using System.Runtime.InteropServices;

namespace Unity.Networking.Transport
{
	// Token: 0x02000010 RID: 16
	[StructLayout(LayoutKind.Explicit)]
	internal struct UIntFloat
	{
		// Token: 0x0400002F RID: 47
		[FieldOffset(0)]
		public float floatValue;

		// Token: 0x04000030 RID: 48
		[FieldOffset(0)]
		public uint intValue;

		// Token: 0x04000031 RID: 49
		[FieldOffset(0)]
		public double doubleValue;

		// Token: 0x04000032 RID: 50
		[FieldOffset(0)]
		public ulong longValue;
	}
}
