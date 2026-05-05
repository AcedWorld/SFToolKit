using System;
using System.Threading;

namespace Unity.Collections
{
	// Token: 0x020000C2 RID: 194
	internal struct Spinner
	{
		// Token: 0x06000806 RID: 2054 RVA: 0x00018FD1 File Offset: 0x000171D1
		public void Lock()
		{
			while (Interlocked.CompareExchange(ref this.m_value, 1, 0) != 0)
			{
			}
			Interlocked.MemoryBarrier();
		}

		// Token: 0x06000807 RID: 2055 RVA: 0x00018FE7 File Offset: 0x000171E7
		public void Unlock()
		{
			Interlocked.MemoryBarrier();
			while (1 != Interlocked.CompareExchange(ref this.m_value, 0, 1))
			{
			}
		}

		// Token: 0x040002C2 RID: 706
		private int m_value;
	}
}
