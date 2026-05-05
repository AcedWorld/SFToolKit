using System;

namespace Unity.Services.Authentication.Shared
{
	// Token: 0x0200005C RID: 92
	internal class ApiException : Exception
	{
		// Token: 0x17000072 RID: 114
		// (get) Token: 0x06000270 RID: 624 RVA: 0x00006DA0 File Offset: 0x00004FA0
		// (set) Token: 0x06000271 RID: 625 RVA: 0x00006DA8 File Offset: 0x00004FA8
		public ApiExceptionType Type { get; private set; }

		// Token: 0x17000073 RID: 115
		// (get) Token: 0x06000272 RID: 626 RVA: 0x00006DB1 File Offset: 0x00004FB1
		// (set) Token: 0x06000273 RID: 627 RVA: 0x00006DB9 File Offset: 0x00004FB9
		public IApiResponse Response { get; private set; }

		// Token: 0x06000274 RID: 628 RVA: 0x00006DC2 File Offset: 0x00004FC2
		public ApiException(ApiExceptionType type, string message, IApiResponse response = null) : base(message)
		{
			this.Type = type;
			this.Response = response;
		}
	}
}
