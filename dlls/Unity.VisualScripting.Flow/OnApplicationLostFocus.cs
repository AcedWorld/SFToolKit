using System;

namespace Unity.VisualScripting
{
	// Token: 0x02000053 RID: 83
	[UnitCategory("Events/Application")]
	public sealed class OnApplicationLostFocus : GlobalEventUnit<EmptyEventArgs>
	{
		// Token: 0x17000122 RID: 290
		// (get) Token: 0x06000345 RID: 837 RVA: 0x000088D4 File Offset: 0x00006AD4
		protected override string hookName
		{
			get
			{
				return "OnApplicationLostFocus";
			}
		}
	}
}
