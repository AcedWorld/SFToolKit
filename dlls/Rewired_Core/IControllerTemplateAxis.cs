using System;

namespace Rewired
{
	// Token: 0x02000089 RID: 137
	public interface IControllerTemplateAxis : IControllerTemplateElement
	{
		// Token: 0x170001CF RID: 463
		// (get) Token: 0x060005D1 RID: 1489
		string positiveDescriptiveName { get; }

		// Token: 0x170001D0 RID: 464
		// (get) Token: 0x060005D2 RID: 1490
		string negativeDescriptiveName { get; }

		// Token: 0x060005D3 RID: 1491
		string GetDescriptiveName(AxisRange axisRange);

		// Token: 0x170001D1 RID: 465
		// (get) Token: 0x060005D4 RID: 1492
		float value { get; }

		// Token: 0x170001D2 RID: 466
		// (get) Token: 0x060005D5 RID: 1493
		float valuePrev { get; }

		// Token: 0x170001D3 RID: 467
		// (get) Token: 0x060005D6 RID: 1494
		IControllerTemplateAxisSource source { get; }

		// Token: 0x170001D4 RID: 468
		// (get) Token: 0x060005D7 RID: 1495
		IControllerTemplateButton AsButton { get; }
	}
}
