using System;

namespace Unity.VisualScripting
{
	// Token: 0x020000A4 RID: 164
	public sealed class OnTriggerStay2D : TriggerEvent2DUnit
	{
		// Token: 0x170001D6 RID: 470
		// (get) Token: 0x060004C6 RID: 1222 RVA: 0x0000A0FE File Offset: 0x000082FE
		public override Type MessageListenerType
		{
			get
			{
				return typeof(UnityOnTriggerStay2DMessageListener);
			}
		}

		// Token: 0x170001D7 RID: 471
		// (get) Token: 0x060004C7 RID: 1223 RVA: 0x0000A10A File Offset: 0x0000830A
		protected override string hookName
		{
			get
			{
				return "OnTriggerStay2D";
			}
		}
	}
}
