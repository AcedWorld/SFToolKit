using System;
using System.Threading.Tasks;
using UnityEngine.Networking;

namespace Unity.Services.Core.Internal
{
	// Token: 0x02000057 RID: 87
	internal static class UnityWebRequestUtils
	{
		// Token: 0x06000195 RID: 405 RVA: 0x00004188 File Offset: 0x00002388
		public static bool HasSucceeded(this UnityWebRequest self)
		{
			return self.result == UnityWebRequest.Result.Success;
		}

		// Token: 0x06000196 RID: 406 RVA: 0x00004194 File Offset: 0x00002394
		public static Task<string> GetTextAsync(string uri)
		{
			UnityWebRequestUtils.<>c__DisplayClass2_0 CS$<>8__locals1 = new UnityWebRequestUtils.<>c__DisplayClass2_0();
			CS$<>8__locals1.completionSource = new TaskCompletionSource<string>();
			UnityWebRequest.Get(uri).SendWebRequest().completed += CS$<>8__locals1.<GetTextAsync>g__CompleteFetchTaskOnRequestCompleted|0;
			return CS$<>8__locals1.completionSource.Task;
		}

		// Token: 0x04000078 RID: 120
		public const string JsonContentType = "application/json";
	}
}
