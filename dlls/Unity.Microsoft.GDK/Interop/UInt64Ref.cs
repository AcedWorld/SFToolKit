using System;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x020001C9 RID: 457
	[StructLayout(LayoutKind.Sequential)]
	internal class UInt64Ref
	{
		// Token: 0x06000AA5 RID: 2725 RVA: 0x0001012F File Offset: 0x0000E32F
		internal UInt64Ref(ulong value)
		{
			this.Value = value;
		}

		// Token: 0x040005F1 RID: 1521
		internal readonly ulong Value;
	}
}
