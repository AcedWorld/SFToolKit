using System;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

namespace UnityEngine.Rendering
{
	// Token: 0x02000485 RID: 1157
	[NativeHeader("Runtime/Shaders/Keywords/KeywordSpaceScriptBindings.h")]
	[UsedByNativeCode]
	public enum ShaderKeywordType
	{
		// Token: 0x04000F0A RID: 3850
		None,
		// Token: 0x04000F0B RID: 3851
		BuiltinDefault = 2,
		// Token: 0x04000F0C RID: 3852
		[Obsolete("Shader keyword type BuiltinExtra is no longer used. Use BuiltinDefault instead. (UnityUpgradable) -> BuiltinDefault")]
		BuiltinExtra = 6,
		// Token: 0x04000F0D RID: 3853
		[Obsolete("Shader keyword type BuiltinAutoStripped is no longer used. Use BuiltinDefault instead. (UnityUpgradable) -> BuiltinDefault")]
		BuiltinAutoStripped = 10,
		// Token: 0x04000F0E RID: 3854
		UserDefined = 16,
		// Token: 0x04000F0F RID: 3855
		Plugin = 32
	}
}
