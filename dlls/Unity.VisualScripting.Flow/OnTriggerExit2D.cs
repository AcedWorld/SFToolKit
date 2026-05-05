using System;

namespace Unity.VisualScripting
{
	// Token: 0x020000A3 RID: 163
	public sealed class OnTriggerExit2D : TriggerEvent2DUnit
	{
		// Token: 0x170001D4 RID: 468
		// (get) Token: 0x060004C3 RID: 1219 RVA: 0x0000A0E3 File Offset: 0x000082E3
		public override Type MessageListenerType
		{
			get
			{
				return typeof(UnityOnTriggerExit2DMessageListener);
			}
		}

		// Token: 0x170001D5 RID: 469
		// (get) Token: 0x060004C4 RID: 1220 RVA: 0x0000A0EF File Offset: 0x000082EF
		protected override string hookName
		{
			get
			{
				return "OnTriggerExit2D";
			}
		}
	}
}
