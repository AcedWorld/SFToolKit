using System;
using System.Diagnostics;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x02000057 RID: 87
	[Conditional("UNITY_EDITOR")]
	internal class HDRPHelpURLAttribute : CoreRPHelpURLAttribute
	{
		// Token: 0x06000255 RID: 597 RVA: 0x0000DCDA File Offset: 0x0000BEDA
		public HDRPHelpURLAttribute(string pageName) : base(pageName, "com.unity.render-pipelines.high-definition")
		{
		}
	}
}
