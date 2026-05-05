using System;
using Unity.Profiling;

namespace Unity.Multiplayer.Tools.NetworkProfiler.Runtime
{
	// Token: 0x02000005 RID: 5
	internal class EventCounterFactory : ICounterFactory
	{
		// Token: 0x06000007 RID: 7 RVA: 0x000020EC File Offset: 0x000002EC
		public ICounter Construct(string name)
		{
			return new CounterWrapper(new ProfilerCounter<long>(ProfilerCategory.Network, name, ProfilerMarkerDataUnit.Count));
		}
	}
}
