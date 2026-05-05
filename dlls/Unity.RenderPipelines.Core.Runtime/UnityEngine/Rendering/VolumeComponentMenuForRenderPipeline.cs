using System;

namespace UnityEngine.Rendering
{
	// Token: 0x020000E9 RID: 233
	public class VolumeComponentMenuForRenderPipeline : VolumeComponentMenu
	{
		// Token: 0x17000127 RID: 295
		// (get) Token: 0x060007AB RID: 1963 RVA: 0x000255EB File Offset: 0x000237EB
		public Type[] pipelineTypes { get; }

		// Token: 0x060007AC RID: 1964 RVA: 0x000255F4 File Offset: 0x000237F4
		public VolumeComponentMenuForRenderPipeline(string menu, params Type[] pipelineTypes) : base(menu)
		{
			if (pipelineTypes == null)
			{
				throw new Exception("Specify a list of supported pipeline");
			}
			foreach (Type type in pipelineTypes)
			{
				if (!typeof(RenderPipeline).IsAssignableFrom(type))
				{
					throw new Exception(string.Format("You can only specify types that inherit from {0}, please check {1}", typeof(RenderPipeline), type));
				}
			}
			this.pipelineTypes = pipelineTypes;
		}
	}
}
