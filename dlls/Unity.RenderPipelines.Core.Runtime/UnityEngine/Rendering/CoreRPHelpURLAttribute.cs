using System;
using System.Diagnostics;

namespace UnityEngine.Rendering
{
	// Token: 0x0200007F RID: 127
	[Conditional("UNITY_EDITOR")]
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Enum, AllowMultiple = false)]
	public class CoreRPHelpURLAttribute : HelpURLAttribute
	{
		// Token: 0x06000405 RID: 1029 RVA: 0x0001135F File Offset: 0x0000F55F
		public CoreRPHelpURLAttribute(string pageName, string packageName = "com.unity.render-pipelines.core") : base(DocumentationInfo.GetPageLink(packageName, pageName, ""))
		{
		}

		// Token: 0x06000406 RID: 1030 RVA: 0x00011373 File Offset: 0x0000F573
		public CoreRPHelpURLAttribute(string pageName, string pageHash, string packageName = "com.unity.render-pipelines.core") : base(DocumentationInfo.GetPageLink(packageName, pageName, pageHash))
		{
		}
	}
}
