using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine.Experimental.Rendering;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x020001C8 RID: 456
	public class HDUtils
	{
		// Token: 0x06000DDB RID: 3547 RVA: 0x0006F6A1 File Offset: 0x0006D8A1
		[Obsolete("Use GetRendererConfiguration() instead. #from(23.2).")]
		public static PerObjectData GetBakedLightingRenderConfig()
		{
			return PerObjectData.LightProbe | PerObjectData.LightProbeProxyVolume | PerObjectData.Lightmaps;
		}

		// Token: 0x06000DDC RID: 3548 RVA: 0x0006F6A5 File Offset: 0x0006D8A5
		[Obsolete("Use GetRendererConfiguration() instead. #from(23.2).")]
		public static PerObjectData GetBakedLightingWithShadowMaskRenderConfig()
		{
			return HDUtils.GetBakedLightingRenderConfig() | PerObjectData.OcclusionProbe | PerObjectData.OcclusionProbeProxyVolume | PerObjectData.ShadowMask;
		}

		// Token: 0x06000DDD RID: 3549 RVA: 0x0006F6C0 File Offset: 0x0006D8C0
		public static PerObjectData GetRendererConfiguration(bool apv, bool shadowMask)
		{
			PerObjectData perObjectData = PerObjectData.Lightmaps;
			if (!apv)
			{
				perObjectData |= (PerObjectData.LightProbe | PerObjectData.LightProbeProxyVolume);
			}
			if (shadowMask)
			{
				perObjectData |= (PerObjectData.OcclusionProbe | PerObjectData.OcclusionProbeProxyVolume | PerObjectData.ShadowMask);
			}
			return perObjectData;
		}

		// Token: 0x1700023A RID: 570
		// (get) Token: 0x06000DDE RID: 3550 RVA: 0x0006F6E2 File Offset: 0x0006D8E2
		internal static HDAdditionalReflectionData s_DefaultHDAdditionalReflectionData
		{
			get
			{
				return ComponentSingleton<HDAdditionalReflectionData>.instance;
			}
		}

		// Token: 0x1700023B RID: 571
		// (get) Token: 0x06000DDF RID: 3551 RVA: 0x0006F6E9 File Offset: 0x0006D8E9
		internal static HDAdditionalLightData s_DefaultHDAdditionalLightData
		{
			get
			{
				return ComponentSingleton<HDAdditionalLightData>.instance;
			}
		}

		// Token: 0x1700023C RID: 572
		// (get) Token: 0x06000DE0 RID: 3552 RVA: 0x0006F6F0 File Offset: 0x0006D8F0
		internal static HDAdditionalCameraData s_DefaultHDAdditionalCameraData
		{
			get
			{
				return ComponentSingleton<HDAdditionalCameraData>.instance;
			}
		}

		// Token: 0x1700023D RID: 573
		// (get) Token: 0x06000DE1 RID: 3553 RVA: 0x0006F6F8 File Offset: 0x0006D8F8
		public static Texture3D clearTexture3D
		{
			get
			{
				if (HDUtils.m_ClearTexture3D == null)
				{
					HDUtils.m_ClearTexture3D = new Texture3D(1, 1, 1, GraphicsFormat.R8G8B8A8_SRGB, TextureCreationFlags.None)
					{
						name = "Transparent Texture 3D"
					};
					HDUtils.m_ClearTexture3D.SetPixel(0, 0, 0, Color.clear);
					HDUtils.m_ClearTexture3D.Apply();
					RTHandles.Release(HDUtils.m_ClearTexture3DRTH);
					HDUtils.m_ClearTexture3DRTH = null;
				}
				return HDUtils.m_ClearTexture3D;
			}
		}

		// Token: 0x1700023E RID: 574
		// (get) Token: 0x06000DE2 RID: 3554 RVA: 0x0006F75D File Offset: 0x0006D95D
		public static RTHandle clearTexture3DRTH
		{
			get
			{
				if (HDUtils.m_ClearTexture3DRTH == null || HDUtils.m_ClearTexture3D == null)
				{
					RTHandles.Release(HDUtils.m_ClearTexture3DRTH);
					HDUtils.m_ClearTexture3DRTH = RTHandles.Alloc(HDUtils.clearTexture3D);
				}
				return HDUtils.m_ClearTexture3DRTH;
			}
		}

		// Token: 0x06000DE3 RID: 3555 RVA: 0x0006F791 File Offset: 0x0006D991
		public static Material GetBlitMaterial(TextureDimension dimension, bool singleSlice = false)
		{
			return Blitter.GetBlitMaterial(dimension, singleSlice);
		}

		// Token: 0x1700023F RID: 575
		// (get) Token: 0x06000DE4 RID: 3556 RVA: 0x0006F79A File Offset: 0x0006D99A
		public static RenderPipelineSettings hdrpSettings
		{
			get
			{
				return HDRenderPipeline.currentAsset.currentPlatformRenderPipelineSettings;
			}
		}

		// Token: 0x06000DE5 RID: 3557 RVA: 0x0006F7A8 File Offset: 0x0006D9A8
		internal static List<RenderPipelineMaterial> GetRenderPipelineMaterialList()
		{
			Type baseType = typeof(RenderPipelineMaterial);
			Assembly assembly = baseType.Assembly;
			List<RenderPipelineMaterial> result;
			try
			{
				result = (from t in assembly.GetTypes()
				where t.IsSubclassOf(baseType)
				select t).Select(new Func<Type, object>(Activator.CreateInstance)).Cast<RenderPipelineMaterial>().ToList<RenderPipelineMaterial>();
			}
			catch (ReflectionTypeLoadException ex)
			{
				foreach (TypeLoadException ex2 in ex.LoaderExceptions)
				{
					Debug.LogError("Encountered an exception while attempting to reflect the HDRP assembly to extract all RenderPipelineMaterial types.\nThis exception must be fixed in order to fully initialize HDRP correctly.\n" + ex2.Message + "\n" + ex2.TypeName);
				}
				result = null;
			}
			return result;
		}

		// Token: 0x06000DE6 RID: 3558 RVA: 0x0006F868 File Offset: 0x0006DA68
		internal static int GetRuntimeDebugPanelWidth(HDCamera hdCamera)
		{
			int val = DebugManager.instance.displayRuntimeUI ? 610 : 0;
			return Math.Min(hdCamera.actualWidth, val);
		}

		// Token: 0x06000DE7 RID: 3559 RVA: 0x0006F896 File Offset: 0x0006DA96
		internal static float ProjectionMatrixAspect(in Matrix4x4 matrix)
		{
			return -matrix.m11 / matrix.m00;
		}

		// Token: 0x06000DE8 RID: 3560 RVA: 0x0006F8A6 File Offset: 0x0006DAA6
		internal static bool IsProjectionMatrixAsymmetric(in Matrix4x4 matrix)
		{
			return matrix.m02 != 0f || matrix.m12 != 0f;
		}

		// Token: 0x06000DE9 RID: 3561 RVA: 0x0006F8C8 File Offset: 0x0006DAC8
		internal static Matrix4x4 ComputePixelCoordToWorldSpaceViewDirectionMatrix(float verticalFoV, Vector2 lensShift, Vector4 screenSize, Matrix4x4 worldToViewMatrix, bool renderToCubemap, float aspectRatio = -1f, bool isOrthographic = false)
		{
			Matrix4x4 rhs;
			if (isOrthographic)
			{
				rhs = new Matrix4x4(new Vector4(-2f * screenSize.z, 0f, 0f, 0f), new Vector4(0f, -2f * screenSize.w, 0f, 0f), new Vector4(1f, 1f, -1f, 0f), new Vector4(0f, 0f, 0f, 0f));
			}
			else
			{
				aspectRatio = ((aspectRatio < 0f) ? (screenSize.x * screenSize.w) : aspectRatio);
				float num = Mathf.Tan(0.5f * verticalFoV);
				float num2 = (1f - 2f * lensShift.y) * num;
				float num3 = -2f * screenSize.w * num;
				float x = (1f - 2f * lensShift.x) * num * aspectRatio;
				float x2 = -2f * screenSize.z * num * aspectRatio;
				if (renderToCubemap)
				{
					num3 = -num3;
					num2 = -num2;
				}
				rhs = new Matrix4x4(new Vector4(x2, 0f, 0f, 0f), new Vector4(0f, num3, 0f, 0f), new Vector4(x, num2, -1f, 0f), new Vector4(0f, 0f, 0f, 1f));
			}
			Vector4 column = new Vector4(0f, 0f, 0f, 1f);
			worldToViewMatrix.SetColumn(3, column);
			worldToViewMatrix.SetRow(2, -worldToViewMatrix.GetRow(2));
			return Matrix4x4.Transpose(worldToViewMatrix.transpose * rhs);
		}

		// Token: 0x06000DEA RID: 3562 RVA: 0x0006FA86 File Offset: 0x0006DC86
		internal static float ComputZPlaneTexelSpacing(float planeDepth, float verticalFoV, float resolutionY)
		{
			return Mathf.Tan(0.5f * verticalFoV) * (2f / resolutionY) * planeDepth;
		}

		// Token: 0x06000DEB RID: 3563 RVA: 0x0006FA9E File Offset: 0x0006DC9E
		public static void BlitQuad(CommandBuffer cmd, Texture source, Vector4 scaleBiasTex, Vector4 scaleBiasRT, int mipLevelTex, bool bilinear)
		{
			Blitter.BlitQuad(cmd, source, scaleBiasTex, scaleBiasRT, mipLevelTex, bilinear);
		}

		// Token: 0x06000DEC RID: 3564 RVA: 0x0006FAAD File Offset: 0x0006DCAD
		public static void BlitQuadWithPadding(CommandBuffer cmd, Texture source, Vector2 textureSize, Vector4 scaleBiasTex, Vector4 scaleBiasRT, int mipLevelTex, bool bilinear, int paddingInPixels)
		{
			Blitter.BlitQuadWithPadding(cmd, source, textureSize, scaleBiasTex, scaleBiasRT, mipLevelTex, bilinear, paddingInPixels);
		}

		// Token: 0x06000DED RID: 3565 RVA: 0x0006FAC0 File Offset: 0x0006DCC0
		public static void BlitQuadWithPaddingMultiply(CommandBuffer cmd, Texture source, Vector2 textureSize, Vector4 scaleBiasTex, Vector4 scaleBiasRT, int mipLevelTex, bool bilinear, int paddingInPixels)
		{
			Blitter.BlitQuadWithPaddingMultiply(cmd, source, textureSize, scaleBiasTex, scaleBiasRT, mipLevelTex, bilinear, paddingInPixels);
		}

		// Token: 0x06000DEE RID: 3566 RVA: 0x0006FAD3 File Offset: 0x0006DCD3
		public static void BlitOctahedralWithPadding(CommandBuffer cmd, Texture source, Vector2 textureSize, Vector4 scaleBiasTex, Vector4 scaleBiasRT, int mipLevelTex, bool bilinear, int paddingInPixels)
		{
			Blitter.BlitOctahedralWithPadding(cmd, source, textureSize, scaleBiasTex, scaleBiasRT, mipLevelTex, bilinear, paddingInPixels);
		}

		// Token: 0x06000DEF RID: 3567 RVA: 0x0006FAE6 File Offset: 0x0006DCE6
		public static void BlitOctahedralWithPaddingMultiply(CommandBuffer cmd, Texture source, Vector2 textureSize, Vector4 scaleBiasTex, Vector4 scaleBiasRT, int mipLevelTex, bool bilinear, int paddingInPixels)
		{
			Blitter.BlitOctahedralWithPaddingMultiply(cmd, source, textureSize, scaleBiasTex, scaleBiasRT, mipLevelTex, bilinear, paddingInPixels);
		}

		// Token: 0x06000DF0 RID: 3568 RVA: 0x0006FAF9 File Offset: 0x0006DCF9
		public static void BlitTexture(CommandBuffer cmd, RTHandle source, Vector4 scaleBias, float mipLevel, bool bilinear)
		{
			Blitter.BlitTexture(cmd, source, scaleBias, mipLevel, bilinear);
		}

		// Token: 0x06000DF1 RID: 3569 RVA: 0x0006FB06 File Offset: 0x0006DD06
		public static void BlitTexture2D(CommandBuffer cmd, RTHandle source, Vector4 scaleBias, float mipLevel, bool bilinear)
		{
			Blitter.BlitTexture2D(cmd, source, scaleBias, mipLevel, bilinear);
		}

		// Token: 0x06000DF2 RID: 3570 RVA: 0x0006FB13 File Offset: 0x0006DD13
		internal static void BlitColorAndDepth(CommandBuffer cmd, Texture sourceColor, RenderTexture sourceDepth, Vector4 scaleBias, float mipLevel, bool blitDepth)
		{
			Blitter.BlitColorAndDepth(cmd, sourceColor, sourceDepth, scaleBias, mipLevel, blitDepth);
		}

		// Token: 0x06000DF3 RID: 3571 RVA: 0x0006FB22 File Offset: 0x0006DD22
		private static void BlitTexture(CommandBuffer cmd, RTHandle source, Vector4 scaleBias, Material material, int pass)
		{
			Blitter.BlitTexture(cmd, source, scaleBias, material, pass);
		}

		// Token: 0x06000DF4 RID: 3572 RVA: 0x0006FB2F File Offset: 0x0006DD2F
		public static void BlitCameraTexture(CommandBuffer cmd, RTHandle source, RTHandle destination, float mipLevel = 0f, bool bilinear = false)
		{
			Blitter.BlitCameraTexture(cmd, source, destination, mipLevel, bilinear);
		}

		// Token: 0x06000DF5 RID: 3573 RVA: 0x0006FB3C File Offset: 0x0006DD3C
		public static void BlitCameraTexture2D(CommandBuffer cmd, RTHandle source, RTHandle destination, float mipLevel = 0f, bool bilinear = false)
		{
			Blitter.BlitCameraTexture2D(cmd, source, destination, mipLevel, bilinear);
		}

		// Token: 0x06000DF6 RID: 3574 RVA: 0x0006FB49 File Offset: 0x0006DD49
		public static void BlitCameraTexture(CommandBuffer cmd, RTHandle source, RTHandle destination, Material material, int pass)
		{
			Blitter.BlitCameraTexture(cmd, source, destination, material, pass);
		}

		// Token: 0x06000DF7 RID: 3575 RVA: 0x0006FB56 File Offset: 0x0006DD56
		public static void BlitCameraTexture(CommandBuffer cmd, RTHandle source, RTHandle destination, Vector4 scaleBias, float mipLevel = 0f, bool bilinear = false)
		{
			Blitter.BlitCameraTexture(cmd, source, destination, scaleBias, mipLevel, bilinear);
		}

		// Token: 0x06000DF8 RID: 3576 RVA: 0x0006FB65 File Offset: 0x0006DD65
		public static void BlitCameraTexture(CommandBuffer cmd, RTHandle source, RTHandle destination, Rect destViewport, float mipLevel = 0f, bool bilinear = false)
		{
			Blitter.BlitCameraTexture(cmd, source, destination, destViewport, mipLevel, bilinear);
		}

		// Token: 0x06000DF9 RID: 3577 RVA: 0x0006FB74 File Offset: 0x0006DD74
		public static void DrawFullScreen(CommandBuffer commandBuffer, Material material, RTHandle colorBuffer, MaterialPropertyBlock properties = null, int shaderPassId = 0)
		{
			CoreUtils.SetRenderTarget(commandBuffer, colorBuffer, ClearFlag.None, 0, CubemapFace.Unknown, -1);
			commandBuffer.DrawProcedural(Matrix4x4.identity, material, shaderPassId, MeshTopology.Triangles, 3, 1, properties);
		}

		// Token: 0x06000DFA RID: 3578 RVA: 0x0006FB93 File Offset: 0x0006DD93
		public static void DrawFullScreen(CommandBuffer commandBuffer, Material material, RTHandle colorBuffer, RTHandle depthStencilBuffer, MaterialPropertyBlock properties = null, int shaderPassId = 0)
		{
			CoreUtils.SetRenderTarget(commandBuffer, colorBuffer, depthStencilBuffer, 0, CubemapFace.Unknown, -1);
			commandBuffer.DrawProcedural(Matrix4x4.identity, material, shaderPassId, MeshTopology.Triangles, 3, 1, properties);
		}

		// Token: 0x06000DFB RID: 3579 RVA: 0x0006FBB3 File Offset: 0x0006DDB3
		public static void DrawFullScreen(CommandBuffer commandBuffer, Material material, RenderTargetIdentifier[] colorBuffers, RTHandle depthStencilBuffer, MaterialPropertyBlock properties = null, int shaderPassId = 0)
		{
			CoreUtils.SetRenderTarget(commandBuffer, colorBuffers, depthStencilBuffer);
			commandBuffer.DrawProcedural(Matrix4x4.identity, material, shaderPassId, MeshTopology.Triangles, 3, 1, properties);
		}

		// Token: 0x06000DFC RID: 3580 RVA: 0x0006FBD0 File Offset: 0x0006DDD0
		public static void DrawFullScreen(CommandBuffer commandBuffer, Rect viewport, Material material, RenderTargetIdentifier destination, CubemapFace cubemapFace, MaterialPropertyBlock properties = null, int shaderPassId = 0, int depthSlice = -1)
		{
			CoreUtils.SetRenderTarget(commandBuffer, destination, ClearFlag.None, 0, cubemapFace, depthSlice);
			commandBuffer.SetViewport(viewport);
			commandBuffer.DrawProcedural(Matrix4x4.identity, material, shaderPassId, MeshTopology.Triangles, 3, 1, properties);
		}

		// Token: 0x06000DFD RID: 3581 RVA: 0x0006FBF9 File Offset: 0x0006DDF9
		public static void DrawFullScreen(CommandBuffer commandBuffer, Rect viewport, Material material, RenderTargetIdentifier destination, MaterialPropertyBlock properties = null, int shaderPassId = 0, int depthSlice = -1)
		{
			HDUtils.DrawFullScreen(commandBuffer, viewport, material, destination, CubemapFace.Unknown, properties, shaderPassId, depthSlice);
		}

		// Token: 0x06000DFE RID: 3582 RVA: 0x0006FC0B File Offset: 0x0006DE0B
		public static void DrawFullScreen(CommandBuffer commandBuffer, Rect viewport, Material material, RenderTargetIdentifier destination, RTHandle depthStencilBuffer, MaterialPropertyBlock properties = null, int shaderPassId = 0)
		{
			CoreUtils.SetRenderTarget(commandBuffer, destination, depthStencilBuffer, ClearFlag.None, 0, CubemapFace.Unknown, -1);
			commandBuffer.SetViewport(viewport);
			commandBuffer.DrawProcedural(Matrix4x4.identity, material, shaderPassId, MeshTopology.Triangles, 3, 1, properties);
		}

		// Token: 0x06000DFF RID: 3583 RVA: 0x0006FC3C File Offset: 0x0006DE3C
		internal static Vector4 GetMouseCoordinates(HDCamera camera)
		{
			Vector2 mousePosition = MousePositionDebug.instance.GetMousePosition(camera.screenSize.y, camera.camera.cameraType == CameraType.SceneView);
			return new Vector4(mousePosition.x, mousePosition.y, RTHandles.rtHandleProperties.rtHandleScale.x * mousePosition.x / camera.screenSize.x, RTHandles.rtHandleProperties.rtHandleScale.y * mousePosition.y / camera.screenSize.y);
		}

		// Token: 0x06000E00 RID: 3584 RVA: 0x0006FCC4 File Offset: 0x0006DEC4
		internal static Vector4 GetMouseClickCoordinates(HDCamera camera)
		{
			Vector2 mouseClickPosition = MousePositionDebug.instance.GetMouseClickPosition(camera.screenSize.y);
			return new Vector4(mouseClickPosition.x, mouseClickPosition.y, RTHandles.rtHandleProperties.rtHandleScale.x * mouseClickPosition.x / camera.screenSize.x, RTHandles.rtHandleProperties.rtHandleScale.y * mouseClickPosition.y / camera.screenSize.y);
		}

		// Token: 0x06000E01 RID: 3585 RVA: 0x0006FD3C File Offset: 0x0006DF3C
		internal static bool IsRegularPreviewCamera(Camera camera)
		{
			if (camera.cameraType == CameraType.Preview)
			{
				HDAdditionalCameraData hdadditionalCameraData;
				camera.TryGetComponent<HDAdditionalCameraData>(out hdadditionalCameraData);
				return hdadditionalCameraData == null || !hdadditionalCameraData.isEditorCameraPreview;
			}
			return false;
		}

		// Token: 0x06000E02 RID: 3586 RVA: 0x0006FD71 File Offset: 0x0006DF71
		internal static string GetHDRenderPipelinePath()
		{
			return "Packages/com.unity.render-pipelines.high-definition/";
		}

		// Token: 0x06000E03 RID: 3587 RVA: 0x0006FD78 File Offset: 0x0006DF78
		internal static string GetCorePath()
		{
			return "Packages/com.unity.render-pipelines.core/";
		}

		// Token: 0x06000E04 RID: 3588 RVA: 0x0006FD7F File Offset: 0x0006DF7F
		internal static string GetVFXPath()
		{
			return "Packages/com.unity.visualeffectgraph/";
		}

		// Token: 0x06000E05 RID: 3589 RVA: 0x0006FD88 File Offset: 0x0006DF88
		internal static RenderPipelineAsset SwitchToBuiltinRenderPipeline(out bool assetWasFromQuality)
		{
			RenderPipelineAsset renderPipelineAsset = GraphicsSettings.renderPipelineAsset;
			assetWasFromQuality = false;
			if (renderPipelineAsset != null && GraphicsSettings.currentRenderPipeline == renderPipelineAsset)
			{
				GraphicsSettings.renderPipelineAsset = null;
				return renderPipelineAsset;
			}
			RenderPipelineAsset renderPipeline = QualitySettings.renderPipeline;
			QualitySettings.renderPipeline = null;
			assetWasFromQuality = true;
			return renderPipeline;
		}

		// Token: 0x06000E06 RID: 3590 RVA: 0x0006FDCA File Offset: 0x0006DFCA
		internal static void RestoreRenderPipelineAsset(bool wasUnsetFromQuality, RenderPipelineAsset renderPipelineAsset)
		{
			if (wasUnsetFromQuality)
			{
				QualitySettings.renderPipeline = renderPipelineAsset;
				return;
			}
			GraphicsSettings.renderPipelineAsset = renderPipelineAsset;
		}

		// Token: 0x06000E07 RID: 3591 RVA: 0x0006FDDC File Offset: 0x0006DFDC
		internal static int DivRoundUp(int x, int y)
		{
			return (x + y - 1) / y;
		}

		// Token: 0x06000E08 RID: 3592 RVA: 0x0006FDE8 File Offset: 0x0006DFE8
		internal static bool IsQuaternionValid(Quaternion q)
		{
			return q[0] * q[0] + q[1] * q[1] + q[2] * q[2] + q[3] * q[3] > float.Epsilon;
		}

		// Token: 0x06000E09 RID: 3593 RVA: 0x0006FE43 File Offset: 0x0006E043
		internal static void CheckRTCreated(RenderTexture rt)
		{
			if (!rt.IsCreated())
			{
				rt.Create();
			}
		}

		// Token: 0x06000E0A RID: 3594 RVA: 0x0006FE54 File Offset: 0x0006E054
		internal static float ComputeViewportScale(int viewportSize, int bufferSize)
		{
			float num = 1f / (float)bufferSize;
			return (float)viewportSize * num;
		}

		// Token: 0x06000E0B RID: 3595 RVA: 0x0006FE70 File Offset: 0x0006E070
		internal static float ComputeViewportLimit(int viewportSize, int bufferSize)
		{
			float num = 1f / (float)bufferSize;
			return ((float)viewportSize - 0.5f) * num;
		}

		// Token: 0x06000E0C RID: 3596 RVA: 0x0006FE90 File Offset: 0x0006E090
		internal static Vector4 ComputeViewportScaleAndLimit(Vector2Int viewportSize, Vector2Int bufferSize)
		{
			return new Vector4(HDUtils.ComputeViewportScale(viewportSize.x, bufferSize.x), HDUtils.ComputeViewportScale(viewportSize.y, bufferSize.y), HDUtils.ComputeViewportLimit(viewportSize.x, bufferSize.x), HDUtils.ComputeViewportLimit(viewportSize.y, bufferSize.y));
		}

		// Token: 0x06000E0D RID: 3597 RVA: 0x0006FEEE File Offset: 0x0006E0EE
		internal static bool IsSupportedGraphicDevice(GraphicsDeviceType graphicDevice)
		{
			return graphicDevice == GraphicsDeviceType.Direct3D11 || graphicDevice == GraphicsDeviceType.Direct3D12 || graphicDevice == GraphicsDeviceType.PlayStation4 || graphicDevice == GraphicsDeviceType.PlayStation5 || graphicDevice == GraphicsDeviceType.PlayStation5NGGC || graphicDevice == GraphicsDeviceType.XboxOne || graphicDevice == GraphicsDeviceType.XboxOneD3D12 || graphicDevice == GraphicsDeviceType.GameCoreXboxOne || graphicDevice == GraphicsDeviceType.GameCoreXboxSeries || graphicDevice == GraphicsDeviceType.Metal || graphicDevice == GraphicsDeviceType.Vulkan;
		}

		// Token: 0x06000E0E RID: 3598 RVA: 0x0006FF28 File Offset: 0x0006E128
		internal static bool IsMacOSVersionAtLeast(string os, int majorVersion, int minorVersion, int patchVersion)
		{
			int num = os.LastIndexOf(" ");
			string[] array = os.Substring(num + 1).Split('.', StringSplitOptions.None);
			int num2 = Convert.ToInt32(array[0]);
			int num3 = Convert.ToInt32(array[1]);
			int num4 = Convert.ToInt32(array[2]);
			return num2 >= majorVersion && (num2 > majorVersion || (num3 >= minorVersion && (num3 > minorVersion || num4 >= patchVersion)));
		}

		// Token: 0x06000E0F RID: 3599 RVA: 0x0006FF8F File Offset: 0x0006E18F
		internal static bool IsOperatingSystemSupported(string os)
		{
			return SystemInfo.graphicsDeviceType != GraphicsDeviceType.Metal || !os.StartsWith("Mac") || HDUtils.IsMacOSVersionAtLeast(os, 10, 13, 0);
		}

		// Token: 0x06000E10 RID: 3600 RVA: 0x0006FFB8 File Offset: 0x0006E1B8
		internal static void GetScaleAndBiasForLinearDistanceFade(float fadeDistance, out float scale, out float bias)
		{
			float num = 0.9f * fadeDistance;
			scale = 1f / (fadeDistance - num);
			bias = -num / (fadeDistance - num);
		}

		// Token: 0x06000E11 RID: 3601 RVA: 0x0006FFE0 File Offset: 0x0006E1E0
		internal static float ComputeLinearDistanceFade(float distanceToCamera, float fadeDistance)
		{
			float num;
			float num2;
			HDUtils.GetScaleAndBiasForLinearDistanceFade(fadeDistance, out num, out num2);
			return 1f - Mathf.Clamp01(distanceToCamera * num + num2);
		}

		// Token: 0x06000E12 RID: 3602 RVA: 0x00070007 File Offset: 0x0006E207
		internal static float ComputeWeightedLinearFadeDistance(Vector3 position1, Vector3 position2, float weight, float fadeDistance)
		{
			return HDUtils.ComputeLinearDistanceFade(Vector3.Magnitude(position1 - position2), fadeDistance) * weight;
		}

		// Token: 0x06000E13 RID: 3603 RVA: 0x00070020 File Offset: 0x0006E220
		internal static bool WillCustomPassBeExecuted(HDCamera hdCamera, CustomPassInjectionPoint injectionPoint)
		{
			if (!hdCamera.frameSettings.IsEnabled(FrameSettingsField.CustomPass))
			{
				return false;
			}
			bool flag = false;
			CustomPassVolume.GetActivePassVolumes(injectionPoint, HDUtils.m_TempCustomPassVolumeList);
			foreach (CustomPassVolume customPassVolume in HDUtils.m_TempCustomPassVolumeList)
			{
				if (customPassVolume == null)
				{
					return false;
				}
				flag |= customPassVolume.WillExecuteInjectionPoint(hdCamera);
			}
			return flag;
		}

		// Token: 0x06000E14 RID: 3604 RVA: 0x000700A8 File Offset: 0x0006E2A8
		internal static bool PostProcessIsFinalPass(HDCamera hdCamera, AOVRequestData aovRequest)
		{
			return !aovRequest.isValid && !Debug.isDebugBuild && !HDUtils.WillCustomPassBeExecuted(hdCamera, CustomPassInjectionPoint.AfterPostProcess) && !hdCamera.hasCaptureActions;
		}

		// Token: 0x06000E15 RID: 3605 RVA: 0x000700D0 File Offset: 0x0006E2D0
		internal unsafe static Vector4 ConvertGUIDToVector4(string guid)
		{
			byte[] array = new byte[16];
			for (int i = 0; i < 16; i++)
			{
				array[i] = byte.Parse(guid.Substring(i * 2, 2), NumberStyles.HexNumber);
			}
			byte[] array2;
			byte* ptr;
			if ((array2 = array) == null || array2.Length == 0)
			{
				ptr = null;
			}
			else
			{
				ptr = &array2[0];
			}
			Vector4 result = *(Vector4*)ptr;
			array2 = null;
			return result;
		}

		// Token: 0x06000E16 RID: 3606 RVA: 0x0007012C File Offset: 0x0006E32C
		internal unsafe static string ConvertVector4ToGUID(Vector4 vector)
		{
			StringBuilder stringBuilder = new StringBuilder();
			byte* ptr = (byte*)(&vector);
			for (int i = 0; i < 16; i++)
			{
				stringBuilder.Append(ptr[i].ToString("x2"));
			}
			byte[] destination = new byte[16];
			Marshal.Copy((IntPtr)((void*)ptr), destination, 0, 16);
			return stringBuilder.ToString();
		}

		// Token: 0x06000E17 RID: 3607 RVA: 0x00070184 File Offset: 0x0006E384
		public static Color NormalizeColor(Color color)
		{
			Vector4 vector = Vector4.Max(color, Vector4.one * 0.0001f);
			Color color2 = vector;
			color = vector / ColorUtils.Luminance(color2);
			color.a = 1f;
			return color;
		}

		// Token: 0x06000E18 RID: 3608 RVA: 0x000701D2 File Offset: 0x0006E3D2
		[Obsolete("Please use CoreUtils.DrawRendererList instead.")]
		public static void DrawRendererList(ScriptableRenderContext renderContext, CommandBuffer cmd, RendererList rendererList)
		{
			CoreUtils.DrawRendererList(renderContext, cmd, rendererList);
		}

		// Token: 0x06000E19 RID: 3609 RVA: 0x000701DC File Offset: 0x0006E3DC
		internal unsafe static string ComputeProbeCameraName(string probeName, int face, string viewerName)
		{
			probeName = (probeName ?? string.Empty);
			viewerName = (viewerName ?? "null");
			int num = Mathf.Min(probeName.Length, 40);
			int num2 = Mathf.Min(viewerName.Length, 40);
			int num3 = "HDProbe RenderCamera (".Length + num + ": ".Length + 2 + " for viewer '".Length + num2 + "')".Length;
			char* ptr = stackalloc char[checked(unchecked((UIntPtr)num3) * 2)];
			char* ptr2 = ptr;
			int num4 = 0;
			int i = 0;
			while (i < "HDProbe RenderCamera (".Length)
			{
				*ptr2 = "HDProbe RenderCamera ("[i];
				i++;
				ptr2++;
			}
			i = 0;
			int num5 = Mathf.Min(probeName.Length, 40);
			while (i < num5)
			{
				*ptr2 = probeName[i];
				i++;
				ptr2++;
			}
			num4 += num5;
			i = 0;
			while (i < ": ".Length)
			{
				*ptr2 = ": "[i];
				i++;
				ptr2++;
			}
			int num6 = face * 205 >> 11;
			*(ptr2++) = (char)(num6 + 48);
			*(ptr2++) = (char)(face - num6 * 10 + 48);
			num4 += 2;
			i = 0;
			while (i < " for viewer '".Length)
			{
				*ptr2 = " for viewer '"[i];
				i++;
				ptr2++;
			}
			i = 0;
			num5 = Mathf.Min(viewerName.Length, 40);
			while (i < num5)
			{
				*ptr2 = viewerName[i];
				i++;
				ptr2++;
			}
			num4 += num5;
			i = 0;
			while (i < "')".Length)
			{
				*ptr2 = "')"[i];
				i++;
				ptr2++;
			}
			num4 += "HDProbe RenderCamera (".Length + ": ".Length + " for viewer '".Length + "')".Length;
			return new string(ptr, 0, num4);
		}

		// Token: 0x06000E1A RID: 3610 RVA: 0x000703F0 File Offset: 0x0006E5F0
		internal unsafe static string ComputeCameraName(string cameraName)
		{
			int num = Mathf.Min(cameraName.Length, 40);
			int num2 = "HDRenderPipeline::Render ".Length + num;
			char* ptr = stackalloc char[checked(unchecked((UIntPtr)num2) * 2)];
			char* ptr2 = ptr;
			int num3 = 0;
			int i = 0;
			while (i < "HDRenderPipeline::Render ".Length)
			{
				*ptr2 = "HDRenderPipeline::Render "[i];
				i++;
				ptr2++;
			}
			i = 0;
			int num4 = num;
			while (i < num4)
			{
				*ptr2 = cameraName[i];
				i++;
				ptr2++;
			}
			num3 += num4;
			num3 += "HDRenderPipeline::Render ".Length;
			return new string(ptr, 0, num3);
		}

		// Token: 0x06000E1B RID: 3611 RVA: 0x00070490 File Offset: 0x0006E690
		internal static float ClampFOV(float fov)
		{
			return Mathf.Clamp(fov, 1E-05f, 179f);
		}

		// Token: 0x06000E1C RID: 3612 RVA: 0x000704A2 File Offset: 0x0006E6A2
		internal static ulong GetSceneCullingMaskFromCamera(Camera camera)
		{
			return 0UL;
		}

		// Token: 0x06000E1D RID: 3613 RVA: 0x000704A8 File Offset: 0x0006E6A8
		internal static HDAdditionalCameraData TryGetAdditionalCameraDataOrDefault(Camera camera)
		{
			if (camera == null || camera.Equals(null))
			{
				return HDUtils.s_DefaultHDAdditionalCameraData;
			}
			HDAdditionalCameraData result;
			if (camera.TryGetComponent<HDAdditionalCameraData>(out result))
			{
				return result;
			}
			return HDUtils.s_DefaultHDAdditionalCameraData;
		}

		// Token: 0x06000E1E RID: 3614 RVA: 0x000704E0 File Offset: 0x0006E6E0
		internal static int GetFormatSizeInBytes(GraphicsFormat format)
		{
			int num;
			if (HDUtils.graphicsFormatSizeCache.TryGetValue(format, out num))
			{
				return num;
			}
			string text = format.ToString();
			int num2 = text.IndexOf('_');
			text = text.Substring(0, (num2 == -1) ? text.Length : num2);
			int num3 = 0;
			foreach (object obj in Regex.Matches(text, "\\d+"))
			{
				Match match = (Match)obj;
				num3 += int.Parse(match.Value);
			}
			num = num3 / 8;
			HDUtils.graphicsFormatSizeCache[format] = num;
			return num;
		}

		// Token: 0x06000E1F RID: 3615 RVA: 0x000705A0 File Offset: 0x0006E7A0
		internal static void DisplayMessageNotification(string msg)
		{
			Debug.LogError(msg);
		}

		// Token: 0x06000E20 RID: 3616 RVA: 0x000705A8 File Offset: 0x0006E7A8
		internal static string GetUnsupportedAPIMessage(string graphicAPI)
		{
			string operatingSystem = SystemInfo.operatingSystem;
			OperatingSystemFamily operatingSystemFamily = SystemInfo.operatingSystemFamily;
			bool flag = true;
			string text = null;
			switch (operatingSystemFamily)
			{
			case OperatingSystemFamily.MacOSX:
				text = "Mac";
				break;
			case OperatingSystemFamily.Windows:
				text = "Windows";
				break;
			case OperatingSystemFamily.Linux:
				text = "Linux";
				break;
			}
			string text2;
			if (flag)
			{
				text2 = string.Concat(new string[]
				{
					"Platform ",
					operatingSystem,
					" with graphics API ",
					graphicAPI,
					" is not supported with HDRP"
				});
			}
			else
			{
				text2 = "Platform " + operatingSystem + " is not supported with HDRP";
			}
			if (graphicAPI.StartsWith("OpenGL"))
			{
				if (SystemInfo.operatingSystem.StartsWith("Mac"))
				{
					text2 += ", use the Metal graphics API instead";
				}
				else if (SystemInfo.operatingSystem.StartsWith("Windows"))
				{
					text2 += ", use the Vulkan graphics API instead";
				}
			}
			text2 += ".\nChange the platform/device to a compatible one or remove incompatible graphics APIs.\n";
			if (text != null)
			{
				text2 = text2 + "To do this, go to Project Settings > Player > Other Settings and modify the Graphics APIs for " + text + " list.";
			}
			return text2;
		}

		// Token: 0x06000E21 RID: 3617 RVA: 0x000706A9 File Offset: 0x0006E8A9
		internal static int GetTextureHash(Texture texture)
		{
			return CoreUtils.GetTextureHash(texture);
		}

		// Token: 0x06000E22 RID: 3618 RVA: 0x000706B1 File Offset: 0x0006E8B1
		internal static void ReleaseComponentSingletons()
		{
			ComponentSingleton<HDAdditionalReflectionData>.Release();
			ComponentSingleton<HDAdditionalLightData>.Release();
			ComponentSingleton<HDAdditionalCameraData>.Release();
		}

		// Token: 0x06000E23 RID: 3619 RVA: 0x000706C4 File Offset: 0x0006E8C4
		internal static float InterpolateOrientation(float fromValue, float toValue, float t)
		{
			float num = Mathf.Abs(toValue - fromValue);
			float num3;
			if (fromValue < toValue)
			{
				if (360f - toValue + fromValue < num)
				{
					float num2 = toValue - 360f;
					num3 = fromValue + (num2 - fromValue) * t;
					if (num3 < 0f)
					{
						num3 += 360f;
					}
				}
				else
				{
					num3 = fromValue + (toValue - fromValue) * t;
				}
			}
			else if (360f - fromValue + toValue < num)
			{
				float num4 = toValue + 360f;
				num3 = fromValue + (num4 - fromValue) * t;
				if (num3 > 360f)
				{
					num3 -= 360f;
				}
			}
			else
			{
				num3 = fromValue + (toValue - fromValue) * t;
			}
			return num3;
		}

		// Token: 0x06000E24 RID: 3620 RVA: 0x0007075C File Offset: 0x0006E95C
		internal static void ConvertHDRColorToLDR(Color hdr, out Color ldr, out float intensity)
		{
			hdr.a = 1f;
			ldr = hdr;
			intensity = 1f;
			float maxColorComponent = hdr.maxColorComponent;
			if (maxColorComponent != 0f)
			{
				float num = 191f / maxColorComponent;
				ldr.r = Mathf.Min(191f, num * hdr.r) / 255f;
				ldr.g = Mathf.Min(191f, num * hdr.g) / 255f;
				ldr.b = Mathf.Min(191f, num * hdr.b) / 255f;
				intensity = 255f / num;
			}
		}

		// Token: 0x040015BC RID: 5564
		internal const SortingCriteria k_OpaqueSortingCriteria = SortingCriteria.SortingLayer | SortingCriteria.RenderQueue | SortingCriteria.OptimizeStateChanges | SortingCriteria.CanvasOrder;

		// Token: 0x040015BD RID: 5565
		private static List<CustomPassVolume> m_TempCustomPassVolumeList = new List<CustomPassVolume>();

		// Token: 0x040015BE RID: 5566
		private static Texture3D m_ClearTexture3D;

		// Token: 0x040015BF RID: 5567
		private static RTHandle m_ClearTexture3DRTH;

		// Token: 0x040015C0 RID: 5568
		private static Dictionary<GraphicsFormat, int> graphicsFormatSizeCache = new Dictionary<GraphicsFormat, int>
		{
			{
				GraphicsFormat.R8G8B8A8_UNorm,
				4
			},
			{
				GraphicsFormat.R16G16B16A16_SFloat,
				8
			},
			{
				GraphicsFormat.RGB_BC6H_SFloat,
				1
			}
		};

		// Token: 0x02000409 RID: 1033
		internal struct PackedMipChainInfo
		{
			// Token: 0x060013EA RID: 5098 RVA: 0x00096D81 File Offset: 0x00094F81
			public void Allocate()
			{
				this.mipLevelOffsets = new Vector2Int[15];
				this.mipLevelSizes = new Vector2Int[15];
				this.m_OffsetBufferWillNeedUpdate = true;
			}

			// Token: 0x060013EB RID: 5099 RVA: 0x00096DA4 File Offset: 0x00094FA4
			public void ComputePackedMipChainInfo(Vector2Int viewportSize)
			{
				bool flag = DynamicResolutionHandler.instance.HardwareDynamicResIsEnabled();
				Vector2Int vector2Int = flag ? DynamicResolutionHandler.instance.ApplyScalesOnSize(viewportSize) : viewportSize;
				Vector2 vector = flag ? new Vector2((float)viewportSize.x / (float)vector2Int.x, (float)viewportSize.y / (float)vector2Int.y) : new Vector2(1f, 1f);
				if (this.cachedHardwareTextureSize == vector2Int && this.cachedTextureScale == vector)
				{
					return;
				}
				this.cachedHardwareTextureSize = vector2Int;
				this.cachedTextureScale = vector;
				this.mipLevelSizes[0] = vector2Int;
				this.mipLevelOffsets[0] = Vector2Int.zero;
				int num = 0;
				Vector2Int vector2Int2 = vector2Int;
				do
				{
					num++;
					vector2Int2.x = Math.Max(1, vector2Int2.x + 1 >> 1);
					vector2Int2.y = Math.Max(1, vector2Int2.y + 1 >> 1);
					this.mipLevelSizes[num] = vector2Int2;
					Vector2Int a = this.mipLevelOffsets[num - 1];
					Vector2Int vector2Int3 = a + this.mipLevelSizes[num - 1];
					Vector2Int vector2Int4 = default(Vector2Int);
					if ((num & 1) != 0)
					{
						vector2Int4.x = a.x;
						vector2Int4.y = vector2Int3.y;
					}
					else
					{
						vector2Int4.x = vector2Int3.x;
						vector2Int4.y = a.y;
					}
					this.mipLevelOffsets[num] = vector2Int4;
					vector2Int.x = Math.Max(vector2Int.x, vector2Int4.x + vector2Int2.x);
					vector2Int.y = Math.Max(vector2Int.y, vector2Int4.y + vector2Int2.y);
				}
				while (vector2Int2.x > 1 || vector2Int2.y > 1);
				this.textureSize = new Vector2Int((int)Mathf.Ceil((float)vector2Int.x * vector.x), (int)Mathf.Ceil((float)vector2Int.y * vector.y));
				this.mipLevelCount = num + 1;
				this.m_OffsetBufferWillNeedUpdate = true;
			}

			// Token: 0x060013EC RID: 5100 RVA: 0x00096FB5 File Offset: 0x000951B5
			public ComputeBuffer GetOffsetBufferData(ComputeBuffer mipLevelOffsetsBuffer)
			{
				if (this.m_OffsetBufferWillNeedUpdate)
				{
					mipLevelOffsetsBuffer.SetData(this.mipLevelOffsets);
					this.m_OffsetBufferWillNeedUpdate = false;
				}
				return mipLevelOffsetsBuffer;
			}

			// Token: 0x040028CA RID: 10442
			public Vector2Int textureSize;

			// Token: 0x040028CB RID: 10443
			public int mipLevelCount;

			// Token: 0x040028CC RID: 10444
			public Vector2Int[] mipLevelSizes;

			// Token: 0x040028CD RID: 10445
			public Vector2Int[] mipLevelOffsets;

			// Token: 0x040028CE RID: 10446
			private Vector2 cachedTextureScale;

			// Token: 0x040028CF RID: 10447
			private Vector2Int cachedHardwareTextureSize;

			// Token: 0x040028D0 RID: 10448
			private bool m_OffsetBufferWillNeedUpdate;
		}
	}
}
