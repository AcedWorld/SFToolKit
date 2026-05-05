using System;
using System.Runtime.InteropServices;

namespace Rewired.Libraries.SharpDX.Windows.Forms
{
	// Token: 0x02000233 RID: 563
	[ComVisible(true)]
	internal enum Keys
	{
		// Token: 0x040028F9 RID: 10489
		KeyCode = 65535,
		// Token: 0x040028FA RID: 10490
		Modifiers = -65536,
		// Token: 0x040028FB RID: 10491
		None = 0,
		// Token: 0x040028FC RID: 10492
		LButton,
		// Token: 0x040028FD RID: 10493
		RButton,
		// Token: 0x040028FE RID: 10494
		Cancel,
		// Token: 0x040028FF RID: 10495
		MButton,
		// Token: 0x04002900 RID: 10496
		XButton1,
		// Token: 0x04002901 RID: 10497
		XButton2,
		// Token: 0x04002902 RID: 10498
		Back = 8,
		// Token: 0x04002903 RID: 10499
		Tab,
		// Token: 0x04002904 RID: 10500
		LineFeed,
		// Token: 0x04002905 RID: 10501
		Clear = 12,
		// Token: 0x04002906 RID: 10502
		Return,
		// Token: 0x04002907 RID: 10503
		Enter = 13,
		// Token: 0x04002908 RID: 10504
		ShiftKey = 16,
		// Token: 0x04002909 RID: 10505
		ControlKey,
		// Token: 0x0400290A RID: 10506
		Menu,
		// Token: 0x0400290B RID: 10507
		Pause,
		// Token: 0x0400290C RID: 10508
		Capital,
		// Token: 0x0400290D RID: 10509
		CapsLock = 20,
		// Token: 0x0400290E RID: 10510
		KanaMode,
		// Token: 0x0400290F RID: 10511
		HanguelMode = 21,
		// Token: 0x04002910 RID: 10512
		HangulMode = 21,
		// Token: 0x04002911 RID: 10513
		JunjaMode = 23,
		// Token: 0x04002912 RID: 10514
		FinalMode,
		// Token: 0x04002913 RID: 10515
		HanjaMode,
		// Token: 0x04002914 RID: 10516
		KanjiMode = 25,
		// Token: 0x04002915 RID: 10517
		Escape = 27,
		// Token: 0x04002916 RID: 10518
		IMEConvert,
		// Token: 0x04002917 RID: 10519
		IMENonconvert,
		// Token: 0x04002918 RID: 10520
		IMEAccept,
		// Token: 0x04002919 RID: 10521
		IMEAceept = 30,
		// Token: 0x0400291A RID: 10522
		IMEModeChange,
		// Token: 0x0400291B RID: 10523
		Space,
		// Token: 0x0400291C RID: 10524
		Prior,
		// Token: 0x0400291D RID: 10525
		PageUp = 33,
		// Token: 0x0400291E RID: 10526
		Next,
		// Token: 0x0400291F RID: 10527
		PageDown = 34,
		// Token: 0x04002920 RID: 10528
		End,
		// Token: 0x04002921 RID: 10529
		Home,
		// Token: 0x04002922 RID: 10530
		Left,
		// Token: 0x04002923 RID: 10531
		Up,
		// Token: 0x04002924 RID: 10532
		Right,
		// Token: 0x04002925 RID: 10533
		Down,
		// Token: 0x04002926 RID: 10534
		Select,
		// Token: 0x04002927 RID: 10535
		Print,
		// Token: 0x04002928 RID: 10536
		Execute,
		// Token: 0x04002929 RID: 10537
		Snapshot,
		// Token: 0x0400292A RID: 10538
		PrintScreen = 44,
		// Token: 0x0400292B RID: 10539
		Insert,
		// Token: 0x0400292C RID: 10540
		Delete,
		// Token: 0x0400292D RID: 10541
		Help,
		// Token: 0x0400292E RID: 10542
		D0,
		// Token: 0x0400292F RID: 10543
		D1,
		// Token: 0x04002930 RID: 10544
		D2,
		// Token: 0x04002931 RID: 10545
		D3,
		// Token: 0x04002932 RID: 10546
		D4,
		// Token: 0x04002933 RID: 10547
		D5,
		// Token: 0x04002934 RID: 10548
		D6,
		// Token: 0x04002935 RID: 10549
		D7,
		// Token: 0x04002936 RID: 10550
		D8,
		// Token: 0x04002937 RID: 10551
		D9,
		// Token: 0x04002938 RID: 10552
		A = 65,
		// Token: 0x04002939 RID: 10553
		B,
		// Token: 0x0400293A RID: 10554
		C,
		// Token: 0x0400293B RID: 10555
		D,
		// Token: 0x0400293C RID: 10556
		E,
		// Token: 0x0400293D RID: 10557
		F,
		// Token: 0x0400293E RID: 10558
		G,
		// Token: 0x0400293F RID: 10559
		H,
		// Token: 0x04002940 RID: 10560
		I,
		// Token: 0x04002941 RID: 10561
		J,
		// Token: 0x04002942 RID: 10562
		K,
		// Token: 0x04002943 RID: 10563
		L,
		// Token: 0x04002944 RID: 10564
		M,
		// Token: 0x04002945 RID: 10565
		N,
		// Token: 0x04002946 RID: 10566
		O,
		// Token: 0x04002947 RID: 10567
		P,
		// Token: 0x04002948 RID: 10568
		Q,
		// Token: 0x04002949 RID: 10569
		R,
		// Token: 0x0400294A RID: 10570
		S,
		// Token: 0x0400294B RID: 10571
		T,
		// Token: 0x0400294C RID: 10572
		U,
		// Token: 0x0400294D RID: 10573
		V,
		// Token: 0x0400294E RID: 10574
		W,
		// Token: 0x0400294F RID: 10575
		X,
		// Token: 0x04002950 RID: 10576
		Y,
		// Token: 0x04002951 RID: 10577
		Z,
		// Token: 0x04002952 RID: 10578
		LWin,
		// Token: 0x04002953 RID: 10579
		RWin,
		// Token: 0x04002954 RID: 10580
		Apps,
		// Token: 0x04002955 RID: 10581
		Sleep = 95,
		// Token: 0x04002956 RID: 10582
		NumPad0,
		// Token: 0x04002957 RID: 10583
		NumPad1,
		// Token: 0x04002958 RID: 10584
		NumPad2,
		// Token: 0x04002959 RID: 10585
		NumPad3,
		// Token: 0x0400295A RID: 10586
		NumPad4,
		// Token: 0x0400295B RID: 10587
		NumPad5,
		// Token: 0x0400295C RID: 10588
		NumPad6,
		// Token: 0x0400295D RID: 10589
		NumPad7,
		// Token: 0x0400295E RID: 10590
		NumPad8,
		// Token: 0x0400295F RID: 10591
		NumPad9,
		// Token: 0x04002960 RID: 10592
		Multiply,
		// Token: 0x04002961 RID: 10593
		Add,
		// Token: 0x04002962 RID: 10594
		Separator,
		// Token: 0x04002963 RID: 10595
		Subtract,
		// Token: 0x04002964 RID: 10596
		Decimal,
		// Token: 0x04002965 RID: 10597
		Divide,
		// Token: 0x04002966 RID: 10598
		F1,
		// Token: 0x04002967 RID: 10599
		F2,
		// Token: 0x04002968 RID: 10600
		F3,
		// Token: 0x04002969 RID: 10601
		F4,
		// Token: 0x0400296A RID: 10602
		F5,
		// Token: 0x0400296B RID: 10603
		F6,
		// Token: 0x0400296C RID: 10604
		F7,
		// Token: 0x0400296D RID: 10605
		F8,
		// Token: 0x0400296E RID: 10606
		F9,
		// Token: 0x0400296F RID: 10607
		F10,
		// Token: 0x04002970 RID: 10608
		F11,
		// Token: 0x04002971 RID: 10609
		F12,
		// Token: 0x04002972 RID: 10610
		F13,
		// Token: 0x04002973 RID: 10611
		F14,
		// Token: 0x04002974 RID: 10612
		F15,
		// Token: 0x04002975 RID: 10613
		F16,
		// Token: 0x04002976 RID: 10614
		F17,
		// Token: 0x04002977 RID: 10615
		F18,
		// Token: 0x04002978 RID: 10616
		F19,
		// Token: 0x04002979 RID: 10617
		F20,
		// Token: 0x0400297A RID: 10618
		F21,
		// Token: 0x0400297B RID: 10619
		F22,
		// Token: 0x0400297C RID: 10620
		F23,
		// Token: 0x0400297D RID: 10621
		F24,
		// Token: 0x0400297E RID: 10622
		NumLock = 144,
		// Token: 0x0400297F RID: 10623
		Scroll,
		// Token: 0x04002980 RID: 10624
		LShiftKey = 160,
		// Token: 0x04002981 RID: 10625
		RShiftKey,
		// Token: 0x04002982 RID: 10626
		LControlKey,
		// Token: 0x04002983 RID: 10627
		RControlKey,
		// Token: 0x04002984 RID: 10628
		LMenu,
		// Token: 0x04002985 RID: 10629
		RMenu,
		// Token: 0x04002986 RID: 10630
		BrowserBack,
		// Token: 0x04002987 RID: 10631
		BrowserForward,
		// Token: 0x04002988 RID: 10632
		BrowserRefresh,
		// Token: 0x04002989 RID: 10633
		BrowserStop,
		// Token: 0x0400298A RID: 10634
		BrowserSearch,
		// Token: 0x0400298B RID: 10635
		BrowserFavorites,
		// Token: 0x0400298C RID: 10636
		BrowserHome,
		// Token: 0x0400298D RID: 10637
		VolumeMute,
		// Token: 0x0400298E RID: 10638
		VolumeDown,
		// Token: 0x0400298F RID: 10639
		VolumeUp,
		// Token: 0x04002990 RID: 10640
		MediaNextTrack,
		// Token: 0x04002991 RID: 10641
		MediaPreviousTrack,
		// Token: 0x04002992 RID: 10642
		MediaStop,
		// Token: 0x04002993 RID: 10643
		MediaPlayPause,
		// Token: 0x04002994 RID: 10644
		LaunchMail,
		// Token: 0x04002995 RID: 10645
		SelectMedia,
		// Token: 0x04002996 RID: 10646
		LaunchApplication1,
		// Token: 0x04002997 RID: 10647
		LaunchApplication2,
		// Token: 0x04002998 RID: 10648
		OemSemicolon = 186,
		// Token: 0x04002999 RID: 10649
		Oem1 = 186,
		// Token: 0x0400299A RID: 10650
		Oemplus,
		// Token: 0x0400299B RID: 10651
		Oemcomma,
		// Token: 0x0400299C RID: 10652
		OemMinus,
		// Token: 0x0400299D RID: 10653
		OemPeriod,
		// Token: 0x0400299E RID: 10654
		OemQuestion,
		// Token: 0x0400299F RID: 10655
		Oem2 = 191,
		// Token: 0x040029A0 RID: 10656
		Oemtilde,
		// Token: 0x040029A1 RID: 10657
		Oem3 = 192,
		// Token: 0x040029A2 RID: 10658
		OemOpenBrackets = 219,
		// Token: 0x040029A3 RID: 10659
		Oem4 = 219,
		// Token: 0x040029A4 RID: 10660
		OemPipe,
		// Token: 0x040029A5 RID: 10661
		Oem5 = 220,
		// Token: 0x040029A6 RID: 10662
		OemCloseBrackets,
		// Token: 0x040029A7 RID: 10663
		Oem6 = 221,
		// Token: 0x040029A8 RID: 10664
		OemQuotes,
		// Token: 0x040029A9 RID: 10665
		Oem7 = 222,
		// Token: 0x040029AA RID: 10666
		Oem8,
		// Token: 0x040029AB RID: 10667
		OemBackslash = 226,
		// Token: 0x040029AC RID: 10668
		Oem102 = 226,
		// Token: 0x040029AD RID: 10669
		ProcessKey = 229,
		// Token: 0x040029AE RID: 10670
		Packet = 231,
		// Token: 0x040029AF RID: 10671
		Attn = 246,
		// Token: 0x040029B0 RID: 10672
		Crsel,
		// Token: 0x040029B1 RID: 10673
		Exsel,
		// Token: 0x040029B2 RID: 10674
		EraseEof,
		// Token: 0x040029B3 RID: 10675
		Play,
		// Token: 0x040029B4 RID: 10676
		Zoom,
		// Token: 0x040029B5 RID: 10677
		NoName,
		// Token: 0x040029B6 RID: 10678
		Pa1,
		// Token: 0x040029B7 RID: 10679
		OemClear,
		// Token: 0x040029B8 RID: 10680
		Shift = 65536,
		// Token: 0x040029B9 RID: 10681
		Control = 131072,
		// Token: 0x040029BA RID: 10682
		Alt = 262144
	}
}
