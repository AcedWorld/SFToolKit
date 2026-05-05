using System;
using System.Collections.Generic;
using Rewired.Utils;

// Token: 0x02000072 RID: 114
internal class HcYEnccIjPAYPjznhnzOXfyNmtcA : ltTfAQarXGuyOkgVdzmGsTLJYqWh
{
	// Token: 0x060003AF RID: 943 RVA: 0x000131B9 File Offset: 0x000113B9
	public HcYEnccIjPAYPjznhnzOXfyNmtcA()
	{
		this.ftdwtHHLIAlkkUuCzNcxMVYWjwOk = new List<ihwszOdiGYsRSXWvkodJEoTjuDiw>();
	}

	// Token: 0x060003B0 RID: 944 RVA: 0x000131CC File Offset: 0x000113CC
	public virtual void xUfZgcQPRAJVBaAHLNVQhKbHKfUt(ihwszOdiGYsRSXWvkodJEoTjuDiw A_1)
	{
		this.ftdwtHHLIAlkkUuCzNcxMVYWjwOk.Add(A_1);
	}

	// Token: 0x060003B1 RID: 945 RVA: 0x000131DA File Offset: 0x000113DA
	public float wYoiXYUrBndvPuoILfVoGOgkslQ(int A_1)
	{
		if (A_1 < 0 || A_1 >= this.VWznnHBBXJJdMnMCDPcQPhGCIios.Length)
		{
			return 0f;
		}
		return HcYEnccIjPAYPjznhnzOXfyNmtcA.BYsTuVWisRSHatmiEBgazmbkrkJE(this.VWznnHBBXJJdMnMCDPcQPhGCIios[A_1].VKRYWMZHkHIznywPVqRInADnarzE);
	}

	// Token: 0x060003B2 RID: 946 RVA: 0x00013203 File Offset: 0x00011403
	public int TLcASOBMpHSiwGDNDoRvfAoduWTgc(int A_1)
	{
		if (A_1 < 0 || A_1 >= this.VWznnHBBXJJdMnMCDPcQPhGCIios.Length)
		{
			return 0;
		}
		return (int)this.VWznnHBBXJJdMnMCDPcQPhGCIios[A_1].MdEkFfkLDDnBrMjoRMUEHYrIjRhw;
	}

	// Token: 0x060003B3 RID: 947 RVA: 0x00013223 File Offset: 0x00011423
	public virtual void cBvrpjNWxHAOBghCtdikxAbGSGOH()
	{
		if (this.FvBShdpftSaqihgjeJCMeZBYwKfJA)
		{
			return;
		}
		this.FvBShdpftSaqihgjeJCMeZBYwKfJA = true;
		this.VWznnHBBXJJdMnMCDPcQPhGCIios = this.ftdwtHHLIAlkkUuCzNcxMVYWjwOk.ToArray();
		this.ftdwtHHLIAlkkUuCzNcxMVYWjwOk = null;
	}

	// Token: 0x060003B4 RID: 948 RVA: 0x0001198F File Offset: 0x0000FB8F
	private static float BYsTuVWisRSHatmiEBgazmbkrkJE(int A_0)
	{
		if (A_0 == 0)
		{
			return 0f;
		}
		return MathTools.Clamp((float)MathTools.Abs(A_0) / 65535f * (float)MathTools.Sign(A_0), -1f, 1f);
	}

	// Token: 0x0400053F RID: 1343
	private List<ihwszOdiGYsRSXWvkodJEoTjuDiw> ftdwtHHLIAlkkUuCzNcxMVYWjwOk;

	// Token: 0x04000540 RID: 1344
	private ihwszOdiGYsRSXWvkodJEoTjuDiw[] VWznnHBBXJJdMnMCDPcQPhGCIios;

	// Token: 0x04000541 RID: 1345
	private bool FvBShdpftSaqihgjeJCMeZBYwKfJA;
}
