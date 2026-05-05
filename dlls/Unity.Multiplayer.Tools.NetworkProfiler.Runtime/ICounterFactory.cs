using System;

namespace Unity.Multiplayer.Tools.NetworkProfiler.Runtime
{
	// Token: 0x02000007 RID: 7
	internal interface ICounterFactory
	{
		// Token: 0x0600000A RID: 10
		ICounter Construct(string name);
	}
}
