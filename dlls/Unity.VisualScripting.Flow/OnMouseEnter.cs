using System;

namespace Unity.VisualScripting
{
	// Token: 0x02000082 RID: 130
	[UnitCategory("Events/Input")]
	public sealed class OnMouseEnter : GameObjectEventUnit<EmptyEventArgs>, IMouseEventUnit
	{
		// Token: 0x17000182 RID: 386
		// (get) Token: 0x0600041B RID: 1051 RVA: 0x000095F8 File Offset: 0x000077F8
		public override Type MessageListenerType
		{
			get
			{
				return typeof(UnityOnMouseEnterMessageListener);
			}
		}

		// Token: 0x17000183 RID: 387
		// (get) Token: 0x0600041C RID: 1052 RVA: 0x00009604 File Offset: 0x00007804
		protected override string hookName
		{
			get
			{
				return "OnMouseEnter";
			}
		}
	}
}
