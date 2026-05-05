using System;

namespace Unity.XGamingRuntime
{
	// Token: 0x0200016B RID: 363
	public abstract class XRegistrationToken<T> : CallbackWrapper<T> where T : Delegate
	{
		// Token: 0x060008B5 RID: 2229 RVA: 0x0000DFCA File Offset: 0x0000C1CA
		protected XRegistrationToken(T callback, IntPtr context, T staticCallback) : base(callback, context, staticCallback)
		{
		}

		// Token: 0x17000269 RID: 617
		// (get) Token: 0x060008B6 RID: 2230 RVA: 0x0000DFD5 File Offset: 0x0000C1D5
		public bool IsValid
		{
			get
			{
				return this.Token > 0UL;
			}
		}

		// Token: 0x060008B7 RID: 2231 RVA: 0x0000DFE1 File Offset: 0x0000C1E1
		protected override void Dispose(bool disposing)
		{
			if (this.Token != 0UL)
			{
				this.DisposeInternal(disposing);
				this.Token = 0UL;
			}
			base.Dispose(disposing);
		}

		// Token: 0x060008B8 RID: 2232
		protected abstract void DisposeInternal(bool disposing);

		// Token: 0x04000513 RID: 1299
		public ulong Token;
	}
}
