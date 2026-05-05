using System;
using UnityEngine.Scripting;

namespace Unity.Collections.LowLevel.Unsafe
{
	// Token: 0x020000B0 RID: 176
	[AttributeUsage(AttributeTargets.Struct)]
	[RequiredByNativeCode]
	[Obsolete("Use NativeSetThreadIndexAttribute instead")]
	public sealed class NativeContainerNeedsThreadIndexAttribute : Attribute
	{
	}
}
