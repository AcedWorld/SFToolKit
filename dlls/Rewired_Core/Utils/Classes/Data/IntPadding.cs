using System;
using UnityEngine;

namespace Rewired.Utils.Classes.Data
{
	// Token: 0x0200050F RID: 1295
	[Serializable]
	public class IntPadding
	{
		// Token: 0x06003508 RID: 13576 RVA: 0x00029264 File Offset: 0x00027464
		public IntPadding()
		{
			this.top = 0;
			this.right = 0;
			this.bottom = 0;
			this.left = 0;
		}

		// Token: 0x06003509 RID: 13577 RVA: 0x00029288 File Offset: 0x00027488
		public IntPadding(int A_1, int A_2, int A_3, int A_4)
		{
			this.top = A_1;
			this.right = A_2;
			this.bottom = A_3;
			this.left = A_4;
		}

		// Token: 0x0600350A RID: 13578 RVA: 0x000292AD File Offset: 0x000274AD
		public IntPadding Clone()
		{
			return new IntPadding(this.top, this.right, this.bottom, this.left);
		}

		// Token: 0x0600350B RID: 13579 RVA: 0x000292CC File Offset: 0x000274CC
		public static IntPadding operator +(IntPadding value1, IntPadding value2)
		{
			return new IntPadding(value1.top + value2.top, value1.right + value2.right, value1.bottom + value2.bottom, value1.left + value2.left);
		}

		// Token: 0x0600350C RID: 13580 RVA: 0x00029307 File Offset: 0x00027507
		public static IntPadding operator -(IntPadding value1, IntPadding value2)
		{
			return new IntPadding(value1.top - value2.top, value1.right - value2.right, value1.bottom - value2.bottom, value1.left - value2.left);
		}

		// Token: 0x0600350D RID: 13581 RVA: 0x00029342 File Offset: 0x00027542
		public static IntPadding operator *(IntPadding value1, IntPadding value2)
		{
			return new IntPadding(value1.top * value2.top, value1.right * value2.right, value1.bottom * value2.bottom, value1.left * value2.left);
		}

		// Token: 0x0600350E RID: 13582 RVA: 0x0002937D File Offset: 0x0002757D
		public static IntPadding operator /(IntPadding value1, IntPadding value2)
		{
			return new IntPadding(value1.top / value2.top, value1.right / value2.right, value1.bottom / value2.bottom, value1.left / value2.left);
		}

		// Token: 0x0600350F RID: 13583 RVA: 0x000293B8 File Offset: 0x000275B8
		public static IntPadding operator +(IntPadding value1, int value2)
		{
			return new IntPadding(value1.top + value2, value1.right + value2, value1.bottom + value2, value1.left + value2);
		}

		// Token: 0x06003510 RID: 13584 RVA: 0x000293DF File Offset: 0x000275DF
		public static IntPadding operator -(IntPadding value1, int value2)
		{
			return new IntPadding(value1.top - value2, value1.right - value2, value1.bottom - value2, value1.left - value2);
		}

		// Token: 0x06003511 RID: 13585 RVA: 0x00029406 File Offset: 0x00027606
		public static IntPadding operator *(IntPadding value1, int value2)
		{
			return new IntPadding(value1.top * value2, value1.right * value2, value1.bottom * value2, value1.left * value2);
		}

		// Token: 0x06003512 RID: 13586 RVA: 0x0002942D File Offset: 0x0002762D
		public static IntPadding operator /(IntPadding value1, int value2)
		{
			return new IntPadding(value1.top / value2, value1.right / value2, value1.bottom / value2, value1.left / value2);
		}

		// Token: 0x06003513 RID: 13587 RVA: 0x00029454 File Offset: 0x00027654
		public static Vector4 operator +(IntPadding value1, float value2)
		{
			return new Vector4((float)value1.top + value2, (float)value1.right + value2, (float)value1.bottom + value2, (float)value1.left + value2);
		}

		// Token: 0x06003514 RID: 13588 RVA: 0x0002947F File Offset: 0x0002767F
		public static Vector4 operator -(IntPadding value1, float value2)
		{
			return new Vector4((float)value1.top - value2, (float)value1.right - value2, (float)value1.bottom - value2, (float)value1.left - value2);
		}

		// Token: 0x06003515 RID: 13589 RVA: 0x000294AA File Offset: 0x000276AA
		public static Vector4 operator *(IntPadding value1, float value2)
		{
			return new Vector4((float)value1.top * value2, (float)value1.right * value2, (float)value1.bottom * value2, (float)value1.left * value2);
		}

		// Token: 0x06003516 RID: 13590 RVA: 0x000294D5 File Offset: 0x000276D5
		public static Vector4 operator /(IntPadding value1, float value2)
		{
			return new Vector4((float)value1.top / value2, (float)value1.right / value2, (float)value1.bottom / value2, (float)value1.left / value2);
		}

		// Token: 0x04001C2B RID: 7211
		public int top;

		// Token: 0x04001C2C RID: 7212
		public int right;

		// Token: 0x04001C2D RID: 7213
		public int bottom;

		// Token: 0x04001C2E RID: 7214
		public int left;
	}
}
