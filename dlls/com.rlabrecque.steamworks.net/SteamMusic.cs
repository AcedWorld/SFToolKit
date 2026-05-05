using System;

namespace Steamworks
{
	// Token: 0x02000019 RID: 25
	public static class SteamMusic
	{
		// Token: 0x060002E9 RID: 745 RVA: 0x000085ED File Offset: 0x000067ED
		public static bool BIsEnabled()
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamMusic_BIsEnabled(CSteamAPIContext.GetSteamMusic());
		}

		// Token: 0x060002EA RID: 746 RVA: 0x000085FE File Offset: 0x000067FE
		public static bool BIsPlaying()
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamMusic_BIsPlaying(CSteamAPIContext.GetSteamMusic());
		}

		// Token: 0x060002EB RID: 747 RVA: 0x0000860F File Offset: 0x0000680F
		public static AudioPlayback_Status GetPlaybackStatus()
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamMusic_GetPlaybackStatus(CSteamAPIContext.GetSteamMusic());
		}

		// Token: 0x060002EC RID: 748 RVA: 0x00008620 File Offset: 0x00006820
		public static void Play()
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamMusic_Play(CSteamAPIContext.GetSteamMusic());
		}

		// Token: 0x060002ED RID: 749 RVA: 0x00008631 File Offset: 0x00006831
		public static void Pause()
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamMusic_Pause(CSteamAPIContext.GetSteamMusic());
		}

		// Token: 0x060002EE RID: 750 RVA: 0x00008642 File Offset: 0x00006842
		public static void PlayPrevious()
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamMusic_PlayPrevious(CSteamAPIContext.GetSteamMusic());
		}

		// Token: 0x060002EF RID: 751 RVA: 0x00008653 File Offset: 0x00006853
		public static void PlayNext()
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamMusic_PlayNext(CSteamAPIContext.GetSteamMusic());
		}

		// Token: 0x060002F0 RID: 752 RVA: 0x00008664 File Offset: 0x00006864
		public static void SetVolume(float flVolume)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamMusic_SetVolume(CSteamAPIContext.GetSteamMusic(), flVolume);
		}

		// Token: 0x060002F1 RID: 753 RVA: 0x00008676 File Offset: 0x00006876
		public static float GetVolume()
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamMusic_GetVolume(CSteamAPIContext.GetSteamMusic());
		}
	}
}
