using System;

namespace Unity.Netcode
{
	// Token: 0x02000083 RID: 131
	[AttributeUsage(AttributeTargets.Method)]
	public class RpcAttribute : Attribute
	{
		// Token: 0x06000301 RID: 769 RVA: 0x00002050 File Offset: 0x00000250
		public RpcAttribute(SendTo target)
		{
		}

		// Token: 0x06000302 RID: 770 RVA: 0x00002050 File Offset: 0x00000250
		public RpcAttribute()
		{
		}

		// Token: 0x040001AD RID: 429
		public RpcDelivery Delivery;

		// Token: 0x040001AE RID: 430
		public bool RequireOwnership;

		// Token: 0x040001AF RID: 431
		public bool DeferLocal;

		// Token: 0x040001B0 RID: 432
		public bool AllowTargetOverride;

		// Token: 0x02000084 RID: 132
		public struct RpcAttributeParams
		{
			// Token: 0x040001B1 RID: 433
			public RpcDelivery Delivery;

			// Token: 0x040001B2 RID: 434
			public bool RequireOwnership;

			// Token: 0x040001B3 RID: 435
			public bool DeferLocal;

			// Token: 0x040001B4 RID: 436
			public bool AllowTargetOverride;
		}
	}
}
