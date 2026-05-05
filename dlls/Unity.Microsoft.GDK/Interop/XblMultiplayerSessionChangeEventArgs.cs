using System;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x020001FB RID: 507
	internal struct XblMultiplayerSessionChangeEventArgs
	{
		// Token: 0x06000DA4 RID: 3492 RVA: 0x00010714 File Offset: 0x0000E914
		internal unsafe string GetBranch()
		{
			byte[] branch;
			byte* bytePointer;
			if ((branch = this.Branch) == null || branch.Length == 0)
			{
				bytePointer = null;
			}
			else
			{
				bytePointer = &branch[0];
			}
			return Converters.BytePointerToString(bytePointer, 40);
		}

		// Token: 0x040006C5 RID: 1733
		internal XblMultiplayerSessionReference SessionReference;

		// Token: 0x040006C6 RID: 1734
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 40)]
		internal byte[] Branch;

		// Token: 0x040006C7 RID: 1735
		internal readonly ulong ChangeNumber;
	}
}
