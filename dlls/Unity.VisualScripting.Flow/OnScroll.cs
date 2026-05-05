using System;

namespace Unity.VisualScripting
{
	// Token: 0x02000071 RID: 113
	[UnitCategory("Events/GUI")]
	[UnitOrder(20)]
	public sealed class OnScroll : PointerEventUnit
	{
		// Token: 0x1700015F RID: 351
		// (get) Token: 0x060003D3 RID: 979 RVA: 0x0000922B File Offset: 0x0000742B
		public override Type MessageListenerType
		{
			get
			{
				return typeof(UnityOnScrollMessageListener);
			}
		}

		// Token: 0x17000160 RID: 352
		// (get) Token: 0x060003D4 RID: 980 RVA: 0x00009237 File Offset: 0x00007437
		protected override string hookName
		{
			get
			{
				return "OnScroll";
			}
		}
	}
}
