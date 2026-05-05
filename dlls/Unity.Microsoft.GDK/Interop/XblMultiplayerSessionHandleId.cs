using System;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x020001FD RID: 509
	internal struct XblMultiplayerSessionHandleId
	{
		// Token: 0x06000DA5 RID: 3493 RVA: 0x00010748 File Offset: 0x0000E948
		internal unsafe string GetValue()
		{
			byte[] array;
			byte* bytePointer;
			if ((array = this.value) == null || array.Length == 0)
			{
				bytePointer = null;
			}
			else
			{
				bytePointer = &array[0];
			}
			return Converters.BytePointerToString(bytePointer, 40);
		}

		// Token: 0x040006C9 RID: 1737
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 40)]
		internal byte[] value;
	}
}
