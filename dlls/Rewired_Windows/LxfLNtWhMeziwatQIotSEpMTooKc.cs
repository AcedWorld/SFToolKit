using System;
using System.Runtime.InteropServices;

// Token: 0x02000184 RID: 388
internal struct LxfLNtWhMeziwatQIotSEpMTooKc
{
	// Token: 0x06000B8D RID: 2957 RVA: 0x000180CA File Offset: 0x000162CA
	internal void dJblrEOihNKmTWBHJftqFcVbLmOu(ref LxfLNtWhMeziwatQIotSEpMTooKc.XjSweIupjiCFVALiqJChWZMlQmUpA A_1)
	{
		A_1.aTDAFoHJDpueCkSAuGJSZDuPPYKMA();
	}

	// Token: 0x06000B8E RID: 2958 RVA: 0x0003E21C File Offset: 0x0003C41C
	internal void PFwDJdkjCwZRsXoKhwxWcMNBxNCv(ref LxfLNtWhMeziwatQIotSEpMTooKc.XjSweIupjiCFVALiqJChWZMlQmUpA A_1)
	{
		this.wNxQqPBkteHohZrUrDazvwSTetMg = ((A_1.hcPpnXqlMPbQBJkEpgalbUYzcXggA == IntPtr.Zero) ? null : Marshal.PtrToStringAnsi(A_1.hcPpnXqlMPbQBJkEpgalbUYzcXggA));
		this.ZkQVtZopaSDQFgnrQaxSzZpyyrtFA = ((A_1.LvHbgZLMfGDZqftMFoFUiQuRIawhb == IntPtr.Zero) ? null : Marshal.PtrToStringAnsi(A_1.LvHbgZLMfGDZqftMFoFUiQuRIawhb));
	}

	// Token: 0x040017DA RID: 6106
	public string wNxQqPBkteHohZrUrDazvwSTetMg;

	// Token: 0x040017DB RID: 6107
	public string ZkQVtZopaSDQFgnrQaxSzZpyyrtFA;

	// Token: 0x02000185 RID: 389
	internal struct XjSweIupjiCFVALiqJChWZMlQmUpA
	{
		// Token: 0x06000B8F RID: 2959 RVA: 0x000180D2 File Offset: 0x000162D2
		internal void aTDAFoHJDpueCkSAuGJSZDuPPYKMA()
		{
			if (this.hcPpnXqlMPbQBJkEpgalbUYzcXggA != IntPtr.Zero)
			{
				Marshal.FreeHGlobal(this.hcPpnXqlMPbQBJkEpgalbUYzcXggA);
			}
			if (this.LvHbgZLMfGDZqftMFoFUiQuRIawhb != IntPtr.Zero)
			{
				Marshal.FreeHGlobal(this.LvHbgZLMfGDZqftMFoFUiQuRIawhb);
			}
		}

		// Token: 0x040017DC RID: 6108
		public IntPtr hcPpnXqlMPbQBJkEpgalbUYzcXggA;

		// Token: 0x040017DD RID: 6109
		public IntPtr LvHbgZLMfGDZqftMFoFUiQuRIawhb;
	}
}
