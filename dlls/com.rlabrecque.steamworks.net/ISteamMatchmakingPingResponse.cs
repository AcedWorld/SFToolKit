using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000182 RID: 386
	public class ISteamMatchmakingPingResponse
	{
		// Token: 0x060008C5 RID: 2245 RVA: 0x0000D0E8 File Offset: 0x0000B2E8
		public ISteamMatchmakingPingResponse(ISteamMatchmakingPingResponse.ServerResponded onServerResponded, ISteamMatchmakingPingResponse.ServerFailedToRespond onServerFailedToRespond)
		{
			if (onServerResponded == null || onServerFailedToRespond == null)
			{
				throw new ArgumentNullException();
			}
			this.m_ServerResponded = onServerResponded;
			this.m_ServerFailedToRespond = onServerFailedToRespond;
			this.m_VTable = new ISteamMatchmakingPingResponse.VTable
			{
				m_VTServerResponded = new ISteamMatchmakingPingResponse.InternalServerResponded(this.InternalOnServerResponded),
				m_VTServerFailedToRespond = new ISteamMatchmakingPingResponse.InternalServerFailedToRespond(this.InternalOnServerFailedToRespond)
			};
			this.m_pVTable = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(ISteamMatchmakingPingResponse.VTable)));
			Marshal.StructureToPtr<ISteamMatchmakingPingResponse.VTable>(this.m_VTable, this.m_pVTable, false);
			this.m_pGCHandle = GCHandle.Alloc(this.m_pVTable, GCHandleType.Pinned);
		}

		// Token: 0x060008C6 RID: 2246 RVA: 0x0000D188 File Offset: 0x0000B388
		~ISteamMatchmakingPingResponse()
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

		// Token: 0x060008C7 RID: 2247 RVA: 0x0000D1E4 File Offset: 0x0000B3E4
		private void InternalOnServerResponded(IntPtr thisptr, gameserveritem_t server)
		{
			this.m_ServerResponded(server);
		}

		// Token: 0x060008C8 RID: 2248 RVA: 0x0000D1F2 File Offset: 0x0000B3F2
		private void InternalOnServerFailedToRespond(IntPtr thisptr)
		{
			this.m_ServerFailedToRespond();
		}

		// Token: 0x060008C9 RID: 2249 RVA: 0x0000D1FF File Offset: 0x0000B3FF
		public static explicit operator IntPtr(ISteamMatchmakingPingResponse that)
		{
			return that.m_pGCHandle.AddrOfPinnedObject();
		}

		// Token: 0x040009F9 RID: 2553
		private ISteamMatchmakingPingResponse.VTable m_VTable;

		// Token: 0x040009FA RID: 2554
		private IntPtr m_pVTable;

		// Token: 0x040009FB RID: 2555
		private GCHandle m_pGCHandle;

		// Token: 0x040009FC RID: 2556
		private ISteamMatchmakingPingResponse.ServerResponded m_ServerResponded;

		// Token: 0x040009FD RID: 2557
		private ISteamMatchmakingPingResponse.ServerFailedToRespond m_ServerFailedToRespond;

		// Token: 0x020001D4 RID: 468
		// (Invoke) Token: 0x06000B86 RID: 2950
		public delegate void ServerResponded(gameserveritem_t server);

		// Token: 0x020001D5 RID: 469
		// (Invoke) Token: 0x06000B8A RID: 2954
		public delegate void ServerFailedToRespond();

		// Token: 0x020001D6 RID: 470
		// (Invoke) Token: 0x06000B8E RID: 2958
		[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
		private delegate void InternalServerResponded(IntPtr thisptr, gameserveritem_t server);

		// Token: 0x020001D7 RID: 471
		// (Invoke) Token: 0x06000B92 RID: 2962
		[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
		private delegate void InternalServerFailedToRespond(IntPtr thisptr);

		// Token: 0x020001D8 RID: 472
		[StructLayout(LayoutKind.Sequential)]
		private class VTable
		{
			// Token: 0x04000ACD RID: 2765
			[NonSerialized]
			[MarshalAs(UnmanagedType.FunctionPtr)]
			public ISteamMatchmakingPingResponse.InternalServerResponded m_VTServerResponded;

			// Token: 0x04000ACE RID: 2766
			[NonSerialized]
			[MarshalAs(UnmanagedType.FunctionPtr)]
			public ISteamMatchmakingPingResponse.InternalServerFailedToRespond m_VTServerFailedToRespond;
		}
	}
}
