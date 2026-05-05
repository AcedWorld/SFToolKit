using System;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x020001DB RID: 475
	public struct XAsyncBlockPtr
	{
		// Token: 0x06000C1E RID: 3102 RVA: 0x000102C3 File Offset: 0x0000E4C3
		internal XAsyncBlockPtr(IntPtr intPtr)
		{
			this.IntPtr = intPtr;
		}

		// Token: 0x06000C1F RID: 3103 RVA: 0x000102CC File Offset: 0x0000E4CC
		public static implicit operator IntPtr(XAsyncBlockPtr ptr)
		{
			return ptr.IntPtr;
		}

		// Token: 0x06000C20 RID: 3104 RVA: 0x000102D4 File Offset: 0x0000E4D4
		public static implicit operator XAsyncBlockPtr(XAsyncBlock block)
		{
			return new XAsyncBlockPtr(block.InteropPtr);
		}

		// Token: 0x04000632 RID: 1586
		internal readonly IntPtr IntPtr;
	}
}
