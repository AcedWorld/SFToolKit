using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x02000025 RID: 37
	public interface IVersionable<TVersion> where TVersion : struct, IConvertible
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x0600004F RID: 79
		// (set) Token: 0x06000050 RID: 80
		TVersion version { get; set; }
	}
}
