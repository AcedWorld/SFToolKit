using System;

namespace Unity.VisualScripting
{
	// Token: 0x0200009A RID: 154
	public sealed class OnTriggerExit : TriggerEventUnit
	{
		// Token: 0x170001BA RID: 442
		// (get) Token: 0x0600048E RID: 1166 RVA: 0x00009D46 File Offset: 0x00007F46
		public override Type MessageListenerType
		{
			get
			{
				return typeof(UnityOnTriggerExitMessageListener);
			}
		}

		// Token: 0x170001BB RID: 443
		// (get) Token: 0x0600048F RID: 1167 RVA: 0x00009D52 File Offset: 0x00007F52
		protected override string hookName
		{
			get
			{
				return "OnTriggerExit";
			}
		}
	}
}
