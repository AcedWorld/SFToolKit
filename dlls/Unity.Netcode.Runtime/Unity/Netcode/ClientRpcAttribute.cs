using System;

namespace Unity.Netcode
{
	// Token: 0x02000086 RID: 134
	[AttributeUsage(AttributeTargets.Method)]
	public class ClientRpcAttribute : RpcAttribute
	{
		// Token: 0x06000304 RID: 772 RVA: 0x0000FED2 File Offset: 0x0000E0D2
		public ClientRpcAttribute() : base(SendTo.NotServer)
		{
		}
	}
}
