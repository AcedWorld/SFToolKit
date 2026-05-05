using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x020001F8 RID: 504
	internal struct XblMultiplayerInviteHandle
	{
		// Token: 0x06000DA3 RID: 3491 RVA: 0x000106F0 File Offset: 0x0000E8F0
		internal unsafe string GetData()
		{
			fixed (byte* ptr = &this.Data.FixedElementField)
			{
				return Converters.BytePointerToString(ptr, 40);
			}
		}

		// Token: 0x040006BF RID: 1727
		[FixedBuffer(typeof(byte), 40)]
		private XblMultiplayerInviteHandle.<Data>e__FixedBuffer Data;

		// Token: 0x02000332 RID: 818
		[CompilerGenerated]
		[UnsafeValueType]
		[StructLayout(LayoutKind.Sequential, Size = 40)]
		public struct <Data>e__FixedBuffer
		{
			// Token: 0x040009A9 RID: 2473
			public byte FixedElementField;
		}
	}
}
