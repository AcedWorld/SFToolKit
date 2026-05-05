using System;

namespace Unity.VisualScripting
{
	// Token: 0x0200009B RID: 155
	public sealed class OnTriggerStay : TriggerEventUnit
	{
		// Token: 0x170001BC RID: 444
		// (get) Token: 0x06000491 RID: 1169 RVA: 0x00009D61 File Offset: 0x00007F61
		public override Type MessageListenerType
		{
			get
			{
				return typeof(UnityOnTriggerStayMessageListener);
			}
		}

		// Token: 0x170001BD RID: 445
		// (get) Token: 0x06000492 RID: 1170 RVA: 0x00009D6D File Offset: 0x00007F6D
		protected override string hookName
		{
			get
			{
				return "OnTriggerStay";
			}
		}
	}
}
