using System;
using Newtonsoft.Json;
using UnityEngine.Scripting;

namespace Unity.Services.Relay.Http
{
	// Token: 0x02000039 RID: 57
	[Preserve]
	[JsonConverter(typeof(JsonObjectConverter))]
	internal interface IDeserializable
	{
		// Token: 0x060000E8 RID: 232
		string GetAsString();

		// Token: 0x060000E9 RID: 233
		T GetAs<T>(DeserializationSettings deserializationSettings = null);
	}
}
