using System;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Utilities;
using UnityEngine;

namespace Unity.Services.Qos.Http
{
	// Token: 0x02000065 RID: 101
	internal static class JsonHelpers
	{
		// Token: 0x060001CA RID: 458 RVA: 0x00006FAD File Offset: 0x000051AD
		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSplashScreen)]
		internal static void RegisterTypesForAOT()
		{
			AotHelper.EnsureType<StringEnumConverter>();
			AotHelper.EnsureType<JsonObjectConverter>();
		}

		// Token: 0x060001CB RID: 459 RVA: 0x00006FBC File Offset: 0x000051BC
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
