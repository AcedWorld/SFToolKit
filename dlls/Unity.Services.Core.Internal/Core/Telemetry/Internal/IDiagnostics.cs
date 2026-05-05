using System;
using System.Collections.Generic;

namespace Unity.Services.Core.Telemetry.Internal
{
	// Token: 0x02000013 RID: 19
	public interface IDiagnostics
	{
		// Token: 0x06000024 RID: 36
		void SendDiagnostic(string name, string message, IDictionary<string, string> tags = null);
	}
}
