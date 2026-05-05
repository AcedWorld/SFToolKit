using System;

namespace Unity.Services.Lobbies.Http
{
	// Token: 0x02000048 RID: 72
	internal static class CommonErrors
	{
		// Token: 0x0600020B RID: 523 RVA: 0x0000820C File Offset: 0x0000640C
		public static IError CreateUnspecifiedHttpError(string details)
		{
			return new BasicError("com.unity.services.lobbyhttp.httperror", "Unspecified HTTP error", null, 0, details);
		}

		// Token: 0x170000B6 RID: 182
		// (get) Token: 0x0600020C RID: 524 RVA: 0x00008234 File Offset: 0x00006434
		public static IError RequestOnSuccessNull
		{
			get
			{
				return new BasicError("com.unity.services.lobbyonsuccessnullerror", "Request must have an onSuccess callback", null, 0, "");
			}
		}

		// Token: 0x170000B7 RID: 183
		// (get) Token: 0x0600020D RID: 525 RVA: 0x00008260 File Offset: 0x00006460
		public static IError HttpNetworkError
		{
			get
			{
				return new BasicError("com.unity.services.lobbyhttpclient.networkerror", "Network Error", null, 0, "");
			}
		}

		// Token: 0x0400010D RID: 269
		private const string ErrorPrefix = "com.unity.services.lobby";
	}
}
