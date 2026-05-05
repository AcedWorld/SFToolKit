using System;

namespace Unity.Services.Authentication
{
	// Token: 0x02000043 RID: 67
	public sealed class SignInCodeInfo
	{
		// Token: 0x1700004A RID: 74
		// (get) Token: 0x0600019D RID: 413 RVA: 0x00005342 File Offset: 0x00003542
		// (set) Token: 0x0600019E RID: 414 RVA: 0x0000534A File Offset: 0x0000354A
		public string SignInCode { get; internal set; }

		// Token: 0x1700004B RID: 75
		// (get) Token: 0x0600019F RID: 415 RVA: 0x00005353 File Offset: 0x00003553
		// (set) Token: 0x060001A0 RID: 416 RVA: 0x0000535B File Offset: 0x0000355B
		public string Expiration { get; internal set; }

		// Token: 0x1700004C RID: 76
		// (get) Token: 0x060001A1 RID: 417 RVA: 0x00005364 File Offset: 0x00003564
		// (set) Token: 0x060001A2 RID: 418 RVA: 0x0000536C File Offset: 0x0000356C
		public string Identifier { get; internal set; }
	}
}
