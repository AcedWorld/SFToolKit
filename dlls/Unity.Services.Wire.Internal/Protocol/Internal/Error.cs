using System;
using Newtonsoft.Json;
using UnityEngine.Scripting;

namespace Unity.Services.Wire.Protocol.Internal
{
	// Token: 0x02000009 RID: 9
	[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
	internal class Error
	{
		// Token: 0x06000015 RID: 21 RVA: 0x00002219 File Offset: 0x00000419
		[Preserve]
		public Error()
		{
		}

		// Token: 0x04000023 RID: 35
		public CentrifugeErrorCode code;

		// Token: 0x04000024 RID: 36
		public string message;
	}
}
