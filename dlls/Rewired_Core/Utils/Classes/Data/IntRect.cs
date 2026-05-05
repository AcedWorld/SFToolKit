using System;

namespace Rewired.Utils.Classes.Data
{
	// Token: 0x0200050E RID: 1294
	[Serializable]
	public class IntRect
	{
		// Token: 0x17000BF8 RID: 3064
		// (get) Token: 0x060034F4 RID: 13556 RVA: 0x000291B9 File Offset: 0x000273B9
		// (set) Token: 0x060034F5 RID: 13557 RVA: 0x000291C1 File Offset: 0x000273C1
		public int yMin
		{
			get
			{
				return this.y;
			}
			set
			{
				this.y = value;
			}
		}

		// Token: 0x17000BF9 RID: 3065
		// (get) Token: 0x060034F6 RID: 13558 RVA: 0x000291CA File Offset: 0x000273CA
		// (set) Token: 0x060034F7 RID: 13559 RVA: 0x000291DB File Offset: 0x000273DB
		public int yMax
		{
			get
			{
				return this.y + this.height - 1;
			}
			set
			{
				this.height = value - 1;
			}
		}

		// Token: 0x17000BFA RID: 3066
		// (get) Token: 0x060034F8 RID: 13560 RVA: 0x000291E6 File Offset: 0x000273E6
		// (set) Token: 0x060034F9 RID: 13561 RVA: 0x000291EE File Offset: 0x000273EE
		public int xMin
		{
			get
			{
				return this.x;
			}
			set
			{
				this.x = value;
			}
		}

		// Token: 0x17000BFB RID: 3067
		// (get) Token: 0x060034FA RID: 13562 RVA: 0x000291F7 File Offset: 0x000273F7
		// (set) Token: 0x060034FB RID: 13563 RVA: 0x00029208 File Offset: 0x00027408
		public int xMax
		{
			get
			{
				return this.x + this.width - 1;
			}
			set
			{
				this.width = value - 1;
			}
		}

		// Token: 0x17000BFC RID: 3068
		// (get) Token: 0x060034FC RID: 13564 RVA: 0x000291B9 File Offset: 0x000273B9
		// (set) Token: 0x060034FD RID: 13565 RVA: 0x000291C1 File Offset: 0x000273C1
		public int top
		{
			get
			{
				return this.y;
			}
			set
			{
				this.y = value;
			}
		}

		// Token: 0x17000BFD RID: 3069
		// (get) Token: 0x060034FE RID: 13566 RVA: 0x000291CA File Offset: 0x000273CA
		// (set) Token: 0x060034FF RID: 13567 RVA: 0x000291DB File Offset: 0x000273DB
		public int bottom
		{
			get
			{
				return this.y + this.height - 1;
			}
			set
			{
				this.height = value - 1;
			}
		}

		// Token: 0x17000BFE RID: 3070
		// (get) Token: 0x06003500 RID: 13568 RVA: 0x000291E6 File Offset: 0x000273E6
		// (set) Token: 0x06003501 RID: 13569 RVA: 0x000291EE File Offset: 0x000273EE
		public int left
		{
			get
			{
				return this.x;
			}
			set
			{
				this.x = value;
			}
		}

		// Token: 0x17000BFF RID: 3071
		// (get) Token: 0x06003502 RID: 13570 RVA: 0x000291F7 File Offset: 0x000273F7
		// (set) Token: 0x06003503 RID: 13571 RVA: 0x00029208 File Offset: 0x00027408
		public int right
		{
			get
			{
				return this.x + this.width - 1;
			}
			set
			{
				this.width = value - 1;
			}
		}

		// Token: 0x06003504 RID: 13572 RVA: 0x000033F4 File Offset: 0x000015F4
		public IntRect()
		{
		}

		// Token: 0x06003505 RID: 13573 RVA: 0x00029213 File Offset: 0x00027413
		public IntRect(int A_1, int A_2, int A_3, int A_4)
		{
			this.x = A_1;
			this.y = A_2;
			this.width = A_3;
			this.height = A_4;
		}

		// Token: 0x06003506 RID: 13574 RVA: 0x00029238 File Offset: 0x00027438
		public IntRect Clone()
		{
			return new IntRect(this.x, this.y, this.width, this.height);
		}

		// Token: 0x06003507 RID: 13575 RVA: 0x00029257 File Offset: 0x00027457
		public static IntRect Clone(IntRect intRect)
		{
			if (intRect == null)
			{
				return null;
			}
			return intRect.Clone();
		}

		// Token: 0x04001C27 RID: 7207
		public int x;

		// Token: 0x04001C28 RID: 7208
		public int y;

		// Token: 0x04001C29 RID: 7209
		public int width;

		// Token: 0x04001C2A RID: 7210
		public int height;
	}
}
