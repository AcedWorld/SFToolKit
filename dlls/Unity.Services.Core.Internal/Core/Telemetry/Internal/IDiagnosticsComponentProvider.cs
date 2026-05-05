using System;
using System.Threading.Tasks;

namespace Unity.Services.Core.Telemetry.Internal
{
	// Token: 0x02000014 RID: 20
	internal interface IDiagnosticsComponentProvider
	{
		// Token: 0x06000025 RID: 37
		Task<IDiagnosticsFactory> CreateDiagnosticsComponents();

		// Token: 0x06000026 RID: 38
		Task<string> GetSerializedProjectConfigurationAsync();
	}
}
