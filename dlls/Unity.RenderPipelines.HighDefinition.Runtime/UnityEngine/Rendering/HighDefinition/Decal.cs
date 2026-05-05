using System;
using System.Runtime.CompilerServices;
using UnityEngine.Experimental.Rendering;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x020000F5 RID: 245
	internal class Decal
	{
		// Token: 0x0600098C RID: 2444 RVA: 0x00053E70 File Offset: 0x00052070
		public static int GetMaterialDBufferCount()
		{
			return 4;
		}

		// Token: 0x0600098D RID: 2445 RVA: 0x00053E74 File Offset: 0x00052074
		public static void GetMaterialDBufferDescription(out GraphicsFormat[] RTFormat)
		{
			HDRenderPipeline hdrenderPipeline = RenderPipelineManager.currentPipeline as HDRenderPipeline;
			RTFormat = ((hdrenderPipeline.currentPlatformRenderPipelineSettings.supportSurfaceGradient && hdrenderPipeline.currentPlatformRenderPipelineSettings.decalNormalBufferHP) ? Decal.m_RTFormatHP : Decal.m_RTFormat);
		}

		// Token: 0x0600098F RID: 2447 RVA: 0x00053EC1 File Offset: 0x000520C1
		// Note: this type is marked as 'beforefieldinit'.
		static Decal()
		{
			GraphicsFormat[] array = new GraphicsFormat[4];
			RuntimeHelpers.InitializeArray(array, fieldof(<PrivateImplementationDetails>.A0A3BE0ACD11B4436BF5CCF41A59B6F6A79683C01EA87559C498652F6E1B9001).FieldHandle);
			Decal.m_RTFormat = array;
			GraphicsFormat[] array2 = new GraphicsFormat[4];
			RuntimeHelpers.InitializeArray(array2, fieldof(<PrivateImplementationDetails>.C34D34D1E838EA2ED2754817A8447A9A981209315180E71B848D0CA597C9ED71).FieldHandle);
			Decal.m_RTFormatHP = array2;
		}

		// Token: 0x04000A69 RID: 2665
		private static GraphicsFormat[] m_RTFormat;

		// Token: 0x04000A6A RID: 2666
		private static GraphicsFormat[] m_RTFormatHP;

		// Token: 0x02000376 RID: 886
		[GenerateHLSL(PackingRules.Exact, false, false, false, 1, false, false, false, -1, ".\\Library\\PackageCache\\com.unity.render-pipelines.high-definition@14.0.11\\Runtime\\Material\\Decal\\Decal.cs")]
		public struct DecalSurfaceData
		{
			// Token: 0x04002414 RID: 9236
			[SurfaceDataAttributes("Base Color", false, true, FieldPrecision.Default, false, "")]
			public Vector4 baseColor;

			// Token: 0x04002415 RID: 9237
			[SurfaceDataAttributes("Normal", true, false, FieldPrecision.Default, false, "")]
			public Vector4 normalWS;

			// Token: 0x04002416 RID: 9238
			[SurfaceDataAttributes("Mask", true, false, FieldPrecision.Default, false, "")]
			public Vector4 mask;

			// Token: 0x04002417 RID: 9239
			[SurfaceDataAttributes("Emissive", false, false, FieldPrecision.Default, false, "")]
			public Vector3 emissive;

			// Token: 0x04002418 RID: 9240
			[SurfaceDataAttributes("AOSBlend", true, false, FieldPrecision.Default, false, "")]
			public Vector2 MAOSBlend;
		}

		// Token: 0x02000377 RID: 887
		[GenerateHLSL(PackingRules.Exact, true, false, false, 1, false, false, false, -1, ".\\Library\\PackageCache\\com.unity.render-pipelines.high-definition@14.0.11\\Runtime\\Material\\Decal\\Decal.cs")]
		public enum DBufferMaterial
		{
			// Token: 0x0400241A RID: 9242
			Count = 4
		}
	}
}
