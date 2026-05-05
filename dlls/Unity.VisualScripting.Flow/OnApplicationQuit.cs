using System;

namespace Unity.VisualScripting
{
	// Token: 0x02000055 RID: 85
	[UnitCategory("Events/Application")]
	public sealed class OnApplicationQuit : GlobalEventUnit<EmptyEventArgs>
	{
		// Token: 0x17000124 RID: 292
		// (get) Token: 0x06000349 RID: 841 RVA: 0x000088F2 File Offset: 0x00006AF2
		protected override string hookName
		{
			get
			{
				return "OnApplicationQuit";
			}
		}
	}
}
