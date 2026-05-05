using System;
using System.Collections.Generic;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x020001A3 RID: 419
	[Serializable]
	public class FullScreenCustomPass : CustomPass
	{
		// Token: 0x06000D31 RID: 3377 RVA: 0x0006BD28 File Offset: 0x00069F28
		protected override void Setup(ScriptableRenderContext renderContext, CommandBuffer cmd)
		{
			this.fadeValueId = Shader.PropertyToID("_FadeValue");
			if (string.IsNullOrEmpty(this.materialPassName) && this.fullscreenPassMaterial != null)
			{
				this.materialPassName = this.fullscreenPassMaterial.GetPassName(this.materialPassIndex);
			}
		}

		// Token: 0x06000D32 RID: 3378 RVA: 0x0006BD78 File Offset: 0x00069F78
		protected override void Execute(CustomPassContext ctx)
		{
			if (this.fullscreenPassMaterial != null && this.fullscreenPassMaterial.passCount > 0)
			{
				if (this.fetchColorBuffer)
				{
					base.ResolveMSAAColorBuffer(ctx.cmd, ctx.hdCamera);
					base.SetRenderTargetAuto(ctx.cmd);
				}
				int num = this.fullscreenPassMaterial.FindPass(this.materialPassName);
				if (num == -1)
				{
					num = 0;
				}
				this.fullscreenPassMaterial.SetFloat(this.fadeValueId, base.fadeValue);
				CoreUtils.DrawFullScreen(ctx.cmd, this.fullscreenPassMaterial, null, num);
			}
		}

		// Token: 0x06000D33 RID: 3379 RVA: 0x0006BE09 File Offset: 0x0006A009
		public override IEnumerable<Material> RegisterMaterialForInspector()
		{
			yield return this.fullscreenPassMaterial;
			yield break;
		}

		// Token: 0x04001434 RID: 5172
		public Material fullscreenPassMaterial;

		// Token: 0x04001435 RID: 5173
		[SerializeField]
		private int materialPassIndex;

		// Token: 0x04001436 RID: 5174
		public string materialPassName = "Custom Pass 0";

		// Token: 0x04001437 RID: 5175
		public bool fetchColorBuffer;

		// Token: 0x04001438 RID: 5176
		private int fadeValueId;
	}
}
