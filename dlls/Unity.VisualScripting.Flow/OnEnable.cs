using System;

namespace Unity.VisualScripting
{
	// Token: 0x0200008C RID: 140
	[UnitCategory("Events/Lifecycle")]
	[UnitOrder(1)]
	public sealed class OnEnable : MachineEventUnit<EmptyEventArgs>
	{
		// Token: 0x17000193 RID: 403
		// (get) Token: 0x0600043C RID: 1084 RVA: 0x000097B3 File Offset: 0x000079B3
		protected override string hookName
		{
			get
			{
				return "OnEnable";
			}
		}
	}
}
