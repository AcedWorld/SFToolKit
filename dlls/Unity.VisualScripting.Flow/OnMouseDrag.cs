using System;

namespace Unity.VisualScripting
{
	// Token: 0x02000081 RID: 129
	[UnitCategory("Events/Input")]
	public sealed class OnMouseDrag : GameObjectEventUnit<EmptyEventArgs>, IMouseEventUnit
	{
		// Token: 0x17000180 RID: 384
		// (get) Token: 0x06000418 RID: 1048 RVA: 0x000095DD File Offset: 0x000077DD
		public override Type MessageListenerType
		{
			get
			{
				return typeof(UnityOnMouseDragMessageListener);
			}
		}

		// Token: 0x17000181 RID: 385
		// (get) Token: 0x06000419 RID: 1049 RVA: 0x000095E9 File Offset: 0x000077E9
		protected override string hookName
		{
			get
			{
				return "OnMouseDrag";
			}
		}
	}
}
