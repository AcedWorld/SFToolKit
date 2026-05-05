using System;

// Token: 0x02000109 RID: 265
internal struct yKkkiQdMdUdcqZKfSgEftOZswBEt : IEquatable<yKkkiQdMdUdcqZKfSgEftOZswBEt>
{
	// Token: 0x060009C5 RID: 2501 RVA: 0x00017288 File Offset: 0x00015488
	public yKkkiQdMdUdcqZKfSgEftOZswBEt(float A_1, float A_2)
	{
		this.TqWqoHWnMKkbJbEAnSvORdicmGCy = A_1;
		this.dnZCcmBfxlrbEGZBJBEFqiMJKNvJ = A_2;
	}

	// Token: 0x060009C6 RID: 2502 RVA: 0x00017298 File Offset: 0x00015498
	public bool Equals(yKkkiQdMdUdcqZKfSgEftOZswBEt other)
	{
		return other.TqWqoHWnMKkbJbEAnSvORdicmGCy == this.TqWqoHWnMKkbJbEAnSvORdicmGCy && other.dnZCcmBfxlrbEGZBJBEFqiMJKNvJ == this.dnZCcmBfxlrbEGZBJBEFqiMJKNvJ;
	}

	// Token: 0x060009C7 RID: 2503 RVA: 0x000172B8 File Offset: 0x000154B8
	public bool RyvilGXDRtmLbXmSZnKCBLHKbNrB(object A_1)
	{
		return A_1 != null && !(A_1.GetType() != typeof(yKkkiQdMdUdcqZKfSgEftOZswBEt)) && this.Equals((yKkkiQdMdUdcqZKfSgEftOZswBEt)A_1);
	}

	// Token: 0x060009C8 RID: 2504 RVA: 0x000172E4 File Offset: 0x000154E4
	public int KmowkYuHmITAKjjZcwLwbYvyIgZf()
	{
		return this.TqWqoHWnMKkbJbEAnSvORdicmGCy.GetHashCode() * 397 ^ this.dnZCcmBfxlrbEGZBJBEFqiMJKNvJ.GetHashCode();
	}

	// Token: 0x060009C9 RID: 2505 RVA: 0x00017303 File Offset: 0x00015503
	public static bool nElhBGlUVtHDruePfXHmWSDbvfhg(yKkkiQdMdUdcqZKfSgEftOZswBEt A_0, yKkkiQdMdUdcqZKfSgEftOZswBEt A_1)
	{
		return A_0.Equals(A_1);
	}

	// Token: 0x060009CA RID: 2506 RVA: 0x0001730D File Offset: 0x0001550D
	public static bool fPXLWFxUrciEMYtxZrLyPekXaJtS(yKkkiQdMdUdcqZKfSgEftOZswBEt A_0, yKkkiQdMdUdcqZKfSgEftOZswBEt A_1)
	{
		return !A_0.Equals(A_1);
	}

	// Token: 0x060009CB RID: 2507 RVA: 0x0001731A File Offset: 0x0001551A
	public string FaJFBezXDtUmBLWxflHyiOocadOT()
	{
		return string.Format("({0},{1})", this.TqWqoHWnMKkbJbEAnSvORdicmGCy, this.dnZCcmBfxlrbEGZBJBEFqiMJKNvJ);
	}

	// Token: 0x0400089E RID: 2206
	public static readonly yKkkiQdMdUdcqZKfSgEftOZswBEt UDarTWUnwtBbitBsSDpaAzyCbBHb = new yKkkiQdMdUdcqZKfSgEftOZswBEt(0f, 0f);

	// Token: 0x0400089F RID: 2207
	public static readonly yKkkiQdMdUdcqZKfSgEftOZswBEt pEEJUJpfpLaeWbQwNzaIbyyzypnaA = yKkkiQdMdUdcqZKfSgEftOZswBEt.UDarTWUnwtBbitBsSDpaAzyCbBHb;

	// Token: 0x040008A0 RID: 2208
	public float TqWqoHWnMKkbJbEAnSvORdicmGCy;

	// Token: 0x040008A1 RID: 2209
	public float dnZCcmBfxlrbEGZBJBEFqiMJKNvJ;
}
