using System;

namespace UnityEngine.UIElements
{
	// Token: 0x020002BF RID: 703
	internal struct Spacing
	{
		// Token: 0x17000441 RID: 1089
		// (get) Token: 0x06001459 RID: 5209 RVA: 0x00048524 File Offset: 0x00046724
		public float horizontal
		{
			get
			{
				return this.left + this.right;
			}
		}

		// Token: 0x17000442 RID: 1090
		// (get) Token: 0x0600145A RID: 5210 RVA: 0x00048544 File Offset: 0x00046744
		public float vertical
		{
			get
			{
				return this.top + this.bottom;
			}
		}

		// Token: 0x0600145B RID: 5211 RVA: 0x00048563 File Offset: 0x00046763
		public Spacing(float left, float top, float right, float bottom)
		{
			this.left = left;
			this.top = top;
			this.right = right;
			this.bottom = bottom;
		}

		// Token: 0x0600145C RID: 5212 RVA: 0x00048584 File Offset: 0x00046784
		public static Rect operator +(Rect r, Spacing a)
		{
			r.x -= a.left;
			r.y -= a.top;
			r.width += a.horizontal;
			r.height += a.vertical;
			return r;
		}

		// Token: 0x0600145D RID: 5213 RVA: 0x000485F0 File Offset: 0x000467F0
		public static Rect operator -(Rect r, Spacing a)
		{
			r.x += a.left;
			r.y += a.top;
			r.width = Mathf.Max(0f, r.width - a.horizontal);
			r.height = Mathf.Max(0f, r.height - a.vertical);
			return r;
		}

		// Token: 0x04000976 RID: 2422
		public float left;

		// Token: 0x04000977 RID: 2423
		public float top;

		// Token: 0x04000978 RID: 2424
		public float right;

		// Token: 0x04000979 RID: 2425
		public float bottom;
	}
}
