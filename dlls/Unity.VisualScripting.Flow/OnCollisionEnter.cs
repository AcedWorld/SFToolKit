using System;

namespace Unity.VisualScripting
{
	// Token: 0x02000093 RID: 147
	public sealed class OnCollisionEnter : CollisionEventUnit
	{
		// Token: 0x170001A2 RID: 418
		// (get) Token: 0x0600045F RID: 1119 RVA: 0x00009A14 File Offset: 0x00007C14
		public override Type MessageListenerType
		{
			get
			{
				return typeof(UnityOnCollisionEnterMessageListener);
			}
		}

		// Token: 0x170001A3 RID: 419
		// (get) Token: 0x06000460 RID: 1120 RVA: 0x00009A20 File Offset: 0x00007C20
		protected override string hookName
		{
			get
			{
				return "OnCollisionEnter";
			}
		}
	}
}
