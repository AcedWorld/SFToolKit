using System;

namespace Unity.VisualScripting
{
	// Token: 0x0200005A RID: 90
	[UnitCategory("Events/Editor")]
	public sealed class OnDrawGizmos : ManualEventUnit<EmptyEventArgs>
	{
		// Token: 0x1700012D RID: 301
		// (get) Token: 0x06000360 RID: 864 RVA: 0x00008A87 File Offset: 0x00006C87
		protected override string hookName
		{
			get
			{
				return "OnDrawGizmos";
			}
		}
	}
}
