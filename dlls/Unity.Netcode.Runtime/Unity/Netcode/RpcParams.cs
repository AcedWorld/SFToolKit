using System;

namespace Unity.Netcode
{
	// Token: 0x0200008A RID: 138
	public struct RpcParams
	{
		// Token: 0x06000307 RID: 775 RVA: 0x0000FF1C File Offset: 0x0000E11C
		public static implicit operator RpcParams(RpcSendParams send)
		{
			return new RpcParams
			{
				Send = send
			};
		}

		// Token: 0x06000308 RID: 776 RVA: 0x0000FF3C File Offset: 0x0000E13C
		public static implicit operator RpcParams(BaseRpcTarget target)
		{
			return new RpcParams
			{
				Send = new RpcSendParams
				{
					Target = target
				}
			};
		}

		// Token: 0x06000309 RID: 777 RVA: 0x0000FF6C File Offset: 0x0000E16C
		public static implicit operator RpcParams(LocalDeferMode deferMode)
		{
			return new RpcParams
			{
				Send = new RpcSendParams
				{
					LocalDeferMode = deferMode
				}
			};
		}

		// Token: 0x0600030A RID: 778 RVA: 0x0000FF9C File Offset: 0x0000E19C
		public static implicit operator RpcParams(RpcReceiveParams receive)
		{
			return new RpcParams
			{
				Receive = receive
			};
		}

		// Token: 0x040001BD RID: 445
		public RpcSendParams Send;

		// Token: 0x040001BE RID: 446
		public RpcReceiveParams Receive;
	}
}
