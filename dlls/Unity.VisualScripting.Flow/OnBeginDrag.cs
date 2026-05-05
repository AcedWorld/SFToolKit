using System;

namespace Unity.VisualScripting
{
	// Token: 0x02000060 RID: 96
	[UnitCategory("Events/GUI")]
	[TypeIcon(typeof(OnDrag))]
	[UnitOrder(16)]
	public sealed class OnBeginDrag : PointerEventUnit
	{
		// Token: 0x17000139 RID: 313
		// (get) Token: 0x0600038F RID: 911 RVA: 0x00008F39 File Offset: 0x00007139
		public override Type MessageListenerType
		{
			get
			{
				return typeof(UnityOnBeginDragMessageListener);
			}
		}

		// Token: 0x1700013A RID: 314
		// (get) Token: 0x06000390 RID: 912 RVA: 0x00008F45 File Offset: 0x00007145
		protected override string hookName
		{
			get
			{
				return "OnBeginDrag";
			}
		}
	}
}
