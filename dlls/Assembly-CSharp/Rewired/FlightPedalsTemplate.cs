using System;

namespace Rewired
{
	// Token: 0x02000270 RID: 624
	public sealed class FlightPedalsTemplate : ControllerTemplate, IFlightPedalsTemplate, IControllerTemplate
	{
		// Token: 0x17000255 RID: 597
		// (get) Token: 0x06000BB3 RID: 2995 RVA: 0x0004398C File Offset: 0x00041B8C
		IControllerTemplateAxis IFlightPedalsTemplate.leftPedal
		{
			get
			{
				return base.GetElement<IControllerTemplateAxis>(0);
			}
		}

		// Token: 0x17000256 RID: 598
		// (get) Token: 0x06000BB4 RID: 2996 RVA: 0x00043995 File Offset: 0x00041B95
		IControllerTemplateAxis IFlightPedalsTemplate.rightPedal
		{
			get
			{
				return base.GetElement<IControllerTemplateAxis>(1);
			}
		}

		// Token: 0x17000257 RID: 599
		// (get) Token: 0x06000BB5 RID: 2997 RVA: 0x0004399E File Offset: 0x00041B9E
		IControllerTemplateAxis IFlightPedalsTemplate.slide
		{
			get
			{
				return base.GetElement<IControllerTemplateAxis>(2);
			}
		}

		// Token: 0x06000BB6 RID: 2998 RVA: 0x00043972 File Offset: 0x00041B72
		public FlightPedalsTemplate(object payload) : base(payload)
		{
		}

		// Token: 0x040011C2 RID: 4546
		public static readonly Guid typeGuid = new Guid("f6fe76f8-be2a-4db2-b853-9e3652075913");

		// Token: 0x040011C3 RID: 4547
		public const int elementId_leftPedal = 0;

		// Token: 0x040011C4 RID: 4548
		public const int elementId_rightPedal = 1;

		// Token: 0x040011C5 RID: 4549
		public const int elementId_slide = 2;
	}
}
