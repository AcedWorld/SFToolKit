using System;

namespace Unity.VisualScripting
{
	// Token: 0x02000095 RID: 149
	public sealed class OnCollisionStay : CollisionEventUnit
	{
		// Token: 0x170001A6 RID: 422
		// (get) Token: 0x06000465 RID: 1125 RVA: 0x00009A4A File Offset: 0x00007C4A
		public override Type MessageListenerType
		{
			get
			{
				return typeof(UnityOnCollisionStayMessageListener);
			}
		}

		// Token: 0x170001A7 RID: 423
		// (get) Token: 0x06000466 RID: 1126 RVA: 0x00009A56 File Offset: 0x00007C56
		protected override string hookName
		{
			get
			{
				return "OnCollisionStay";
			}
		}
	}
}
