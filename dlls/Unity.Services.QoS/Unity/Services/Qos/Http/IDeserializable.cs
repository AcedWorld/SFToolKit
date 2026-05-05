using System;
using Newtonsoft.Json;
using UnityEngine.Scripting;

namespace Unity.Services.Qos.Http
{
	// Token: 0x02000063 RID: 99
	[Preserve]
	[JsonConverter(typeof(JsonObjectConverter))]
	internal interface IDeserializable
	{
		// Token: 0x060001C6 RID: 454
		string GetAsString();

		// Token: 0x060001C7 RID: 455
		T GetAs<T>(DeserializationSettings deserializationSettings = null);
	}
}
