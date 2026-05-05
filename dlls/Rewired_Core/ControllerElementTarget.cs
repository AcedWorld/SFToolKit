using System;

namespace Rewired
{
	// Token: 0x02000081 RID: 129
	public struct ControllerElementTarget
	{
		// Token: 0x06000594 RID: 1428 RVA: 0x0003A054 File Offset: 0x00038254
		public ControllerElementTarget(ActionElementMap A_1)
		{
			if (A_1 == null)
			{
				throw new ArgumentNullException("actionElementMap");
			}
			if (A_1.NNDdFGwfHOMtmloXpknTohmlGIGT != null)
			{
				Controller controller = ReInput.JVYgltGRcvVxyHxDFcTYdYskrSmBb.YCdAacShUnGEqBEtkCPIWZicyHmg(A_1.NNDdFGwfHOMtmloXpknTohmlGIGT.controllerType, A_1.NNDdFGwfHOMtmloXpknTohmlGIGT.controllerId, false);
				this.DYvhCLJvIhXlmPnwfrgeMDbEQpKB = controller.GetElementById(A_1._elementIdentifierId);
			}
			else
			{
				this.DYvhCLJvIhXlmPnwfrgeMDbEQpKB = null;
			}
			this.LYEIDHmHrQRzuzTwrDtPVOGOKXdp = A_1._axisRange;
		}

		// Token: 0x06000595 RID: 1429 RVA: 0x00006F96 File Offset: 0x00005196
		public ControllerElementTarget(ControllerElementTarget A_1)
		{
			this.DYvhCLJvIhXlmPnwfrgeMDbEQpKB = A_1.DYvhCLJvIhXlmPnwfrgeMDbEQpKB;
			this.LYEIDHmHrQRzuzTwrDtPVOGOKXdp = A_1.LYEIDHmHrQRzuzTwrDtPVOGOKXdp;
		}

		// Token: 0x06000596 RID: 1430 RVA: 0x00006FB0 File Offset: 0x000051B0
		public ControllerElementTarget(IControllerElementTarget A_1)
		{
			if (A_1 == null)
			{
				throw new ArgumentNullException("other");
			}
			this.DYvhCLJvIhXlmPnwfrgeMDbEQpKB = A_1.element;
			this.LYEIDHmHrQRzuzTwrDtPVOGOKXdp = A_1.axisRange;
		}

		// Token: 0x170001AC RID: 428
		// (get) Token: 0x06000597 RID: 1431 RVA: 0x00006FD8 File Offset: 0x000051D8
		public int elementIdentifierId
		{
			get
			{
				if (this.DYvhCLJvIhXlmPnwfrgeMDbEQpKB == null)
				{
					return -1;
				}
				return this.DYvhCLJvIhXlmPnwfrgeMDbEQpKB.id;
			}
		}

		// Token: 0x170001AD RID: 429
		// (get) Token: 0x06000598 RID: 1432 RVA: 0x00006FEF File Offset: 0x000051EF
		// (set) Token: 0x06000599 RID: 1433 RVA: 0x00006FF7 File Offset: 0x000051F7
		public AxisRange axisRange
		{
			get
			{
				return this.LYEIDHmHrQRzuzTwrDtPVOGOKXdp;
			}
			set
			{
				this.LYEIDHmHrQRzuzTwrDtPVOGOKXdp = value;
			}
		}

		// Token: 0x170001AE RID: 430
		// (get) Token: 0x0600059A RID: 1434 RVA: 0x00007000 File Offset: 0x00005200
		public bool hasTarget
		{
			get
			{
				return this.DYvhCLJvIhXlmPnwfrgeMDbEQpKB != null;
			}
		}

		// Token: 0x170001AF RID: 431
		// (get) Token: 0x0600059B RID: 1435 RVA: 0x0000700B File Offset: 0x0000520B
		public ControllerElementType elementType
		{
			get
			{
				if (this.DYvhCLJvIhXlmPnwfrgeMDbEQpKB == null)
				{
					return ControllerElementType.Axis;
				}
				return this.DYvhCLJvIhXlmPnwfrgeMDbEQpKB.type;
			}
		}

		// Token: 0x170001B0 RID: 432
		// (get) Token: 0x0600059C RID: 1436 RVA: 0x0003A0C0 File Offset: 0x000382C0
		public string descriptiveName
		{
			get
			{
				if (this.DYvhCLJvIhXlmPnwfrgeMDbEQpKB == null)
				{
					return string.Empty;
				}
				ControllerElementIdentifier elementIdentifier = this.DYvhCLJvIhXlmPnwfrgeMDbEQpKB.elementIdentifier;
				if (elementIdentifier == null)
				{
					return string.Empty;
				}
				return elementIdentifier.GetDisplayName(this.DYvhCLJvIhXlmPnwfrgeMDbEQpKB.type, this.LYEIDHmHrQRzuzTwrDtPVOGOKXdp);
			}
		}

		// Token: 0x170001B1 RID: 433
		// (get) Token: 0x0600059D RID: 1437 RVA: 0x00007022 File Offset: 0x00005222
		public Controller controller
		{
			get
			{
				if (this.DYvhCLJvIhXlmPnwfrgeMDbEQpKB == null)
				{
					return null;
				}
				return this.DYvhCLJvIhXlmPnwfrgeMDbEQpKB.LKHdGzaUtOjlAXoGCxNOPVjCeYNe;
			}
		}

		// Token: 0x170001B2 RID: 434
		// (get) Token: 0x0600059E RID: 1438 RVA: 0x00007039 File Offset: 0x00005239
		// (set) Token: 0x0600059F RID: 1439 RVA: 0x00007041 File Offset: 0x00005241
		public Controller.Element element
		{
			get
			{
				return this.DYvhCLJvIhXlmPnwfrgeMDbEQpKB;
			}
			set
			{
				this.DYvhCLJvIhXlmPnwfrgeMDbEQpKB = value;
			}
		}

		// Token: 0x060005A0 RID: 1440 RVA: 0x0003A108 File Offset: 0x00038308
		public static implicit operator ControllerElementTarget(ActionElementMap actionElementMap)
		{
			if (actionElementMap == null)
			{
				return default(ControllerElementTarget);
			}
			return new ControllerElementTarget(actionElementMap);
		}

		// Token: 0x040003A7 RID: 935
		private Controller.Element DYvhCLJvIhXlmPnwfrgeMDbEQpKB;

		// Token: 0x040003A8 RID: 936
		private AxisRange LYEIDHmHrQRzuzTwrDtPVOGOKXdp;
	}
}
