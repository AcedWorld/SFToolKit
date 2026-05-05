using System;

namespace Unity.Netcode
{
	// Token: 0x02000054 RID: 84
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = true)]
	public class GenerateSerializationForGenericParameterAttribute : Attribute
	{
		// Token: 0x06000240 RID: 576 RVA: 0x0000BF48 File Offset: 0x0000A148
		public GenerateSerializationForGenericParameterAttribute(int parameterIndex)
		{
			this.ParameterIndex = parameterIndex;
		}

		// Token: 0x0400012C RID: 300
		internal int ParameterIndex;
	}
}
