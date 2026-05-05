using System;

namespace Unity.VisualScripting
{
	// Token: 0x02000064 RID: 100
	[UnitCategory("Events/GUI")]
	[UnitOrder(17)]
	public sealed class OnDrag : PointerEventUnit
	{
		// Token: 0x17000141 RID: 321
		// (get) Token: 0x0600039B RID: 923 RVA: 0x00008FA5 File Offset: 0x000071A5
		protected override string hookName
		{
			get
			{
				return "OnDrag";
			}
		}

		// Token: 0x17000142 RID: 322
		// (get) Token: 0x0600039C RID: 924 RVA: 0x00008FAC File Offset: 0x000071AC
		public override Type MessageListenerType
		{
			get
			{
				return typeof(UnityOnDragMessageListener);
			}
		}
	}
}
