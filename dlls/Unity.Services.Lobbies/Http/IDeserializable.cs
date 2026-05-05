using System;
using Newtonsoft.Json;
using UnityEngine.Scripting;

namespace Unity.Services.Lobbies.Http
{
	// Token: 0x02000050 RID: 80
	[Preserve]
	[JsonConverter(typeof(JsonObjectConverter))]
	public interface IDeserializable
	{
		// Token: 0x06000229 RID: 553
		string GetAsString();

		// Token: 0x0600022A RID: 554
		T GetAs<T>(DeserializationSettings deserializationSettings = null);
	}
}
