using System;
using System.Diagnostics;
using UnityEngine.Scripting;

namespace UnityEngine.TextCore.LowLevel
{
	// Token: 0x02000011 RID: 17
	[DebuggerDisplay("Language = {tag},  Feature Count = {featureIndexes.Length}")]
	[UsedByNativeCode]
	internal struct OTL_Language
	{
		// Token: 0x04000085 RID: 133
		public string tag;

		// Token: 0x04000086 RID: 134
		public uint[] featureIndexes;
	}
}
