using System;
using UnityEngine;

namespace Rewired.Utils.Classes.Data
{
	// Token: 0x02000510 RID: 1296
	[Serializable]
	public class SerializableULong
	{
		// Token: 0x17000C00 RID: 3072
		// (get) Token: 0x06003517 RID: 13591 RVA: 0x00029500 File Offset: 0x00027700
		// (set) Token: 0x06003518 RID: 13592 RVA: 0x00029514 File Offset: 0x00027714
		public ulong value
		{
			get
			{
				return this.RSHGPjJrobWmPbkydICbfTXeOhYR(this.ulong_32BitLow, this.ulong_32BitHigh);
			}
			set
			{
				this.fGRaqGAFbXNSjUIyniMHZUgBOdxVA(value, out this.ulong_32BitLow, out this.ulong_32BitHigh);
			}
		}

		// Token: 0x06003519 RID: 13593 RVA: 0x000033F4 File Offset: 0x000015F4
		public SerializableULong()
		{
		}

		// Token: 0x0600351A RID: 13594 RVA: 0x00029529 File Offset: 0x00027729
		public SerializableULong(SerializableULong A_1)
		{
			this.ulong_32BitLow = A_1.ulong_32BitLow;
			this.ulong_32BitHigh = A_1.ulong_32BitHigh;
		}

		// Token: 0x0600351B RID: 13595 RVA: 0x00029549 File Offset: 0x00027749
		private void fGRaqGAFbXNSjUIyniMHZUgBOdxVA(ulong A_1, out int A_2, out int A_3)
		{
			A_2 = (int)A_1;
			A_3 = (int)(A_1 >> 32);
		}

		// Token: 0x0600351C RID: 13596 RVA: 0x000B52D4 File Offset: 0x000B34D4
		private ulong RSHGPjJrobWmPbkydICbfTXeOhYR(int A_1, int A_2)
		{
			ulong num = (ulong)((long)A_1 & (long)((ulong)-1));
			ulong num2 = (ulong)((ulong)((long)A_2) << 32);
			return num | num2;
		}

		// Token: 0x0600351D RID: 13597 RVA: 0x00029556 File Offset: 0x00027756
		public SerializableULong Clone()
		{
			return new SerializableULong
			{
				ulong_32BitLow = this.ulong_32BitLow,
				ulong_32BitHigh = this.ulong_32BitHigh
			};
		}

		// Token: 0x04001C2F RID: 7215
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private int ulong_32BitLow;

		// Token: 0x04001C30 RID: 7216
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private int ulong_32BitHigh;
	}
}
