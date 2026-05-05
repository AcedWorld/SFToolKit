using System;
using Newtonsoft.Json;
using UnityEngine.Scripting;

namespace Unity.Services.Qos.V2.Http
{
	// Token: 0x02000032 RID: 50
	[Preserve]
	[JsonConverter(typeof(JsonObjectConverter))]
	internal interface IDeserializable
	{
		// Token: 0x060000CB RID: 203
		string GetAsString();

		// Token: 0x060000CC RID: 204
		T GetAs<T>(DeserializationSettings deserializationSettings = null);
	}
}
