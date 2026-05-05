using System;

namespace JetBrains.Annotations
{
	// Token: 0x020000DD RID: 221
	[AttributeUsage(AttributeTargets.Method)]
	[Obsolete("Use [ContractAnnotation('=> halt')] instead")]
	public sealed class TerminatesProgramAttribute : Attribute
	{
	}
}
