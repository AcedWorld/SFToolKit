using System;

namespace Unity.VisualScripting
{
	// Token: 0x0200002C RID: 44
	public interface IConnection<out TSource, out TDestination>
	{
		// Token: 0x1700004E RID: 78
		// (get) Token: 0x060001A4 RID: 420
		TSource source { get; }

		// Token: 0x1700004F RID: 79
		// (get) Token: 0x060001A5 RID: 421
		TDestination destination { get; }
	}
}
