using System;
using System.Collections.Generic;
using Unity.Services.Core.Internal;

namespace Unity.Services.Core.Telemetry.Internal
{
	// Token: 0x02000015 RID: 21
	public interface IDiagnosticsFactory : IServiceComponent
	{
		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000027 RID: 39
		IReadOnlyDictionary<string, string> CommonTags { get; }

		// Token: 0x06000028 RID: 40
		IDiagnostics Create(string packageName);
	}
}
