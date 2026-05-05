using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000184 RID: 388
	public class ISteamMatchmakingRulesResponse
	{
		// Token: 0x060008D0 RID: 2256 RVA: 0x0000D364 File Offset: 0x0000B564
		public ISteamMatchmakingRulesResponse(ISteamMatchmakingRulesResponse.RulesResponded onRulesResponded, ISteamMatchmakingRulesResponse.RulesFailedToRespond onRulesFailedToRespond, ISteamMatchmakingRulesResponse.RulesRefreshComplete onRulesRefreshComplete)
		{
			if (onRulesResponded == null || onRulesFailedToRespond == null || onRulesRefreshComplete == null)
			{
				throw new ArgumentNullException();
			}
			this.m_RulesResponded = onRulesResponded;
			this.m_RulesFailedToRespond = onRulesFailedToRespond;
			this.m_RulesRefreshComplete = onRulesRefreshComplete;
			this.m_VTable = new ISteamMatchmakingRulesResponse.VTable
			{
				m_VTRulesResponded = new ISteamMatchmakingRulesResponse.InternalRulesResponded(this.InternalOnRulesResponded),
				m_VTRulesFailedToRespond = new ISteamMatchmakingRulesResponse.InternalRulesFailedToRespond(this.InternalOnRulesFailedToRespond),
				m_VTRulesRefreshComplete = new ISteamMatchmakingRulesResponse.InternalRulesRefreshComplete(this.InternalOnRulesRefreshComplete)
			};
			this.m_pVTable = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(ISteamMatchmakingRulesResponse.VTable)));
			Marshal.StructureToPtr<ISteamMatchmakingRulesResponse.VTable>(this.m_VTable, this.m_pVTable, false);
			this.m_pGCHandle = GCHandle.Alloc(this.m_pVTable, GCHandleType.Pinned);
		}

		// Token: 0x060008D1 RID: 2257 RVA: 0x0000D420 File Offset: 0x0000B620
		~ISteamMatchmakingRulesResponse()
		{
			if (this.m_pVTable != IntPtr.Zero)
			{
				Marshal.FreeHGlobal(this.m_pVTable);
			}
			if (this.m_pGCHandle.IsAllocated)
			{
				this.m_pGCHandle.Free();
			}
		}

		// Token: 0x060008D2 RID: 2258 RVA: 0x0000D47C File Offset: 0x0000B67C
		private void InternalOnRulesResponded(IntPtr thisptr, IntPtr pchRule, IntPtr pchValue)
		{
			this.m_RulesResponded(InteropHelp.PtrToStringUTF8(pchRule), InteropHelp.PtrToStringUTF8(pchValue));
		}

		// Token: 0x060008D3 RID: 2259 RVA: 0x0000D495 File Offset: 0x0000B695
		private void InternalOnRulesFailedToRespond(IntPtr thisptr)
		{
			this.m_RulesFailedToRespond();
		}

		// Token: 0x060008D4 RID: 2260 RVA: 0x0000D4A2 File Offset: 0x0000B6A2
		private void InternalOnRulesRefreshComplete(IntPtr thisptr)
		{
			this.m_RulesRefreshComplete();
		}

		// Token: 0x060008D5 RID: 2261 RVA: 0x0000D4AF File Offset: 0x0000B6AF
		public static explicit operator IntPtr(ISteamMatchmakingRulesResponse that)
		{
			return that.m_pGCHandle.AddrOfPinnedObject();
		}

		// Token: 0x04000A04 RID: 2564
		private ISteamMatchmakingRulesResponse.VTable m_VTable;

		// Token: 0x04000A05 RID: 2565
		private IntPtr m_pVTable;

		// Token: 0x04000A06 RID: 2566
		private GCHandle m_pGCHandle;

		// Token: 0x04000A07 RID: 2567
		private ISteamMatchmakingRulesResponse.RulesResponded m_RulesResponded;

		// Token: 0x04000A08 RID: 2568
		private ISteamMatchmakingRulesResponse.RulesFailedToRespond m_RulesFailedToRespond;

		// Token: 0x04000A09 RID: 2569
		private ISteamMatchmakingRulesResponse.RulesRefreshComplete m_RulesRefreshComplete;

		// Token: 0x020001E0 RID: 480
		// (Invoke) Token: 0x06000BB0 RID: 2992
		public delegate void RulesResponded(string pchRule, string pchValue);

		// Token: 0x020001E1 RID: 481
		// (Invoke) Token: 0x06000BB4 RID: 2996
		public delegate void RulesFailedToRespond();

		// Token: 0x020001E2 RID: 482
		// (Invoke) Token: 0x06000BB8 RID: 3000
		public delegate void RulesRefreshComplete();

		// Token: 0x020001E3 RID: 483
		// (Invoke) Token: 0x06000BBC RID: 3004
		[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
		public delegate void InternalRulesResponded(IntPtr thisptr, IntPtr pchRule, IntPtr pchValue);

		// Token: 0x020001E4 RID: 484
		// (Invoke) Token: 0x06000BC0 RID: 3008
		[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
		public delegate void InternalRulesFailedToRespond(IntPtr thisptr);

		// Token: 0x020001E5 RID: 485
		// (Invoke) Token: 0x06000BC4 RID: 3012
		[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
		public delegate void InternalRulesRefreshComplete(IntPtr thisptr);

		// Token: 0x020001E6 RID: 486
		[StructLayout(LayoutKind.Sequential)]
		private class VTable
		{
			// Token: 0x04000AD2 RID: 2770
			[NonSerialized]
			[MarshalAs(UnmanagedType.FunctionPtr)]
			public ISteamMatchmakingRulesResponse.InternalRulesResponded m_VTRulesResponded;

			// Token: 0x04000AD3 RID: 2771
			[NonSerialized]
			[MarshalAs(UnmanagedType.FunctionPtr)]
			public ISteamMatchmakingRulesResponse.InternalRulesFailedToRespond m_VTRulesFailedToRespond;

			// Token: 0x04000AD4 RID: 2772
			[NonSerialized]
			[MarshalAs(UnmanagedType.FunctionPtr)]
			public ISteamMatchmakingRulesResponse.InternalRulesRefreshComplete m_VTRulesRefreshComplete;
		}
	}
}
