using System;
using System.Collections.Generic;

// Token: 0x02000186 RID: 390
internal static class qMVbwuihHnGurDXvaDfqecGAOKEEe
{
	// Token: 0x040017DE RID: 6110
	public static readonly IEqualityComparer<IntPtr> TSxzSLbhUehTfHSNGHyLCRKBeIHHA = new qMVbwuihHnGurDXvaDfqecGAOKEEe.tYgvWIXOhkwHqzZmkOZGQwVECrPf();

	// Token: 0x02000187 RID: 391
	internal class tYgvWIXOhkwHqzZmkOZGQwVECrPf : EqualityComparer<IntPtr>
	{
		// Token: 0x06000B91 RID: 2961 RVA: 0x0001811A File Offset: 0x0001631A
		public virtual bool naUdClAAMtHiaBBpkNCVWUqjGKLsb(IntPtr A_1, IntPtr A_2)
		{
			return A_1 == A_2;
		}

		// Token: 0x06000B92 RID: 2962 RVA: 0x00018123 File Offset: 0x00016323
		public virtual int SMRkIoEVIubVbdvQaehUXqYxCNfU(IntPtr A_1)
		{
			return A_1.GetHashCode();
		}
	}
}
