using System;

namespace Unity.VisualScripting
{
	// Token: 0x02000088 RID: 136
	[UnitCategory("Events/Lifecycle")]
	[UnitOrder(4)]
	[UnitTitle("On Fixed Update")]
	public sealed class FixedUpdate : MachineEventUnit<EmptyEventArgs>
	{
		// Token: 0x1700018F RID: 399
		// (get) Token: 0x06000432 RID: 1074 RVA: 0x00009733 File Offset: 0x00007933
		protected override string hookName
		{
			get
			{
				return "FixedUpdate";
			}
		}
	}
}
