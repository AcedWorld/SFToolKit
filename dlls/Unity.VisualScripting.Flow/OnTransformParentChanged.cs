using System;

namespace Unity.VisualScripting
{
	// Token: 0x0200007A RID: 122
	[UnitCategory("Events/Hierarchy")]
	public sealed class OnTransformParentChanged : GameObjectEventUnit<EmptyEventArgs>
	{
		// Token: 0x17000174 RID: 372
		// (get) Token: 0x06000400 RID: 1024 RVA: 0x0000943C File Offset: 0x0000763C
		public override Type MessageListenerType
		{
			get
			{
				return typeof(UnityOnTransformParentChangedMessageListener);
			}
		}

		// Token: 0x17000175 RID: 373
		// (get) Token: 0x06000401 RID: 1025 RVA: 0x00009448 File Offset: 0x00007648
		protected override string hookName
		{
			get
			{
				return "OnTransformParentChanged";
			}
		}
	}
}
