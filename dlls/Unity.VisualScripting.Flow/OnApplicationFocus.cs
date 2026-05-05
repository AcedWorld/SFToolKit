using System;

namespace Unity.VisualScripting
{
	// Token: 0x02000052 RID: 82
	[UnitCategory("Events/Application")]
	public sealed class OnApplicationFocus : GlobalEventUnit<EmptyEventArgs>
	{
		// Token: 0x17000121 RID: 289
		// (get) Token: 0x06000343 RID: 835 RVA: 0x000088C5 File Offset: 0x00006AC5
		protected override string hookName
		{
			get
			{
				return "OnApplicationFocus";
			}
		}
	}
}
