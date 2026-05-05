using System;

namespace Unity.VisualScripting
{
	// Token: 0x0200008B RID: 139
	[UnitCategory("Events/Lifecycle")]
	[UnitOrder(6)]
	public sealed class OnDisable : MachineEventUnit<EmptyEventArgs>
	{
		// Token: 0x17000192 RID: 402
		// (get) Token: 0x0600043A RID: 1082 RVA: 0x000097A4 File Offset: 0x000079A4
		protected override string hookName
		{
			get
			{
				return "OnDisable";
			}
		}
	}
}
