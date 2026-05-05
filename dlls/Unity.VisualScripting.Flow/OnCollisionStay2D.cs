using System;

namespace Unity.VisualScripting
{
	// Token: 0x020000A0 RID: 160
	public sealed class OnCollisionStay2D : CollisionEvent2DUnit
	{
		// Token: 0x170001C8 RID: 456
		// (get) Token: 0x060004AC RID: 1196 RVA: 0x00009F26 File Offset: 0x00008126
		public override Type MessageListenerType
		{
			get
			{
				return typeof(UnityOnCollisionStay2DMessageListener);
			}
		}

		// Token: 0x170001C9 RID: 457
		// (get) Token: 0x060004AD RID: 1197 RVA: 0x00009F32 File Offset: 0x00008132
		protected override string hookName
		{
			get
			{
				return "OnCollisionStay2D";
			}
		}
	}
}
