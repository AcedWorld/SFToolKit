using System;

namespace Unity.VisualScripting
{
	// Token: 0x0200008D RID: 141
	[UnitCategory("Events/Lifecycle")]
	[UnitOrder(2)]
	[UnitTitle("On Start")]
	public sealed class Start : MachineEventUnit<EmptyEventArgs>
	{
		// Token: 0x17000194 RID: 404
		// (get) Token: 0x0600043E RID: 1086 RVA: 0x000097C2 File Offset: 0x000079C2
		protected override string hookName
		{
			get
			{
				return "Start";
			}
		}
	}
}
