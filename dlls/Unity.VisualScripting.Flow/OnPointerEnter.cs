using System;

namespace Unity.VisualScripting
{
	// Token: 0x0200006E RID: 110
	[UnitCategory("Events/GUI")]
	[UnitOrder(14)]
	public sealed class OnPointerEnter : PointerEventUnit
	{
		// Token: 0x17000159 RID: 345
		// (get) Token: 0x060003CA RID: 970 RVA: 0x000091DA File Offset: 0x000073DA
		public override Type MessageListenerType
		{
			get
			{
				return typeof(UnityOnPointerEnterMessageListener);
			}
		}

		// Token: 0x1700015A RID: 346
		// (get) Token: 0x060003CB RID: 971 RVA: 0x000091E6 File Offset: 0x000073E6
		protected override string hookName
		{
			get
			{
				return "OnPointerEnter";
			}
		}
	}
}
