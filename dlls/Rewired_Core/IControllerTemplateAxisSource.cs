using System;

namespace Rewired
{
	// Token: 0x02000092 RID: 146
	public interface IControllerTemplateAxisSource : IControllerTemplateElementSource
	{
		// Token: 0x17000203 RID: 515
		// (get) Token: 0x06000606 RID: 1542
		bool splitAxis { get; }

		// Token: 0x17000204 RID: 516
		// (get) Token: 0x06000607 RID: 1543
		IControllerElementTarget fullTarget { get; }

		// Token: 0x17000205 RID: 517
		// (get) Token: 0x06000608 RID: 1544
		IControllerElementTarget positiveTarget { get; }

		// Token: 0x17000206 RID: 518
		// (get) Token: 0x06000609 RID: 1545
		IControllerElementTarget negativeTarget { get; }
	}
}
