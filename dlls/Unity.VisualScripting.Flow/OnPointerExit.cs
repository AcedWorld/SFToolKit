using System;

namespace Unity.VisualScripting
{
	// Token: 0x0200006F RID: 111
	[UnitCategory("Events/GUI")]
	[UnitOrder(15)]
	public sealed class OnPointerExit : PointerEventUnit
	{
		// Token: 0x1700015B RID: 347
		// (get) Token: 0x060003CD RID: 973 RVA: 0x000091F5 File Offset: 0x000073F5
		public override Type MessageListenerType
		{
			get
			{
				return typeof(UnityOnPointerExitMessageListener);
			}
		}

		// Token: 0x1700015C RID: 348
		// (get) Token: 0x060003CE RID: 974 RVA: 0x00009201 File Offset: 0x00007401
		protected override string hookName
		{
			get
			{
				return "OnPointerExit";
			}
		}
	}
}
