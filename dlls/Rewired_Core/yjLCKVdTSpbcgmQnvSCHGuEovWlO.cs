using System;
using UnityEngine;

// Token: 0x020004C2 RID: 1218
internal static class yjLCKVdTSpbcgmQnvSCHGuEovWlO
{
	// Token: 0x17000B2A RID: 2858
	// (get) Token: 0x0600310E RID: 12558 RVA: 0x000258C1 File Offset: 0x00023AC1
	public static double iIPFJYQIxtkAvckkzRtiwBOykiYl
	{
		get
		{
			return yjLCKVdTSpbcgmQnvSCHGuEovWlO.pJdPhmUhNnJXGOmKgrjPlvyvVGwG;
		}
	}

	// Token: 0x17000B2B RID: 2859
	// (get) Token: 0x0600310F RID: 12559 RVA: 0x000258C8 File Offset: 0x00023AC8
	// (set) Token: 0x06003110 RID: 12560 RVA: 0x000258CF File Offset: 0x00023ACF
	public static int vqvaWAAmGLeWTmsrbruCMAzdDkwB
	{
		get
		{
			return yjLCKVdTSpbcgmQnvSCHGuEovWlO.vlRoAIdfZiCJSkOVvokhhfrGBjCgc;
		}
		set
		{
			if (value <= 0)
			{
				value = 1;
			}
			if (value == yjLCKVdTSpbcgmQnvSCHGuEovWlO.vlRoAIdfZiCJSkOVvokhhfrGBjCgc)
			{
				return;
			}
			yjLCKVdTSpbcgmQnvSCHGuEovWlO.vlRoAIdfZiCJSkOVvokhhfrGBjCgc = value;
			yjLCKVdTSpbcgmQnvSCHGuEovWlO.xqapBvRsTbiqtcHzkvIZhWuCIWMn();
		}
	}

	// Token: 0x06003111 RID: 12561 RVA: 0x000258EC File Offset: 0x00023AEC
	static yjLCKVdTSpbcgmQnvSCHGuEovWlO()
	{
		yjLCKVdTSpbcgmQnvSCHGuEovWlO.xqapBvRsTbiqtcHzkvIZhWuCIWMn();
	}

	// Token: 0x06003112 RID: 12562 RVA: 0x000AB6BC File Offset: 0x000A98BC
	public static void MQCyoYVJCNjkBfaiiQlVUGyRiDOMA()
	{
		int frameCount = Time.frameCount;
		if (yjLCKVdTSpbcgmQnvSCHGuEovWlO.tebZIaNyCnlruPwpoZwoBdjzSFUH >= frameCount)
		{
			return;
		}
		yjLCKVdTSpbcgmQnvSCHGuEovWlO.tekbhmHRzEeWWCRQlkmucnpHaMRbA[yjLCKVdTSpbcgmQnvSCHGuEovWlO.CGOCzMwkhJFcgJahkDqBoGLBEVau] = (double)Time.deltaTime;
		if (yjLCKVdTSpbcgmQnvSCHGuEovWlO.yYADblUUXyFafGvUJeMoDmMwNCDy < yjLCKVdTSpbcgmQnvSCHGuEovWlO.vlRoAIdfZiCJSkOVvokhhfrGBjCgc)
		{
			yjLCKVdTSpbcgmQnvSCHGuEovWlO.yYADblUUXyFafGvUJeMoDmMwNCDy++;
		}
		double num = 0.0;
		for (int i = 0; i < yjLCKVdTSpbcgmQnvSCHGuEovWlO.yYADblUUXyFafGvUJeMoDmMwNCDy; i++)
		{
			num += yjLCKVdTSpbcgmQnvSCHGuEovWlO.tekbhmHRzEeWWCRQlkmucnpHaMRbA[i];
		}
		yjLCKVdTSpbcgmQnvSCHGuEovWlO.pJdPhmUhNnJXGOmKgrjPlvyvVGwG = num / (double)yjLCKVdTSpbcgmQnvSCHGuEovWlO.yYADblUUXyFafGvUJeMoDmMwNCDy;
		yjLCKVdTSpbcgmQnvSCHGuEovWlO.CGOCzMwkhJFcgJahkDqBoGLBEVau++;
		if (yjLCKVdTSpbcgmQnvSCHGuEovWlO.CGOCzMwkhJFcgJahkDqBoGLBEVau >= yjLCKVdTSpbcgmQnvSCHGuEovWlO.vlRoAIdfZiCJSkOVvokhhfrGBjCgc)
		{
			yjLCKVdTSpbcgmQnvSCHGuEovWlO.CGOCzMwkhJFcgJahkDqBoGLBEVau = 0;
		}
		yjLCKVdTSpbcgmQnvSCHGuEovWlO.tebZIaNyCnlruPwpoZwoBdjzSFUH = frameCount;
	}

	// Token: 0x06003113 RID: 12563 RVA: 0x000258FA File Offset: 0x00023AFA
	public static void xqapBvRsTbiqtcHzkvIZhWuCIWMn()
	{
		if (yjLCKVdTSpbcgmQnvSCHGuEovWlO.tekbhmHRzEeWWCRQlkmucnpHaMRbA == null || yjLCKVdTSpbcgmQnvSCHGuEovWlO.tekbhmHRzEeWWCRQlkmucnpHaMRbA.Length != yjLCKVdTSpbcgmQnvSCHGuEovWlO.vlRoAIdfZiCJSkOVvokhhfrGBjCgc)
		{
			yjLCKVdTSpbcgmQnvSCHGuEovWlO.tekbhmHRzEeWWCRQlkmucnpHaMRbA = new double[yjLCKVdTSpbcgmQnvSCHGuEovWlO.vlRoAIdfZiCJSkOVvokhhfrGBjCgc];
		}
		yjLCKVdTSpbcgmQnvSCHGuEovWlO.yYADblUUXyFafGvUJeMoDmMwNCDy = 0;
		yjLCKVdTSpbcgmQnvSCHGuEovWlO.CGOCzMwkhJFcgJahkDqBoGLBEVau = 0;
		yjLCKVdTSpbcgmQnvSCHGuEovWlO.tebZIaNyCnlruPwpoZwoBdjzSFUH = 0;
	}

	// Token: 0x04001AE4 RID: 6884
	private static int vlRoAIdfZiCJSkOVvokhhfrGBjCgc = 30;

	// Token: 0x04001AE5 RID: 6885
	private static int CGOCzMwkhJFcgJahkDqBoGLBEVau;

	// Token: 0x04001AE6 RID: 6886
	private static double[] tekbhmHRzEeWWCRQlkmucnpHaMRbA;

	// Token: 0x04001AE7 RID: 6887
	private static int yYADblUUXyFafGvUJeMoDmMwNCDy;

	// Token: 0x04001AE8 RID: 6888
	private static double pJdPhmUhNnJXGOmKgrjPlvyvVGwG;

	// Token: 0x04001AE9 RID: 6889
	private static int tebZIaNyCnlruPwpoZwoBdjzSFUH;
}
