using System;
using Unity.Jobs;

namespace Unity.Collections
{
	// Token: 0x02000026 RID: 38
	public interface INativeDisposable : IDisposable
	{
		// Token: 0x060000C4 RID: 196
		JobHandle Dispose(JobHandle inputDeps);
	}
}
