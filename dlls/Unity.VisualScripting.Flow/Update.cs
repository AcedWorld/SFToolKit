using System;

namespace Unity.VisualScripting
{
	// Token: 0x0200008E RID: 142
	[UnitCategory("Events/Lifecycle")]
	[UnitOrder(3)]
	[UnitTitle("On Update")]
	public sealed class Update : MachineEventUnit<EmptyEventArgs>
	{
		// Token: 0x17000195 RID: 405
		// (get) Token: 0x06000440 RID: 1088 RVA: 0x000097D1 File Offset: 0x000079D1
		protected override string hookName
		{
			get
			{
				return "Update";
			}
		}
	}
}
