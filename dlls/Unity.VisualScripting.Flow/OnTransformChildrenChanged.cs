using System;

namespace Unity.VisualScripting
{
	// Token: 0x02000079 RID: 121
	[UnitCategory("Events/Hierarchy")]
	public sealed class OnTransformChildrenChanged : GameObjectEventUnit<EmptyEventArgs>
	{
		// Token: 0x17000172 RID: 370
		// (get) Token: 0x060003FD RID: 1021 RVA: 0x00009421 File Offset: 0x00007621
		public override Type MessageListenerType
		{
			get
			{
				return typeof(UnityOnTransformChildrenChangedMessageListener);
			}
		}

		// Token: 0x17000173 RID: 371
		// (get) Token: 0x060003FE RID: 1022 RVA: 0x0000942D File Offset: 0x0000762D
		protected override string hookName
		{
			get
			{
				return "OnTransformChildrenChanged";
			}
		}
	}
}
