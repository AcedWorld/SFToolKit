using System;
using UnityEngine;

namespace Rewired.Utils.Classes.Data
{
	// Token: 0x0200050C RID: 1292
	[Serializable]
	public class IntVector3
	{
		// Token: 0x060034D6 RID: 13526 RVA: 0x00028D0E File Offset: 0x00026F0E
		public IntVector3()
		{
			this.x = 0;
			this.y = 0;
			this.z = 0;
		}

		// Token: 0x060034D7 RID: 13527 RVA: 0x00028D2B File Offset: 0x00026F2B
		public IntVector3(int A_1, int A_2, int A_3)
		{
			this.x = A_1;
			this.y = A_2;
			this.z = A_3;
		}

		// Token: 0x060034D8 RID: 13528 RVA: 0x00028D48 File Offset: 0x00026F48
		public IntVector3 Clone()
		{
			return new IntVector3(this.x, this.y, this.z);
		}

		// Token: 0x060034D9 RID: 13529 RVA: 0x00028D61 File Offset: 0x00026F61
		public static IntVector3 operator +(IntVector3 value1, IntVector3 value2)
		{
			return new IntVector3(value1.x + value2.x, value1.y + value2.y, value1.z + value2.z);
		}

		// Token: 0x060034DA RID: 13530 RVA: 0x00028D8F File Offset: 0x00026F8F
		public static IntVector3 operator -(IntVector3 value1, IntVector3 value2)
		{
			return new IntVector3(value1.x - value2.x, value1.y - value2.y, value1.z - value2.z);
		}

		// Token: 0x060034DB RID: 13531 RVA: 0x00028DBD File Offset: 0x00026FBD
		public static IntVector3 operator *(IntVector3 value1, IntVector3 value2)
		{
			return new IntVector3(value1.x * value2.x, value1.y * value2.y, value1.z * value2.z);
		}

		// Token: 0x060034DC RID: 13532 RVA: 0x00028DEB File Offset: 0x00026FEB
		public static IntVector3 operator /(IntVector3 value1, IntVector3 value2)
		{
			return new IntVector3(value1.x / value2.x, value1.y / value2.y, value1.z / value2.z);
		}

		// Token: 0x060034DD RID: 13533 RVA: 0x00028E19 File Offset: 0x00027019
		public static IntVector3 operator +(IntVector3 value1, int value2)
		{
			return new IntVector3(value1.x + value2, value1.y + value2, value1.z + value2);
		}

		// Token: 0x060034DE RID: 13534 RVA: 0x00028E38 File Offset: 0x00027038
		public static IntVector3 operator -(IntVector3 value1, int value2)
		{
			return new IntVector3(value1.x - value2, value1.y - value2, value1.z - value2);
		}

		// Token: 0x060034DF RID: 13535 RVA: 0x00028E57 File Offset: 0x00027057
		public static IntVector3 operator *(IntVector3 value1, int value2)
		{
			return new IntVector3(value1.x * value2, value1.y * value2, value1.z * value2);
		}

		// Token: 0x060034E0 RID: 13536 RVA: 0x00028E76 File Offset: 0x00027076
		public static IntVector3 operator /(IntVector3 value1, int value2)
		{
			return new IntVector3(value1.x / value2, value1.y / value2, value1.z / value2);
		}

		// Token: 0x060034E1 RID: 13537 RVA: 0x00028E95 File Offset: 0x00027095
		public static Vector3 operator +(IntVector3 value1, float value2)
		{
			return new Vector3((float)value1.x + value2, (float)value1.y + value2, (float)value1.z + value2);
		}

		// Token: 0x060034E2 RID: 13538 RVA: 0x00028EB7 File Offset: 0x000270B7
		public static Vector3 operator -(IntVector3 value1, float value2)
		{
			return new Vector3((float)value1.x - value2, (float)value1.y - value2, (float)value1.z - value2);
		}

		// Token: 0x060034E3 RID: 13539 RVA: 0x00028ED9 File Offset: 0x000270D9
		public static Vector3 operator *(IntVector3 value1, float value2)
		{
			return new Vector3((float)value1.x * value2, (float)value1.y * value2, (float)value1.z * value2);
		}

		// Token: 0x060034E4 RID: 13540 RVA: 0x00028EFB File Offset: 0x000270FB
		public static Vector3 operator /(IntVector3 value1, float value2)
		{
			return new Vector3((float)value1.x / value2, (float)value1.y / value2, (float)value1.z / value2);
		}

		// Token: 0x04001C20 RID: 7200
		public int x;

		// Token: 0x04001C21 RID: 7201
		public int y;

		// Token: 0x04001C22 RID: 7202
		public int z;
	}
}
