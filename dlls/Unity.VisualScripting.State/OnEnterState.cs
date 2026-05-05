using System;

namespace Unity.VisualScripting
{
	// Token: 0x0200000F RID: 15
	[UnitCategory("Events/State")]
	public class OnEnterState : ManualEventUnit<EmptyEventArgs>
	{
		// Token: 0x1700001D RID: 29
		// (get) Token: 0x06000054 RID: 84 RVA: 0x00002793 File Offset: 0x00000993
		protected override string hookName
		{
			get
			{
				return "OnEnterState";
			}
		}
	}
}
