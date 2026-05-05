using System;
using UnityEngine.Scripting;

namespace UnityEngine.TestTools
{
	// Token: 0x020004B2 RID: 1202
	[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Constructor | AttributeTargets.Method)]
	[UsedByNativeCode]
	public class ExcludeFromCoverageAttribute : Attribute
	{
	}
}
