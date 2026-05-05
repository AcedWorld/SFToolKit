using System;

namespace Unity.VisualScripting
{
	// Token: 0x02000089 RID: 137
	[UnitCategory("Events/Lifecycle")]
	[UnitOrder(5)]
	[UnitTitle("On Late Update")]
	public sealed class LateUpdate : MachineEventUnit<EmptyEventArgs>
	{
		// Token: 0x17000190 RID: 400
		// (get) Token: 0x06000434 RID: 1076 RVA: 0x00009742 File Offset: 0x00007942
		protected override string hookName
		{
			get
			{
				return "LateUpdate";
			}
		}
	}
}
