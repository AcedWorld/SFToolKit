using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x02000058 RID: 88
	internal class Documentation : DocumentationInfo
	{
		// Token: 0x06000256 RID: 598 RVA: 0x0000DCE8 File Offset: 0x0000BEE8
		public static string GetPageLink(string pageName)
		{
			return DocumentationInfo.GetPageLink("com.unity.render-pipelines.high-definition", pageName);
		}

		// Token: 0x04000260 RID: 608
		public const string packageName = "com.unity.render-pipelines.high-definition";
	}
}
