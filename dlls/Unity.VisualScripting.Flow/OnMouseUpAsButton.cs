using System;

namespace Unity.VisualScripting
{
	// Token: 0x02000087 RID: 135
	[UnitCategory("Events/Input")]
	public sealed class OnMouseUpAsButton : GameObjectEventUnit<EmptyEventArgs>, IMouseEventUnit
	{
		// Token: 0x1700018D RID: 397
		// (get) Token: 0x0600042F RID: 1071 RVA: 0x00009718 File Offset: 0x00007918
		public override Type MessageListenerType
		{
			get
			{
				return typeof(UnityOnMouseUpAsButtonMessageListener);
			}
		}

		// Token: 0x1700018E RID: 398
		// (get) Token: 0x06000430 RID: 1072 RVA: 0x00009724 File Offset: 0x00007924
		protected override string hookName
		{
			get
			{
				return "OnMouseUpAsButton";
			}
		}
	}
}
