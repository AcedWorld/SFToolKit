using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x02000206 RID: 518
	internal sealed class ExcludeCopyAttribute : CopyFilterAttribute
	{
		// Token: 0x06000F70 RID: 3952 RVA: 0x00078634 File Offset: 0x00076834
		public ExcludeCopyAttribute() : base(CopyFilterAttribute.Filter.Exclude)
		{
		}
	}
}
