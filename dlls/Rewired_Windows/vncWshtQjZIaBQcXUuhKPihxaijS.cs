using System;
using System.Globalization;

// Token: 0x02000102 RID: 258
internal struct vncWshtQjZIaBQcXUuhKPihxaijS : IEquatable<vncWshtQjZIaBQcXUuhKPihxaijS>
{
	// Token: 0x06000948 RID: 2376 RVA: 0x00016B12 File Offset: 0x00014D12
	public vncWshtQjZIaBQcXUuhKPihxaijS(float A_1, float A_2, float A_3, float A_4)
	{
		this.SuIEkgLJhlfYWfkaIMihNlQWxXjoA = A_1;
		this.FJXAcoUBJZeYsAtuvYVTgVDCSxEMA = A_2;
		this.CDhjxbSyXhVDyEsKtbKdLRtNCMWA = A_1 + A_3;
		this.KNqBLQCkiClPYjdhJOXUGmMuuFumA = A_2 + A_4;
	}

	// Token: 0x170001AE RID: 430
	// (get) Token: 0x06000949 RID: 2377 RVA: 0x00016B35 File Offset: 0x00014D35
	// (set) Token: 0x0600094A RID: 2378 RVA: 0x00016B3D File Offset: 0x00014D3D
	public float YxYalUvbQdFgoIsCPEtZgKvHNRZv
	{
		get
		{
			return this.SuIEkgLJhlfYWfkaIMihNlQWxXjoA;
		}
		set
		{
			this.SuIEkgLJhlfYWfkaIMihNlQWxXjoA = value;
		}
	}

	// Token: 0x170001AF RID: 431
	// (get) Token: 0x0600094B RID: 2379 RVA: 0x00016B46 File Offset: 0x00014D46
	// (set) Token: 0x0600094C RID: 2380 RVA: 0x00016B4E File Offset: 0x00014D4E
	public float dSExOTQJZrvgFBFYhPykXnGPLSHD
	{
		get
		{
			return this.FJXAcoUBJZeYsAtuvYVTgVDCSxEMA;
		}
		set
		{
			this.FJXAcoUBJZeYsAtuvYVTgVDCSxEMA = value;
		}
	}

	// Token: 0x170001B0 RID: 432
	// (get) Token: 0x0600094D RID: 2381 RVA: 0x00016B57 File Offset: 0x00014D57
	// (set) Token: 0x0600094E RID: 2382 RVA: 0x00016B5F File Offset: 0x00014D5F
	public float VRhhdrHHwosRgPpFeFfaWAVwdLVo
	{
		get
		{
			return this.CDhjxbSyXhVDyEsKtbKdLRtNCMWA;
		}
		set
		{
			this.CDhjxbSyXhVDyEsKtbKdLRtNCMWA = value;
		}
	}

	// Token: 0x170001B1 RID: 433
	// (get) Token: 0x0600094F RID: 2383 RVA: 0x00016B68 File Offset: 0x00014D68
	// (set) Token: 0x06000950 RID: 2384 RVA: 0x00016B70 File Offset: 0x00014D70
	public float OLZRgkgngLoNhoStFDOURjEIdPJA
	{
		get
		{
			return this.KNqBLQCkiClPYjdhJOXUGmMuuFumA;
		}
		set
		{
			this.KNqBLQCkiClPYjdhJOXUGmMuuFumA = value;
		}
	}

	// Token: 0x170001B2 RID: 434
	// (get) Token: 0x06000951 RID: 2385 RVA: 0x00016B35 File Offset: 0x00014D35
	// (set) Token: 0x06000952 RID: 2386 RVA: 0x00016B79 File Offset: 0x00014D79
	public float PFuMhIIRJYTjmnucPdkWeLbGgOIs
	{
		get
		{
			return this.SuIEkgLJhlfYWfkaIMihNlQWxXjoA;
		}
		set
		{
			this.CDhjxbSyXhVDyEsKtbKdLRtNCMWA = value + this.mlHWQwyndDaVYeXGAUOBvLwyyNGA;
			this.SuIEkgLJhlfYWfkaIMihNlQWxXjoA = value;
		}
	}

	// Token: 0x170001B3 RID: 435
	// (get) Token: 0x06000953 RID: 2387 RVA: 0x00016B46 File Offset: 0x00014D46
	// (set) Token: 0x06000954 RID: 2388 RVA: 0x00016B90 File Offset: 0x00014D90
	public float WZOEnrAzvxHxrndUymUZZqZkaVrB
	{
		get
		{
			return this.FJXAcoUBJZeYsAtuvYVTgVDCSxEMA;
		}
		set
		{
			this.KNqBLQCkiClPYjdhJOXUGmMuuFumA = value + this.PHyazyGGmzdpyjvOdnLvyrFCREWfB;
			this.FJXAcoUBJZeYsAtuvYVTgVDCSxEMA = value;
		}
	}

	// Token: 0x170001B4 RID: 436
	// (get) Token: 0x06000955 RID: 2389 RVA: 0x00016BA7 File Offset: 0x00014DA7
	// (set) Token: 0x06000956 RID: 2390 RVA: 0x00016BB6 File Offset: 0x00014DB6
	public float mlHWQwyndDaVYeXGAUOBvLwyyNGA
	{
		get
		{
			return this.CDhjxbSyXhVDyEsKtbKdLRtNCMWA - this.SuIEkgLJhlfYWfkaIMihNlQWxXjoA;
		}
		set
		{
			this.CDhjxbSyXhVDyEsKtbKdLRtNCMWA = this.SuIEkgLJhlfYWfkaIMihNlQWxXjoA + value;
		}
	}

	// Token: 0x170001B5 RID: 437
	// (get) Token: 0x06000957 RID: 2391 RVA: 0x00016BC6 File Offset: 0x00014DC6
	// (set) Token: 0x06000958 RID: 2392 RVA: 0x00016BD5 File Offset: 0x00014DD5
	public float PHyazyGGmzdpyjvOdnLvyrFCREWfB
	{
		get
		{
			return this.KNqBLQCkiClPYjdhJOXUGmMuuFumA - this.FJXAcoUBJZeYsAtuvYVTgVDCSxEMA;
		}
		set
		{
			this.KNqBLQCkiClPYjdhJOXUGmMuuFumA = this.FJXAcoUBJZeYsAtuvYVTgVDCSxEMA + value;
		}
	}

	// Token: 0x170001B6 RID: 438
	// (get) Token: 0x06000959 RID: 2393 RVA: 0x00016BE5 File Offset: 0x00014DE5
	// (set) Token: 0x0600095A RID: 2394 RVA: 0x00016BF8 File Offset: 0x00014DF8
	public qCqIBPaXfxjAqItjUhVdAyyFkGwAB KYPROVaADYUJQCzzcjqWPbAzNFXt
	{
		get
		{
			return new qCqIBPaXfxjAqItjUhVdAyyFkGwAB(this.PFuMhIIRJYTjmnucPdkWeLbGgOIs, this.WZOEnrAzvxHxrndUymUZZqZkaVrB);
		}
		set
		{
			this.PFuMhIIRJYTjmnucPdkWeLbGgOIs = value.EhulLFHPwUfVSsKKVPGVaiBMdoqH;
			this.WZOEnrAzvxHxrndUymUZZqZkaVrB = value.zIdinbmUoEeKBlIQLDYxCrGNpGsJA;
		}
	}

	// Token: 0x170001B7 RID: 439
	// (get) Token: 0x0600095B RID: 2395 RVA: 0x00016C12 File Offset: 0x00014E12
	public qCqIBPaXfxjAqItjUhVdAyyFkGwAB YEhoMesGwGMearnuJkUpSldDkUxn
	{
		get
		{
			return new qCqIBPaXfxjAqItjUhVdAyyFkGwAB(this.PFuMhIIRJYTjmnucPdkWeLbGgOIs + this.mlHWQwyndDaVYeXGAUOBvLwyyNGA / 2f, this.WZOEnrAzvxHxrndUymUZZqZkaVrB + this.PHyazyGGmzdpyjvOdnLvyrFCREWfB / 2f);
		}
	}

	// Token: 0x170001B8 RID: 440
	// (get) Token: 0x0600095C RID: 2396 RVA: 0x00016C3F File Offset: 0x00014E3F
	public bool WmMghoGyIavrfarghsOcOCriIxXz
	{
		get
		{
			return this.mlHWQwyndDaVYeXGAUOBvLwyyNGA == 0f && this.PHyazyGGmzdpyjvOdnLvyrFCREWfB == 0f && this.PFuMhIIRJYTjmnucPdkWeLbGgOIs == 0f && this.WZOEnrAzvxHxrndUymUZZqZkaVrB == 0f;
		}
	}

	// Token: 0x170001B9 RID: 441
	// (get) Token: 0x0600095D RID: 2397 RVA: 0x00016C77 File Offset: 0x00014E77
	// (set) Token: 0x0600095E RID: 2398 RVA: 0x00016C8A File Offset: 0x00014E8A
	public yKkkiQdMdUdcqZKfSgEftOZswBEt bluXsPFOAkevDWJzjkeyQZZXqHFB
	{
		get
		{
			return new yKkkiQdMdUdcqZKfSgEftOZswBEt(this.mlHWQwyndDaVYeXGAUOBvLwyyNGA, this.PHyazyGGmzdpyjvOdnLvyrFCREWfB);
		}
		set
		{
			this.mlHWQwyndDaVYeXGAUOBvLwyyNGA = value.TqWqoHWnMKkbJbEAnSvORdicmGCy;
			this.PHyazyGGmzdpyjvOdnLvyrFCREWfB = value.dnZCcmBfxlrbEGZBJBEFqiMJKNvJ;
		}
	}

	// Token: 0x170001BA RID: 442
	// (get) Token: 0x0600095F RID: 2399 RVA: 0x00016CA4 File Offset: 0x00014EA4
	public qCqIBPaXfxjAqItjUhVdAyyFkGwAB SAmNjAkmVZcpDXSJpoydInHapanI
	{
		get
		{
			return new qCqIBPaXfxjAqItjUhVdAyyFkGwAB(this.SuIEkgLJhlfYWfkaIMihNlQWxXjoA, this.FJXAcoUBJZeYsAtuvYVTgVDCSxEMA);
		}
	}

	// Token: 0x170001BB RID: 443
	// (get) Token: 0x06000960 RID: 2400 RVA: 0x00016CB7 File Offset: 0x00014EB7
	public qCqIBPaXfxjAqItjUhVdAyyFkGwAB DeTqaUbIzpootqJOQtWnNJpQKmHl
	{
		get
		{
			return new qCqIBPaXfxjAqItjUhVdAyyFkGwAB(this.CDhjxbSyXhVDyEsKtbKdLRtNCMWA, this.FJXAcoUBJZeYsAtuvYVTgVDCSxEMA);
		}
	}

	// Token: 0x170001BC RID: 444
	// (get) Token: 0x06000961 RID: 2401 RVA: 0x00016CCA File Offset: 0x00014ECA
	public qCqIBPaXfxjAqItjUhVdAyyFkGwAB siHrwbJckGucymnYkzutcSAtFKGV
	{
		get
		{
			return new qCqIBPaXfxjAqItjUhVdAyyFkGwAB(this.SuIEkgLJhlfYWfkaIMihNlQWxXjoA, this.KNqBLQCkiClPYjdhJOXUGmMuuFumA);
		}
	}

	// Token: 0x170001BD RID: 445
	// (get) Token: 0x06000962 RID: 2402 RVA: 0x00016CDD File Offset: 0x00014EDD
	public qCqIBPaXfxjAqItjUhVdAyyFkGwAB XGOfEDafANLQLVVsAdTnlSuOqIOaA
	{
		get
		{
			return new qCqIBPaXfxjAqItjUhVdAyyFkGwAB(this.CDhjxbSyXhVDyEsKtbKdLRtNCMWA, this.KNqBLQCkiClPYjdhJOXUGmMuuFumA);
		}
	}

	// Token: 0x06000963 RID: 2403 RVA: 0x00016CF0 File Offset: 0x00014EF0
	public void CaLGejhhjuSWOXHSYrBfoCeUEbWx(UsSOPzanjIgLYcPHHnDuDkTLGntP A_1)
	{
		this.thBMyswwKvgtZElyCENGmlHRdkKZ((float)A_1.CHHjiTGmHfRRQJnktCRaHsADXNLSA, (float)A_1.VuyUSeRQwbUbdgQTiEKcLyAArdqj);
	}

	// Token: 0x06000964 RID: 2404 RVA: 0x00016D06 File Offset: 0x00014F06
	public void HLnFyZoHFeUpYPexeTIXLbYdCjXI(qCqIBPaXfxjAqItjUhVdAyyFkGwAB A_1)
	{
		this.thBMyswwKvgtZElyCENGmlHRdkKZ(A_1.EhulLFHPwUfVSsKKVPGVaiBMdoqH, A_1.zIdinbmUoEeKBlIQLDYxCrGNpGsJA);
	}

	// Token: 0x06000965 RID: 2405 RVA: 0x00016D1A File Offset: 0x00014F1A
	public void thBMyswwKvgtZElyCENGmlHRdkKZ(float A_1, float A_2)
	{
		this.PFuMhIIRJYTjmnucPdkWeLbGgOIs += A_1;
		this.WZOEnrAzvxHxrndUymUZZqZkaVrB += A_2;
	}

	// Token: 0x06000966 RID: 2406 RVA: 0x0003A998 File Offset: 0x00038B98
	public void nBIDyrTmCVaoCDjJxBxzRgYRoTpJA(float A_1, float A_2)
	{
		this.PFuMhIIRJYTjmnucPdkWeLbGgOIs -= A_1;
		this.WZOEnrAzvxHxrndUymUZZqZkaVrB -= A_2;
		this.mlHWQwyndDaVYeXGAUOBvLwyyNGA += A_1 * 2f;
		this.PHyazyGGmzdpyjvOdnLvyrFCREWfB += A_2 * 2f;
	}

	// Token: 0x06000967 RID: 2407 RVA: 0x00016D38 File Offset: 0x00014F38
	public void BTyonRPDODLyDdBeQFIddKqEZcJv(ref qCqIBPaXfxjAqItjUhVdAyyFkGwAB A_1, out bool A_2)
	{
		A_2 = (this.PFuMhIIRJYTjmnucPdkWeLbGgOIs <= A_1.EhulLFHPwUfVSsKKVPGVaiBMdoqH && A_1.EhulLFHPwUfVSsKKVPGVaiBMdoqH < this.VRhhdrHHwosRgPpFeFfaWAVwdLVo && this.WZOEnrAzvxHxrndUymUZZqZkaVrB <= A_1.zIdinbmUoEeKBlIQLDYxCrGNpGsJA && A_1.zIdinbmUoEeKBlIQLDYxCrGNpGsJA < this.OLZRgkgngLoNhoStFDOURjEIdPJA);
	}

	// Token: 0x06000968 RID: 2408 RVA: 0x0003A9EC File Offset: 0x00038BEC
	public bool WtiaFqhMMQWUADtAkcyspKQakHPx(kiQRbEZsKkcjshJAvWBOGasyhmQyA A_1)
	{
		return this.PFuMhIIRJYTjmnucPdkWeLbGgOIs <= (float)A_1.BaIwmQBiQOGKUfDCkDggNeRMmhogA && (float)A_1.aIravJZpoYzNpykFkYjsqGYKUsQm <= this.VRhhdrHHwosRgPpFeFfaWAVwdLVo && this.WZOEnrAzvxHxrndUymUZZqZkaVrB <= (float)A_1.wRwZrXswEIpRnLAcMJAQLbrzKLuO && (float)A_1.YuWafxhSBeNrxHJuKpnIDZSlzGRT <= this.OLZRgkgngLoNhoStFDOURjEIdPJA;
	}

	// Token: 0x06000969 RID: 2409 RVA: 0x0003AA40 File Offset: 0x00038C40
	public void bVsXwRkrwDDFfLfmTnSZTCbVpIBg(ref vncWshtQjZIaBQcXUuhKPihxaijS A_1, out bool A_2)
	{
		A_2 = (this.PFuMhIIRJYTjmnucPdkWeLbGgOIs <= A_1.PFuMhIIRJYTjmnucPdkWeLbGgOIs && A_1.VRhhdrHHwosRgPpFeFfaWAVwdLVo <= this.VRhhdrHHwosRgPpFeFfaWAVwdLVo && this.WZOEnrAzvxHxrndUymUZZqZkaVrB <= A_1.WZOEnrAzvxHxrndUymUZZqZkaVrB && A_1.OLZRgkgngLoNhoStFDOURjEIdPJA <= this.OLZRgkgngLoNhoStFDOURjEIdPJA);
	}

	// Token: 0x0600096A RID: 2410 RVA: 0x00016D77 File Offset: 0x00014F77
	public bool TVwZgyPWfUgGBsGQywEXsDpAOKxB(float A_1, float A_2)
	{
		return A_1 >= this.SuIEkgLJhlfYWfkaIMihNlQWxXjoA && A_1 <= this.CDhjxbSyXhVDyEsKtbKdLRtNCMWA && A_2 >= this.FJXAcoUBJZeYsAtuvYVTgVDCSxEMA && A_2 <= this.KNqBLQCkiClPYjdhJOXUGmMuuFumA;
	}

	// Token: 0x0600096B RID: 2411 RVA: 0x00016DA2 File Offset: 0x00014FA2
	public bool tVqHdkoqJLiUninaxPuuJjLdeWIfA(qCqIBPaXfxjAqItjUhVdAyyFkGwAB A_1)
	{
		return this.TVwZgyPWfUgGBsGQywEXsDpAOKxB(A_1.EhulLFHPwUfVSsKKVPGVaiBMdoqH, A_1.zIdinbmUoEeKBlIQLDYxCrGNpGsJA);
	}

	// Token: 0x0600096C RID: 2412 RVA: 0x00016DB6 File Offset: 0x00014FB6
	public bool XlcMgvUazWXhpFmzYXYtQrpntGoc(UsSOPzanjIgLYcPHHnDuDkTLGntP A_1)
	{
		return this.TVwZgyPWfUgGBsGQywEXsDpAOKxB((float)A_1.CHHjiTGmHfRRQJnktCRaHsADXNLSA, (float)A_1.VuyUSeRQwbUbdgQTiEKcLyAArdqj);
	}

	// Token: 0x0600096D RID: 2413 RVA: 0x0003AA90 File Offset: 0x00038C90
	public bool indtmGEdfvWrwFLKmHwEeLwWmAv(vncWshtQjZIaBQcXUuhKPihxaijS A_1)
	{
		bool result;
		this.WUVwJoCONxOKAKAToANehdEXJnPab(ref A_1, out result);
		return result;
	}

	// Token: 0x0600096E RID: 2414 RVA: 0x00016DCC File Offset: 0x00014FCC
	public void WUVwJoCONxOKAKAToANehdEXJnPab(ref vncWshtQjZIaBQcXUuhKPihxaijS A_1, out bool A_2)
	{
		A_2 = (A_1.PFuMhIIRJYTjmnucPdkWeLbGgOIs < this.VRhhdrHHwosRgPpFeFfaWAVwdLVo && this.PFuMhIIRJYTjmnucPdkWeLbGgOIs < A_1.VRhhdrHHwosRgPpFeFfaWAVwdLVo && A_1.WZOEnrAzvxHxrndUymUZZqZkaVrB < this.OLZRgkgngLoNhoStFDOURjEIdPJA && this.WZOEnrAzvxHxrndUymUZZqZkaVrB < A_1.OLZRgkgngLoNhoStFDOURjEIdPJA);
	}

	// Token: 0x0600096F RID: 2415 RVA: 0x0003AAA8 File Offset: 0x00038CA8
	public static vncWshtQjZIaBQcXUuhKPihxaijS nCSsIqxLsXbzmVYnQGFBLltjxkJd(vncWshtQjZIaBQcXUuhKPihxaijS A_0, vncWshtQjZIaBQcXUuhKPihxaijS A_1)
	{
		vncWshtQjZIaBQcXUuhKPihxaijS result;
		vncWshtQjZIaBQcXUuhKPihxaijS.DLidchUBoXdVQdXPGCCIEfuIFvyKb(ref A_0, ref A_1, out result);
		return result;
	}

	// Token: 0x06000970 RID: 2416 RVA: 0x0003AAC4 File Offset: 0x00038CC4
	public static void DLidchUBoXdVQdXPGCCIEfuIFvyKb(ref vncWshtQjZIaBQcXUuhKPihxaijS A_0, ref vncWshtQjZIaBQcXUuhKPihxaijS A_1, out vncWshtQjZIaBQcXUuhKPihxaijS A_2)
	{
		float num = (A_0.PFuMhIIRJYTjmnucPdkWeLbGgOIs > A_1.PFuMhIIRJYTjmnucPdkWeLbGgOIs) ? A_0.PFuMhIIRJYTjmnucPdkWeLbGgOIs : A_1.PFuMhIIRJYTjmnucPdkWeLbGgOIs;
		float num2 = (A_0.WZOEnrAzvxHxrndUymUZZqZkaVrB > A_1.WZOEnrAzvxHxrndUymUZZqZkaVrB) ? A_0.WZOEnrAzvxHxrndUymUZZqZkaVrB : A_1.WZOEnrAzvxHxrndUymUZZqZkaVrB;
		float num3 = (A_0.VRhhdrHHwosRgPpFeFfaWAVwdLVo < A_1.VRhhdrHHwosRgPpFeFfaWAVwdLVo) ? A_0.VRhhdrHHwosRgPpFeFfaWAVwdLVo : A_1.VRhhdrHHwosRgPpFeFfaWAVwdLVo;
		float num4 = (A_0.OLZRgkgngLoNhoStFDOURjEIdPJA < A_1.OLZRgkgngLoNhoStFDOURjEIdPJA) ? A_0.OLZRgkgngLoNhoStFDOURjEIdPJA : A_1.OLZRgkgngLoNhoStFDOURjEIdPJA;
		if (num3 > num && num4 > num2)
		{
			A_2 = new vncWshtQjZIaBQcXUuhKPihxaijS(num, num2, num3 - num, num4 - num2);
			return;
		}
		A_2 = vncWshtQjZIaBQcXUuhKPihxaijS.xagYOCgJJufnnjjimNTJsidVcWkVA;
	}

	// Token: 0x06000971 RID: 2417 RVA: 0x0003AB6C File Offset: 0x00038D6C
	public static vncWshtQjZIaBQcXUuhKPihxaijS zuujCGoIpTxRDmixKHQPyaksppsx(vncWshtQjZIaBQcXUuhKPihxaijS A_0, vncWshtQjZIaBQcXUuhKPihxaijS A_1)
	{
		vncWshtQjZIaBQcXUuhKPihxaijS result;
		vncWshtQjZIaBQcXUuhKPihxaijS.ZNmqRgBSSehQyKWhkrpeyTJYKKxe(ref A_0, ref A_1, out result);
		return result;
	}

	// Token: 0x06000972 RID: 2418 RVA: 0x0003AB88 File Offset: 0x00038D88
	public static void ZNmqRgBSSehQyKWhkrpeyTJYKKxe(ref vncWshtQjZIaBQcXUuhKPihxaijS A_0, ref vncWshtQjZIaBQcXUuhKPihxaijS A_1, out vncWshtQjZIaBQcXUuhKPihxaijS A_2)
	{
		float num = Math.Min(A_0.YxYalUvbQdFgoIsCPEtZgKvHNRZv, A_1.YxYalUvbQdFgoIsCPEtZgKvHNRZv);
		float num2 = Math.Max(A_0.VRhhdrHHwosRgPpFeFfaWAVwdLVo, A_1.VRhhdrHHwosRgPpFeFfaWAVwdLVo);
		float num3 = Math.Min(A_0.dSExOTQJZrvgFBFYhPykXnGPLSHD, A_1.dSExOTQJZrvgFBFYhPykXnGPLSHD);
		float num4 = Math.Max(A_0.OLZRgkgngLoNhoStFDOURjEIdPJA, A_1.OLZRgkgngLoNhoStFDOURjEIdPJA);
		A_2 = new vncWshtQjZIaBQcXUuhKPihxaijS(num, num3, num2 - num, num4 - num3);
	}

	// Token: 0x06000973 RID: 2419 RVA: 0x00016E0B File Offset: 0x0001500B
	public bool WWxGRzVLQJCNcFjKQiDfsgjIeNUlA(object A_1)
	{
		return A_1 != null && !(A_1.GetType() != typeof(vncWshtQjZIaBQcXUuhKPihxaijS)) && this.Equals((vncWshtQjZIaBQcXUuhKPihxaijS)A_1);
	}

	// Token: 0x06000974 RID: 2420 RVA: 0x0003ABF0 File Offset: 0x00038DF0
	public bool Equals(vncWshtQjZIaBQcXUuhKPihxaijS other)
	{
		return ACVTseoaUnpTFsXommHYwDIfFbWHA.AqzqamXttNjEeXpXFNqLKUCLnHCV(other.YxYalUvbQdFgoIsCPEtZgKvHNRZv, this.YxYalUvbQdFgoIsCPEtZgKvHNRZv) && ACVTseoaUnpTFsXommHYwDIfFbWHA.AqzqamXttNjEeXpXFNqLKUCLnHCV(other.VRhhdrHHwosRgPpFeFfaWAVwdLVo, this.VRhhdrHHwosRgPpFeFfaWAVwdLVo) && ACVTseoaUnpTFsXommHYwDIfFbWHA.AqzqamXttNjEeXpXFNqLKUCLnHCV(other.dSExOTQJZrvgFBFYhPykXnGPLSHD, this.dSExOTQJZrvgFBFYhPykXnGPLSHD) && ACVTseoaUnpTFsXommHYwDIfFbWHA.AqzqamXttNjEeXpXFNqLKUCLnHCV(other.OLZRgkgngLoNhoStFDOURjEIdPJA, this.OLZRgkgngLoNhoStFDOURjEIdPJA);
	}

	// Token: 0x06000975 RID: 2421 RVA: 0x0003AC50 File Offset: 0x00038E50
	public int mltnxvJkJEQeyNWLLclLERSjjyhD()
	{
		return ((this.SuIEkgLJhlfYWfkaIMihNlQWxXjoA.GetHashCode() * 397 ^ this.FJXAcoUBJZeYsAtuvYVTgVDCSxEMA.GetHashCode()) * 397 ^ this.CDhjxbSyXhVDyEsKtbKdLRtNCMWA.GetHashCode()) * 397 ^ this.KNqBLQCkiClPYjdhJOXUGmMuuFumA.GetHashCode();
	}

	// Token: 0x06000976 RID: 2422 RVA: 0x0003ACA0 File Offset: 0x00038EA0
	public string yVkHJpxDJaowRoxPXZBHxzkSSHpL()
	{
		return string.Format(CultureInfo.InvariantCulture, "X:{0} Y:{1} Width:{2} Height:{3}", new object[]
		{
			this.PFuMhIIRJYTjmnucPdkWeLbGgOIs,
			this.WZOEnrAzvxHxrndUymUZZqZkaVrB,
			this.mlHWQwyndDaVYeXGAUOBvLwyyNGA,
			this.PHyazyGGmzdpyjvOdnLvyrFCREWfB
		});
	}

	// Token: 0x06000977 RID: 2423 RVA: 0x00016E37 File Offset: 0x00015037
	public static bool hgLWwZADrDxUULDYPgRvVnxIujDx(vncWshtQjZIaBQcXUuhKPihxaijS A_0, vncWshtQjZIaBQcXUuhKPihxaijS A_1)
	{
		return A_0.Equals(A_1);
	}

	// Token: 0x06000978 RID: 2424 RVA: 0x00016E41 File Offset: 0x00015041
	public static bool fpBZEuhDYhlbfIacijrxaxiYuwyM(vncWshtQjZIaBQcXUuhKPihxaijS A_0, vncWshtQjZIaBQcXUuhKPihxaijS A_1)
	{
		return !vncWshtQjZIaBQcXUuhKPihxaijS.hgLWwZADrDxUULDYPgRvVnxIujDx(A_0, A_1);
	}

	// Token: 0x06000979 RID: 2425 RVA: 0x00016E4D File Offset: 0x0001504D
	public static kiQRbEZsKkcjshJAvWBOGasyhmQyA JiliyJTzbsfOgksHybPvAyvHUzZI(vncWshtQjZIaBQcXUuhKPihxaijS A_0)
	{
		return new kiQRbEZsKkcjshJAvWBOGasyhmQyA((int)A_0.PFuMhIIRJYTjmnucPdkWeLbGgOIs, (int)A_0.WZOEnrAzvxHxrndUymUZZqZkaVrB, (int)A_0.mlHWQwyndDaVYeXGAUOBvLwyyNGA, (int)A_0.PHyazyGGmzdpyjvOdnLvyrFCREWfB);
	}

	// Token: 0x04000876 RID: 2166
	private float SuIEkgLJhlfYWfkaIMihNlQWxXjoA;

	// Token: 0x04000877 RID: 2167
	private float FJXAcoUBJZeYsAtuvYVTgVDCSxEMA;

	// Token: 0x04000878 RID: 2168
	private float CDhjxbSyXhVDyEsKtbKdLRtNCMWA;

	// Token: 0x04000879 RID: 2169
	private float KNqBLQCkiClPYjdhJOXUGmMuuFumA;

	// Token: 0x0400087A RID: 2170
	public static readonly vncWshtQjZIaBQcXUuhKPihxaijS xagYOCgJJufnnjjimNTJsidVcWkVA = default(vncWshtQjZIaBQcXUuhKPihxaijS);

	// Token: 0x0400087B RID: 2171
	public static readonly vncWshtQjZIaBQcXUuhKPihxaijS lGartHQsQVhFUFHVYoWDQgPCHLec = new vncWshtQjZIaBQcXUuhKPihxaijS
	{
		YxYalUvbQdFgoIsCPEtZgKvHNRZv = float.NegativeInfinity,
		dSExOTQJZrvgFBFYhPykXnGPLSHD = float.NegativeInfinity,
		VRhhdrHHwosRgPpFeFfaWAVwdLVo = float.PositiveInfinity,
		OLZRgkgngLoNhoStFDOURjEIdPJA = float.PositiveInfinity
	};
}
