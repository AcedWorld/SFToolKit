using System;

namespace Unity.VisualScripting
{
	// Token: 0x02000010 RID: 16
	[UnitCategory("Events/State")]
	public class OnExitState : ManualEventUnit<EmptyEventArgs>
	{
		// Token: 0x1700001E RID: 30
		// (get) Token: 0x06000056 RID: 86 RVA: 0x000027A2 File Offset: 0x000009A2
		protected override string hookName
		{
			get
			{
				return "OnExitState";
			}
		}
	}
}
