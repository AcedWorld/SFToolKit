using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Unity.Services.Wire.Internal;
using UnityEngine.Scripting;

namespace Unity.Services.Wire.Protocol.Internal
{
	// Token: 0x0200000F RID: 15
	[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
	internal class SubscribeRequest
	{
		// Token: 0x06000028 RID: 40 RVA: 0x00002359 File Offset: 0x00000559
		[Preserve]
		public SubscribeRequest()
		{
		}

		// Token: 0x06000029 RID: 41 RVA: 0x00002364 File Offset: 0x00000564
		public static Task<Dictionary<string, SubscribeRequest>> getRequestFromRepo(ISubscriptionRepository repository)
		{
			SubscribeRequest.<getRequestFromRepo>d__6 <getRequestFromRepo>d__;
			<getRequestFromRepo>d__.<>t__builder = AsyncTaskMethodBuilder<Dictionary<string, SubscribeRequest>>.Create();
			<getRequestFromRepo>d__.repository = repository;
			<getRequestFromRepo>d__.<>1__state = -1;
			<getRequestFromRepo>d__.<>t__builder.Start<SubscribeRequest.<getRequestFromRepo>d__6>(ref <getRequestFromRepo>d__);
			return <getRequestFromRepo>d__.<>t__builder.Task;
		}

		// Token: 0x04000034 RID: 52
		public string channel;

		// Token: 0x04000035 RID: 53
		public string token;

		// Token: 0x04000036 RID: 54
		public bool recover;

		// Token: 0x04000037 RID: 55
		public ulong offset;

		// Token: 0x04000038 RID: 56
		public string epoch;
	}
}
