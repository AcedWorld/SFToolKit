using System;

namespace Unity.VisualScripting
{
	// Token: 0x02000099 RID: 153
	public sealed class OnTriggerEnter : TriggerEventUnit
	{
		// Token: 0x170001B8 RID: 440
		// (get) Token: 0x0600048B RID: 1163 RVA: 0x00009D2B File Offset: 0x00007F2B
		public override Type MessageListenerType
		{
			get
			{
				return typeof(UnityOnTriggerEnterMessageListener);
			}
		}

		// Token: 0x170001B9 RID: 441
		// (get) Token: 0x0600048C RID: 1164 RVA: 0x00009D37 File Offset: 0x00007F37
		protected override string hookName
		{
			get
			{
				return "OnTriggerEnter";
			}
		}
	}
}
