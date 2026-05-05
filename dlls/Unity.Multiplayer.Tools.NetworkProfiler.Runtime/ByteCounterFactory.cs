using System;
using Unity.Profiling;

namespace Unity.Multiplayer.Tools.NetworkProfiler.Runtime
{
	// Token: 0x02000003 RID: 3
	internal class ByteCounterFactory : ICounterFactory
	{
		// Token: 0x06000003 RID: 3 RVA: 0x000020C0 File Offset: 0x000002C0
		public ICounter Construct(string name)
		{
			return new CounterWrapper(new ProfilerCounter<long>(ProfilerCategory.Network, name, ProfilerMarkerDataUnit.Bytes));
		}
	}
}
