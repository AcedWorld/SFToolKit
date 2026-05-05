using System;

namespace Unity.VisualScripting
{
	// Token: 0x0200005B RID: 91
	[UnitCategory("Events/Editor")]
	public sealed class OnDrawGizmosSelected : ManualEventUnit<EmptyEventArgs>
	{
		// Token: 0x1700012E RID: 302
		// (get) Token: 0x06000362 RID: 866 RVA: 0x00008A96 File Offset: 0x00006C96
		protected override string hookName
		{
			get
			{
				return "OnDrawGizmosSelected";
			}
		}
	}
}
