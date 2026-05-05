using System;

namespace Unity.Netcode
{
	// Token: 0x02000088 RID: 136
	public struct RpcSendParams
	{
		// Token: 0x06000305 RID: 773 RVA: 0x0000FEDC File Offset: 0x0000E0DC
		public static implicit operator RpcSendParams(BaseRpcTarget target)
		{
			return new RpcSendParams
			{
				Target = target
			};
		}

		// Token: 0x06000306 RID: 774 RVA: 0x0000FEFC File Offset: 0x0000E0FC
		public static implicit operator RpcSendParams(LocalDeferMode deferMode)
		{
			return new RpcSendParams
			{
				LocalDeferMode = deferMode
			};
		}

		// Token: 0x040001BA RID: 442
		public BaseRpcTarget Target;

		// Token: 0x040001BB RID: 443
		public LocalDeferMode LocalDeferMode;
	}
}
