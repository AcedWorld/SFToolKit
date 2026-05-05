using System;

namespace Unity.VisualScripting
{
	// Token: 0x0200006D RID: 109
	[UnitCategory("Events/GUI")]
	[UnitOrder(12)]
	public sealed class OnPointerDown : PointerEventUnit
	{
		// Token: 0x17000157 RID: 343
		// (get) Token: 0x060003C7 RID: 967 RVA: 0x000091BF File Offset: 0x000073BF
		public override Type MessageListenerType
		{
			get
			{
				return typeof(UnityOnPointerDownMessageListener);
			}
		}

		// Token: 0x17000158 RID: 344
		// (get) Token: 0x060003C8 RID: 968 RVA: 0x000091CB File Offset: 0x000073CB
		protected override string hookName
		{
			get
			{
				return "OnPointerDown";
			}
		}
	}
}
