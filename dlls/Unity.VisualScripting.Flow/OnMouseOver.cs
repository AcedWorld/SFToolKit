using System;

namespace Unity.VisualScripting
{
	// Token: 0x02000085 RID: 133
	[UnitCategory("Events/Input")]
	public sealed class OnMouseOver : GameObjectEventUnit<EmptyEventArgs>, IMouseEventUnit
	{
		// Token: 0x17000189 RID: 393
		// (get) Token: 0x06000429 RID: 1065 RVA: 0x000096E2 File Offset: 0x000078E2
		public override Type MessageListenerType
		{
			get
			{
				return typeof(UnityOnMouseOverMessageListener);
			}
		}

		// Token: 0x1700018A RID: 394
		// (get) Token: 0x0600042A RID: 1066 RVA: 0x000096EE File Offset: 0x000078EE
		protected override string hookName
		{
			get
			{
				return "OnMouseOver";
			}
		}
	}
}
