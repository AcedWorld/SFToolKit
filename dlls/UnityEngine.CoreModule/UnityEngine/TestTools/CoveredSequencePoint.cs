using System;
using System.Reflection;
using UnityEngine.Bindings;

namespace UnityEngine.TestTools
{
	// Token: 0x020004B3 RID: 1203
	[NativeType(CodegenOptions.Custom, "ManagedCoveredSequencePoint", Header = "Runtime/Scripting/ScriptingCoverage.bindings.h")]
	public struct CoveredSequencePoint
	{
		// Token: 0x04000F8C RID: 3980
		public MethodBase method;

		// Token: 0x04000F8D RID: 3981
		public uint ilOffset;

		// Token: 0x04000F8E RID: 3982
		public uint hitCount;

		// Token: 0x04000F8F RID: 3983
		public string filename;

		// Token: 0x04000F90 RID: 3984
		public uint line;

		// Token: 0x04000F91 RID: 3985
		public uint column;
	}
}
