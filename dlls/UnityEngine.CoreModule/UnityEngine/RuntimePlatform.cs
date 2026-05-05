using System;

namespace UnityEngine
{
	// Token: 0x020000F8 RID: 248
	public enum RuntimePlatform
	{
		// Token: 0x040002D3 RID: 723
		OSXEditor,
		// Token: 0x040002D4 RID: 724
		OSXPlayer,
		// Token: 0x040002D5 RID: 725
		WindowsPlayer,
		// Token: 0x040002D6 RID: 726
		[Obsolete("WebPlayer export is no longer supported in Unity 5.4+.", true)]
		OSXWebPlayer,
		// Token: 0x040002D7 RID: 727
		[Obsolete("Dashboard widget on Mac OS X export is no longer supported in Unity 5.4+.", true)]
		OSXDashboardPlayer,
		// Token: 0x040002D8 RID: 728
		[Obsolete("WebPlayer export is no longer supported in Unity 5.4+.", true)]
		WindowsWebPlayer,
		// Token: 0x040002D9 RID: 729
		WindowsEditor = 7,
		// Token: 0x040002DA RID: 730
		IPhonePlayer,
		// Token: 0x040002DB RID: 731
		[Obsolete("Xbox360 export is no longer supported in Unity 5.5+.")]
		XBOX360 = 10,
		// Token: 0x040002DC RID: 732
		[Obsolete("PS3 export is no longer supported in Unity >=5.5.")]
		PS3 = 9,
		// Token: 0x040002DD RID: 733
		Android = 11,
		// Token: 0x040002DE RID: 734
		[Obsolete("NaCl export is no longer supported in Unity 5.0+.")]
		NaCl,
		// Token: 0x040002DF RID: 735
		[Obsolete("FlashPlayer export is no longer supported in Unity 5.0+.")]
		FlashPlayer = 15,
		// Token: 0x040002E0 RID: 736
		LinuxPlayer = 13,
		// Token: 0x040002E1 RID: 737
		LinuxEditor = 16,
		// Token: 0x040002E2 RID: 738
		WebGLPlayer,
		// Token: 0x040002E3 RID: 739
		[Obsolete("Use WSAPlayerX86 instead")]
		MetroPlayerX86,
		// Token: 0x040002E4 RID: 740
		WSAPlayerX86 = 18,
		// Token: 0x040002E5 RID: 741
		[Obsolete("Use WSAPlayerX64 instead")]
		MetroPlayerX64,
		// Token: 0x040002E6 RID: 742
		WSAPlayerX64 = 19,
		// Token: 0x040002E7 RID: 743
		[Obsolete("Use WSAPlayerARM instead")]
		MetroPlayerARM,
		// Token: 0x040002E8 RID: 744
		WSAPlayerARM = 20,
		// Token: 0x040002E9 RID: 745
		[Obsolete("Windows Phone 8 was removed in 5.3")]
		WP8Player,
		// Token: 0x040002EA RID: 746
		[Obsolete("BlackBerryPlayer export is no longer supported in Unity 5.4+.")]
		BlackBerryPlayer,
		// Token: 0x040002EB RID: 747
		[Obsolete("TizenPlayer export is no longer supported in Unity 2017.3+.")]
		TizenPlayer,
		// Token: 0x040002EC RID: 748
		[Obsolete("PSP2 is no longer supported as of Unity 2018.3")]
		PSP2,
		// Token: 0x040002ED RID: 749
		PS4,
		// Token: 0x040002EE RID: 750
		[Obsolete("PSM export is no longer supported in Unity >= 5.3")]
		PSM,
		// Token: 0x040002EF RID: 751
		XboxOne,
		// Token: 0x040002F0 RID: 752
		[Obsolete("SamsungTVPlayer export is no longer supported in Unity 2017.3+.")]
		SamsungTVPlayer,
		// Token: 0x040002F1 RID: 753
		[Obsolete("Wii U is no longer supported in Unity 2018.1+.")]
		WiiU = 30,
		// Token: 0x040002F2 RID: 754
		tvOS,
		// Token: 0x040002F3 RID: 755
		Switch,
		// Token: 0x040002F4 RID: 756
		[Obsolete("Lumin is no longer supported in Unity 2022.2")]
		Lumin,
		// Token: 0x040002F5 RID: 757
		Stadia,
		// Token: 0x040002F6 RID: 758
		[Obsolete("Use LinuxPlayer instead")]
		CloudRendering,
		// Token: 0x040002F7 RID: 759
		[Obsolete("GameCoreScarlett is deprecated, please use GameCoreXboxSeries (UnityUpgradable) -> GameCoreXboxSeries", false)]
		GameCoreScarlett = -1,
		// Token: 0x040002F8 RID: 760
		GameCoreXboxSeries = 36,
		// Token: 0x040002F9 RID: 761
		GameCoreXboxOne,
		// Token: 0x040002FA RID: 762
		PS5,
		// Token: 0x040002FB RID: 763
		EmbeddedLinuxArm64,
		// Token: 0x040002FC RID: 764
		EmbeddedLinuxArm32,
		// Token: 0x040002FD RID: 765
		EmbeddedLinuxX64,
		// Token: 0x040002FE RID: 766
		EmbeddedLinuxX86,
		// Token: 0x040002FF RID: 767
		LinuxServer,
		// Token: 0x04000300 RID: 768
		WindowsServer,
		// Token: 0x04000301 RID: 769
		OSXServer,
		// Token: 0x04000302 RID: 770
		QNXArm32,
		// Token: 0x04000303 RID: 771
		QNXArm64,
		// Token: 0x04000304 RID: 772
		QNXX64,
		// Token: 0x04000305 RID: 773
		QNXX86,
		// Token: 0x04000306 RID: 774
		VisionOS
	}
}
