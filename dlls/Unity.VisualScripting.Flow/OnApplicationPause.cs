using System;

namespace Unity.VisualScripting
{
	// Token: 0x02000054 RID: 84
	[UnitCategory("Events/Application")]
	public sealed class OnApplicationPause : GlobalEventUnit<EmptyEventArgs>
	{
		// Token: 0x17000123 RID: 291
		// (get) Token: 0x06000347 RID: 839 RVA: 0x000088E3 File Offset: 0x00006AE3
		protected override string hookName
		{
			get
			{
				return "OnApplicationPause";
			}
		}
	}
}
