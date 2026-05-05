using System;
using System.Collections.Generic;
using Unity.Services.Relay.Http;
using Unity.Services.Relay.Models;

namespace Unity.Services.Relay
{
	// Token: 0x0200000C RID: 12
	internal static class ApiErrorExtender
	{
		// Token: 0x06000025 RID: 37 RVA: 0x00002410 File Offset: 0x00000610
		public static RelayExceptionReason GetExceptionReason(this ErrorResponseBody error)
		{
			RelayExceptionReason result = RelayExceptionReason.Unknown;
			if (error.Code != 15000)
			{
				if (Enum.IsDefined(typeof(RelayExceptionReason), error.Code))
				{
					result = (RelayExceptionReason)error.Code;
				}
			}
			else if (Enum.IsDefined(typeof(RelayExceptionReason), error.Status))
			{
				result = (RelayExceptionReason)error.Status;
			}
			return result;
		}

		// Token: 0x06000026 RID: 38 RVA: 0x0000247C File Offset: 0x0000067C
		public static RelayExceptionReason GetExceptionReason(this HttpClientResponse error)
		{
			RelayExceptionReason result = RelayExceptionReason.Unknown;
			if (error.IsHttpError)
			{
				int num = (int)error.StatusCode + 15000;
				if (Enum.IsDefined(typeof(RelayExceptionReason), num))
				{
					result = (RelayExceptionReason)num;
				}
			}
			else if (error.IsNetworkError)
			{
				result = RelayExceptionReason.NetworkError;
			}
			return result;
		}

		// Token: 0x06000027 RID: 39 RVA: 0x000024D0 File Offset: 0x000006D0
		public static string GetExceptionMessage(this ErrorResponseBody error)
		{
			string text = error.Title + ": " + error.Detail;
			foreach (KeyValuePair keyValuePair in (error.Details ?? new List<KeyValuePair>()))
			{
				text = string.Concat(new string[]
				{
					text,
					"\n",
					keyValuePair.Key,
					": ",
					keyValuePair.Value
				});
			}
			return text;
		}
	}
}
