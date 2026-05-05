using System;

namespace Unity.Netcode
{
	// Token: 0x02000055 RID: 85
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Method, AllowMultiple = true)]
	public class GenerateSerializationForTypeAttribute : Attribute
	{
		// Token: 0x06000241 RID: 577 RVA: 0x0000BF57 File Offset: 0x0000A157
		public GenerateSerializationForTypeAttribute(Type type)
		{
			this.Type = type;
		}

		// Token: 0x0400012D RID: 301
		internal Type Type;
	}
}
