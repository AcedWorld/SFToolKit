using System;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Utilities;
using UnityEngine;

namespace Unity.Services.Qos.V2.Http
{
	// Token: 0x02000035 RID: 53
	internal static class JsonHelpers
	{
		// Token: 0x060000D6 RID: 214 RVA: 0x00004C14 File Offset: 0x00002E14
		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSplashScreen)]
		internal static void RegisterTypesForAOT()
		{
			AotHelper.EnsureType<StringEnumConverter>();
			AotHelper.EnsureType<JsonObjectConverter>();
		}

		// Token: 0x060000D7 RID: 215 RVA: 0x00004C20 File Offset: 0x00002E20
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
			result = IsolatedJsonConvert.DeserializeObject<T>(@this, settings);
			return success;
		}
	}
}
