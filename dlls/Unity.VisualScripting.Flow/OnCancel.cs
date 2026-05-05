using System;

namespace Unity.VisualScripting
{
	// Token: 0x02000062 RID: 98
	[UnitCategory("Events/GUI")]
	[UnitOrder(25)]
	public sealed class OnCancel : GenericGuiEventUnit
	{
		// Token: 0x1700013D RID: 317
		// (get) Token: 0x06000395 RID: 917 RVA: 0x00008F6F File Offset: 0x0000716F
		public override Type MessageListenerType
		{
			get
			{
				return typeof(UnityOnCancelMessageListener);
			}
		}

		// Token: 0x1700013E RID: 318
		// (get) Token: 0x06000396 RID: 918 RVA: 0x00008F7B File Offset: 0x0000717B
		protected override string hookName
		{
			get
			{
				return "OnCancel";
			}
		}
	}
}
