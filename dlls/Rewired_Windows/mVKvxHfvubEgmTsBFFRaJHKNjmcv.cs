using System;
using System.Runtime.InteropServices;

// Token: 0x02000134 RID: 308
internal class mVKvxHfvubEgmTsBFFRaJHKNjmcv : IDisposable
{
	// Token: 0x06000AE1 RID: 2785 RVA: 0x0003C858 File Offset: 0x0003AA58
	public mVKvxHfvubEgmTsBFFRaJHKNjmcv(uint A_1)
	{
		if (A_1 == 0U)
		{
			throw new Exception("size must be > 0!");
		}
		this.xaYDKKhZOWluNemBMfyfqWAGFeJr = A_1;
		this.bQnOhDZMkmAjVfTAsNegFWPLLVFwA = 0;
		try
		{
			this.IwMVtXkGIKFDppjKREbPKRGqSpEe = Marshal.AllocHGlobal((int)A_1);
			if (this.IwMVtXkGIKFDppjKREbPKRGqSpEe == IntPtr.Zero)
			{
				throw new Exception("Could not allocate native memory.");
			}
		}
		catch
		{
			throw;
		}
	}

	// Token: 0x06000AE2 RID: 2786 RVA: 0x0003C8C8 File Offset: 0x0003AAC8
	public unsafe IntPtr hUSjnslKtHBXtaEQJEMyAyNaeVZyA(uint A_1, void* A_2)
	{
		if (this.nVHnZEAerACiNDUFCEGSDgJaBvQqB)
		{
			return IntPtr.Zero;
		}
		if (A_1 == 0U)
		{
			return IntPtr.Zero;
		}
		if (A_1 > this.xaYDKKhZOWluNemBMfyfqWAGFeJr)
		{
			return IntPtr.Zero;
		}
		if ((long)this.bQnOhDZMkmAjVfTAsNegFWPLLVFwA + (long)((ulong)A_1) >= (long)((ulong)this.xaYDKKhZOWluNemBMfyfqWAGFeJr))
		{
			this.bQnOhDZMkmAjVfTAsNegFWPLLVFwA = 0;
		}
		IntPtr intPtr = new IntPtr(this.IwMVtXkGIKFDppjKREbPKRGqSpEe.ToInt64() + (long)this.bQnOhDZMkmAjVfTAsNegFWPLLVFwA);
		HtGHfzvtpMNSxwkJwcWlhmdnZCmfA.bHAETBtKdLwdhZkJqcIebuAEEprdb(intPtr, (IntPtr)A_2, (int)A_1);
		this.bQnOhDZMkmAjVfTAsNegFWPLLVFwA += (int)A_1;
		return intPtr;
	}

	// Token: 0x06000AE3 RID: 2787 RVA: 0x00017AD4 File Offset: 0x00015CD4
	public void Dispose()
	{
		this.UETXHxhCWeyKcMwFXkcTAViLjINA(true);
		GC.SuppressFinalize(this);
	}

	// Token: 0x06000AE4 RID: 2788 RVA: 0x0003C94C File Offset: 0x0003AB4C
	protected virtual void XCTNTQaZmLQhrbTGVuCdkueBEsHb()
	{
		try
		{
			this.UETXHxhCWeyKcMwFXkcTAViLjINA(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	// Token: 0x06000AE5 RID: 2789 RVA: 0x00017AE3 File Offset: 0x00015CE3
	protected virtual void UETXHxhCWeyKcMwFXkcTAViLjINA(bool A_1)
	{
		if (this.nVHnZEAerACiNDUFCEGSDgJaBvQqB)
		{
			return;
		}
		this.nVHnZEAerACiNDUFCEGSDgJaBvQqB = true;
		if (this.IwMVtXkGIKFDppjKREbPKRGqSpEe != IntPtr.Zero)
		{
			Marshal.FreeHGlobal(this.IwMVtXkGIKFDppjKREbPKRGqSpEe);
		}
	}

	// Token: 0x0400095E RID: 2398
	private int bQnOhDZMkmAjVfTAsNegFWPLLVFwA;

	// Token: 0x0400095F RID: 2399
	private uint xaYDKKhZOWluNemBMfyfqWAGFeJr;

	// Token: 0x04000960 RID: 2400
	private IntPtr IwMVtXkGIKFDppjKREbPKRGqSpEe;

	// Token: 0x04000961 RID: 2401
	private bool nVHnZEAerACiNDUFCEGSDgJaBvQqB;
}
