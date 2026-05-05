using System;

namespace Unity.Netcode
{
	// Token: 0x02000085 RID: 133
	[AttributeUsage(AttributeTargets.Method)]
	public class ServerRpcAttribute : RpcAttribute
	{
		// Token: 0x06000303 RID: 771 RVA: 0x0000FEC9 File Offset: 0x0000E0C9
		public ServerRpcAttribute() : base(SendTo.Server)
		{
		}

		// Token: 0x040001B5 RID: 437
		public new bool RequireOwnership;
	}
}
