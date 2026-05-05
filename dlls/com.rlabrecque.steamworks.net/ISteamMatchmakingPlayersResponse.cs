using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000183 RID: 387
	public class ISteamMatchmakingPlayersResponse
	{
		// Token: 0x060008CA RID: 2250 RVA: 0x0000D20C File Offset: 0x0000B40C
		public ISteamMatchmakingPlayersResponse(ISteamMatchmakingPlayersResponse.AddPlayerToList onAddPlayerToList, ISteamMatchmakingPlayersResponse.PlayersFailedToRespond onPlayersFailedToRespond, ISteamMatchmakingPlayersResponse.PlayersRefreshComplete onPlayersRefreshComplete)
		{
			if (onAddPlayerToList == null || onPlayersFailedToRespond == null || onPlayersRefreshComplete == null)
			{
				throw new ArgumentNullException();
			}
			this.m_AddPlayerToList = onAddPlayerToList;
			this.m_PlayersFailedToRespond = onPlayersFailedToRespond;
			this.m_PlayersRefreshComplete = onPlayersRefreshComplete;
			this.m_VTable = new ISteamMatchmakingPlayersResponse.VTable
			{
				m_VTAddPlayerToList = new ISteamMatchmakingPlayersResponse.InternalAddPlayerToList(this.InternalOnAddPlayerToList),
				m_VTPlayersFailedToRespond = new ISteamMatchmakingPlayersResponse.InternalPlayersFailedToRespond(this.InternalOnPlayersFailedToRespond),
				m_VTPlayersRefreshComplete = new ISteamMatchmakingPlayersResponse.InternalPlayersRefreshComplete(this.InternalOnPlayersRefreshComplete)
			};
			this.m_pVTable = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(ISteamMatchmakingPlayersResponse.VTable)));
			Marshal.StructureToPtr<ISteamMatchmakingPlayersResponse.VTable>(this.m_VTable, this.m_pVTable, false);
			this.m_pGCHandle = GCHandle.Alloc(this.m_pVTable, GCHandleType.Pinned);
		}

		// Token: 0x060008CB RID: 2251 RVA: 0x0000D2C8 File Offset: 0x0000B4C8
		~ISteamMatchmakingPlayersResponse()
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

		// Token: 0x060008CC RID: 2252 RVA: 0x0000D324 File Offset: 0x0000B524
		private void InternalOnAddPlayerToList(IntPtr thisptr, IntPtr pchName, int nScore, float flTimePlayed)
		{
			this.m_AddPlayerToList(InteropHelp.PtrToStringUTF8(pchName), nScore, flTimePlayed);
		}

		// Token: 0x060008CD RID: 2253 RVA: 0x0000D33A File Offset: 0x0000B53A
		private void InternalOnPlayersFailedToRespond(IntPtr thisptr)
		{
			this.m_PlayersFailedToRespond();
		}

		// Token: 0x060008CE RID: 2254 RVA: 0x0000D347 File Offset: 0x0000B547
		private void InternalOnPlayersRefreshComplete(IntPtr thisptr)
		{
			this.m_PlayersRefreshComplete();
		}

		// Token: 0x060008CF RID: 2255 RVA: 0x0000D354 File Offset: 0x0000B554
		public static explicit operator IntPtr(ISteamMatchmakingPlayersResponse that)
		{
			return that.m_pGCHandle.AddrOfPinnedObject();
		}

		// Token: 0x040009FE RID: 2558
		private ISteamMatchmakingPlayersResponse.VTable m_VTable;

		// Token: 0x040009FF RID: 2559
		private IntPtr m_pVTable;

		// Token: 0x04000A00 RID: 2560
		private GCHandle m_pGCHandle;

		// Token: 0x04000A01 RID: 2561
		private ISteamMatchmakingPlayersResponse.AddPlayerToList m_AddPlayerToList;

		// Token: 0x04000A02 RID: 2562
		private ISteamMatchmakingPlayersResponse.PlayersFailedToRespond m_PlayersFailedToRespond;

		// Token: 0x04000A03 RID: 2563
		private ISteamMatchmakingPlayersResponse.PlayersRefreshComplete m_PlayersRefreshComplete;

		// Token: 0x020001D9 RID: 473
		// (Invoke) Token: 0x06000B97 RID: 2967
		public delegate void AddPlayerToList(string pchName, int nScore, float flTimePlayed);

		// Token: 0x020001DA RID: 474
		// (Invoke) Token: 0x06000B9B RID: 2971
		public delegate void PlayersFailedToRespond();

		// Token: 0x020001DB RID: 475
		// (Invoke) Token: 0x06000B9F RID: 2975
		public delegate void PlayersRefreshComplete();

		// Token: 0x020001DC RID: 476
		// (Invoke) Token: 0x06000BA3 RID: 2979
		[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
		public delegate void InternalAddPlayerToList(IntPtr thisptr, IntPtr pchName, int nScore, float flTimePlayed);

		// Token: 0x020001DD RID: 477
		// (Invoke) Token: 0x06000BA7 RID: 2983
		[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
		public delegate void InternalPlayersFailedToRespond(IntPtr thisptr);

		// Token: 0x020001DE RID: 478
		// (Invoke) Token: 0x06000BAB RID: 2987
		[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
		public delegate void InternalPlayersRefreshComplete(IntPtr thisptr);

		// Token: 0x020001DF RID: 479
		[StructLayout(LayoutKind.Sequential)]
		private class VTable
		{
			// Token: 0x04000ACF RID: 2767
			[NonSerialized]
			[MarshalAs(UnmanagedType.FunctionPtr)]
			public ISteamMatchmakingPlayersResponse.InternalAddPlayerToList m_VTAddPlayerToList;

			// Token: 0x04000AD0 RID: 2768
			[NonSerialized]
			[MarshalAs(UnmanagedType.FunctionPtr)]
			public ISteamMatchmakingPlayersResponse.InternalPlayersFailedToRespond m_VTPlayersFailedToRespond;

			// Token: 0x04000AD1 RID: 2769
			[NonSerialized]
			[MarshalAs(UnmanagedType.FunctionPtr)]
			public ISteamMatchmakingPlayersResponse.InternalPlayersRefreshComplete m_VTPlayersRefreshComplete;
		}
	}
}
