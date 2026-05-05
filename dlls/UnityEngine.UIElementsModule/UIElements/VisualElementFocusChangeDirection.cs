using System;

namespace UnityEngine.UIElements
{
	// Token: 0x02000402 RID: 1026
	public class VisualElementFocusChangeDirection : FocusChangeDirection
	{
		// Token: 0x170007A1 RID: 1953
		// (get) Token: 0x060020DE RID: 8414 RVA: 0x0007C484 File Offset: 0x0007A684
		public static FocusChangeDirection left
		{
			get
			{
				return VisualElementFocusChangeDirection.s_Left;
			}
		}

		// Token: 0x170007A2 RID: 1954
		// (get) Token: 0x060020DF RID: 8415 RVA: 0x0007C48B File Offset: 0x0007A68B
		public static FocusChangeDirection right
		{
			get
			{
				return VisualElementFocusChangeDirection.s_Right;
			}
		}

		// Token: 0x170007A3 RID: 1955
		// (get) Token: 0x060020E0 RID: 8416 RVA: 0x0007C494 File Offset: 0x0007A694
		protected new static VisualElementFocusChangeDirection lastValue
		{
			get
			{
				return VisualElementFocusChangeDirection.s_Right;
			}
		}

		// Token: 0x060020E1 RID: 8417 RVA: 0x0003CC01 File Offset: 0x0003AE01
		protected VisualElementFocusChangeDirection(int value) : base(value)
		{
		}

		// Token: 0x04000DE7 RID: 3559
		private static readonly VisualElementFocusChangeDirection s_Left = new VisualElementFocusChangeDirection(FocusChangeDirection.lastValue + 1);

		// Token: 0x04000DE8 RID: 3560
		private static readonly VisualElementFocusChangeDirection s_Right = new VisualElementFocusChangeDirection(FocusChangeDirection.lastValue + 2);
	}
}
