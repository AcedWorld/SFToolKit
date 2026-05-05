using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x020001F6 RID: 502
	internal struct XblFormattedSecureDeviceAddress
	{
		// Token: 0x06000DA1 RID: 3489 RVA: 0x00010694 File Offset: 0x0000E894
		internal unsafe string GetValue()
		{
			fixed (byte* ptr = &this.value.FixedElementField)
			{
				return Converters.BytePointerToString(ptr, 4096);
			}
		}

		// Token: 0x040006B4 RID: 1716
		[FixedBuffer(typeof(byte), 4096)]
		private XblFormattedSecureDeviceAddress.<value>e__FixedBuffer value;

		// Token: 0x02000331 RID: 817
		[CompilerGenerated]
		[UnsafeValueType]
		[StructLayout(LayoutKind.Sequential, Size = 4096)]
		public struct <value>e__FixedBuffer
		{
			// Token: 0x040009A8 RID: 2472
			public byte FixedElementField;
		}
	}
}
