using System;

namespace Unity.VisualScripting
{
	// Token: 0x0200006C RID: 108
	[UnitCategory("Events/GUI")]
	[UnitOrder(11)]
	public sealed class OnPointerClick : PointerEventUnit
	{
		// Token: 0x17000155 RID: 341
		// (get) Token: 0x060003C4 RID: 964 RVA: 0x000091A4 File Offset: 0x000073A4
		public override Type MessageListenerType
		{
			get
			{
				return typeof(UnityOnPointerClickMessageListener);
			}
		}

		// Token: 0x17000156 RID: 342
		// (get) Token: 0x060003C5 RID: 965 RVA: 0x000091B0 File Offset: 0x000073B0
		protected override string hookName
		{
			get
			{
				return "OnPointerClick";
			}
		}
	}
}
