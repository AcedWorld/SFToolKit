using System;
using UnityEngine;

namespace Rewired.Utils.Classes.Data
{
	// Token: 0x02000518 RID: 1304
	[Serializable]
	public struct ScreenRect
	{
		// Token: 0x060035B5 RID: 13749 RVA: 0x00029FFE File Offset: 0x000281FE
		public ScreenRect(float A_1, float A_2, float A_3, float A_4)
		{
			this.xMin = A_1;
			this.yMin = A_2;
			this.width = A_3;
			this.height = A_4;
		}

		// Token: 0x17000C07 RID: 3079
		// (get) Token: 0x060035B6 RID: 13750 RVA: 0x0002A01D File Offset: 0x0002821D
		// (set) Token: 0x060035B7 RID: 13751 RVA: 0x0002A02C File Offset: 0x0002822C
		public float xMax
		{
			get
			{
				return this.xMin + this.width;
			}
			set
			{
				this.width = value - this.xMin;
			}
		}

		// Token: 0x17000C08 RID: 3080
		// (get) Token: 0x060035B8 RID: 13752 RVA: 0x0002A03C File Offset: 0x0002823C
		// (set) Token: 0x060035B9 RID: 13753 RVA: 0x0002A04B File Offset: 0x0002824B
		public float yMax
		{
			get
			{
				return this.yMin + this.height;
			}
			set
			{
				this.height = value - this.yMin;
			}
		}

		// Token: 0x17000C09 RID: 3081
		// (get) Token: 0x060035BA RID: 13754 RVA: 0x0002A05B File Offset: 0x0002825B
		public Vector2 center
		{
			get
			{
				return new Vector2(this.xMin + 0.5f * this.width, this.yMin + 0.5f * this.height);
			}
		}

		// Token: 0x060035BB RID: 13755 RVA: 0x000B5D6C File Offset: 0x000B3F6C
		public override string ToString()
		{
			return string.Format("xMin: {0}, yMin: {1}, width: {2}, height: {3}", new object[]
			{
				this.xMin,
				this.xMax,
				this.width,
				this.height
			});
		}

		// Token: 0x060035BC RID: 13756 RVA: 0x0002A088 File Offset: 0x00028288
		public static implicit operator Rect(ScreenRect o)
		{
			return new Rect(o.xMin, o.yMax, o.width, o.height);
		}

		// Token: 0x060035BD RID: 13757 RVA: 0x0002A0A8 File Offset: 0x000282A8
		public static implicit operator ScreenRect(Rect o)
		{
			return new ScreenRect(o.xMin, o.yMax, o.width, o.height);
		}

		// Token: 0x04001C62 RID: 7266
		public float xMin;

		// Token: 0x04001C63 RID: 7267
		public float yMin;

		// Token: 0x04001C64 RID: 7268
		public float width;

		// Token: 0x04001C65 RID: 7269
		public float height;
	}
}
