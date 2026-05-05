using System;

namespace Unity.VisualScripting
{
	// Token: 0x02000063 RID: 99
	[UnitCategory("Events/GUI")]
	[UnitOrder(23)]
	public sealed class OnDeselect : GenericGuiEventUnit
	{
		// Token: 0x1700013F RID: 319
		// (get) Token: 0x06000398 RID: 920 RVA: 0x00008F8A File Offset: 0x0000718A
		public override Type MessageListenerType
		{
			get
			{
				return typeof(UnityOnDeselectMessageListener);
			}
		}

		// Token: 0x17000140 RID: 320
		// (get) Token: 0x06000399 RID: 921 RVA: 0x00008F96 File Offset: 0x00007196
		protected override string hookName
		{
			get
			{
				return "OnDeselect";
			}
		}
	}
}
