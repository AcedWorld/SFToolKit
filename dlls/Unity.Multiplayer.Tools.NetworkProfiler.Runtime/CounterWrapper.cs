using System;
using Unity.Profiling;

namespace Unity.Multiplayer.Tools.NetworkProfiler.Runtime
{
	// Token: 0x02000004 RID: 4
	internal class CounterWrapper : ICounter
	{
		// Token: 0x06000005 RID: 5 RVA: 0x000020DB File Offset: 0x000002DB
		public CounterWrapper(ProfilerCounter<long> counter)
		{
			this.m_Counter = counter;
		}

		// Token: 0x06000006 RID: 6 RVA: 0x000020EA File Offset: 0x000002EA
		public void Sample(long inValue)
		{
		}

		// Token: 0x04000001 RID: 1
		private ProfilerCounter<long> m_Counter;
	}
}
