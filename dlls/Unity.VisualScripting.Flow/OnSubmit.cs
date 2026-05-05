using System;

namespace Unity.VisualScripting
{
	// Token: 0x02000076 RID: 118
	[UnitCategory("Events/GUI")]
	[UnitOrder(24)]
	public sealed class OnSubmit : GenericGuiEventUnit
	{
		// Token: 0x1700016C RID: 364
		// (get) Token: 0x060003EE RID: 1006 RVA: 0x0000936C File Offset: 0x0000756C
		public override Type MessageListenerType
		{
			get
			{
				return typeof(UnityOnSubmitMessageListener);
			}
		}

		// Token: 0x1700016D RID: 365
		// (get) Token: 0x060003EF RID: 1007 RVA: 0x00009378 File Offset: 0x00007578
		protected override string hookName
		{
			get
			{
				return "OnSubmit";
			}
		}
	}
}
