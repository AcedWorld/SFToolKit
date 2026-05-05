using System;
using System.Collections.Generic;

namespace Unity.Services.Qos
{
	// Token: 0x02000019 RID: 25
	public interface IQosAnnotatedResult : IQosResult
	{
		// Token: 0x17000023 RID: 35
		// (get) Token: 0x06000064 RID: 100
		Dictionary<string, List<string>> Annotations { get; }
	}
}
