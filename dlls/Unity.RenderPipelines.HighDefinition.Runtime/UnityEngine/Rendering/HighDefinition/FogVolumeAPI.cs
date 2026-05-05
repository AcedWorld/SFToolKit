using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x02000104 RID: 260
	internal static class FogVolumeAPI
	{
		// Token: 0x06000A1D RID: 2589 RVA: 0x00055FBC File Offset: 0x000541BC
		internal static void ComputeBlendParameters(LocalVolumetricFogBlendingMode mode, out BlendMode srcColorBlend, out BlendMode srcAlphaBlend, out BlendMode dstColorBlend, out BlendMode dstAlphaBlend, out BlendOp colorBlendOp, out BlendOp alphaBlendOp)
		{
			colorBlendOp = BlendOp.Add;
			alphaBlendOp = BlendOp.Add;
			switch (mode)
			{
			case LocalVolumetricFogBlendingMode.Overwrite:
				srcColorBlend = BlendMode.One;
				dstColorBlend = BlendMode.Zero;
				srcAlphaBlend = BlendMode.One;
				dstAlphaBlend = BlendMode.Zero;
				return;
			default:
				srcColorBlend = BlendMode.One;
				dstColorBlend = BlendMode.One;
				srcAlphaBlend = BlendMode.One;
				dstAlphaBlend = BlendMode.One;
				return;
			case LocalVolumetricFogBlendingMode.Multiply:
				srcColorBlend = BlendMode.DstColor;
				dstColorBlend = BlendMode.Zero;
				srcAlphaBlend = BlendMode.DstAlpha;
				dstAlphaBlend = BlendMode.Zero;
				return;
			case LocalVolumetricFogBlendingMode.Min:
				srcColorBlend = BlendMode.One;
				dstColorBlend = BlendMode.One;
				srcAlphaBlend = BlendMode.One;
				dstAlphaBlend = BlendMode.One;
				alphaBlendOp = BlendOp.Min;
				colorBlendOp = BlendOp.Min;
				return;
			case LocalVolumetricFogBlendingMode.Max:
				srcColorBlend = BlendMode.One;
				dstColorBlend = BlendMode.One;
				srcAlphaBlend = BlendMode.One;
				dstAlphaBlend = BlendMode.One;
				alphaBlendOp = BlendOp.Max;
				colorBlendOp = BlendOp.Max;
				return;
			}
		}

		// Token: 0x06000A1E RID: 2590 RVA: 0x00056040 File Offset: 0x00054240
		internal static void SetupFogVolumeKeywordsAndProperties(Material material)
		{
			if (material.HasProperty(FogVolumeAPI.k_BlendModeProperty))
			{
				LocalVolumetricFogBlendingMode mode = (LocalVolumetricFogBlendingMode)material.GetFloat(FogVolumeAPI.k_BlendModeProperty);
				FogVolumeAPI.SetupFogVolumeBlendMode(material, mode);
			}
		}

		// Token: 0x06000A1F RID: 2591 RVA: 0x0005606E File Offset: 0x0005426E
		internal static int GetPassIndexFromBlendingMode(LocalVolumetricFogBlendingMode mode)
		{
			return (int)mode;
		}

		// Token: 0x06000A20 RID: 2592 RVA: 0x00056074 File Offset: 0x00054274
		internal static void SetupFogVolumeBlendMode(Material material, LocalVolumetricFogBlendingMode mode)
		{
			BlendMode blendMode;
			BlendMode blendMode2;
			BlendMode blendMode3;
			BlendMode blendMode4;
			BlendOp blendOp;
			BlendOp blendOp2;
			FogVolumeAPI.ComputeBlendParameters(mode, out blendMode, out blendMode2, out blendMode3, out blendMode4, out blendOp, out blendOp2);
			material.SetFloat(FogVolumeAPI.k_SrcColorBlendProperty, (float)blendMode);
			material.SetFloat(FogVolumeAPI.k_DstColorBlendProperty, (float)blendMode3);
			material.SetFloat(FogVolumeAPI.k_SrcAlphaBlendProperty, (float)blendMode2);
			material.SetFloat(FogVolumeAPI.k_DstAlphaBlendProperty, (float)blendMode4);
			material.SetFloat(FogVolumeAPI.k_ColorBlendOpProperty, (float)blendOp);
			material.SetFloat(FogVolumeAPI.k_AlphaBlendOpProperty, (float)blendOp2);
		}

		// Token: 0x04000AD9 RID: 2777
		internal static readonly string k_BlendModeProperty = "_FogVolumeBlendMode";

		// Token: 0x04000ADA RID: 2778
		internal static readonly string k_SrcColorBlendProperty = "_FogVolumeSrcColorBlend";

		// Token: 0x04000ADB RID: 2779
		internal static readonly string k_DstColorBlendProperty = "_FogVolumeDstColorBlend";

		// Token: 0x04000ADC RID: 2780
		internal static readonly string k_SrcAlphaBlendProperty = "_FogVolumeSrcAlphaBlend";

		// Token: 0x04000ADD RID: 2781
		internal static readonly string k_DstAlphaBlendProperty = "_FogVolumeDstAlphaBlend";

		// Token: 0x04000ADE RID: 2782
		internal static readonly string k_ColorBlendOpProperty = "_FogVolumeColorBlendOp";

		// Token: 0x04000ADF RID: 2783
		internal static readonly string k_AlphaBlendOpProperty = "_FogVolumeAlphaBlendOp";
	}
}
