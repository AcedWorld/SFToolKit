using System;

namespace Steamworks
{
	// Token: 0x0200001A RID: 26
	public static class SteamMusicRemote
	{
		// Token: 0x060002F2 RID: 754 RVA: 0x00008688 File Offset: 0x00006888
		public static bool RegisterSteamMusicRemote(string pchName)
		{
			InteropHelp.TestIfAvailableClient();
			bool result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchName))
			{
				result = NativeMethods.ISteamMusicRemote_RegisterSteamMusicRemote(CSteamAPIContext.GetSteamMusicRemote(), utf8StringHandle);
			}
			return result;
		}

		// Token: 0x060002F3 RID: 755 RVA: 0x000086CC File Offset: 0x000068CC
		public static bool DeregisterSteamMusicRemote()
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamMusicRemote_DeregisterSteamMusicRemote(CSteamAPIContext.GetSteamMusicRemote());
		}

		// Token: 0x060002F4 RID: 756 RVA: 0x000086DD File Offset: 0x000068DD
		public static bool BIsCurrentMusicRemote()
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamMusicRemote_BIsCurrentMusicRemote(CSteamAPIContext.GetSteamMusicRemote());
		}

		// Token: 0x060002F5 RID: 757 RVA: 0x000086EE File Offset: 0x000068EE
		public static bool BActivationSuccess(bool bValue)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamMusicRemote_BActivationSuccess(CSteamAPIContext.GetSteamMusicRemote(), bValue);
		}

		// Token: 0x060002F6 RID: 758 RVA: 0x00008700 File Offset: 0x00006900
		public static bool SetDisplayName(string pchDisplayName)
		{
			InteropHelp.TestIfAvailableClient();
			bool result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchDisplayName))
			{
				result = NativeMethods.ISteamMusicRemote_SetDisplayName(CSteamAPIContext.GetSteamMusicRemote(), utf8StringHandle);
			}
			return result;
		}

		// Token: 0x060002F7 RID: 759 RVA: 0x00008744 File Offset: 0x00006944
		public static bool SetPNGIcon_64x64(byte[] pvBuffer, uint cbBufferLength)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamMusicRemote_SetPNGIcon_64x64(CSteamAPIContext.GetSteamMusicRemote(), pvBuffer, cbBufferLength);
		}

		// Token: 0x060002F8 RID: 760 RVA: 0x00008757 File Offset: 0x00006957
		public static bool EnablePlayPrevious(bool bValue)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamMusicRemote_EnablePlayPrevious(CSteamAPIContext.GetSteamMusicRemote(), bValue);
		}

		// Token: 0x060002F9 RID: 761 RVA: 0x00008769 File Offset: 0x00006969
		public static bool EnablePlayNext(bool bValue)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamMusicRemote_EnablePlayNext(CSteamAPIContext.GetSteamMusicRemote(), bValue);
		}

		// Token: 0x060002FA RID: 762 RVA: 0x0000877B File Offset: 0x0000697B
		public static bool EnableShuffled(bool bValue)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamMusicRemote_EnableShuffled(CSteamAPIContext.GetSteamMusicRemote(), bValue);
		}

		// Token: 0x060002FB RID: 763 RVA: 0x0000878D File Offset: 0x0000698D
		public static bool EnableLooped(bool bValue)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamMusicRemote_EnableLooped(CSteamAPIContext.GetSteamMusicRemote(), bValue);
		}

		// Token: 0x060002FC RID: 764 RVA: 0x0000879F File Offset: 0x0000699F
		public static bool EnableQueue(bool bValue)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamMusicRemote_EnableQueue(CSteamAPIContext.GetSteamMusicRemote(), bValue);
		}

		// Token: 0x060002FD RID: 765 RVA: 0x000087B1 File Offset: 0x000069B1
		public static bool EnablePlaylists(bool bValue)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamMusicRemote_EnablePlaylists(CSteamAPIContext.GetSteamMusicRemote(), bValue);
		}

		// Token: 0x060002FE RID: 766 RVA: 0x000087C3 File Offset: 0x000069C3
		public static bool UpdatePlaybackStatus(AudioPlayback_Status nStatus)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamMusicRemote_UpdatePlaybackStatus(CSteamAPIContext.GetSteamMusicRemote(), nStatus);
		}

		// Token: 0x060002FF RID: 767 RVA: 0x000087D5 File Offset: 0x000069D5
		public static bool UpdateShuffled(bool bValue)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamMusicRemote_UpdateShuffled(CSteamAPIContext.GetSteamMusicRemote(), bValue);
		}

		// Token: 0x06000300 RID: 768 RVA: 0x000087E7 File Offset: 0x000069E7
		public static bool UpdateLooped(bool bValue)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamMusicRemote_UpdateLooped(CSteamAPIContext.GetSteamMusicRemote(), bValue);
		}

		// Token: 0x06000301 RID: 769 RVA: 0x000087F9 File Offset: 0x000069F9
		public static bool UpdateVolume(float flValue)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamMusicRemote_UpdateVolume(CSteamAPIContext.GetSteamMusicRemote(), flValue);
		}

		// Token: 0x06000302 RID: 770 RVA: 0x0000880B File Offset: 0x00006A0B
		public static bool CurrentEntryWillChange()
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamMusicRemote_CurrentEntryWillChange(CSteamAPIContext.GetSteamMusicRemote());
		}

		// Token: 0x06000303 RID: 771 RVA: 0x0000881C File Offset: 0x00006A1C
		public static bool CurrentEntryIsAvailable(bool bAvailable)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamMusicRemote_CurrentEntryIsAvailable(CSteamAPIContext.GetSteamMusicRemote(), bAvailable);
		}

		// Token: 0x06000304 RID: 772 RVA: 0x00008830 File Offset: 0x00006A30
		public static bool UpdateCurrentEntryText(string pchText)
		{
			InteropHelp.TestIfAvailableClient();
			bool result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchText))
			{
				result = NativeMethods.ISteamMusicRemote_UpdateCurrentEntryText(CSteamAPIContext.GetSteamMusicRemote(), utf8StringHandle);
			}
			return result;
		}

		// Token: 0x06000305 RID: 773 RVA: 0x00008874 File Offset: 0x00006A74
		public static bool UpdateCurrentEntryElapsedSeconds(int nValue)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamMusicRemote_UpdateCurrentEntryElapsedSeconds(CSteamAPIContext.GetSteamMusicRemote(), nValue);
		}

		// Token: 0x06000306 RID: 774 RVA: 0x00008886 File Offset: 0x00006A86
		public static bool UpdateCurrentEntryCoverArt(byte[] pvBuffer, uint cbBufferLength)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamMusicRemote_UpdateCurrentEntryCoverArt(CSteamAPIContext.GetSteamMusicRemote(), pvBuffer, cbBufferLength);
		}

		// Token: 0x06000307 RID: 775 RVA: 0x00008899 File Offset: 0x00006A99
		public static bool CurrentEntryDidChange()
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamMusicRemote_CurrentEntryDidChange(CSteamAPIContext.GetSteamMusicRemote());
		}

		// Token: 0x06000308 RID: 776 RVA: 0x000088AA File Offset: 0x00006AAA
		public static bool QueueWillChange()
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamMusicRemote_QueueWillChange(CSteamAPIContext.GetSteamMusicRemote());
		}

		// Token: 0x06000309 RID: 777 RVA: 0x000088BB File Offset: 0x00006ABB
		public static bool ResetQueueEntries()
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamMusicRemote_ResetQueueEntries(CSteamAPIContext.GetSteamMusicRemote());
		}

		// Token: 0x0600030A RID: 778 RVA: 0x000088CC File Offset: 0x00006ACC
		public static bool SetQueueEntry(int nID, int nPosition, string pchEntryText)
		{
			InteropHelp.TestIfAvailableClient();
			bool result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchEntryText))
			{
				result = NativeMethods.ISteamMusicRemote_SetQueueEntry(CSteamAPIContext.GetSteamMusicRemote(), nID, nPosition, utf8StringHandle);
			}
			return result;
		}

		// Token: 0x0600030B RID: 779 RVA: 0x00008910 File Offset: 0x00006B10
		public static bool SetCurrentQueueEntry(int nID)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamMusicRemote_SetCurrentQueueEntry(CSteamAPIContext.GetSteamMusicRemote(), nID);
		}

		// Token: 0x0600030C RID: 780 RVA: 0x00008922 File Offset: 0x00006B22
		public static bool QueueDidChange()
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamMusicRemote_QueueDidChange(CSteamAPIContext.GetSteamMusicRemote());
		}

		// Token: 0x0600030D RID: 781 RVA: 0x00008933 File Offset: 0x00006B33
		public static bool PlaylistWillChange()
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamMusicRemote_PlaylistWillChange(CSteamAPIContext.GetSteamMusicRemote());
		}

		// Token: 0x0600030E RID: 782 RVA: 0x00008944 File Offset: 0x00006B44
		public static bool ResetPlaylistEntries()
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamMusicRemote_ResetPlaylistEntries(CSteamAPIContext.GetSteamMusicRemote());
		}

		// Token: 0x0600030F RID: 783 RVA: 0x00008958 File Offset: 0x00006B58
		public static bool SetPlaylistEntry(int nID, int nPosition, string pchEntryText)
		{
			InteropHelp.TestIfAvailableClient();
			bool result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchEntryText))
			{
				result = NativeMethods.ISteamMusicRemote_SetPlaylistEntry(CSteamAPIContext.GetSteamMusicRemote(), nID, nPosition, utf8StringHandle);
			}
			return result;
		}

		// Token: 0x06000310 RID: 784 RVA: 0x0000899C File Offset: 0x00006B9C
		public static bool SetCurrentPlaylistEntry(int nID)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamMusicRemote_SetCurrentPlaylistEntry(CSteamAPIContext.GetSteamMusicRemote(), nID);
		}

		// Token: 0x06000311 RID: 785 RVA: 0x000089AE File Offset: 0x00006BAE
		public static bool PlaylistDidChange()
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamMusicRemote_PlaylistDidChange(CSteamAPIContext.GetSteamMusicRemote());
		}
	}
}
