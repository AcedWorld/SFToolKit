using System;

namespace Unity.Services.Core.Internal.Serialization
{
	// Token: 0x02000058 RID: 88
	internal interface IJsonSerializer
	{
		// Token: 0x06000197 RID: 407
		string SerializeObject<T>(T value);

		// Token: 0x06000198 RID: 408
		T DeserializeObject<T>(string value);
	}
}
