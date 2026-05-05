using System;

namespace Unity.VisualScripting
{
	// Token: 0x02000067 RID: 103
	[UnitCategory("Events/GUI")]
	[TypeIcon(typeof(OnDrag))]
	[UnitOrder(18)]
	public sealed class OnEndDrag : PointerEventUnit
	{
		// Token: 0x17000149 RID: 329
		// (get) Token: 0x060003AA RID: 938 RVA: 0x0000907E File Offset: 0x0000727E
		public override Type MessageListenerType
		{
			get
			{
				return typeof(UnityOnEndDragMessageListener);
			}
		}

		// Token: 0x1700014A RID: 330
		// (get) Token: 0x060003AB RID: 939 RVA: 0x0000908A File Offset: 0x0000728A
		protected override string hookName
		{
			get
			{
				return "OnEndDrag";
			}
		}
	}
}
