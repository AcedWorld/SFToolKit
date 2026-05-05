using System;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Rendering.HighDefinition.LTC;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x020000F3 RID: 243
	internal class LTCAreaLight
	{
		// Token: 0x0600097F RID: 2431 RVA: 0x00053A4C File Offset: 0x00051C4C
		internal static IBRDF GetBRDFInterface(LTCLightingModel model)
		{
			switch (model)
			{
			case LTCLightingModel.GGX:
				return new BRDF_GGX();
			case LTCLightingModel.DisneyDiffuse:
				return default(BRDF_Disney);
			case LTCLightingModel.Charlie:
				return default(BRDF_Charlie);
			case LTCLightingModel.FabricLambert:
				return default(BRDF_FabricLambert);
			case LTCLightingModel.KajiyaKaySpecular:
				return default(BRDF_KajiyaKaySpecular);
			case LTCLightingModel.KajiyaKayDiffuse:
				return default(BRDF_KajiyaKayDiffuse);
			case LTCLightingModel.Marschner:
				return default(BRDF_Marschner);
			case LTCLightingModel.CookTorrance:
				return default(BRDF_CookTorrance);
			case LTCLightingModel.Ward:
				return default(BRDF_Ward);
			case LTCLightingModel.OrenNayar:
				return default(BRDF_OrenNayar);
			default:
				return new BRDF_GGX();
			}
		}

		// Token: 0x1700015A RID: 346
		// (get) Token: 0x06000980 RID: 2432 RVA: 0x00053B23 File Offset: 0x00051D23
		internal static LTCAreaLight instance
		{
			get
			{
				if (LTCAreaLight.s_Instance == null)
				{
					LTCAreaLight.s_Instance = new LTCAreaLight();
				}
				return LTCAreaLight.s_Instance;
			}
		}

		// Token: 0x06000981 RID: 2433 RVA: 0x00053B3B File Offset: 0x00051D3B
		internal LTCAreaLight()
		{
			this.m_refCounting = 0;
		}

		// Token: 0x06000982 RID: 2434 RVA: 0x00053B4C File Offset: 0x00051D4C
		internal static void LoadLUT(Texture2DArray tex, int arrayElement, GraphicsFormat format, double[,] LUTTransformInv)
		{
			Color[] array = new Color[4096];
			float a = (format == GraphicsFormat.R16G16B16A16_SFloat) ? 65504f : float.MaxValue;
			for (int i = 0; i < 4096; i++)
			{
				array[i] = new Color(Mathf.Min(a, (float)LUTTransformInv[i, 0]), Mathf.Min(a, (float)LUTTransformInv[i, 2]), Mathf.Min(a, (float)LUTTransformInv[i, 4]), Mathf.Min(a, (float)LUTTransformInv[i, 6]));
			}
			tex.SetPixels(array, arrayElement);
		}

		// Token: 0x06000983 RID: 2435 RVA: 0x00053BD8 File Offset: 0x00051DD8
		internal void Build()
		{
			if (this.m_refCounting == 0)
			{
				this.m_LtcData = new Texture2DArray(64, 64, 10, GraphicsFormat.R16G16B16A16_SFloat, TextureCreationFlags.None)
				{
					hideFlags = HideFlags.HideAndDontSave,
					wrapMode = TextureWrapMode.Clamp,
					filterMode = FilterMode.Bilinear,
					name = CoreUtils.GetTextureAutoName(64, 64, GraphicsFormat.R16G16B16A16_SFloat, TextureDimension.Tex2DArray, "LTC_LUT", false, 10)
				};
				LTCAreaLight.LoadLUT(this.m_LtcData, 0, GraphicsFormat.R16G16B16A16_SFloat, LTCAreaLight.s_LtcMatrixData_BRDF_GGX);
				LTCAreaLight.LoadLUT(this.m_LtcData, 1, GraphicsFormat.R16G16B16A16_SFloat, LTCAreaLight.s_LtcMatrixData_BRDF_Disney);
				LTCAreaLight.LoadLUT(this.m_LtcData, 2, GraphicsFormat.R16G16B16A16_SFloat, LTCAreaLight.s_LtcMatrixData_BRDF_Charlie);
				LTCAreaLight.LoadLUT(this.m_LtcData, 3, GraphicsFormat.R16G16B16A16_SFloat, LTCAreaLight.s_LtcMatrixData_BRDF_FabricLambert);
				LTCAreaLight.LoadLUT(this.m_LtcData, 4, GraphicsFormat.R16G16B16A16_SFloat, LTCAreaLight.s_LtcMatrixData_BRDF_KajiyaKaySpecular);
				LTCAreaLight.LoadLUT(this.m_LtcData, 5, GraphicsFormat.R16G16B16A16_SFloat, LTCAreaLight.s_LtcMatrixData_BRDF_KajiyaKayDiffuse);
				LTCAreaLight.LoadLUT(this.m_LtcData, 7, GraphicsFormat.R16G16B16A16_SFloat, LTCAreaLight.s_LtcMatrixData_BRDF_CookTorrance);
				LTCAreaLight.LoadLUT(this.m_LtcData, 8, GraphicsFormat.R16G16B16A16_SFloat, LTCAreaLight.s_LtcMatrixData_BRDF_Ward);
				LTCAreaLight.LoadLUT(this.m_LtcData, 9, GraphicsFormat.R16G16B16A16_SFloat, LTCAreaLight.s_LtcMatrixData_BRDF_OrenNayar);
				this.m_LtcData.Apply();
			}
			this.m_refCounting++;
		}

		// Token: 0x06000984 RID: 2436 RVA: 0x00053CF9 File Offset: 0x00051EF9
		internal void Cleanup()
		{
			this.m_refCounting--;
			if (this.m_refCounting == 0)
			{
				CoreUtils.Destroy(this.m_LtcData);
			}
		}

		// Token: 0x06000985 RID: 2437 RVA: 0x00053D1C File Offset: 0x00051F1C
		internal void Bind(CommandBuffer cmd)
		{
			cmd.SetGlobalTexture("_LtcData", this.m_LtcData);
		}

		// Token: 0x06000986 RID: 2438 RVA: 0x00053D34 File Offset: 0x00051F34
		// Note: this type is marked as 'beforefieldinit'.
		static LTCAreaLight()
		{
			/*
An exception occurred when decompiling this method (06000986)

ICSharpCode.Decompiler.DecompilerException: Error decompiling System.Void UnityEngine.Rendering.HighDefinition.LTCAreaLight::.cctor()

 ---> System.ArgumentException: Offset and length were out of bounds for the array or count is greater than the number of elements from index to the end of the source collection.
   at System.Collections.Generic.List`1.GetRange(Int32 index, Int32 count)
   at ICSharpCode.Decompiler.Ast.AstMethodBodyBuilder.TransformByteCode(ILExpression byteCode) in D:\a\dnSpy\dnSpy\Extensions\ILSpy.Decompiler\ICSharpCode.Decompiler\ICSharpCode.Decompiler\Ast\AstMethodBodyBuilder.cs:line 599
   at ICSharpCode.Decompiler.Ast.AstMethodBodyBuilder.TransformExpression(ILExpression expr) in D:\a\dnSpy\dnSpy\Extensions\ILSpy.Decompiler\ICSharpCode.Decompiler\ICSharpCode.Decompiler\Ast\AstMethodBodyBuilder.cs:line 414
   at ICSharpCode.Decompiler.Ast.AstMethodBodyBuilder.TransformByteCode(ILExpression byteCode) in D:\a\dnSpy\dnSpy\Extensions\ILSpy.Decompiler\ICSharpCode.Decompiler\ICSharpCode.Decompiler\Ast\AstMethodBodyBuilder.cs:line 479
   at ICSharpCode.Decompiler.Ast.AstMethodBodyBuilder.TransformExpression(ILExpression expr) in D:\a\dnSpy\dnSpy\Extensions\ILSpy.Decompiler\ICSharpCode.Decompiler\ICSharpCode.Decompiler\Ast\AstMethodBodyBuilder.cs:line 414
   at ICSharpCode.Decompiler.Ast.AstMethodBodyBuilder.TransformNode(ILNode node) in D:\a\dnSpy\dnSpy\Extensions\ILSpy.Decompiler\ICSharpCode.Decompiler\ICSharpCode.Decompiler\Ast\AstMethodBodyBuilder.cs:line 270
   at ICSharpCode.Decompiler.Ast.AstMethodBodyBuilder.TransformBlock(ILBlock block) in D:\a\dnSpy\dnSpy\Extensions\ILSpy.Decompiler\ICSharpCode.Decompiler\ICSharpCode.Decompiler\Ast\AstMethodBodyBuilder.cs:line 254
   at ICSharpCode.Decompiler.Ast.AstMethodBodyBuilder.CreateMethodBody(IEnumerable`1 parameters, MethodDebugInfoBuilder& builder) in D:\a\dnSpy\dnSpy\Extensions\ILSpy.Decompiler\ICSharpCode.Decompiler\ICSharpCode.Decompiler\Ast\AstMethodBodyBuilder.cs:line 151
   at ICSharpCode.Decompiler.Ast.AstMethodBodyBuilder.CreateMethodBody(MethodDef methodDef, DecompilerContext context, AutoPropertyProvider autoPropertyProvider, IEnumerable`1 parameters, Boolean valueParameterIsKeyword, StringBuilder sb, MethodDebugInfoBuilder& stmtsBuilder) in D:\a\dnSpy\dnSpy\Extensions\ILSpy.Decompiler\ICSharpCode.Decompiler\ICSharpCode.Decompiler\Ast\AstMethodBodyBuilder.cs:line 99
   --- End of inner exception stack trace ---
   at ICSharpCode.Decompiler.Ast.AstMethodBodyBuilder.CreateMethodBody(MethodDef methodDef, DecompilerContext context, AutoPropertyProvider autoPropertyProvider, IEnumerable`1 parameters, Boolean valueParameterIsKeyword, StringBuilder sb, MethodDebugInfoBuilder& stmtsBuilder) in D:\a\dnSpy\dnSpy\Extensions\ILSpy.Decompiler\ICSharpCode.Decompiler\ICSharpCode.Decompiler\Ast\AstMethodBodyBuilder.cs:line 99
   at ICSharpCode.Decompiler.Ast.AstBuilder.AddMethodBody(EntityDeclaration methodNode, EntityDeclaration& updatedNode, MethodDef method, IEnumerable`1 parameters, Boolean valueParameterIsKeyword, MethodKind methodKind) in D:\a\dnSpy\dnSpy\Extensions\ILSpy.Decompiler\ICSharpCode.Decompiler\ICSharpCode.Decompiler\Ast\AstBuilder.cs:line 1533
*/;
		}

		// Token: 0x04000A5A RID: 2650
		internal static double[,] s_LtcMatrixData_GGX;

		// Token: 0x04000A5B RID: 2651
		internal static double[,] s_LtcMatrixData_BRDF_Charlie;

		// Token: 0x04000A5C RID: 2652
		internal static double[,] s_LtcMatrixData_BRDF_CookTorrance;

		// Token: 0x04000A5D RID: 2653
		internal static double[,] s_LtcMatrixData_BRDF_Disney;

		// Token: 0x04000A5E RID: 2654
		internal static double[,] s_LtcMatrixData_BRDF_FabricLambert;

		// Token: 0x04000A5F RID: 2655
		internal static double[,] s_LtcMatrixData_BRDF_GGX;

		// Token: 0x04000A60 RID: 2656
		internal static double[,] s_LtcMatrixData_BRDF_KajiyaKayDiffuse;

		// Token: 0x04000A61 RID: 2657
		internal static double[,] s_LtcMatrixData_BRDF_KajiyaKaySpecular;

		// Token: 0x04000A62 RID: 2658
		internal static double[,] s_LtcMatrixData_BRDF_OrenNayar;

		// Token: 0x04000A63 RID: 2659
		internal static double[,] s_LtcMatrixData_BRDF_Ward;

		// Token: 0x04000A64 RID: 2660
		private static LTCAreaLight s_Instance;

		// Token: 0x04000A65 RID: 2661
		private int m_refCounting;

		// Token: 0x04000A66 RID: 2662
		private Texture2DArray m_LtcData;

		// Token: 0x04000A67 RID: 2663
		internal const int k_LtcLUTMatrixDim = 3;

		// Token: 0x04000A68 RID: 2664
		internal const int k_LtcLUTResolution = 64;
	}
}
