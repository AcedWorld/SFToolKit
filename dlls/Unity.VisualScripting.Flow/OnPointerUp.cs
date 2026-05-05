using System;

namespace Unity.VisualScripting
{
	// Token: 0x02000070 RID: 112
	[UnitCategory("Events/GUI")]
	[UnitOrder(13)]
	public sealed class OnPointerUp : PointerEventUnit
	{
		// Token: 0x1700015D RID: 349
		// (get) Token: 0x060003D0 RID: 976 RVA: 0x00009210 File Offset: 0x00007410
		public override Type MessageListenerType
		{
			get
			{
				return typeof(UnityOnPointerUpMessageListener);
			}
		}

		// Token: 0x1700015E RID: 350
		// (get) Token: 0x060003D1 RID: 977 RVA: 0x0000921C File Offset: 0x0000741C
		protected override string hookName
		{
			get
			{
				return "OnPointerUp";
			}
		}
	}
}
