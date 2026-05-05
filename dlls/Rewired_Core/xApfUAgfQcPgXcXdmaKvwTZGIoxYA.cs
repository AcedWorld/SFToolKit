using System;
using Rewired.Platforms.Custom;

// Token: 0x0200023C RID: 572
internal static class xApfUAgfQcPgXcXdmaKvwTZGIoxYA
{
	// Token: 0x17000651 RID: 1617
	// (get) Token: 0x06001A2B RID: 6699 RVA: 0x0001557F File Offset: 0x0001377F
	public static int OmZwoJVuDaIJjIIgibqUDqkIfENMA
	{
		get
		{
			if (xApfUAgfQcPgXcXdmaKvwTZGIoxYA.ecEHmCIjChNhJJUyWWmGPjAptjyM == null)
			{
				return -1;
			}
			return xApfUAgfQcPgXcXdmaKvwTZGIoxYA.ecEHmCIjChNhJJUyWWmGPjAptjyM.platformId;
		}
	}

	// Token: 0x17000652 RID: 1618
	// (get) Token: 0x06001A2C RID: 6700 RVA: 0x00015594 File Offset: 0x00013794
	public static bool GXntXWfLzMLrGpDuLwjFcqKwikHHA
	{
		get
		{
			return xApfUAgfQcPgXcXdmaKvwTZGIoxYA.OmZwoJVuDaIJjIIgibqUDqkIfENMA != -1;
		}
	}

	// Token: 0x06001A2D RID: 6701 RVA: 0x000155A1 File Offset: 0x000137A1
	public static void kidcqqMtTLidcqUHAhKRqNcdxuPm(CustomPlatformInitOptions A_0)
	{
		if (A_0 == null)
		{
			throw new ArgumentNullException("options");
		}
		if (xApfUAgfQcPgXcXdmaKvwTZGIoxYA.GXntXWfLzMLrGpDuLwjFcqKwikHHA)
		{
			throw new Exception("Already initialized");
		}
		xApfUAgfQcPgXcXdmaKvwTZGIoxYA.uNLkbPlPlMEjvNSpQRMnFMCMvuYt(A_0);
		xApfUAgfQcPgXcXdmaKvwTZGIoxYA.ecEHmCIjChNhJJUyWWmGPjAptjyM = A_0;
	}

	// Token: 0x06001A2E RID: 6702 RVA: 0x000155CF File Offset: 0x000137CF
	public static void reIfIRfdmmHnkEcFiuHGQPySJmtZb()
	{
		xApfUAgfQcPgXcXdmaKvwTZGIoxYA.ecEHmCIjChNhJJUyWWmGPjAptjyM = null;
	}

	// Token: 0x06001A2F RID: 6703 RVA: 0x0001557F File Offset: 0x0001377F
	internal static int TiHGHzFnKDNAgnKQZBAUymjWPNJQ()
	{
		if (xApfUAgfQcPgXcXdmaKvwTZGIoxYA.ecEHmCIjChNhJJUyWWmGPjAptjyM == null)
		{
			return -1;
		}
		return xApfUAgfQcPgXcXdmaKvwTZGIoxYA.ecEHmCIjChNhJJUyWWmGPjAptjyM.platformId;
	}

	// Token: 0x06001A30 RID: 6704 RVA: 0x000155D7 File Offset: 0x000137D7
	internal static string TPxDaPfqMCkhyAkpodGjZISyJCpuA()
	{
		if (xApfUAgfQcPgXcXdmaKvwTZGIoxYA.ecEHmCIjChNhJJUyWWmGPjAptjyM == null)
		{
			return null;
		}
		return xApfUAgfQcPgXcXdmaKvwTZGIoxYA.ecEHmCIjChNhJJUyWWmGPjAptjyM.platformIdentifierString;
	}

	// Token: 0x06001A31 RID: 6705 RVA: 0x000155EC File Offset: 0x000137EC
	internal static IHardwareJoystickMapCustomPlatformMapProvider smuPPWtijAeWDxTnQgXWGCxzyKZf()
	{
		if (xApfUAgfQcPgXcXdmaKvwTZGIoxYA.ecEHmCIjChNhJJUyWWmGPjAptjyM == null)
		{
			return null;
		}
		return xApfUAgfQcPgXcXdmaKvwTZGIoxYA.ecEHmCIjChNhJJUyWWmGPjAptjyM.hardwareJoystickMapCustomPlatformMapProvider;
	}

	// Token: 0x06001A32 RID: 6706 RVA: 0x00015601 File Offset: 0x00013801
	internal static CustomInputSource GUFXNCLOdUWYIEOzaHcfTTHLdKNp()
	{
		if (xApfUAgfQcPgXcXdmaKvwTZGIoxYA.ecEHmCIjChNhJJUyWWmGPjAptjyM == null)
		{
			return null;
		}
		return xApfUAgfQcPgXcXdmaKvwTZGIoxYA.ecEHmCIjChNhJJUyWWmGPjAptjyM.inputSource;
	}

	// Token: 0x06001A33 RID: 6707 RVA: 0x00015616 File Offset: 0x00013816
	internal static CustomPlatformConfigVars fhPwoQDVaCrGxJIrWVnEEYfkeXpd()
	{
		if (xApfUAgfQcPgXcXdmaKvwTZGIoxYA.ecEHmCIjChNhJJUyWWmGPjAptjyM == null)
		{
			return null;
		}
		return xApfUAgfQcPgXcXdmaKvwTZGIoxYA.ecEHmCIjChNhJJUyWWmGPjAptjyM.configVars;
	}

	// Token: 0x06001A34 RID: 6708 RVA: 0x00072960 File Offset: 0x00070B60
	private static void uNLkbPlPlMEjvNSpQRMnFMCMvuYt(CustomPlatformInitOptions A_0)
	{
		if (A_0.platformId == -1)
		{
			throw new Exception("customPlatformId is invalid.");
		}
		if (string.IsNullOrEmpty(A_0.platformIdentifierString))
		{
			throw new Exception("platformIdentifierString is invalid.");
		}
		if (A_0.inputSource == null)
		{
			throw new Exception("inputSource cannot be null.");
		}
		if (A_0.hardwareJoystickMapCustomPlatformMapProvider == null)
		{
			throw new Exception("hardwareJoystickMapCustomPlatformMapProvider cannot be null.");
		}
	}

	// Token: 0x04000ED4 RID: 3796
	private static CustomPlatformInitOptions ecEHmCIjChNhJJUyWWmGPjAptjyM;
}
