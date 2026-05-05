using System;
using System.Runtime.InteropServices;

// Token: 0x02000162 RID: 354
internal class grNAtvFujPhmdeEnFJdVRbGsuTPEb : IDisposable
{
	// Token: 0x06000B7B RID: 2939 RVA: 0x0003E11C File Offset: 0x0003C31C
	public void HgveOCFjqtftUvyOToQJrxaRFRXk(Action<IntPtr, IntPtr, uint, uint> A_1, grNAtvFujPhmdeEnFJdVRbGsuTPEb.MfeRXGAZNaydFnHwpnKdhocxAgHJ A_2)
	{
		this.HslEQSPKyMcveMmtuYElGLZkpCHO = A_1;
		this.vvnkjCsvAgrqlzgdpRLrhNzWEnrdA = new grNAtvFujPhmdeEnFJdVRbGsuTPEb.HJKwYgyRcWobRUmQgojAXJbgyNSn(this.qZQPymwqNRrQuyrvLNIpmPnTKgmp);
		uint num = 0U;
		if (A_2 == grNAtvFujPhmdeEnFJdVRbGsuTPEb.MfeRXGAZNaydFnHwpnKdhocxAgHJ.Current)
		{
			num = (uint)AppDomain.GetCurrentThreadId();
		}
		this.SFMpWUtSTfOdqMxVaBjDObYAIMOT = grNAtvFujPhmdeEnFJdVRbGsuTPEb.DAEFGrxRfNCdmezlcSfdJSXBSBmlA(4, this.vvnkjCsvAgrqlzgdpRLrhNzWEnrdA, IntPtr.Zero, num);
		this.SFMpWUtSTfOdqMxVaBjDObYAIMOT == IntPtr.Zero;
	}

	// Token: 0x06000B7C RID: 2940 RVA: 0x0001803F File Offset: 0x0001623F
	public void NfZlzDPGmZElNSNJEMTgLnCEbCTN()
	{
		if (this.SFMpWUtSTfOdqMxVaBjDObYAIMOT == IntPtr.Zero)
		{
			return;
		}
		if (!grNAtvFujPhmdeEnFJdVRbGsuTPEb.wqWcoZSMfceuFcjfTnhpNqYFGnShb(this.SFMpWUtSTfOdqMxVaBjDObYAIMOT))
		{
			return;
		}
		this.SFMpWUtSTfOdqMxVaBjDObYAIMOT = IntPtr.Zero;
	}

	// Token: 0x06000B7D RID: 2941 RVA: 0x0003E178 File Offset: 0x0003C378
	private IntPtr qZQPymwqNRrQuyrvLNIpmPnTKgmp(int A_1, IntPtr A_2, IntPtr A_3)
	{
		if (A_1 >= 0)
		{
			int num = 0;
			IntPtr arg = Marshal.ReadIntPtr(A_3, num);
			num += IntPtr.Size;
			IntPtr arg2 = Marshal.ReadIntPtr(A_3, num);
			num += IntPtr.Size;
			uint arg3 = (uint)Marshal.ReadInt32(A_3, num);
			num += 4;
			if (IntPtr.Size == 8)
			{
				num += 4;
			}
			uint arg4 = (uint)Marshal.ReadInt32(A_3, num);
			this.HslEQSPKyMcveMmtuYElGLZkpCHO(arg, arg2, arg3, arg4);
		}
		return grNAtvFujPhmdeEnFJdVRbGsuTPEb.cXuyPbMaVeFKzDnlgGRVhCZmqahhb(this.SFMpWUtSTfOdqMxVaBjDObYAIMOT, A_1, A_2, A_3);
	}

	// Token: 0x06000B7E RID: 2942 RVA: 0x0001806D File Offset: 0x0001626D
	public void Dispose()
	{
		this.EnAYvZQFfMxisNmSKEsOadRXaVmZ(true);
		GC.SuppressFinalize(this);
	}

	// Token: 0x06000B7F RID: 2943 RVA: 0x0003E1EC File Offset: 0x0003C3EC
	protected virtual void tIcekUagYLldYNpDNEJfEDhyoPqGA()
	{
		try
		{
			this.EnAYvZQFfMxisNmSKEsOadRXaVmZ(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	// Token: 0x06000B80 RID: 2944 RVA: 0x0001807C File Offset: 0x0001627C
	protected virtual void EnAYvZQFfMxisNmSKEsOadRXaVmZ(bool A_1)
	{
		if (this.ZCzYnivLUpnVgAdNfnzGlPbPdJpj)
		{
			return;
		}
		this.NfZlzDPGmZElNSNJEMTgLnCEbCTN();
		this.ZCzYnivLUpnVgAdNfnzGlPbPdJpj = true;
	}

	// Token: 0x06000B81 RID: 2945
	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "SetWindowsHookEx")]
	private static extern IntPtr DAEFGrxRfNCdmezlcSfdJSXBSBmlA(int, grNAtvFujPhmdeEnFJdVRbGsuTPEb.HJKwYgyRcWobRUmQgojAXJbgyNSn, IntPtr, uint);

	// Token: 0x06000B82 RID: 2946
	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "UnhookWindowsHookEx")]
	private static extern bool wqWcoZSMfceuFcjfTnhpNqYFGnShb(IntPtr);

	// Token: 0x06000B83 RID: 2947
	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "CallNextHookEx")]
	private static extern IntPtr cXuyPbMaVeFKzDnlgGRVhCZmqahhb(IntPtr, int, IntPtr, IntPtr);

	// Token: 0x0400157A RID: 5498
	private const int bYcDAbDRUCKGRFSdbUsxINkFYzoP = 4;

	// Token: 0x0400157B RID: 5499
	private IntPtr SFMpWUtSTfOdqMxVaBjDObYAIMOT = IntPtr.Zero;

	// Token: 0x0400157C RID: 5500
	private grNAtvFujPhmdeEnFJdVRbGsuTPEb.HJKwYgyRcWobRUmQgojAXJbgyNSn vvnkjCsvAgrqlzgdpRLrhNzWEnrdA;

	// Token: 0x0400157D RID: 5501
	private Action<IntPtr, IntPtr, uint, uint> HslEQSPKyMcveMmtuYElGLZkpCHO;

	// Token: 0x0400157E RID: 5502
	private bool ZCzYnivLUpnVgAdNfnzGlPbPdJpj;

	// Token: 0x02000163 RID: 355
	internal enum MfeRXGAZNaydFnHwpnKdhocxAgHJ
	{
		// Token: 0x04001580 RID: 5504
		Current,
		// Token: 0x04001581 RID: 5505
		All
	}

	// Token: 0x02000164 RID: 356
	// (Invoke) Token: 0x06000B85 RID: 2949
	private delegate IntPtr HJKwYgyRcWobRUmQgojAXJbgyNSn(int nCode, IntPtr wParam, IntPtr lParam);
}
