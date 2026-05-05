using System;

namespace Unity.VisualScripting
{
	// Token: 0x02000074 RID: 116
	[UnitCategory("Events/GUI")]
	[UnitOrder(22)]
	public sealed class OnSelect : GenericGuiEventUnit
	{
		// Token: 0x17000167 RID: 359
		// (get) Token: 0x060003E4 RID: 996 RVA: 0x000092F8 File Offset: 0x000074F8
		public override Type MessageListenerType
		{
			get
			{
				return typeof(UnityOnSelectMessageListener);
			}
		}

		// Token: 0x17000168 RID: 360
		// (get) Token: 0x060003E5 RID: 997 RVA: 0x00009304 File Offset: 0x00007504
		protected override string hookName
		{
			get
			{
				return "OnSelect";
			}
		}
	}
}
