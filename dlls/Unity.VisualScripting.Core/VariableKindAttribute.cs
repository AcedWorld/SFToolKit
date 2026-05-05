using System;

namespace Unity.VisualScripting
{
	// Token: 0x02000175 RID: 373
	[Obsolete("Set VariableKind via VariableDeclarations.Kind")]
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
	public sealed class VariableKindAttribute : Attribute
	{
		// Token: 0x060009EC RID: 2540 RVA: 0x00029994 File Offset: 0x00027B94
		public VariableKindAttribute(VariableKind kind)
		{
			this.kind = kind;
		}

		// Token: 0x170001C9 RID: 457
		// (get) Token: 0x060009ED RID: 2541 RVA: 0x000299A3 File Offset: 0x00027BA3
		public VariableKind kind { get; }
	}
}
