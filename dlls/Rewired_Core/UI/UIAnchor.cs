using System;
using UnityEngine;

namespace Rewired.UI
{
	// Token: 0x02000473 RID: 1139
	public struct UIAnchor
	{
		// Token: 0x06002D49 RID: 11593 RVA: 0x0009FD38 File Offset: 0x0009DF38
		public UIAnchor(float A_1, float A_2, float A_3, float A_4)
		{
			if (A_1 < 0f)
			{
				A_1 = 0f;
			}
			if (A_2 < 0f)
			{
				A_2 = 0f;
			}
			if (A_3 < 0f)
			{
				A_3 = 0f;
			}
			if (A_4 < 0f)
			{
				A_4 = 0f;
			}
			this.min = new Vector2(A_1, A_2);
			this.max = new Vector2(A_3, A_4);
		}

		// Token: 0x06002D4A RID: 11594 RVA: 0x0009FDA0 File Offset: 0x0009DFA0
		public UIAnchor(Vector2 A_1, Vector2 A_2)
		{
			if (A_1.x < 0f)
			{
				A_1.x = 0f;
			}
			if (A_1.y < 0f)
			{
				A_1.y = 0f;
			}
			if (A_2.x < 0f)
			{
				A_2.x = 0f;
			}
			if (A_2.y < 0f)
			{
				A_2.y = 0f;
			}
			this.min = A_1;
			this.max = A_2;
		}

		// Token: 0x17000ABB RID: 2747
		// (get) Token: 0x06002D4B RID: 11595 RVA: 0x00022E3D File Offset: 0x0002103D
		public static UIAnchor TopLeft
		{
			get
			{
				return new UIAnchor(0f, 1f, 0f, 1f);
			}
		}

		// Token: 0x17000ABC RID: 2748
		// (get) Token: 0x06002D4C RID: 11596 RVA: 0x00022E58 File Offset: 0x00021058
		public static UIAnchor TopCenter
		{
			get
			{
				return new UIAnchor(0.5f, 1f, 0.5f, 1f);
			}
		}

		// Token: 0x17000ABD RID: 2749
		// (get) Token: 0x06002D4D RID: 11597 RVA: 0x00022E73 File Offset: 0x00021073
		public static UIAnchor TopRight
		{
			get
			{
				return new UIAnchor(1f, 1f, 1f, 1f);
			}
		}

		// Token: 0x17000ABE RID: 2750
		// (get) Token: 0x06002D4E RID: 11598 RVA: 0x00022E8E File Offset: 0x0002108E
		public static UIAnchor MiddleLeft
		{
			get
			{
				return new UIAnchor(0f, 0.5f, 0f, 0.5f);
			}
		}

		// Token: 0x17000ABF RID: 2751
		// (get) Token: 0x06002D4F RID: 11599 RVA: 0x00022EA9 File Offset: 0x000210A9
		public static UIAnchor MiddleCenter
		{
			get
			{
				return new UIAnchor(0.5f, 0.5f, 0.5f, 0.5f);
			}
		}

		// Token: 0x17000AC0 RID: 2752
		// (get) Token: 0x06002D50 RID: 11600 RVA: 0x00022EC4 File Offset: 0x000210C4
		public static UIAnchor MiddleRight
		{
			get
			{
				return new UIAnchor(1f, 0.5f, 1f, 0.5f);
			}
		}

		// Token: 0x17000AC1 RID: 2753
		// (get) Token: 0x06002D51 RID: 11601 RVA: 0x00022EDF File Offset: 0x000210DF
		public static UIAnchor BottomLeft
		{
			get
			{
				return new UIAnchor(0f, 0f, 0f, 0f);
			}
		}

		// Token: 0x17000AC2 RID: 2754
		// (get) Token: 0x06002D52 RID: 11602 RVA: 0x00022EFA File Offset: 0x000210FA
		public static UIAnchor BottomCenter
		{
			get
			{
				return new UIAnchor(0.5f, 0f, 0.5f, 0f);
			}
		}

		// Token: 0x17000AC3 RID: 2755
		// (get) Token: 0x06002D53 RID: 11603 RVA: 0x00022F15 File Offset: 0x00021115
		public static UIAnchor BottomRight
		{
			get
			{
				return new UIAnchor(1f, 0f, 1f, 0f);
			}
		}

		// Token: 0x17000AC4 RID: 2756
		// (get) Token: 0x06002D54 RID: 11604 RVA: 0x00022F30 File Offset: 0x00021130
		public static UIAnchor TopHStretch
		{
			get
			{
				return new UIAnchor(0f, 1f, 1f, 1f);
			}
		}

		// Token: 0x17000AC5 RID: 2757
		// (get) Token: 0x06002D55 RID: 11605 RVA: 0x00022F4B File Offset: 0x0002114B
		public static UIAnchor MiddleHStretch
		{
			get
			{
				return new UIAnchor(0f, 0.5f, 1f, 0.5f);
			}
		}

		// Token: 0x17000AC6 RID: 2758
		// (get) Token: 0x06002D56 RID: 11606 RVA: 0x00022F66 File Offset: 0x00021166
		public static UIAnchor BottomHStretch
		{
			get
			{
				return new UIAnchor(0f, 0f, 1f, 0f);
			}
		}

		// Token: 0x17000AC7 RID: 2759
		// (get) Token: 0x06002D57 RID: 11607 RVA: 0x00022F81 File Offset: 0x00021181
		public static UIAnchor LeftVStretch
		{
			get
			{
				return new UIAnchor(0f, 0f, 0f, 1f);
			}
		}

		// Token: 0x17000AC8 RID: 2760
		// (get) Token: 0x06002D58 RID: 11608 RVA: 0x00022F9C File Offset: 0x0002119C
		public static UIAnchor CenterVStretch
		{
			get
			{
				return new UIAnchor(0.5f, 0f, 0.5f, 1f);
			}
		}

		// Token: 0x17000AC9 RID: 2761
		// (get) Token: 0x06002D59 RID: 11609 RVA: 0x00022FB7 File Offset: 0x000211B7
		public static UIAnchor RightVStretch
		{
			get
			{
				return new UIAnchor(1f, 0f, 1f, 1f);
			}
		}

		// Token: 0x17000ACA RID: 2762
		// (get) Token: 0x06002D5A RID: 11610 RVA: 0x00022FD2 File Offset: 0x000211D2
		public static UIAnchor Stretch
		{
			get
			{
				return new UIAnchor(0f, 0f, 1f, 1f);
			}
		}

		// Token: 0x04001981 RID: 6529
		public Vector2 min;

		// Token: 0x04001982 RID: 6530
		public Vector2 max;
	}
}
