using System;
using UnityEngine;

namespace Rewired.Utils.Classes.Data
{
	// Token: 0x0200050B RID: 1291
	[Serializable]
	public class IntVector2
	{
		// Token: 0x060034C6 RID: 13510 RVA: 0x00028B7E File Offset: 0x00026D7E
		public IntVector2()
		{
			this.x = 0;
			this.y = 0;
		}

		// Token: 0x060034C7 RID: 13511 RVA: 0x00028B94 File Offset: 0x00026D94
		public IntVector2(int A_1, int A_2)
		{
			this.x = A_1;
			this.y = A_2;
		}

		// Token: 0x060034C8 RID: 13512 RVA: 0x00028BAA File Offset: 0x00026DAA
		public IntVector2 Clone()
		{
			return new IntVector2(this.x, this.y);
		}

		// Token: 0x060034C9 RID: 13513 RVA: 0x00028BBD File Offset: 0x00026DBD
		public static IntVector2 Clone(IntVector2 intVector2)
		{
			if (intVector2 == null)
			{
				return null;
			}
			return intVector2.Clone();
		}

		// Token: 0x060034CA RID: 13514 RVA: 0x00028BCA File Offset: 0x00026DCA
		public static IntVector2 operator +(IntVector2 value1, IntVector2 value2)
		{
			return new IntVector2(value1.x + value2.x, value1.y + value2.y);
		}

		// Token: 0x060034CB RID: 13515 RVA: 0x00028BEB File Offset: 0x00026DEB
		public static IntVector2 operator -(IntVector2 value1, IntVector2 value2)
		{
			return new IntVector2(value1.x - value2.x, value1.y - value2.y);
		}

		// Token: 0x060034CC RID: 13516 RVA: 0x00028C0C File Offset: 0x00026E0C
		public static IntVector2 operator *(IntVector2 value1, IntVector2 value2)
		{
			return new IntVector2(value1.x * value2.x, value1.y * value2.y);
		}

		// Token: 0x060034CD RID: 13517 RVA: 0x00028C2D File Offset: 0x00026E2D
		public static IntVector2 operator /(IntVector2 value1, IntVector2 value2)
		{
			return new IntVector2(value1.x / value2.x, value1.y / value2.y);
		}

		// Token: 0x060034CE RID: 13518 RVA: 0x00028C4E File Offset: 0x00026E4E
		public static IntVector2 operator +(IntVector2 value1, int value2)
		{
			return new IntVector2(value1.x + value2, value1.y + value2);
		}

		// Token: 0x060034CF RID: 13519 RVA: 0x00028C65 File Offset: 0x00026E65
		public static IntVector2 operator -(IntVector2 value1, int value2)
		{
			return new IntVector2(value1.x - value2, value1.y - value2);
		}

		// Token: 0x060034D0 RID: 13520 RVA: 0x00028C7C File Offset: 0x00026E7C
		public static IntVector2 operator *(IntVector2 value1, int value2)
		{
			return new IntVector2(value1.x * value2, value1.y * value2);
		}

		// Token: 0x060034D1 RID: 13521 RVA: 0x00028C93 File Offset: 0x00026E93
		public static IntVector2 operator /(IntVector2 value1, int value2)
		{
			return new IntVector2(value1.x / value2, value1.y / value2);
		}

		// Token: 0x060034D2 RID: 13522 RVA: 0x00028CAA File Offset: 0x00026EAA
		public static Vector2 operator +(IntVector2 value1, float value2)
		{
			return new Vector2((float)value1.x + value2, (float)value1.y + value2);
		}

		// Token: 0x060034D3 RID: 13523 RVA: 0x00028CC3 File Offset: 0x00026EC3
		public static Vector2 operator -(IntVector2 value1, float value2)
		{
			return new Vector2((float)value1.x - value2, (float)value1.y - value2);
		}

		// Token: 0x060034D4 RID: 13524 RVA: 0x00028CDC File Offset: 0x00026EDC
		public static Vector2 operator *(IntVector2 value1, float value2)
		{
			return new Vector2((float)value1.x * value2, (float)value1.y * value2);
		}

		// Token: 0x060034D5 RID: 13525 RVA: 0x00028CF5 File Offset: 0x00026EF5
		public static Vector2 operator /(IntVector2 value1, float value2)
		{
			return new Vector2((float)value1.x / value2, (float)value1.y / value2);
		}

		// Token: 0x04001C1E RID: 7198
		public int x;

		// Token: 0x04001C1F RID: 7199
		public int y;
	}
}
