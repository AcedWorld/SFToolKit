using System;

namespace Unity.VisualScripting
{
	// Token: 0x02000065 RID: 101
	[UnitCategory("Events/GUI")]
	[TypeIcon(typeof(OnDrag))]
	[UnitOrder(19)]
	public sealed class OnDrop : PointerEventUnit
	{
		// Token: 0x17000143 RID: 323
		// (get) Token: 0x0600039E RID: 926 RVA: 0x00008FC0 File Offset: 0x000071C0
		public override Type MessageListenerType
		{
			get
			{
				return typeof(UnityOnDropMessageListener);
			}
		}

		// Token: 0x17000144 RID: 324
		// (get) Token: 0x0600039F RID: 927 RVA: 0x00008FCC File Offset: 0x000071CC
		protected override string hookName
		{
			get
			{
				return "OnDrop";
			}
		}
	}
}
