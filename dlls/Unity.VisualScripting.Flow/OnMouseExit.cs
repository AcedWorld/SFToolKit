using System;

namespace Unity.VisualScripting
{
	// Token: 0x02000083 RID: 131
	[UnitCategory("Events/Input")]
	public sealed class OnMouseExit : GameObjectEventUnit<EmptyEventArgs>, IMouseEventUnit
	{
		// Token: 0x17000184 RID: 388
		// (get) Token: 0x0600041E RID: 1054 RVA: 0x00009613 File Offset: 0x00007813
		public override Type MessageListenerType
		{
			get
			{
				return typeof(UnityOnMouseExitMessageListener);
			}
		}

		// Token: 0x17000185 RID: 389
		// (get) Token: 0x0600041F RID: 1055 RVA: 0x0000961F File Offset: 0x0000781F
		protected override string hookName
		{
			get
			{
				return "OnMouseExit";
			}
		}
	}
}
