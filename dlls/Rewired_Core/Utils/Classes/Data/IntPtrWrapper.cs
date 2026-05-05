using System;

namespace Rewired.Utils.Classes.Data
{
	// Token: 0x0200050A RID: 1290
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class IntPtrWrapper
	{
		// Token: 0x17000BF7 RID: 3063
		// (get) Token: 0x060034C2 RID: 13506 RVA: 0x00028B3F File Offset: 0x00026D3F
		public bool IsValid
		{
			get
			{
				return this.rnTDEEwHigONtWEdKbXNmsAldZVL != IntPtr.Zero;
			}
		}

		// Token: 0x060034C3 RID: 13507 RVA: 0x00028B51 File Offset: 0x00026D51
		public IntPtrWrapper(IntPtr A_1)
		{
			this.rnTDEEwHigONtWEdKbXNmsAldZVL = A_1;
		}

		// Token: 0x060034C4 RID: 13508 RVA: 0x00028B60 File Offset: 0x00026D60
		public void Clear()
		{
			this.rnTDEEwHigONtWEdKbXNmsAldZVL = IntPtr.Zero;
		}

		// Token: 0x060034C5 RID: 13509 RVA: 0x00028B6D File Offset: 0x00026D6D
		public static implicit operator IntPtr(IntPtrWrapper obj)
		{
			if (obj == null)
			{
				return IntPtr.Zero;
			}
			return obj.rnTDEEwHigONtWEdKbXNmsAldZVL;
		}

		// Token: 0x04001C1D RID: 7197
		private IntPtr rnTDEEwHigONtWEdKbXNmsAldZVL;
	}
}
