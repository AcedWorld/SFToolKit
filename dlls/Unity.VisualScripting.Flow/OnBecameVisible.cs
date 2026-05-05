using System;

namespace Unity.VisualScripting
{
	// Token: 0x020000A7 RID: 167
	[UnitCategory("Events/Rendering")]
	public sealed class OnBecameVisible : GameObjectEventUnit<EmptyEventArgs>
	{
		// Token: 0x170001DB RID: 475
		// (get) Token: 0x060004D1 RID: 1233 RVA: 0x0000A175 File Offset: 0x00008375
		public override Type MessageListenerType
		{
			get
			{
				return typeof(UnityOnBecameVisibleMessageListener);
			}
		}

		// Token: 0x170001DC RID: 476
		// (get) Token: 0x060004D2 RID: 1234 RVA: 0x0000A181 File Offset: 0x00008381
		protected override string hookName
		{
			get
			{
				return "OnBecameVisible";
			}
		}
	}
}
