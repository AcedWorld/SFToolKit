using System;

namespace Unity.VisualScripting
{
	// Token: 0x02000080 RID: 128
	[UnitCategory("Events/Input")]
	public sealed class OnMouseDown : GameObjectEventUnit<EmptyEventArgs>, IMouseEventUnit
	{
		// Token: 0x1700017E RID: 382
		// (get) Token: 0x06000415 RID: 1045 RVA: 0x000095C2 File Offset: 0x000077C2
		protected override string hookName
		{
			get
			{
				return "OnMouseDown";
			}
		}

		// Token: 0x1700017F RID: 383
		// (get) Token: 0x06000416 RID: 1046 RVA: 0x000095C9 File Offset: 0x000077C9
		public override Type MessageListenerType
		{
			get
			{
				return typeof(UnityOnMouseDownMessageListener);
			}
		}
	}
}
