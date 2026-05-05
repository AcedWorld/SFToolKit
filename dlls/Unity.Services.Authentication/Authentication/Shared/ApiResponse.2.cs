using System;

namespace Unity.Services.Authentication.Shared
{
	// Token: 0x02000062 RID: 98
	internal class ApiResponse<T> : ApiResponse, IApiResponse
	{
		// Token: 0x1700008D RID: 141
		// (get) Token: 0x0600029F RID: 671 RVA: 0x000070D3 File Offset: 0x000052D3
		// (set) Token: 0x060002A0 RID: 672 RVA: 0x000070DB File Offset: 0x000052DB
		public T Data { get; internal set; }

		// Token: 0x1700008E RID: 142
		// (get) Token: 0x060002A1 RID: 673 RVA: 0x000070E4 File Offset: 0x000052E4
		public override object Content
		{
			get
			{
				return this.Data;
			}
		}
	}
}
