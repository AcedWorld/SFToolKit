using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Token: 0x02000104 RID: 260
internal sealed class xjxVCBoExZFwupbVmOSiLDNkuyDl
{
	// Token: 0x0600098D RID: 2445 RVA: 0x00016F73 File Offset: 0x00015173
	public xjxVCBoExZFwupbVmOSiLDNkuyDl(amHHBhGeKFDKabaJrcgEFNDIMzwE A_1, string A_2, string A_3, string A_4, string A_5 = null)
	{
		this.mNBtJjbpiXCALbFsqJjfzhxABRQI = A_1;
		this.dKmCfjvkymORDcCCkkpBQvHreRSm = A_2;
		this.hEbgNzilnxiIJBbPlUYcwfTcfkAsA = A_3;
		this.TCPXXqyWiKQNBAQBjRZGOShHIyRT = A_4;
		this.gEfCjoBbrbSrEBTGyeHAHRceQjSY = A_5;
	}

	// Token: 0x170001C1 RID: 449
	// (get) Token: 0x0600098E RID: 2446 RVA: 0x00016FA0 File Offset: 0x000151A0
	// (set) Token: 0x0600098F RID: 2447 RVA: 0x00016FA8 File Offset: 0x000151A8
	public amHHBhGeKFDKabaJrcgEFNDIMzwE mNBtJjbpiXCALbFsqJjfzhxABRQI { get; private set; }

	// Token: 0x170001C2 RID: 450
	// (get) Token: 0x06000990 RID: 2448 RVA: 0x0003AED0 File Offset: 0x000390D0
	public int xKNzcRElUTeyYAqiopwcOzvZbQkkA
	{
		get
		{
			return this.mNBtJjbpiXCALbFsqJjfzhxABRQI.ribBaPJKLxFndwkqMLctglWdCyZWb;
		}
	}

	// Token: 0x170001C3 RID: 451
	// (get) Token: 0x06000991 RID: 2449 RVA: 0x00016FB1 File Offset: 0x000151B1
	// (set) Token: 0x06000992 RID: 2450 RVA: 0x00016FB9 File Offset: 0x000151B9
	public string dKmCfjvkymORDcCCkkpBQvHreRSm { get; private set; }

	// Token: 0x170001C4 RID: 452
	// (get) Token: 0x06000993 RID: 2451 RVA: 0x00016FC2 File Offset: 0x000151C2
	// (set) Token: 0x06000994 RID: 2452 RVA: 0x00016FCA File Offset: 0x000151CA
	public string hEbgNzilnxiIJBbPlUYcwfTcfkAsA { get; private set; }

	// Token: 0x170001C5 RID: 453
	// (get) Token: 0x06000995 RID: 2453 RVA: 0x00016FD3 File Offset: 0x000151D3
	// (set) Token: 0x06000996 RID: 2454 RVA: 0x00016FDB File Offset: 0x000151DB
	public string TCPXXqyWiKQNBAQBjRZGOShHIyRT { get; private set; }

	// Token: 0x170001C6 RID: 454
	// (get) Token: 0x06000997 RID: 2455 RVA: 0x00016FE4 File Offset: 0x000151E4
	// (set) Token: 0x06000998 RID: 2456 RVA: 0x00016FEC File Offset: 0x000151EC
	public string gEfCjoBbrbSrEBTGyeHAHRceQjSY { get; set; }

	// Token: 0x06000999 RID: 2457 RVA: 0x0003AEEC File Offset: 0x000390EC
	public bool gSmduimlMHVSWviECMykYcqiSzFb(xjxVCBoExZFwupbVmOSiLDNkuyDl A_1)
	{
		return A_1 != null && (this == A_1 || A_1.mNBtJjbpiXCALbFsqJjfzhxABRQI.Equals(this.mNBtJjbpiXCALbFsqJjfzhxABRQI));
	}

	// Token: 0x0600099A RID: 2458 RVA: 0x00016FF5 File Offset: 0x000151F5
	public bool JEASmfZpMoRSXmCemMFbAaPxMmU(object A_1)
	{
		return A_1 != null && (this == A_1 || (!(A_1.GetType() != typeof(xjxVCBoExZFwupbVmOSiLDNkuyDl)) && this.gSmduimlMHVSWviECMykYcqiSzFb((xjxVCBoExZFwupbVmOSiLDNkuyDl)A_1)));
	}

	// Token: 0x0600099B RID: 2459 RVA: 0x0003AF18 File Offset: 0x00039118
	public int FAPaonbdsMNxoVAPGgSxPfMRNPRIA()
	{
		return this.mNBtJjbpiXCALbFsqJjfzhxABRQI.GetHashCode();
	}

	// Token: 0x0600099C RID: 2460 RVA: 0x0003AF3C File Offset: 0x0003913C
	public string INZgVRIbqcPqltoXHtHzqIvNRkOE()
	{
		return string.Format("HRESULT: [0x{0:X}], Module: [{1}], ApiCode: [{2}/{3}], Message: {4}", new object[]
		{
			this.mNBtJjbpiXCALbFsqJjfzhxABRQI.ribBaPJKLxFndwkqMLctglWdCyZWb,
			this.dKmCfjvkymORDcCCkkpBQvHreRSm,
			this.hEbgNzilnxiIJBbPlUYcwfTcfkAsA,
			this.TCPXXqyWiKQNBAQBjRZGOShHIyRT,
			this.gEfCjoBbrbSrEBTGyeHAHRceQjSY
		});
	}

	// Token: 0x0600099D RID: 2461 RVA: 0x00017027 File Offset: 0x00015227
	public static amHHBhGeKFDKabaJrcgEFNDIMzwE aDBixfHFLztviQjPwsFRhPZkBuLoA(xjxVCBoExZFwupbVmOSiLDNkuyDl A_0)
	{
		return A_0.mNBtJjbpiXCALbFsqJjfzhxABRQI;
	}

	// Token: 0x0600099E RID: 2462 RVA: 0x0003AF94 File Offset: 0x00039194
	public static int jroZxCmbmPCvBQgAsWpNKyMHqHOb(xjxVCBoExZFwupbVmOSiLDNkuyDl A_0)
	{
		return A_0.mNBtJjbpiXCALbFsqJjfzhxABRQI.ribBaPJKLxFndwkqMLctglWdCyZWb;
	}

	// Token: 0x0600099F RID: 2463 RVA: 0x0003AF94 File Offset: 0x00039194
	public static uint jroZxCmbmPCvBQgAsWpNKyMHqHOb(xjxVCBoExZFwupbVmOSiLDNkuyDl A_0)
	{
		return (uint)A_0.mNBtJjbpiXCALbFsqJjfzhxABRQI.ribBaPJKLxFndwkqMLctglWdCyZWb;
	}

	// Token: 0x060009A0 RID: 2464 RVA: 0x0003AFB0 File Offset: 0x000391B0
	public static bool CZLIcfVXjkjPBfQVKmvBXuVIbzDs(xjxVCBoExZFwupbVmOSiLDNkuyDl A_0, amHHBhGeKFDKabaJrcgEFNDIMzwE A_1)
	{
		return A_0 != null && A_0.mNBtJjbpiXCALbFsqJjfzhxABRQI.ribBaPJKLxFndwkqMLctglWdCyZWb == A_1.ribBaPJKLxFndwkqMLctglWdCyZWb;
	}

	// Token: 0x060009A1 RID: 2465 RVA: 0x0003AFDC File Offset: 0x000391DC
	public static bool iyXugZLNiStiReXIwpTmSShDwpIK(xjxVCBoExZFwupbVmOSiLDNkuyDl A_0, amHHBhGeKFDKabaJrcgEFNDIMzwE A_1)
	{
		return A_0 != null && A_0.mNBtJjbpiXCALbFsqJjfzhxABRQI.ribBaPJKLxFndwkqMLctglWdCyZWb != A_1.ribBaPJKLxFndwkqMLctglWdCyZWb;
	}

	// Token: 0x060009A2 RID: 2466 RVA: 0x0003B008 File Offset: 0x00039208
	public static void COEyBaHLODrJZTUZbHoURzlFtvme(Type A_0)
	{
		object gcKfexqtzzcXosGYAvUxZSLKBAfV = xjxVCBoExZFwupbVmOSiLDNkuyDl.GcKfexqtzzcXosGYAvUxZSLKBAfV;
		lock (gcKfexqtzzcXosGYAvUxZSLKBAfV)
		{
			if (!xjxVCBoExZFwupbVmOSiLDNkuyDl.RuXgXFMeHKqdDKktVVUYOVLyyIvf.Contains(A_0))
			{
				xjxVCBoExZFwupbVmOSiLDNkuyDl.RuXgXFMeHKqdDKktVVUYOVLyyIvf.Add(A_0);
			}
		}
	}

	// Token: 0x060009A3 RID: 2467 RVA: 0x0003B05C File Offset: 0x0003925C
	public static xjxVCBoExZFwupbVmOSiLDNkuyDl WvfkGPimWOiHIjSfbWXfpmzqkIry(amHHBhGeKFDKabaJrcgEFNDIMzwE A_0)
	{
		object gcKfexqtzzcXosGYAvUxZSLKBAfV = xjxVCBoExZFwupbVmOSiLDNkuyDl.GcKfexqtzzcXosGYAvUxZSLKBAfV;
		xjxVCBoExZFwupbVmOSiLDNkuyDl xjxVCBoExZFwupbVmOSiLDNkuyDl;
		lock (gcKfexqtzzcXosGYAvUxZSLKBAfV)
		{
			if (xjxVCBoExZFwupbVmOSiLDNkuyDl.RuXgXFMeHKqdDKktVVUYOVLyyIvf.Count > 0)
			{
				foreach (Type type in xjxVCBoExZFwupbVmOSiLDNkuyDl.RuXgXFMeHKqdDKktVVUYOVLyyIvf)
				{
					xjxVCBoExZFwupbVmOSiLDNkuyDl.VTFhWyLgIbMUKlZBvOsczUHOmHWV(type);
				}
				xjxVCBoExZFwupbVmOSiLDNkuyDl.RuXgXFMeHKqdDKktVVUYOVLyyIvf.Clear();
			}
			if (!xjxVCBoExZFwupbVmOSiLDNkuyDl.LqJEBSwLSKviWlbuWostGhCqzWlj.TryGetValue(A_0, out xjxVCBoExZFwupbVmOSiLDNkuyDl))
			{
				xjxVCBoExZFwupbVmOSiLDNkuyDl = new xjxVCBoExZFwupbVmOSiLDNkuyDl(A_0, "Unknown", "Unknown", "Unknown", null);
			}
			if (xjxVCBoExZFwupbVmOSiLDNkuyDl.gEfCjoBbrbSrEBTGyeHAHRceQjSY == null)
			{
				string text = xjxVCBoExZFwupbVmOSiLDNkuyDl.aRRBAXJlBxptVETMcqPUaRZeGmGcE(A_0.ribBaPJKLxFndwkqMLctglWdCyZWb);
				xjxVCBoExZFwupbVmOSiLDNkuyDl.gEfCjoBbrbSrEBTGyeHAHRceQjSY = (text ?? "Unknown");
			}
		}
		return xjxVCBoExZFwupbVmOSiLDNkuyDl;
	}

	// Token: 0x060009A4 RID: 2468 RVA: 0x0003B138 File Offset: 0x00039338
	private static void VTFhWyLgIbMUKlZBvOsczUHOmHWV(Type A_0)
	{
		foreach (FieldInfo fieldInfo in A_0.GetFields(BindingFlags.Static | BindingFlags.Public))
		{
			if (fieldInfo.FieldType == typeof(xjxVCBoExZFwupbVmOSiLDNkuyDl))
			{
				xjxVCBoExZFwupbVmOSiLDNkuyDl xjxVCBoExZFwupbVmOSiLDNkuyDl = (xjxVCBoExZFwupbVmOSiLDNkuyDl)fieldInfo.GetValue(null);
				if (!xjxVCBoExZFwupbVmOSiLDNkuyDl.LqJEBSwLSKviWlbuWostGhCqzWlj.ContainsKey(xjxVCBoExZFwupbVmOSiLDNkuyDl.mNBtJjbpiXCALbFsqJjfzhxABRQI))
				{
					xjxVCBoExZFwupbVmOSiLDNkuyDl.LqJEBSwLSKviWlbuWostGhCqzWlj.Add(xjxVCBoExZFwupbVmOSiLDNkuyDl.mNBtJjbpiXCALbFsqJjfzhxABRQI, xjxVCBoExZFwupbVmOSiLDNkuyDl);
				}
			}
		}
	}

	// Token: 0x060009A5 RID: 2469 RVA: 0x0003B1A8 File Offset: 0x000393A8
	private static string aRRBAXJlBxptVETMcqPUaRZeGmGcE(int A_0)
	{
		IntPtr zero = IntPtr.Zero;
		xjxVCBoExZFwupbVmOSiLDNkuyDl.ohdmTBZDTdSXjWVDuPepVkqZDlFt(4864, IntPtr.Zero, A_0, 0, ref zero, 0, IntPtr.Zero);
		string result = Marshal.PtrToStringUni(zero);
		Marshal.FreeHGlobal(zero);
		return result;
	}

	// Token: 0x060009A6 RID: 2470
	[DllImport("kernel32.dll", EntryPoint = "FormatMessageW")]
	private static extern uint ohdmTBZDTdSXjWVDuPepVkqZDlFt(int, IntPtr, int, int, ref IntPtr, int, IntPtr);

	// Token: 0x0400088B RID: 2187
	private static readonly object GcKfexqtzzcXosGYAvUxZSLKBAfV = new object();

	// Token: 0x0400088C RID: 2188
	private static readonly List<Type> RuXgXFMeHKqdDKktVVUYOVLyyIvf = new List<Type>();

	// Token: 0x0400088D RID: 2189
	private static readonly Dictionary<amHHBhGeKFDKabaJrcgEFNDIMzwE, xjxVCBoExZFwupbVmOSiLDNkuyDl> LqJEBSwLSKviWlbuWostGhCqzWlj = new Dictionary<amHHBhGeKFDKabaJrcgEFNDIMzwE, xjxVCBoExZFwupbVmOSiLDNkuyDl>();

	// Token: 0x0400088E RID: 2190
	private const string lhUTGrSNWeYRoqHUArPHVjfKewMv = "Unknown";

	// Token: 0x0400088F RID: 2191
	[CompilerGenerated]
	private amHHBhGeKFDKabaJrcgEFNDIMzwE HfjvitjagpKMlCLrJPYdBedJtigJ;

	// Token: 0x04000890 RID: 2192
	[CompilerGenerated]
	private string XgkBKJgHCDFxrFDJSgUIWBwHGshu;

	// Token: 0x04000891 RID: 2193
	[CompilerGenerated]
	private string VgEbSZtziWQbxtaUwtLMBNRnBUiBA;

	// Token: 0x04000892 RID: 2194
	[CompilerGenerated]
	private string CjPdKEEGIrRQcHUKSodatRfyycVX;

	// Token: 0x04000893 RID: 2195
	[CompilerGenerated]
	private string EFwotGqBBvHprGxVMagpcFPLcmMW;
}
