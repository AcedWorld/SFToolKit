using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000181 RID: 385
	public class ISteamMatchmakingServerListResponse
	{
		// Token: 0x060008BF RID: 2239 RVA: 0x0000CF24 File Offset: 0x0000B124
		public ISteamMatchmakingServerListResponse(ISteamMatchmakingServerListResponse.ServerResponded onServerResponded, ISteamMatchmakingServerListResponse.ServerFailedToRespond onServerFailedToRespond, ISteamMatchmakingServerListResponse.RefreshComplete onRefreshComplete)
		{
			if (onServerResponded == null || onServerFailedToRespond == null || onRefreshComplete == null)
			{
				throw new ArgumentNullException();
			}
			this.m_ServerResponded = onServerResponded;
			this.m_ServerFailedToRespond = onServerFailedToRespond;
			this.m_RefreshComplete = onRefreshComplete;
			this.m_VTable = new ISteamMatchmakingServerListResponse.VTable
			{
				m_VTServerResponded = new ISteamMatchmakingServerListResponse.InternalServerResponded(this.InternalOnServerResponded),
				m_VTServerFailedToRespond = new ISteamMatchmakingServerListResponse.InternalServerFailedToRespond(this.InternalOnServerFailedToRespond),
				m_VTRefreshComplete = new ISteamMatchmakingServerListResponse.InternalRefreshComplete(this.InternalOnRefreshComplete)
			};
			this.m_pVTable = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(ISteamMatchmakingServerListResponse.VTable)));
			Marshal.StructureToPtr<ISteamMatchmakingServerListResponse.VTable>(this.m_VTable, this.m_pVTable, false);
			this.m_pGCHandle = GCHandle.Alloc(this.m_pVTable, GCHandleType.Pinned);
		}

		// Token: 0x060008C0 RID: 2240 RVA: 0x0000CFE0 File Offset: 0x0000B1E0
		~ISteamMatchmakingServerListResponse()
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

		// Token: 0x060008C1 RID: 2241 RVA: 0x0000D03C File Offset: 0x0000B23C
		private void InternalOnServerResponded(IntPtr thisptr, HServerListRequest hRequest, int iServer)
		{
			try
			{
				this.m_ServerResponded(hRequest, iServer);
			}
			catch (Exception e)
			{
				CallbackDispatcher.ExceptionHandler(e);
			}
		}

		// Token: 0x060008C2 RID: 2242 RVA: 0x0000D070 File Offset: 0x0000B270
		private void InternalOnServerFailedToRespond(IntPtr thisptr, HServerListRequest hRequest, int iServer)
		{
			try
			{
				this.m_ServerFailedToRespond(hRequest, iServer);
			}
			catch (Exception e)
			{
				CallbackDispatcher.ExceptionHandler(e);
			}
		}

		// Token: 0x060008C3 RID: 2243 RVA: 0x0000D0A4 File Offset: 0x0000B2A4
		private void InternalOnRefreshComplete(IntPtr thisptr, HServerListRequest hRequest, EMatchMakingServerResponse response)
		{
			try
			{
				this.m_RefreshComplete(hRequest, response);
			}
			catch (Exception e)
			{
				CallbackDispatcher.ExceptionHandler(e);
			}
		}

		// Token: 0x060008C4 RID: 2244 RVA: 0x0000D0D8 File Offset: 0x0000B2D8
		public static explicit operator IntPtr(ISteamMatchmakingServerListResponse that)
		{
			return that.m_pGCHandle.AddrOfPinnedObject();
		}

		// Token: 0x040009F3 RID: 2547
		private ISteamMatchmakingServerListResponse.VTable m_VTable;

		// Token: 0x040009F4 RID: 2548
		private IntPtr m_pVTable;

		// Token: 0x040009F5 RID: 2549
		private GCHandle m_pGCHandle;

		// Token: 0x040009F6 RID: 2550
		private ISteamMatchmakingServerListResponse.ServerResponded m_ServerResponded;

		// Token: 0x040009F7 RID: 2551
		private ISteamMatchmakingServerListResponse.ServerFailedToRespond m_ServerFailedToRespond;

		// Token: 0x040009F8 RID: 2552
		private ISteamMatchmakingServerListResponse.RefreshComplete m_RefreshComplete;

		// Token: 0x020001CD RID: 461
		// (Invoke) Token: 0x06000B6D RID: 2925
		public delegate void ServerResponded(HServerListRequest hRequest, int iServer);

		// Token: 0x020001CE RID: 462
		// (Invoke) Token: 0x06000B71 RID: 2929
		public delegate void ServerFailedToRespond(HServerListRequest hRequest, int iServer);

		// Token: 0x020001CF RID: 463
		// (Invoke) Token: 0x06000B75 RID: 2933
		public delegate void RefreshComplete(HServerListRequest hRequest, EMatchMakingServerResponse response);

		// Token: 0x020001D0 RID: 464
		// (Invoke) Token: 0x06000B79 RID: 2937
		[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
		private delegate void InternalServerResponded(IntPtr thisptr, HServerListRequest hRequest, int iServer);

		// Token: 0x020001D1 RID: 465
		// (Invoke) Token: 0x06000B7D RID: 2941
		[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
		private delegate void InternalServerFailedToRespond(IntPtr thisptr, HServerListRequest hRequest, int iServer);

		// Token: 0x020001D2 RID: 466
		// (Invoke) Token: 0x06000B81 RID: 2945
		[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
		private delegate void InternalRefreshComplete(IntPtr thisptr, HServerListRequest hRequest, EMatchMakingServerResponse response);

		// Token: 0x020001D3 RID: 467
		[StructLayout(LayoutKind.Sequential)]
		private class VTable
		{
			// Token: 0x04000ACA RID: 2762
			[NonSerialized]
			[MarshalAs(UnmanagedType.FunctionPtr)]
			public ISteamMatchmakingServerListResponse.InternalServerResponded m_VTServerResponded;

			// Token: 0x04000ACB RID: 2763
			[NonSerialized]
			[MarshalAs(UnmanagedType.FunctionPtr)]
			public ISteamMatchmakingServerListResponse.InternalServerFailedToRespond m_VTServerFailedToRespond;

			// Token: 0x04000ACC RID: 2764
			[NonSerialized]
			[MarshalAs(UnmanagedType.FunctionPtr)]
			public ISteamMatchmakingServerListResponse.InternalRefreshComplete m_VTRefreshComplete;
		}
	}
}
