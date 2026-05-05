using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000185 RID: 389
	public static class Packsize
	{
		// Token: 0x060008D6 RID: 2262 RVA: 0x0000D4BC File Offset: 0x0000B6BC
		public static bool Test()
		{
			int num = Marshal.SizeOf(typeof(Packsize.ValvePackingSentinel_t));
			int num2 = Marshal.SizeOf(typeof(RemoteStorageEnumerateUserSubscribedFilesResult_t));
			return num == 32 && num2 == 616;
		}

		// Token: 0x04000A0A RID: 2570
		public const int value = 8;

		// Token: 0x020001E7 RID: 487
		[StructLayout(LayoutKind.Sequential, Pack = 8)]
		private struct ValvePackingSentinel_t
		{
			// Token: 0x04000AD5 RID: 2773
			private uint m_u32;

			// Token: 0x04000AD6 RID: 2774
			private ulong m_u64;

			// Token: 0x04000AD7 RID: 2775
			private ushort m_u16;

			// Token: 0x04000AD8 RID: 2776
			private double m_d;
		}
	}
}
