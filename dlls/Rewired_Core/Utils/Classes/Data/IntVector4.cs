using System;
using UnityEngine;

namespace Rewired.Utils.Classes.Data
{
	// Token: 0x0200050D RID: 1293
	[Serializable]
	public class IntVector4
	{
		// Token: 0x060034E5 RID: 13541 RVA: 0x00028F1D File Offset: 0x0002711D
		public IntVector4()
		{
			this.x = 0;
			this.y = 0;
			this.z = 0;
			this.q = 0;
		}

		// Token: 0x060034E6 RID: 13542 RVA: 0x00028F41 File Offset: 0x00027141
		public IntVector4(int A_1, int A_2, int A_3, int A_4)
		{
			this.x = A_1;
			this.y = A_2;
			this.z = A_3;
			this.q = A_4;
		}

		// Token: 0x060034E7 RID: 13543 RVA: 0x00028F66 File Offset: 0x00027166
		public IntVector4 Clone()
		{
			return new IntVector4(this.x, this.y, this.z, this.q);
		}

		// Token: 0x060034E8 RID: 13544 RVA: 0x00028F85 File Offset: 0x00027185
		public static IntVector4 operator +(IntVector4 value1, IntVector4 value2)
		{
			return new IntVector4(value1.x + value2.x, value1.y + value2.y, value1.z + value2.z, value1.q + value2.q);
		}

		// Token: 0x060034E9 RID: 13545 RVA: 0x00028FC0 File Offset: 0x000271C0
		public static IntVector4 operator -(IntVector4 value1, IntVector4 value2)
		{
			return new IntVector4(value1.x - value2.x, value1.y - value2.y, value1.z - value2.z, value1.q - value2.q);
		}

		// Token: 0x060034EA RID: 13546 RVA: 0x00028FFB File Offset: 0x000271FB
		public static IntVector4 operator *(IntVector4 value1, IntVector4 value2)
		{
			return new IntVector4(value1.x * value2.x, value1.y * value2.y, value1.z * value2.z, value1.q * value2.q);
		}

		// Token: 0x060034EB RID: 13547 RVA: 0x00029036 File Offset: 0x00027236
		public static IntVector4 operator /(IntVector4 value1, IntVector4 value2)
		{
			return new IntVector4(value1.x / value2.x, value1.y / value2.y, value1.z / value2.z, value1.q / value2.q);
		}

		// Token: 0x060034EC RID: 13548 RVA: 0x00029071 File Offset: 0x00027271
		public static IntVector4 operator +(IntVector4 value1, int value2)
		{
			return new IntVector4(value1.x + value2, value1.y + value2, value1.z + value2, value1.q + value2);
		}

		// Token: 0x060034ED RID: 13549 RVA: 0x00029098 File Offset: 0x00027298
		public static IntVector4 operator -(IntVector4 value1, int value2)
		{
			return new IntVector4(value1.x - value2, value1.y - value2, value1.z - value2, value1.q - value2);
		}

		// Token: 0x060034EE RID: 13550 RVA: 0x000290BF File Offset: 0x000272BF
		public static IntVector4 operator *(IntVector4 value1, int value2)
		{
			return new IntVector4(value1.x * value2, value1.y * value2, value1.z * value2, value1.q * value2);
		}

		// Token: 0x060034EF RID: 13551 RVA: 0x000290E6 File Offset: 0x000272E6
		public static IntVector4 operator /(IntVector4 value1, int value2)
		{
			return new IntVector4(value1.x / value2, value1.y / value2, value1.z / value2, value1.q / value2);
		}

		// Token: 0x060034F0 RID: 13552 RVA: 0x0002910D File Offset: 0x0002730D
		public static Vector4 operator +(IntVector4 value1, float value2)
		{
			return new Vector4((float)value1.x + value2, (float)value1.y + value2, (float)value1.z + value2, (float)value1.q + value2);
		}

		// Token: 0x060034F1 RID: 13553 RVA: 0x00029138 File Offset: 0x00027338
		public static Vector4 operator -(IntVector4 value1, float value2)
		{
			return new Vector4((float)value1.x - value2, (float)value1.y - value2, (float)value1.z - value2, (float)value1.q - value2);
		}

		// Token: 0x060034F2 RID: 13554 RVA: 0x00029163 File Offset: 0x00027363
		public static Vector4 operator *(IntVector4 value1, float value2)
		{
			return new Vector4((float)value1.x * value2, (float)value1.y * value2, (float)value1.z * value2, (float)value1.q * value2);
		}

		// Token: 0x060034F3 RID: 13555 RVA: 0x0002918E File Offset: 0x0002738E
		public static Vector4 operator /(IntVector4 value1, float value2)
		{
			return new Vector4((float)value1.x / value2, (float)value1.y / value2, (float)value1.z / value2, (float)value1.q / value2);
		}

		// Token: 0x04001C23 RID: 7203
		public int x;

		// Token: 0x04001C24 RID: 7204
		public int y;

		// Token: 0x04001C25 RID: 7205
		public int z;

		// Token: 0x04001C26 RID: 7206
		public int q;
	}
}
