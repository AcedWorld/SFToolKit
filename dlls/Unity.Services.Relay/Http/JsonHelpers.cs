using System;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Utilities;
using UnityEngine;

namespace Unity.Services.Relay.Http
{
	// Token: 0x0200003B RID: 59
	internal static class JsonHelpers
	{
		// Token: 0x060000EC RID: 236 RVA: 0x0000404D File Offset: 0x0000224D
		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSplashScreen)]
		internal static void RegisterTypesForAOT()
		{
			AotHelper.EnsureType<StringEnumConverter>();
			AotHelper.EnsureType<JsonObjectConverter>();
		}

		// Token: 0x060000ED RID: 237 RVA: 0x0000405C File Offset: 0x0000225C
		internal static bool TryParseJson<T>(this string @this, out T result)
		{
			bool success = true;
			JsonSerializerSettings settings = new JsonSerializerSettings
			{
				Error = delegate(object sender, [Nullable(1)] ErrorEventArgs args)
				{
					success = false;
					args.ErrorContext.Handled = true;
				},
				MissingMemberHandling = MissingMemberHandling.Ignore,
				ReferenceLoopHandling = ReferenceLoopHandling.Ignore
			};
			result = JsonConvert.DeserializeObject<T>(@this, settings);
			return success;
		}
	}
}
