using System;
using Unity.Services.Core;

namespace Unity.Services.Wire.Internal
{
	// Token: 0x02000027 RID: 39
	public class ConnectionFailedException : RequestFailedException
	{
		// Token: 0x060000A3 RID: 163 RVA: 0x00003B22 File Offset: 0x00001D22
		public ConnectionFailedException(string reason) : base(23003, "Connection failed: " + reason + ".")
		{
		}
	}
}
