using System;

namespace Unity.VisualScripting
{
	// Token: 0x02000094 RID: 148
	public sealed class OnCollisionExit : CollisionEventUnit
	{
		// Token: 0x170001A4 RID: 420
		// (get) Token: 0x06000462 RID: 1122 RVA: 0x00009A2F File Offset: 0x00007C2F
		public override Type MessageListenerType
		{
			get
			{
				return typeof(UnityOnCollisionExitMessageListener);
			}
		}

		// Token: 0x170001A5 RID: 421
		// (get) Token: 0x06000463 RID: 1123 RVA: 0x00009A3B File Offset: 0x00007C3B
		protected override string hookName
		{
			get
			{
				return "OnCollisionExit";
			}
		}
	}
}
