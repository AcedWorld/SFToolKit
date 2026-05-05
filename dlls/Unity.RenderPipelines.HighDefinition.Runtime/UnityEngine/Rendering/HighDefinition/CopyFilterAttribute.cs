using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x02000205 RID: 517
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
	internal class CopyFilterAttribute : Attribute
	{
		// Token: 0x06000F6F RID: 3951 RVA: 0x0007862C File Offset: 0x0007682C
		protected CopyFilterAttribute(CopyFilterAttribute.Filter test)
		{
		}

		// Token: 0x0200043E RID: 1086
		public enum Filter
		{
			// Token: 0x0400297F RID: 10623
			Exclude = 1,
			// Token: 0x04002980 RID: 10624
			CheckContent
		}
	}
}
