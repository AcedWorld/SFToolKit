using System;

namespace Unity.VisualScripting
{
	// Token: 0x020000A2 RID: 162
	public sealed class OnTriggerEnter2D : TriggerEvent2DUnit
	{
		// Token: 0x170001D2 RID: 466
		// (get) Token: 0x060004C0 RID: 1216 RVA: 0x0000A0C8 File Offset: 0x000082C8
		public override Type MessageListenerType
		{
			get
			{
				return typeof(UnityOnTriggerEnter2DMessageListener);
			}
		}

		// Token: 0x170001D3 RID: 467
		// (get) Token: 0x060004C1 RID: 1217 RVA: 0x0000A0D4 File Offset: 0x000082D4
		protected override string hookName
		{
			get
			{
				return "OnTriggerEnter2D";
			}
		}
	}
}
