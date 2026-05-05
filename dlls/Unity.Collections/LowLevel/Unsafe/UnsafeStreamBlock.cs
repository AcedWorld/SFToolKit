using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Unity.Collections.LowLevel.Unsafe
{
	// Token: 0x0200011D RID: 285
	[BurstCompatible]
	internal struct UnsafeStreamBlock
	{
		// Token: 0x040003AB RID: 939
		internal unsafe UnsafeStreamBlock* Next;

		// Token: 0x040003AC RID: 940
		[FixedBuffer(typeof(byte), 1)]
		internal UnsafeStreamBlock.<Data>e__FixedBuffer Data;

		// Token: 0x0200011E RID: 286
		[CompilerGenerated]
		[UnsafeValueType]
		[StructLayout(LayoutKind.Sequential, Size = 1)]
		public struct <Data>e__FixedBuffer
		{
			// Token: 0x040003AD RID: 941
			public byte FixedElementField;
		}
	}
}
