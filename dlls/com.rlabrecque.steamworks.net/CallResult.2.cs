using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x0200017B RID: 379
	public sealed class CallResult<T> : CallResult, IDisposable
	{
		// Token: 0x14000002 RID: 2
		// (add) Token: 0x060008A1 RID: 2209 RVA: 0x0000CAA0 File Offset: 0x0000ACA0
		// (remove) Token: 0x060008A2 RID: 2210 RVA: 0x0000CAD8 File Offset: 0x0000ACD8
		private event CallResult<T>.APIDispatchDelegate m_Func;

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x060008A3 RID: 2211 RVA: 0x0000CB0D File Offset: 0x0000AD0D
		public SteamAPICall_t Handle
		{
			get
			{
				return this.m_hAPICall;
			}
		}

		// Token: 0x060008A4 RID: 2212 RVA: 0x0000CB15 File Offset: 0x0000AD15
		public static CallResult<T> Create(CallResult<T>.APIDispatchDelegate func = null)
		{
			return new CallResult<T>(func);
		}

		// Token: 0x060008A5 RID: 2213 RVA: 0x0000CB1D File Offset: 0x0000AD1D
		public CallResult(CallResult<T>.APIDispatchDelegate func = null)
		{
			this.m_Func = func;
		}

		// Token: 0x060008A6 RID: 2214 RVA: 0x0000CB38 File Offset: 0x0000AD38
		~CallResult()
		{
			this.Dispose();
		}

		// Token: 0x060008A7 RID: 2215 RVA: 0x0000CB64 File Offset: 0x0000AD64
		public void Dispose()
		{
			if (this.m_bDisposed)
			{
				return;
			}
			GC.SuppressFinalize(this);
			this.Cancel();
			this.m_bDisposed = true;
		}

		// Token: 0x060008A8 RID: 2216 RVA: 0x0000CB84 File Offset: 0x0000AD84
		public void Set(SteamAPICall_t hAPICall, CallResult<T>.APIDispatchDelegate func = null)
		{
			if (func != null)
			{
				this.m_Func = func;
			}
			if (this.m_Func == null)
			{
				throw new Exception("CallResult function was null, you must either set it in the CallResult Constructor or via Set()");
			}
			if (this.m_hAPICall != SteamAPICall_t.Invalid)
			{
				CallbackDispatcher.Unregister(this.m_hAPICall, this);
			}
			this.m_hAPICall = hAPICall;
			if (hAPICall != SteamAPICall_t.Invalid)
			{
				CallbackDispatcher.Register(hAPICall, this);
			}
		}

		// Token: 0x060008A9 RID: 2217 RVA: 0x0000CBE7 File Offset: 0x0000ADE7
		public bool IsActive()
		{
			return this.m_hAPICall != SteamAPICall_t.Invalid;
		}

		// Token: 0x060008AA RID: 2218 RVA: 0x0000CBF9 File Offset: 0x0000ADF9
		public void Cancel()
		{
			if (this.IsActive())
			{
				CallbackDispatcher.Unregister(this.m_hAPICall, this);
			}
		}

		// Token: 0x060008AB RID: 2219 RVA: 0x0000CC0F File Offset: 0x0000AE0F
		internal override Type GetCallbackType()
		{
			return typeof(T);
		}

		// Token: 0x060008AC RID: 2220 RVA: 0x0000CC1C File Offset: 0x0000AE1C
		internal override void OnRunCallResult(IntPtr pvParam, bool bFailed, ulong hSteamAPICall_)
		{
			if ((SteamAPICall_t)hSteamAPICall_ == this.m_hAPICall)
			{
				try
				{
					this.m_Func((T)((object)Marshal.PtrToStructure(pvParam, typeof(T))), bFailed);
				}
				catch (Exception e)
				{
					CallbackDispatcher.ExceptionHandler(e);
				}
			}
		}

		// Token: 0x060008AD RID: 2221 RVA: 0x0000CC78 File Offset: 0x0000AE78
		internal override void SetUnregistered()
		{
			this.m_hAPICall = SteamAPICall_t.Invalid;
		}

		// Token: 0x040009EE RID: 2542
		private SteamAPICall_t m_hAPICall = SteamAPICall_t.Invalid;

		// Token: 0x040009EF RID: 2543
		private bool m_bDisposed;

		// Token: 0x020001CA RID: 458
		// (Invoke) Token: 0x06000B64 RID: 2916
		public delegate void APIDispatchDelegate(T param, bool bIOFailure);
	}
}
