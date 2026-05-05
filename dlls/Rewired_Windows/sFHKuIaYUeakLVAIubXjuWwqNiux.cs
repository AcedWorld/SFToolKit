using System;
using System.Runtime.InteropServices;
using Rewired;
using Rewired.Utils.Attributes;

// Token: 0x0200004E RID: 78
internal class sFHKuIaYUeakLVAIubXjuWwqNiux : IDisposable
{
	// Token: 0x060002D8 RID: 728 RVA: 0x00029CA8 File Offset: 0x00027EA8
	public sFHKuIaYUeakLVAIubXjuWwqNiux()
	{
		if (sFHKuIaYUeakLVAIubXjuWwqNiux.swxXkknMfWBAxGLMKGeCUiNPLiMCb != null)
		{
			throw new Exception("Singleton instance already exists!");
		}
		sFHKuIaYUeakLVAIubXjuWwqNiux.swxXkknMfWBAxGLMKGeCUiNPLiMCb = this;
		this.gKpQJAfUKUjRQmUEhMOYWwyyiqnE = (IntPtr.Size == 8);
		this.mBXYQJHZRKGJlGIPeXKIHtLrfnBF = new byte[IntPtr.Size * 3 + 4];
	}

	// Token: 0x060002D9 RID: 729 RVA: 0x00029D00 File Offset: 0x00027F00
	public void lXwqtUeNGEWkdqihILiyJLGZwbde(Action<kZdMVYdrJYnBIKqGOBfzblDVLyEjA, hrpcZZIqnmZSMLjZjTNAXapJJkbG, uint, IntPtr> A_1, bool A_2)
	{
		this.ecSnLReMJqiPPkrYgkxudiLQeArcb = A_1;
		this.TRdrjxVGlKodEYWocjTqZnHSERDx = new sFHKuIaYUeakLVAIubXjuWwqNiux.DySxdCqNpsWtUVSEoQGAOZgQndZI(sFHKuIaYUeakLVAIubXjuWwqNiux.UMgcrcCchLmGnzRMkcGOkFFMboGE);
		uint num = 0U;
		if (A_2)
		{
			num = (uint)AppDomain.GetCurrentThreadId();
		}
		this.eUoeuKmdsJEqoICTxdmUOOEFzUnMA = sFHKuIaYUeakLVAIubXjuWwqNiux.EQdQQVenrVAEluNkPCfaHBMAFzjCb(4, this.TRdrjxVGlKodEYWocjTqZnHSERDx, IntPtr.Zero, num);
		if (this.eUoeuKmdsJEqoICTxdmUOOEFzUnMA == IntPtr.Zero)
		{
			Logger.LogError("SetWindowsHookEx Failed");
			return;
		}
	}

	// Token: 0x060002DA RID: 730 RVA: 0x00012B37 File Offset: 0x00010D37
	public void LAzqeRHxnVRgoyelUhOgszrfJGxD()
	{
		if (this.eUoeuKmdsJEqoICTxdmUOOEFzUnMA == IntPtr.Zero)
		{
			return;
		}
		if (!sFHKuIaYUeakLVAIubXjuWwqNiux.JOQKNhvKXlmOyRmTmvjhMIUWOSIs(this.eUoeuKmdsJEqoICTxdmUOOEFzUnMA))
		{
			Logger.LogError("UnhookWindowsHookEx Failed");
			return;
		}
		this.eUoeuKmdsJEqoICTxdmUOOEFzUnMA = IntPtr.Zero;
	}

	// Token: 0x060002DB RID: 731 RVA: 0x00029D68 File Offset: 0x00027F68
	[MonoPInvokeCallback(typeof(sFHKuIaYUeakLVAIubXjuWwqNiux.DySxdCqNpsWtUVSEoQGAOZgQndZI))]
	private static IntPtr UMgcrcCchLmGnzRMkcGOkFFMboGE(int A_0, IntPtr A_1, IntPtr A_2)
	{
		Marshal.Copy(A_2, sFHKuIaYUeakLVAIubXjuWwqNiux.swxXkknMfWBAxGLMKGeCUiNPLiMCb.mBXYQJHZRKGJlGIPeXKIHtLrfnBF, 0, sFHKuIaYUeakLVAIubXjuWwqNiux.swxXkknMfWBAxGLMKGeCUiNPLiMCb.mBXYQJHZRKGJlGIPeXKIHtLrfnBF.Length);
		int num = 0;
		sFHKuIaYUeakLVAIubXjuWwqNiux.swxXkknMfWBAxGLMKGeCUiNPLiMCb.dxmGHuIiPnootHqrBPiXxnVgdgyH.XwfYmCyISyyxrQJOkyVNbhKczcdL = kZdMVYdrJYnBIKqGOBfzblDVLyEjA.OQRvHBAFMCxTJPYalufDKrvfaMFh(kZdMVYdrJYnBIKqGOBfzblDVLyEjA.HXPphJERgMCHaXSEgCFFHrhVJVwu(sFHKuIaYUeakLVAIubXjuWwqNiux.swxXkknMfWBAxGLMKGeCUiNPLiMCb.mBXYQJHZRKGJlGIPeXKIHtLrfnBF, num));
		num += kZdMVYdrJYnBIKqGOBfzblDVLyEjA.kUKmuWfsqEQBWKgIAMkBwlinzjIc;
		sFHKuIaYUeakLVAIubXjuWwqNiux.swxXkknMfWBAxGLMKGeCUiNPLiMCb.dxmGHuIiPnootHqrBPiXxnVgdgyH.lcieZuecxbfXtMlyMxnMIQxYmYgZA = hrpcZZIqnmZSMLjZjTNAXapJJkbG.HkvJIvzgYovqNXbBhQyZROqZLDKe(hrpcZZIqnmZSMLjZjTNAXapJJkbG.eCkafLFmHWHXPAYGdTcCxpuZgFSvA(sFHKuIaYUeakLVAIubXjuWwqNiux.swxXkknMfWBAxGLMKGeCUiNPLiMCb.mBXYQJHZRKGJlGIPeXKIHtLrfnBF, num));
		num += hrpcZZIqnmZSMLjZjTNAXapJJkbG.ZSYQTclJRvCVVlFaHcCqwDqfpRGt;
		sFHKuIaYUeakLVAIubXjuWwqNiux.swxXkknMfWBAxGLMKGeCUiNPLiMCb.dxmGHuIiPnootHqrBPiXxnVgdgyH.RZhBEcZyIbHkKYBmSpwlGnEKOvzG = BitConverter.ToUInt32(sFHKuIaYUeakLVAIubXjuWwqNiux.swxXkknMfWBAxGLMKGeCUiNPLiMCb.mBXYQJHZRKGJlGIPeXKIHtLrfnBF, num);
		num += 4;
		if (sFHKuIaYUeakLVAIubXjuWwqNiux.swxXkknMfWBAxGLMKGeCUiNPLiMCb.gKpQJAfUKUjRQmUEhMOYWwyyiqnE)
		{
			sFHKuIaYUeakLVAIubXjuWwqNiux.swxXkknMfWBAxGLMKGeCUiNPLiMCb.dxmGHuIiPnootHqrBPiXxnVgdgyH.nYWdkuEdEardVlqDBRSYLEseojKBb = new IntPtr(BitConverter.ToInt32(sFHKuIaYUeakLVAIubXjuWwqNiux.swxXkknMfWBAxGLMKGeCUiNPLiMCb.mBXYQJHZRKGJlGIPeXKIHtLrfnBF, num + 4));
		}
		else
		{
			sFHKuIaYUeakLVAIubXjuWwqNiux.swxXkknMfWBAxGLMKGeCUiNPLiMCb.dxmGHuIiPnootHqrBPiXxnVgdgyH.nYWdkuEdEardVlqDBRSYLEseojKBb = new IntPtr(BitConverter.ToInt32(sFHKuIaYUeakLVAIubXjuWwqNiux.swxXkknMfWBAxGLMKGeCUiNPLiMCb.mBXYQJHZRKGJlGIPeXKIHtLrfnBF, num));
		}
		if (A_0 >= 0)
		{
			sFHKuIaYUeakLVAIubXjuWwqNiux.swxXkknMfWBAxGLMKGeCUiNPLiMCb.ecSnLReMJqiPPkrYgkxudiLQeArcb(kZdMVYdrJYnBIKqGOBfzblDVLyEjA.ADkZRkXLIFGYzhPpEyjtmJlwpNIPA(sFHKuIaYUeakLVAIubXjuWwqNiux.swxXkknMfWBAxGLMKGeCUiNPLiMCb.dxmGHuIiPnootHqrBPiXxnVgdgyH.XwfYmCyISyyxrQJOkyVNbhKczcdL), hrpcZZIqnmZSMLjZjTNAXapJJkbG.qUExyHmGDHFBGSdyvQzZmRGfFvXe(sFHKuIaYUeakLVAIubXjuWwqNiux.swxXkknMfWBAxGLMKGeCUiNPLiMCb.dxmGHuIiPnootHqrBPiXxnVgdgyH.lcieZuecxbfXtMlyMxnMIQxYmYgZA), sFHKuIaYUeakLVAIubXjuWwqNiux.swxXkknMfWBAxGLMKGeCUiNPLiMCb.dxmGHuIiPnootHqrBPiXxnVgdgyH.RZhBEcZyIbHkKYBmSpwlGnEKOvzG, sFHKuIaYUeakLVAIubXjuWwqNiux.swxXkknMfWBAxGLMKGeCUiNPLiMCb.dxmGHuIiPnootHqrBPiXxnVgdgyH.nYWdkuEdEardVlqDBRSYLEseojKBb);
		}
		return sFHKuIaYUeakLVAIubXjuWwqNiux.utBazmnkxOyAPRhbiEnMpLUukIbG(sFHKuIaYUeakLVAIubXjuWwqNiux.swxXkknMfWBAxGLMKGeCUiNPLiMCb.eUoeuKmdsJEqoICTxdmUOOEFzUnMA, A_0, A_1, A_2);
	}

	// Token: 0x060002DC RID: 732 RVA: 0x00012B6F File Offset: 0x00010D6F
	public void Dispose()
	{
		this.eliNfGeiUsscqxqqSnAxplKCIJCA(true);
		GC.SuppressFinalize(this);
	}

	// Token: 0x060002DD RID: 733 RVA: 0x00029ED4 File Offset: 0x000280D4
	protected virtual void RqkyWpxCbPpedNXgfvBadefkWmZR()
	{
		try
		{
			this.eliNfGeiUsscqxqqSnAxplKCIJCA(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	// Token: 0x060002DE RID: 734 RVA: 0x00012B7E File Offset: 0x00010D7E
	protected virtual void eliNfGeiUsscqxqqSnAxplKCIJCA(bool A_1)
	{
		if (this.mgCAvQfXpBgFANYOgvQWOsNXMATNA)
		{
			return;
		}
		this.LAzqeRHxnVRgoyelUhOgszrfJGxD();
		if (sFHKuIaYUeakLVAIubXjuWwqNiux.swxXkknMfWBAxGLMKGeCUiNPLiMCb == this)
		{
			sFHKuIaYUeakLVAIubXjuWwqNiux.swxXkknMfWBAxGLMKGeCUiNPLiMCb = null;
		}
		this.mgCAvQfXpBgFANYOgvQWOsNXMATNA = true;
	}

	// Token: 0x060002DF RID: 735
	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, EntryPoint = "SetWindowsHookEx")]
	private static extern IntPtr EQdQQVenrVAEluNkPCfaHBMAFzjCb(int, sFHKuIaYUeakLVAIubXjuWwqNiux.DySxdCqNpsWtUVSEoQGAOZgQndZI, IntPtr, uint);

	// Token: 0x060002E0 RID: 736
	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, EntryPoint = "UnhookWindowsHookEx")]
	private static extern bool JOQKNhvKXlmOyRmTmvjhMIUWOSIs(IntPtr);

	// Token: 0x060002E1 RID: 737
	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, EntryPoint = "CallNextHookEx")]
	private static extern IntPtr utBazmnkxOyAPRhbiEnMpLUukIbG(IntPtr, int, IntPtr, IntPtr);

	// Token: 0x04000493 RID: 1171
	private const int MOubnKrFVLisBUdPPCGLtbGfrQIC = 4;

	// Token: 0x04000494 RID: 1172
	private static sFHKuIaYUeakLVAIubXjuWwqNiux swxXkknMfWBAxGLMKGeCUiNPLiMCb;

	// Token: 0x04000495 RID: 1173
	private IntPtr eUoeuKmdsJEqoICTxdmUOOEFzUnMA = IntPtr.Zero;

	// Token: 0x04000496 RID: 1174
	private sFHKuIaYUeakLVAIubXjuWwqNiux.DySxdCqNpsWtUVSEoQGAOZgQndZI TRdrjxVGlKodEYWocjTqZnHSERDx;

	// Token: 0x04000497 RID: 1175
	private Action<kZdMVYdrJYnBIKqGOBfzblDVLyEjA, hrpcZZIqnmZSMLjZjTNAXapJJkbG, uint, IntPtr> ecSnLReMJqiPPkrYgkxudiLQeArcb;

	// Token: 0x04000498 RID: 1176
	private byte[] mBXYQJHZRKGJlGIPeXKIHtLrfnBF;

	// Token: 0x04000499 RID: 1177
	private readonly bool gKpQJAfUKUjRQmUEhMOYWwyyiqnE;

	// Token: 0x0400049A RID: 1178
	private sFHKuIaYUeakLVAIubXjuWwqNiux.EatWaYDuLgXBJCqUNoimAUgJIald dxmGHuIiPnootHqrBPiXxnVgdgyH;

	// Token: 0x0400049B RID: 1179
	private bool mgCAvQfXpBgFANYOgvQWOsNXMATNA;

	// Token: 0x0200004F RID: 79
	// (Invoke) Token: 0x060002E3 RID: 739
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private delegate IntPtr DySxdCqNpsWtUVSEoQGAOZgQndZI(int nCode, IntPtr wParam, IntPtr lParam);

	// Token: 0x02000050 RID: 80
	private struct EatWaYDuLgXBJCqUNoimAUgJIald
	{
		// Token: 0x0400049C RID: 1180
		public IntPtr XwfYmCyISyyxrQJOkyVNbhKczcdL;

		// Token: 0x0400049D RID: 1181
		public IntPtr lcieZuecxbfXtMlyMxnMIQxYmYgZA;

		// Token: 0x0400049E RID: 1182
		public uint RZhBEcZyIbHkKYBmSpwlGnEKOvzG;

		// Token: 0x0400049F RID: 1183
		public IntPtr nYWdkuEdEardVlqDBRSYLEseojKBb;
	}
}
