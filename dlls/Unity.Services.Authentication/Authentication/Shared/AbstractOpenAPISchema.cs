using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Unity.Services.Authentication.Shared
{
	// Token: 0x0200005A RID: 90
	internal abstract class AbstractOpenAPISchema
	{
		// Token: 0x17000065 RID: 101
		// (get) Token: 0x0600024E RID: 590
		// (set) Token: 0x0600024F RID: 591
		public abstract object ActualInstance { get; set; }

		// Token: 0x17000066 RID: 102
		// (get) Token: 0x06000250 RID: 592 RVA: 0x00006A4D File Offset: 0x00004C4D
		// (set) Token: 0x06000251 RID: 593 RVA: 0x00006A55 File Offset: 0x00004C55
		public bool IsNullable { get; protected set; }

		// Token: 0x17000067 RID: 103
		// (get) Token: 0x06000252 RID: 594 RVA: 0x00006A5E File Offset: 0x00004C5E
		// (set) Token: 0x06000253 RID: 595 RVA: 0x00006A66 File Offset: 0x00004C66
		public string SchemaType { get; protected set; }

		// Token: 0x06000254 RID: 596
		public abstract string ToJson();

		// Token: 0x04000126 RID: 294
		public static readonly JsonSerializerSettings SerializerSettings = new JsonSerializerSettings
		{
			ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor,
			MissingMemberHandling = MissingMemberHandling.Error,
			ContractResolver = new DefaultContractResolver
			{
				NamingStrategy = new CamelCaseNamingStrategy
				{
					OverrideSpecifiedNames = false
				}
			}
		};

		// Token: 0x04000127 RID: 295
		public static readonly JsonSerializerSettings AdditionalPropertiesSerializerSettings = new JsonSerializerSettings
		{
			ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor,
			MissingMemberHandling = MissingMemberHandling.Ignore,
			ContractResolver = new DefaultContractResolver
			{
				NamingStrategy = new CamelCaseNamingStrategy
				{
					OverrideSpecifiedNames = false
				}
			}
		};
	}
}
