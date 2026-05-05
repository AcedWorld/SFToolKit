using System;
using System.Runtime.InteropServices;
using Rewired.Utils;

// Token: 0x02000035 RID: 53
internal static class aZbrTJbdkEqNgMSlZADNlszSrpmR
{
	// Token: 0x0600023E RID: 574
	[DllImport("bthprops.cpl", EntryPoint = "BluetoothDisplayDeviceProperties", SetLastError = true)]
	public static extern bool McadXfFdTVSfxrMEBhyQYHJLobWib(IntPtr, ref aZbrTJbdkEqNgMSlZADNlszSrpmR.vCxDyydNFJNMDqHSEqWWufpOoHJUA);

	// Token: 0x0600023F RID: 575
	[DllImport("bthprops.cpl", EntryPoint = "BluetoothFindFirstDevice", SetLastError = true)]
	public static extern IntPtr EomKHPjrBmopuxcJOhvjiYYPfwUT(ref aZbrTJbdkEqNgMSlZADNlszSrpmR.AnIursTJiGuiIahXHibSRdYFdKfZ, ref aZbrTJbdkEqNgMSlZADNlszSrpmR.vCxDyydNFJNMDqHSEqWWufpOoHJUA);

	// Token: 0x06000240 RID: 576
	[DllImport("bthprops.cpl", EntryPoint = "BluetoothFindFirstDevice", SetLastError = true)]
	public static extern IntPtr paDAioGPJhTWjBYebXPrTmACOXGF(ref aZbrTJbdkEqNgMSlZADNlszSrpmR.AnIursTJiGuiIahXHibSRdYFdKfZ, IntPtr);

	// Token: 0x06000241 RID: 577
	[DllImport("bthprops.cpl", EntryPoint = "BluetoothFindNextDevice", SetLastError = true)]
	public static extern bool IkFkMtkdenEmWhullKMjhcFMIAcV(IntPtr, ref aZbrTJbdkEqNgMSlZADNlszSrpmR.vCxDyydNFJNMDqHSEqWWufpOoHJUA);

	// Token: 0x06000242 RID: 578
	[DllImport("bthprops.cpl", EntryPoint = "BluetoothFindNextDevice", SetLastError = true)]
	public static extern bool MsAJGcATiDFVsodwijZXlcbOxqyn(IntPtr, IntPtr);

	// Token: 0x06000243 RID: 579
	[DllImport("bthprops.cpl", EntryPoint = "BluetoothFindDeviceClose", SetLastError = true)]
	public static extern bool zjNdeVOudKBFlOLOJifersFeZMgT(IntPtr);

	// Token: 0x06000244 RID: 580
	[DllImport("bthprops.cpl", EntryPoint = "BluetoothGetDeviceInfo", SetLastError = true)]
	public static extern uint iIFylnNWrkcTeEeTJOinoFehdozT(IntPtr, ref aZbrTJbdkEqNgMSlZADNlszSrpmR.vCxDyydNFJNMDqHSEqWWufpOoHJUA);

	// Token: 0x06000245 RID: 581
	[DllImport("bthprops.cpl", EntryPoint = "BluetoothIsConnectable", SetLastError = true)]
	public static extern bool yhSFamIfsfBvVmLyyAvQwKvJtXmJ(IntPtr);

	// Token: 0x06000246 RID: 582
	[DllImport("bthprops.cpl", EntryPoint = "BluetoothIsDiscoverable", SetLastError = true)]
	public static extern bool irWqBHaeMbDNypjwzQXyCbckhSvt(IntPtr);

	// Token: 0x06000247 RID: 583
	[DllImport("bthprops.cpl", EntryPoint = "BluetoothIsVersionAvailable", SetLastError = true)]
	public static extern bool gUKLJmoEvJQFddyyalxOZVWuKSJh(byte, byte);

	// Token: 0x06000248 RID: 584
	[DllImport("bthprops.cpl", EntryPoint = "BluetoothUpdateDeviceRecord", SetLastError = true)]
	public static extern uint AyIMxkqroxXaEJoXGaEFHGOBkoCc(ref aZbrTJbdkEqNgMSlZADNlszSrpmR.vCxDyydNFJNMDqHSEqWWufpOoHJUA);

	// Token: 0x06000249 RID: 585
	[DllImport("bthprops.cpl", CharSet = CharSet.Unicode, EntryPoint = "BluetoothFindFirstRadio")]
	public static extern IntPtr bIEDMwmSwZriqUiZWgjhDGBiJQbO(ref aZbrTJbdkEqNgMSlZADNlszSrpmR.lknaqAFHGiQTciKNXosZPKfMIEtib, ref IntPtr);

	// Token: 0x0600024A RID: 586
	[DllImport("bthprops.cpl", CharSet = CharSet.Unicode, EntryPoint = "BluetoothFindNextRadio")]
	public static extern bool ZvYEjVabdbBTdGzTijQcMqwJHjJiB(IntPtr, ref IntPtr);

	// Token: 0x0600024B RID: 587
	[DllImport("bthprops.cpl", CharSet = CharSet.Unicode, EntryPoint = "BluetoothFindRadioClose")]
	public static extern bool wYbNmgQlbAdvqarBibcYsipwikdJA(IntPtr);

	// Token: 0x040001AE RID: 430
	private const string uymMdcFTZkCVSTvgZWYrQGuVcHAq = "bthprops.cpl";

	// Token: 0x040001AF RID: 431
	private const int ClbbJizUxkOZMynuxUTwTrgiLvyb = 248;

	// Token: 0x02000036 RID: 54
	public struct AnIursTJiGuiIahXHibSRdYFdKfZ
	{
		// Token: 0x0600024C RID: 588 RVA: 0x00028DAC File Offset: 0x00026FAC
		public string GKlDvgpUTEeydrQRSMofZgmfzzdn()
		{
			return "" + StringTools.WriteVar("dwSize", this.OnJGzWMJOkxkATlpluSVlPnmrMIH) + StringTools.WriteVar("fReturnAuthenticated", this.GHNkjnBJUjplzLmywRadbNMWldFA) + StringTools.WriteVar("fReturnRemembered", this.IdQtdOHFkZFQHtYTifxMEDStAZLB) + StringTools.WriteVar("fReturnUnknown", this.AplKVHuYukjdyoKgcEqKUHODyLzy) + StringTools.WriteVar("fReturnConnected", this.UxYWMbUdjVSbIGFBRessNrffemhT) + StringTools.WriteVar("fIssueInquiry", this.vtfGptpJDxrFrYepgcnMeLbDUVgX) + StringTools.WriteVar("cTimeoutMultiplier", this.KoKgweCHWXDJcjvpKSmcSnTlEiUKA) + StringTools.WriteVar("hRadio", this.TemHGbdWzAXkpLQfGyOlqEjldWEvA);
		}

		// Token: 0x040001B0 RID: 432
		public uint OnJGzWMJOkxkATlpluSVlPnmrMIH;

		// Token: 0x040001B1 RID: 433
		public bool GHNkjnBJUjplzLmywRadbNMWldFA;

		// Token: 0x040001B2 RID: 434
		public bool IdQtdOHFkZFQHtYTifxMEDStAZLB;

		// Token: 0x040001B3 RID: 435
		public bool AplKVHuYukjdyoKgcEqKUHODyLzy;

		// Token: 0x040001B4 RID: 436
		public bool UxYWMbUdjVSbIGFBRessNrffemhT;

		// Token: 0x040001B5 RID: 437
		public bool vtfGptpJDxrFrYepgcnMeLbDUVgX;

		// Token: 0x040001B6 RID: 438
		public byte KoKgweCHWXDJcjvpKSmcSnTlEiUKA;

		// Token: 0x040001B7 RID: 439
		public IntPtr TemHGbdWzAXkpLQfGyOlqEjldWEvA;
	}

	// Token: 0x02000037 RID: 55
	public struct lknaqAFHGiQTciKNXosZPKfMIEtib
	{
		// Token: 0x040001B8 RID: 440
		[MarshalAs(UnmanagedType.U4)]
		public int TkjUCjCHUhNAhVqVcgopWoefxehC;
	}

	// Token: 0x02000038 RID: 56
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 1)]
	public struct vCxDyydNFJNMDqHSEqWWufpOoHJUA
	{
		// Token: 0x0600024D RID: 589 RVA: 0x00028E90 File Offset: 0x00027090
		public string XCtJTIlMnvjGDBEKMXIRSPWAgeuu()
		{
			string str = "" + "dwSize = " + this.JoJOgnnMFOFJfjMLWcwRlZpkptgUA.ToString() + "\n";
			string str2 = "Address = ";
			aZbrTJbdkEqNgMSlZADNlszSrpmR.fNNAvaynvHBxIGSwpnmvkuHEjJxF fNNAvaynvHBxIGSwpnmvkuHEjJxF = this.zvWzuUFMBUcZHiSzvGaYMwaIIYDx;
			string str3 = str + str2 + fNNAvaynvHBxIGSwpnmvkuHEjJxF.ToString() + "\n" + "ulClassofDevice = " + this.SnrDPndnhMlejgMWdihEMWPMkFnJB.ToString() + "\n" + "fConnected = " + this.zmMmjbdLshcozVzmdLxjgoRjfzfq.ToString() + "\n" + "fRemembered = " + this.WETcktFIYRmsIluzvKoZrPDckGSW.ToString() + "\n" + "fAuthenticated = " + this.DfzqFlJmNGJdYZpRYFleNpDAXWDw.ToString() + "\n";
			string str4 = "stLastSeen = ";
			aZbrTJbdkEqNgMSlZADNlszSrpmR.NBNHaofifNrCIFYjbdzObtZCnGKLb nbnhaofifNrCIFYjbdzObtZCnGKLb = this.wtIcNCBfMWRoflwCHGLLXjjSQaOoA;
			string str5 = str3 + str4 + nbnhaofifNrCIFYjbdzObtZCnGKLb.ToString() + "\n";
			string str6 = "stLastUsed = ";
			nbnhaofifNrCIFYjbdzObtZCnGKLb = this.vEMwlCcnQCgNwxcOqAoIgpBmlKFC;
			return str5 + str6 + nbnhaofifNrCIFYjbdzObtZCnGKLb.ToString() + "\n" + "szName = " + this.VPtNOwddrVRNzfzUUlBanFMajgLGA;
		}

		// Token: 0x0600024E RID: 590 RVA: 0x00028FA0 File Offset: 0x000271A0
		public static aZbrTJbdkEqNgMSlZADNlszSrpmR.vCxDyydNFJNMDqHSEqWWufpOoHJUA qjIByCWlgxekxDObTIDlPXbeauoB()
		{
			return new aZbrTJbdkEqNgMSlZADNlszSrpmR.vCxDyydNFJNMDqHSEqWWufpOoHJUA
			{
				JoJOgnnMFOFJfjMLWcwRlZpkptgUA = (uint)Marshal.SizeOf(typeof(aZbrTJbdkEqNgMSlZADNlszSrpmR.vCxDyydNFJNMDqHSEqWWufpOoHJUA))
			};
		}

		// Token: 0x040001B9 RID: 441
		public const int qypGWsqxDGuIhWMSzTOxPyVUjKyg = 0;

		// Token: 0x040001BA RID: 442
		public const int fwbvkYFhyoGPzhCwEyndzEgwvIeH = 4;

		// Token: 0x040001BB RID: 443
		public const int DDiPhhWnPSlfhRaKAbsAKwgvCSRTA = 8;

		// Token: 0x040001BC RID: 444
		public const int BnDuAvsBRzkdRtHMZbYDylAMuicO = 20;

		// Token: 0x040001BD RID: 445
		public const int ihnkZzhQvRpoufJXAhlOXgEEZtRj = 24;

		// Token: 0x040001BE RID: 446
		public const int IRmhCZJndziNVbYYmobCetJszAOQA = 28;

		// Token: 0x040001BF RID: 447
		public const int zatFFQwkelGbEgGzXHRvIWJOOQxhA = 32;

		// Token: 0x040001C0 RID: 448
		public const int AiiCCkdmRVRbesAoVOQXHlTNaXQI = 48;

		// Token: 0x040001C1 RID: 449
		public const int YjlXabWBxYkZsovGfCOjKqUNJnEg = 64;

		// Token: 0x040001C2 RID: 450
		public uint JoJOgnnMFOFJfjMLWcwRlZpkptgUA;

		// Token: 0x040001C3 RID: 451
		public aZbrTJbdkEqNgMSlZADNlszSrpmR.fNNAvaynvHBxIGSwpnmvkuHEjJxF zvWzuUFMBUcZHiSzvGaYMwaIIYDx;

		// Token: 0x040001C4 RID: 452
		public uint SnrDPndnhMlejgMWdihEMWPMkFnJB;

		// Token: 0x040001C5 RID: 453
		public bool zmMmjbdLshcozVzmdLxjgoRjfzfq;

		// Token: 0x040001C6 RID: 454
		public bool WETcktFIYRmsIluzvKoZrPDckGSW;

		// Token: 0x040001C7 RID: 455
		public bool DfzqFlJmNGJdYZpRYFleNpDAXWDw;

		// Token: 0x040001C8 RID: 456
		public aZbrTJbdkEqNgMSlZADNlszSrpmR.NBNHaofifNrCIFYjbdzObtZCnGKLb wtIcNCBfMWRoflwCHGLLXjjSQaOoA;

		// Token: 0x040001C9 RID: 457
		public aZbrTJbdkEqNgMSlZADNlszSrpmR.NBNHaofifNrCIFYjbdzObtZCnGKLb vEMwlCcnQCgNwxcOqAoIgpBmlKFC;

		// Token: 0x040001CA RID: 458
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 248)]
		public string VPtNOwddrVRNzfzUUlBanFMajgLGA;
	}

	// Token: 0x02000039 RID: 57
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct NBNHaofifNrCIFYjbdzObtZCnGKLb
	{
		// Token: 0x0600024F RID: 591 RVA: 0x00028FCC File Offset: 0x000271CC
		public string iqBXHevqCuTtXqSJRohTfMcAlIIL()
		{
			return string.Format("{0} : {1} : {2} : {3} : {4} : {5} : {6} : {7}", new object[]
			{
				this.syrNKvvmynepGtGHJELEkKCIqaFgb,
				this.zoWIpSBBhrBLEkGbTPnVEmcNEJHhb,
				this.TcuCRdGOFuAknxJVkHAHJbPlJBOHA,
				this.bkYJZYTZjRpjPbgFBrZLygKZsUQk,
				this.OUeYCCsxkoeOXajUXIPjbFJDJuYJ,
				this.zQANGsaYtKytvseqChrZabtXBHhgA,
				this.ZSyCsxdnZjtPyRmKCPXFcFfaDuGfc,
				this.ZqXfwyxrPqhRXXSLRFuGGKalYlzjA
			});
		}

		// Token: 0x040001CB RID: 459
		public ushort syrNKvvmynepGtGHJELEkKCIqaFgb;

		// Token: 0x040001CC RID: 460
		public ushort zoWIpSBBhrBLEkGbTPnVEmcNEJHhb;

		// Token: 0x040001CD RID: 461
		public ushort TcuCRdGOFuAknxJVkHAHJbPlJBOHA;

		// Token: 0x040001CE RID: 462
		public ushort bkYJZYTZjRpjPbgFBrZLygKZsUQk;

		// Token: 0x040001CF RID: 463
		public ushort OUeYCCsxkoeOXajUXIPjbFJDJuYJ;

		// Token: 0x040001D0 RID: 464
		public ushort zQANGsaYtKytvseqChrZabtXBHhgA;

		// Token: 0x040001D1 RID: 465
		public ushort ZSyCsxdnZjtPyRmKCPXFcFfaDuGfc;

		// Token: 0x040001D2 RID: 466
		public ushort ZqXfwyxrPqhRXXSLRFuGGKalYlzjA;
	}

	// Token: 0x0200003A RID: 58
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct fNNAvaynvHBxIGSwpnmvkuHEjJxF
	{
		// Token: 0x06000250 RID: 592 RVA: 0x0002905C File Offset: 0x0002725C
		public string moeTNOQVjTDpVhRPxOEdgCxWNAAc()
		{
			return string.Format("{0}:{1}:{2}:{3}:{4}:{5}", new object[]
			{
				this.hRgdVobnyMIltcRmmAKRTHCHdntab.ToString("x"),
				this.UlzxSCBjzJKTERrbOmlcMqSIwMKJ.ToString("x"),
				this.EtIsAqDiftcsxTJQXjyfBAyfkKxT.ToString("x"),
				this.IhWBxpfmoWLDjrzfeFVHvTWiIgMgb.ToString("x"),
				this.eLNpNRAsRcjbVkdOjMQiBmoOYQkq.ToString("x"),
				this.UCKqgZeElbhEkfaSptTOXPaCBnpR.ToString("x")
			});
		}

		// Token: 0x06000251 RID: 593 RVA: 0x000290EC File Offset: 0x000272EC
		public bool VkWDveydFvKyVANeXReNViKkFvmQ(ref aZbrTJbdkEqNgMSlZADNlszSrpmR.qXPBVSdfZfmMFrhYwxHhnBTLxtJD A_1)
		{
			return this.UCKqgZeElbhEkfaSptTOXPaCBnpR == A_1.lziceOYYmZQgkaQZpqYyaBPcKdSP && this.eLNpNRAsRcjbVkdOjMQiBmoOYQkq == A_1.hYkuGuZhiWPrGSuvwtHGODEPuCBN && this.IhWBxpfmoWLDjrzfeFVHvTWiIgMgb == A_1.ExlQUXZvWAocDwpNWuLYJXRupDFs && this.EtIsAqDiftcsxTJQXjyfBAyfkKxT == A_1.ZNfwAnoIsKBumjBDCZYOtDAbSHkT && this.UlzxSCBjzJKTERrbOmlcMqSIwMKJ == A_1.oUNMUDGfWgbIXjKmLJxSNjjGkXQD && this.hRgdVobnyMIltcRmmAKRTHCHdntab == A_1.YspOugAyxXKkGHOmXqcTlqTPQRpt;
		}

		// Token: 0x040001D3 RID: 467
		public byte zRfTBMrrpyomwmTLidzAyfWVEBPw;

		// Token: 0x040001D4 RID: 468
		public byte qqksyDpuwAwbOeoyiHFcCPmoqrfG;

		// Token: 0x040001D5 RID: 469
		public byte EgJSOmxpTdbvGwqQKnVYgLAWcPUp;

		// Token: 0x040001D6 RID: 470
		public byte pzLfERGDNYMPxwNBRExSUYvBwjivA;

		// Token: 0x040001D7 RID: 471
		public byte UCKqgZeElbhEkfaSptTOXPaCBnpR;

		// Token: 0x040001D8 RID: 472
		public byte eLNpNRAsRcjbVkdOjMQiBmoOYQkq;

		// Token: 0x040001D9 RID: 473
		public byte IhWBxpfmoWLDjrzfeFVHvTWiIgMgb;

		// Token: 0x040001DA RID: 474
		public byte EtIsAqDiftcsxTJQXjyfBAyfkKxT;

		// Token: 0x040001DB RID: 475
		public byte UlzxSCBjzJKTERrbOmlcMqSIwMKJ;

		// Token: 0x040001DC RID: 476
		public byte hRgdVobnyMIltcRmmAKRTHCHdntab;

		// Token: 0x040001DD RID: 477
		public byte QMMlhSsegQiOoHdMrBceWESZcOfdb;

		// Token: 0x040001DE RID: 478
		public byte RUDRbOISypScdPXeIxXWHZRHTqzy;
	}

	// Token: 0x0200003B RID: 59
	public struct qXPBVSdfZfmMFrhYwxHhnBTLxtJD
	{
		// Token: 0x06000252 RID: 594 RVA: 0x0002915C File Offset: 0x0002735C
		public long ilReKnOvBsFlkEzCHaJzeFgSFeUyA()
		{
			Array.Clear(aZbrTJbdkEqNgMSlZADNlszSrpmR.qXPBVSdfZfmMFrhYwxHhnBTLxtJD.IGFRpFmBQzAacBYvugpTmIltTkOh, 0, aZbrTJbdkEqNgMSlZADNlszSrpmR.qXPBVSdfZfmMFrhYwxHhnBTLxtJD.IGFRpFmBQzAacBYvugpTmIltTkOh.Length);
			aZbrTJbdkEqNgMSlZADNlszSrpmR.qXPBVSdfZfmMFrhYwxHhnBTLxtJD.IGFRpFmBQzAacBYvugpTmIltTkOh[0] = this.lziceOYYmZQgkaQZpqYyaBPcKdSP;
			aZbrTJbdkEqNgMSlZADNlszSrpmR.qXPBVSdfZfmMFrhYwxHhnBTLxtJD.IGFRpFmBQzAacBYvugpTmIltTkOh[1] = this.hYkuGuZhiWPrGSuvwtHGODEPuCBN;
			aZbrTJbdkEqNgMSlZADNlszSrpmR.qXPBVSdfZfmMFrhYwxHhnBTLxtJD.IGFRpFmBQzAacBYvugpTmIltTkOh[2] = this.ExlQUXZvWAocDwpNWuLYJXRupDFs;
			aZbrTJbdkEqNgMSlZADNlszSrpmR.qXPBVSdfZfmMFrhYwxHhnBTLxtJD.IGFRpFmBQzAacBYvugpTmIltTkOh[3] = this.ZNfwAnoIsKBumjBDCZYOtDAbSHkT;
			aZbrTJbdkEqNgMSlZADNlszSrpmR.qXPBVSdfZfmMFrhYwxHhnBTLxtJD.IGFRpFmBQzAacBYvugpTmIltTkOh[4] = this.oUNMUDGfWgbIXjKmLJxSNjjGkXQD;
			aZbrTJbdkEqNgMSlZADNlszSrpmR.qXPBVSdfZfmMFrhYwxHhnBTLxtJD.IGFRpFmBQzAacBYvugpTmIltTkOh[5] = this.YspOugAyxXKkGHOmXqcTlqTPQRpt;
			return BitConverter.ToInt64(aZbrTJbdkEqNgMSlZADNlszSrpmR.qXPBVSdfZfmMFrhYwxHhnBTLxtJD.IGFRpFmBQzAacBYvugpTmIltTkOh, 0);
		}

		// Token: 0x06000253 RID: 595 RVA: 0x000291D4 File Offset: 0x000273D4
		public static aZbrTJbdkEqNgMSlZADNlszSrpmR.qXPBVSdfZfmMFrhYwxHhnBTLxtJD dmJuydWZIUrHtJSJqbiQxeJLnqDT(string A_0, out bool A_1)
		{
			A_1 = false;
			aZbrTJbdkEqNgMSlZADNlszSrpmR.qXPBVSdfZfmMFrhYwxHhnBTLxtJD result = default(aZbrTJbdkEqNgMSlZADNlszSrpmR.qXPBVSdfZfmMFrhYwxHhnBTLxtJD);
			if (string.IsNullOrEmpty(A_0))
			{
				return result;
			}
			if (A_0.Length != 12)
			{
				return result;
			}
			try
			{
				result.lziceOYYmZQgkaQZpqYyaBPcKdSP = Convert.ToByte(A_0.Substring(10, 2), 16);
				result.hYkuGuZhiWPrGSuvwtHGODEPuCBN = Convert.ToByte(A_0.Substring(8, 2), 16);
				result.ExlQUXZvWAocDwpNWuLYJXRupDFs = Convert.ToByte(A_0.Substring(6, 2), 16);
				result.ZNfwAnoIsKBumjBDCZYOtDAbSHkT = Convert.ToByte(A_0.Substring(4, 2), 16);
				result.oUNMUDGfWgbIXjKmLJxSNjjGkXQD = Convert.ToByte(A_0.Substring(2, 2), 16);
				result.YspOugAyxXKkGHOmXqcTlqTPQRpt = Convert.ToByte(A_0.Substring(0, 2), 16);
				A_1 = true;
			}
			catch
			{
			}
			return result;
		}

		// Token: 0x040001DF RID: 479
		private static byte[] IGFRpFmBQzAacBYvugpTmIltTkOh = new byte[8];

		// Token: 0x040001E0 RID: 480
		public byte lziceOYYmZQgkaQZpqYyaBPcKdSP;

		// Token: 0x040001E1 RID: 481
		public byte hYkuGuZhiWPrGSuvwtHGODEPuCBN;

		// Token: 0x040001E2 RID: 482
		public byte ExlQUXZvWAocDwpNWuLYJXRupDFs;

		// Token: 0x040001E3 RID: 483
		public byte ZNfwAnoIsKBumjBDCZYOtDAbSHkT;

		// Token: 0x040001E4 RID: 484
		public byte oUNMUDGfWgbIXjKmLJxSNjjGkXQD;

		// Token: 0x040001E5 RID: 485
		public byte YspOugAyxXKkGHOmXqcTlqTPQRpt;
	}
}
