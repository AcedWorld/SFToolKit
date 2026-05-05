using System;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Utilities;
using UnityEngine;

namespace Unity.Services.Lobbies.Http
{
	// Token: 0x02000053 RID: 83
	internal static class JsonHelpers
	{
		// Token: 0x06000232 RID: 562 RVA: 0x00008631 File Offset: 0x00006831
		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSplashScreen)]
		internal static void RegisterTypesForAOT()
		{
			AotHelper.EnsureType<StringEnumConverter>();
			AotHelper.EnsureType<JsonObjectConverter>();
		}

		// Token: 0x06000233 RID: 563 RVA: 0x00008640 File Offset: 0x00006840
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
