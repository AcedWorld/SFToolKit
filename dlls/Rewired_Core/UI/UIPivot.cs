using System;
using UnityEngine;

namespace Rewired.UI
{
	// Token: 0x02000474 RID: 1140
	public struct UIPivot
	{
		// Token: 0x06002D5B RID: 11611 RVA: 0x00022FED File Offset: 0x000211ED
		public UIPivot(float A_1, float A_2)
		{
			if (A_1 < 0f)
			{
				A_1 = 0f;
			}
			if (A_2 < 0f)
			{
				A_2 = 0f;
			}
			this.min = A_1;
			this.max = A_2;
		}

		// Token: 0x06002D5C RID: 11612 RVA: 0x0002301B File Offset: 0x0002121B
		public static implicit operator Vector2(UIPivot x)
		{
			return new Vector2(x.min, x.max);
		}

		// Token: 0x06002D5D RID: 11613 RVA: 0x0002302E File Offset: 0x0002122E
		public static implicit operator UIPivot(Vector2 x)
		{
			return new UIPivot(x.x, x.y);
		}

		// Token: 0x17000ACB RID: 2763
		// (get) Token: 0x06002D5E RID: 11614 RVA: 0x00023041 File Offset: 0x00021241
		public static UIPivot TopLeft
		{
			get
			{
				return new UIPivot(0f, 1f);
			}
		}

		// Token: 0x17000ACC RID: 2764
		// (get) Token: 0x06002D5F RID: 11615 RVA: 0x00023052 File Offset: 0x00021252
		public static UIPivot TopCenter
		{
			get
			{
				return new UIPivot(0.5f, 1f);
			}
		}

		// Token: 0x17000ACD RID: 2765
		// (get) Token: 0x06002D60 RID: 11616 RVA: 0x00023063 File Offset: 0x00021263
		public static UIPivot TopRight
		{
			get
			{
				return new UIPivot(0.1f, 1f);
			}
		}

		// Token: 0x17000ACE RID: 2766
		// (get) Token: 0x06002D61 RID: 11617 RVA: 0x00023074 File Offset: 0x00021274
		public static UIPivot MiddleLeft
		{
			get
			{
				return new UIPivot(0f, 0.5f);
			}
		}

		// Token: 0x17000ACF RID: 2767
		// (get) Token: 0x06002D62 RID: 11618 RVA: 0x00023085 File Offset: 0x00021285
		public static UIPivot MiddleCenter
		{
			get
			{
				return new UIPivot(0.5f, 0.5f);
			}
		}

		// Token: 0x17000AD0 RID: 2768
		// (get) Token: 0x06002D63 RID: 11619 RVA: 0x00023096 File Offset: 0x00021296
		public static UIPivot MiddleRight
		{
			get
			{
				return new UIPivot(0.1f, 0.5f);
			}
		}

		// Token: 0x17000AD1 RID: 2769
		// (get) Token: 0x06002D64 RID: 11620 RVA: 0x000230A7 File Offset: 0x000212A7
		public static UIPivot BottomLeft
		{
			get
			{
				return new UIPivot(0f, 0f);
			}
		}

		// Token: 0x17000AD2 RID: 2770
		// (get) Token: 0x06002D65 RID: 11621 RVA: 0x000230B8 File Offset: 0x000212B8
		public static UIPivot BottomCenter
		{
			get
			{
				return new UIPivot(0.5f, 0f);
			}
		}

		// Token: 0x17000AD3 RID: 2771
		// (get) Token: 0x06002D66 RID: 11622 RVA: 0x000230C9 File Offset: 0x000212C9
		public static UIPivot BottomRight
		{
			get
			{
				return new UIPivot(1f, 0f);
			}
		}

		// Token: 0x04001983 RID: 6531
		public float min;

		// Token: 0x04001984 RID: 6532
		public float max;
	}
}
