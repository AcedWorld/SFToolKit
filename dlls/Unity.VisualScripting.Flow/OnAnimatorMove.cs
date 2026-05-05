using System;

namespace Unity.VisualScripting
{
	// Token: 0x02000051 RID: 81
	[UnitCategory("Events/Animation")]
	public sealed class OnAnimatorMove : GameObjectEventUnit<EmptyEventArgs>
	{
		// Token: 0x1700011F RID: 287
		// (get) Token: 0x06000340 RID: 832 RVA: 0x000088AA File Offset: 0x00006AAA
		public override Type MessageListenerType
		{
			get
			{
				return typeof(AnimatorMessageListener);
			}
		}

		// Token: 0x17000120 RID: 288
		// (get) Token: 0x06000341 RID: 833 RVA: 0x000088B6 File Offset: 0x00006AB6
		protected override string hookName
		{
			get
			{
				return "OnAnimatorMove";
			}
		}
	}
}
