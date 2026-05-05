using System;
using Newtonsoft.Json;

namespace Unity.Services.Authentication
{
	// Token: 0x02000058 RID: 88
	internal static class SerializerSettings
	{
		// Token: 0x17000063 RID: 99
		// (get) Token: 0x0600024A RID: 586 RVA: 0x00006A35 File Offset: 0x00004C35
		internal static JsonSerializerSettings DefaultSerializerSettings
		{
			get
			{
				if (SerializerSettings.s_Instance == null)
				{
					SerializerSettings.s_Instance = new JsonSerializerSettings();
				}
				return SerializerSettings.s_Instance;
			}
		}

		// Token: 0x04000123 RID: 291
		private static JsonSerializerSettings s_Instance;
	}
}
