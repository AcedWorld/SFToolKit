using System;

namespace Unity.Services.Authentication.Shared
{
	// Token: 0x02000061 RID: 97
	internal class ApiResponse : IApiResponse
	{
		// Token: 0x17000084 RID: 132
		// (get) Token: 0x06000291 RID: 657 RVA: 0x0000700C File Offset: 0x0000520C
		// (set) Token: 0x06000292 RID: 658 RVA: 0x00007014 File Offset: 0x00005214
		public int StatusCode { get; internal set; }

		// Token: 0x17000085 RID: 133
		// (get) Token: 0x06000293 RID: 659 RVA: 0x0000701D File Offset: 0x0000521D
		// (set) Token: 0x06000294 RID: 660 RVA: 0x00007025 File Offset: 0x00005225
		public Multimap<string, string> Headers { get; internal set; }

		// Token: 0x17000086 RID: 134
		// (get) Token: 0x06000295 RID: 661 RVA: 0x0000702E File Offset: 0x0000522E
		// (set) Token: 0x06000296 RID: 662 RVA: 0x00007036 File Offset: 0x00005236
		public string ErrorText { get; internal set; }

		// Token: 0x17000087 RID: 135
		// (get) Token: 0x06000297 RID: 663 RVA: 0x0000703F File Offset: 0x0000523F
		// (set) Token: 0x06000298 RID: 664 RVA: 0x00007047 File Offset: 0x00005247
		public string RawContent { get; internal set; }

		// Token: 0x17000088 RID: 136
		// (get) Token: 0x06000299 RID: 665 RVA: 0x00007050 File Offset: 0x00005250
		public virtual object Content
		{
			get
			{
				return null;
			}
		}

		// Token: 0x17000089 RID: 137
		// (get) Token: 0x0600029A RID: 666 RVA: 0x00007053 File Offset: 0x00005253
		public bool IsSuccessful
		{
			get
			{
				return this.StatusCode >= 200 && this.StatusCode < 300;
			}
		}

		// Token: 0x1700008A RID: 138
		// (get) Token: 0x0600029B RID: 667 RVA: 0x00007071 File Offset: 0x00005271
		public bool IsRedirection
		{
			get
			{
				return this.StatusCode >= 300 && this.StatusCode < 400;
			}
		}

		// Token: 0x1700008B RID: 139
		// (get) Token: 0x0600029C RID: 668 RVA: 0x0000708F File Offset: 0x0000528F
		public bool IsClientError
		{
			get
			{
				return this.StatusCode >= 400 && this.StatusCode < 500;
			}
		}

		// Token: 0x1700008C RID: 140
		// (get) Token: 0x0600029D RID: 669 RVA: 0x000070AD File Offset: 0x000052AD
		public bool IsServerError
		{
			get
			{
				return this.StatusCode >= 500 && this.StatusCode < 600;
			}
		}
	}
}
