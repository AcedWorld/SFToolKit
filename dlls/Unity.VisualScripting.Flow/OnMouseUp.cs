using System;

namespace Unity.VisualScripting
{
	// Token: 0x02000086 RID: 134
	[UnitCategory("Events/Input")]
	public sealed class OnMouseUp : GameObjectEventUnit<EmptyEventArgs>, IMouseEventUnit
	{
		// Token: 0x1700018B RID: 395
		// (get) Token: 0x0600042C RID: 1068 RVA: 0x000096FD File Offset: 0x000078FD
		public override Type MessageListenerType
		{
			get
			{
				return typeof(UnityOnMouseUpMessageListener);
			}
		}

		// Token: 0x1700018C RID: 396
		// (get) Token: 0x0600042D RID: 1069 RVA: 0x00009709 File Offset: 0x00007909
		protected override string hookName
		{
			get
			{
				return "OnMouseUp";
			}
		}
	}
}
