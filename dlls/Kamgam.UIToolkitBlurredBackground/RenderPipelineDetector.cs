using System;
using UnityEngine.Rendering;

namespace Kamgam.UGUIBlurredBackground
{
	// Token: 0x02000014 RID: 20
	public static class RenderPipelineDetector
	{
		// Token: 0x060000D0 RID: 208 RVA: 0x00004C04 File Offset: 0x00002E04
		public static RenderPipelineDetector.RenderPiplelineType GetCurrentRenderPiplelineType()
		{
			RenderPipelineAsset currentRenderPipeline = GraphicsSettings.currentRenderPipeline;
			if (!(currentRenderPipeline != null))
			{
				return RenderPipelineDetector.RenderPiplelineType.BuiltIn;
			}
			if (currentRenderPipeline.GetType().Name.Contains("Universal"))
			{
				return RenderPipelineDetector.RenderPiplelineType.URP;
			}
			return RenderPipelineDetector.RenderPiplelineType.HDRP;
		}

		// Token: 0x060000D1 RID: 209 RVA: 0x00004C3C File Offset: 0x00002E3C
		public static bool IsURP()
		{
			return RenderPipelineDetector.GetCurrentRenderPiplelineType() == RenderPipelineDetector.RenderPiplelineType.URP;
		}

		// Token: 0x060000D2 RID: 210 RVA: 0x00004C46 File Offset: 0x00002E46
		public static bool IsHDRP()
		{
			return RenderPipelineDetector.GetCurrentRenderPiplelineType() == RenderPipelineDetector.RenderPiplelineType.HDRP;
		}

		// Token: 0x060000D3 RID: 211 RVA: 0x00004C50 File Offset: 0x00002E50
		public static bool IsBuiltIn()
		{
			return RenderPipelineDetector.GetCurrentRenderPiplelineType() == RenderPipelineDetector.RenderPiplelineType.BuiltIn;
		}

		// Token: 0x02000020 RID: 32
		public enum RenderPiplelineType
		{
			// Token: 0x0400008E RID: 142
			URP,
			// Token: 0x0400008F RID: 143
			HDRP,
			// Token: 0x04000090 RID: 144
			BuiltIn
		}
	}
}
