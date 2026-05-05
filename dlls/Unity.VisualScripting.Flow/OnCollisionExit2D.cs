using System;

namespace Unity.VisualScripting
{
	// Token: 0x0200009F RID: 159
	public sealed class OnCollisionExit2D : CollisionEvent2DUnit
	{
		// Token: 0x170001C6 RID: 454
		// (get) Token: 0x060004A9 RID: 1193 RVA: 0x00009F0B File Offset: 0x0000810B
		public override Type MessageListenerType
		{
			get
			{
				return typeof(UnityOnCollisionExit2DMessageListener);
			}
		}

		// Token: 0x170001C7 RID: 455
		// (get) Token: 0x060004AA RID: 1194 RVA: 0x00009F17 File Offset: 0x00008117
		protected override string hookName
		{
			get
			{
				return "OnCollisionExit2D";
			}
		}
	}
}
