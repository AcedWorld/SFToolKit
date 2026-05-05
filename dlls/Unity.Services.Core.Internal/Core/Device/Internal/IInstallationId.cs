using System;
using Unity.Services.Core.Internal;

namespace Unity.Services.Core.Device.Internal
{
	// Token: 0x02000021 RID: 33
	public interface IInstallationId : IServiceComponent
	{
		// Token: 0x0600005F RID: 95
		string GetOrCreateIdentifier();
	}
}
