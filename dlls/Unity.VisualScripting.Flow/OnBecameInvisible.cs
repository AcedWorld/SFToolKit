using System;

namespace Unity.VisualScripting
{
	// Token: 0x020000A6 RID: 166
	[UnitCategory("Events/Rendering")]
	public sealed class OnBecameInvisible : GameObjectEventUnit<EmptyEventArgs>
	{
		// Token: 0x170001D9 RID: 473
		// (get) Token: 0x060004CE RID: 1230 RVA: 0x0000A15A File Offset: 0x0000835A
		public override Type MessageListenerType
		{
			get
			{
				return typeof(UnityOnBecameInvisibleMessageListener);
			}
		}

		// Token: 0x170001DA RID: 474
		// (get) Token: 0x060004CF RID: 1231 RVA: 0x0000A166 File Offset: 0x00008366
		protected override string hookName
		{
			get
			{
				return "OnBecameInvisible";
			}
		}
	}
}
