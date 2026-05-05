using System;
using System.Collections.Generic;
using UnityEngine.Experimental.Rendering;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x02000209 RID: 521
	public static class HDRenderUtilities
	{
		// Token: 0x06000F7B RID: 3963 RVA: 0x0007886C File Offset: 0x00076A6C
		public static void Render(CameraSettings settings, CameraPositionSettings position, Texture target, uint staticFlags = 0U)
		{
			if (target == null)
			{
				throw new ArgumentNullException("target");
			}
			RenderTexture renderTexture = target as RenderTexture;
			Cubemap cubemap = target as Cubemap;
			TextureDimension dimension = target.dimension;
			if (dimension != TextureDimension.Tex2D)
			{
				if (dimension != TextureDimension.Cube)
				{
					throw new ArgumentException("Rendering into a target of dimension " + string.Format("{0} is not supported", target.dimension));
				}
			}
			else if (renderTexture == null)
			{
				throw new ArgumentException("'target' must be a RenderTexture when rendering into a 2D texture");
			}
			Camera camera = HDRenderUtilities.NewRenderingCamera();
			try
			{
				camera.ApplySettings(settings);
				camera.ApplySettings(position);
				dimension = target.dimension;
				if (dimension != TextureDimension.Tex2D)
				{
					if (dimension == TextureDimension.Cube)
					{
						bool flag = false;
						if (!flag || staticFlags == 0U)
						{
							if (!flag && staticFlags != 0U)
							{
								Debug.LogWarning("A static flags bitmask was provided but this is ignored in player builds");
							}
							if (renderTexture != null)
							{
								camera.RenderToCubemap(renderTexture);
							}
							if (cubemap != null)
							{
								camera.RenderToCubemap(cubemap);
							}
						}
						target.IncrementUpdateCount();
					}
				}
				else
				{
					camera.targetTexture = renderTexture;
					camera.Render();
					camera.targetTexture = null;
					target.IncrementUpdateCount();
				}
			}
			finally
			{
				CoreUtils.Destroy(camera.gameObject);
			}
		}

		// Token: 0x06000F7C RID: 3964 RVA: 0x00078988 File Offset: 0x00076B88
		public static void Render(ProbeSettings settings, ProbeCapturePositionSettings position, Texture target, bool forceFlipY = false, bool forceInvertBackfaceCulling = false, uint staticFlags = 0U, float referenceFieldOfView = 90f, float referenceAspect = 1f)
		{
			CameraSettings cameraSettings;
			CameraPositionSettings cameraPositionSettings;
			HDRenderUtilities.Render(settings, position, target, out cameraSettings, out cameraPositionSettings, forceFlipY, forceInvertBackfaceCulling, staticFlags, referenceFieldOfView, referenceAspect);
		}

		// Token: 0x06000F7D RID: 3965 RVA: 0x000789AC File Offset: 0x00076BAC
		public static void GenerateRenderingSettingsFor(ProbeSettings settings, ProbeCapturePositionSettings position, List<CameraSettings> cameras, List<CameraPositionSettings> cameraPositions, List<CubemapFace> cameraCubeFaces, ulong overrideSceneCullingMask, ProbeRenderSteps renderSteps, bool forceFlipY = false, float referenceFieldOfView = 90f, float referenceAspect = 1f)
		{
			CameraSettings item;
			CameraPositionSettings cameraPositionSettings;
			HDRenderUtilities.ComputeCameraSettingsFromProbeSettings(settings, position, out item, out cameraPositionSettings, overrideSceneCullingMask, referenceFieldOfView, referenceAspect);
			if (forceFlipY)
			{
				item.flipYMode = HDAdditionalCameraData.FlipYMode.ForceFlipY;
			}
			ProbeSettings.ProbeType type = settings.type;
			if (type != ProbeSettings.ProbeType.ReflectionProbe)
			{
				if (type == ProbeSettings.ProbeType.PlanarProbe)
				{
					cameras.Add(item);
					cameraPositions.Add(cameraPositionSettings);
					cameraCubeFaces.Add(CubemapFace.Unknown);
					return;
				}
			}
			else
			{
				for (int i = 0; i < 6; i++)
				{
					CubemapFace cubemapFace = (CubemapFace)i;
					if (renderSteps.HasCubeFace(cubemapFace))
					{
						CameraPositionSettings cameraPositionSettings2 = cameraPositionSettings;
						cameraPositionSettings2.rotation *= Quaternion.Euler(HDRenderUtilities.s_GenerateRenderingSettingsFor_Rotations[i]);
						cameras.Add(item);
						cameraPositions.Add(cameraPositionSettings2);
						cameraCubeFaces.Add(cubemapFace);
					}
				}
			}
		}

		// Token: 0x06000F7E RID: 3966 RVA: 0x00078A53 File Offset: 0x00076C53
		public static void ComputeCameraSettingsFromProbeSettings(ProbeSettings settings, ProbeCapturePositionSettings position, out CameraSettings cameraSettings, out CameraPositionSettings cameraPositionSettings, ulong overrideSceneCullingMask, float referenceFieldOfView = 90f, float referenceAspect = 1f)
		{
			cameraSettings = settings.cameraSettings;
			cameraPositionSettings = CameraPositionSettings.NewDefault();
			ProbeSettingsUtilities.ApplySettings(ref settings, ref position, ref cameraSettings, ref cameraPositionSettings, referenceFieldOfView, referenceAspect);
			cameraSettings.culling.sceneCullingMaskOverride = overrideSceneCullingMask;
		}

		// Token: 0x06000F7F RID: 3967 RVA: 0x00078A88 File Offset: 0x00076C88
		public static void Render(ProbeSettings settings, ProbeCapturePositionSettings position, Texture target, out CameraSettings cameraSettings, out CameraPositionSettings cameraPositionSettings, bool forceFlipY = false, bool forceInvertBackfaceCulling = false, uint staticFlags = 0U, float referenceFieldOfView = 90f, float referenceAspect = 1f)
		{
			HDRenderUtilities.ComputeCameraSettingsFromProbeSettings(settings, position, out cameraSettings, out cameraPositionSettings, 0UL, referenceFieldOfView, referenceAspect);
			if (forceFlipY)
			{
				cameraSettings.flipYMode = HDAdditionalCameraData.FlipYMode.ForceFlipY;
			}
			if (forceInvertBackfaceCulling)
			{
				cameraSettings.invertFaceCulling = true;
			}
			HDRenderUtilities.Render(cameraSettings, cameraPositionSettings, target, staticFlags);
		}

		// Token: 0x06000F80 RID: 3968 RVA: 0x00078AC5 File Offset: 0x00076CC5
		[Obsolete("Use CreateReflectionProbeRenderTarget with explicit format instead", true)]
		public static RenderTexture CreateReflectionProbeRenderTarget(int cubemapSize)
		{
			RenderTexture renderTexture = new RenderTexture(cubemapSize, cubemapSize, 1, GraphicsFormat.R16G16B16A16_SFloat);
			renderTexture.dimension = TextureDimension.Cube;
			renderTexture.enableRandomWrite = true;
			renderTexture.useMipMap = true;
			renderTexture.autoGenerateMips = false;
			renderTexture.Create();
			return renderTexture;
		}

		// Token: 0x06000F81 RID: 3969 RVA: 0x00078AF4 File Offset: 0x00076CF4
		public static RenderTexture CreateReflectionProbeRenderTarget(int cubemapSize, GraphicsFormat format)
		{
			RenderTexture renderTexture = new RenderTexture(cubemapSize, cubemapSize, 1, format);
			renderTexture.dimension = TextureDimension.Cube;
			renderTexture.enableRandomWrite = true;
			renderTexture.useMipMap = true;
			renderTexture.autoGenerateMips = false;
			renderTexture.depth = 0;
			renderTexture.Create();
			return renderTexture;
		}

		// Token: 0x06000F82 RID: 3970 RVA: 0x00078B29 File Offset: 0x00076D29
		public static RenderTexture CreatePlanarProbeRenderTarget(int planarSize, GraphicsFormat format)
		{
			RenderTexture renderTexture = new RenderTexture(planarSize, planarSize, 1, format);
			renderTexture.dimension = TextureDimension.Tex2D;
			renderTexture.enableRandomWrite = true;
			renderTexture.useMipMap = true;
			renderTexture.autoGenerateMips = false;
			renderTexture.depth = 0;
			renderTexture.Create();
			return renderTexture;
		}

		// Token: 0x06000F83 RID: 3971 RVA: 0x00078B5E File Offset: 0x00076D5E
		public static RenderTexture CreatePlanarProbeDepthRenderTarget(int planarSize)
		{
			RenderTexture renderTexture = new RenderTexture(planarSize, planarSize, 1, GraphicsFormat.R32_SFloat);
			renderTexture.dimension = TextureDimension.Tex2D;
			renderTexture.enableRandomWrite = true;
			renderTexture.useMipMap = true;
			renderTexture.autoGenerateMips = false;
			renderTexture.Create();
			return renderTexture;
		}

		// Token: 0x06000F84 RID: 3972 RVA: 0x00078B8D File Offset: 0x00076D8D
		public static Cubemap CreateReflectionProbeTarget(int cubemapSize)
		{
			return new Cubemap(cubemapSize, GraphicsFormat.R16G16B16A16_SFloat, TextureCreationFlags.None);
		}

		// Token: 0x06000F85 RID: 3973 RVA: 0x00078B98 File Offset: 0x00076D98
		private static Camera NewRenderingCamera()
		{
			GameObject gameObject = new GameObject("__Render Camera");
			Camera camera = gameObject.AddComponent<Camera>();
			camera.cameraType = CameraType.Reflection;
			gameObject.AddComponent<HDAdditionalCameraData>();
			return camera;
		}

		// Token: 0x06000F86 RID: 3974 RVA: 0x00078BC8 File Offset: 0x00076DC8
		private static void FixSettings(Texture target, ref ProbeSettings settings, ref ProbeCapturePositionSettings position, ref CameraSettings cameraSettings, ref CameraPositionSettings cameraPositionSettings)
		{
			RenderTexture renderTexture;
			if ((renderTexture = (target as RenderTexture)) != null && renderTexture.dimension == TextureDimension.Cube && settings.type == ProbeSettings.ProbeType.ReflectionProbe && SystemInfo.graphicsUVStartsAtTop)
			{
				cameraSettings.flipYMode = HDAdditionalCameraData.FlipYMode.ForceFlipY;
			}
		}

		// Token: 0x04001808 RID: 6152
		private static readonly Vector3[] s_GenerateRenderingSettingsFor_Rotations = new Vector3[]
		{
			new Vector3(0f, 90f, 0f),
			new Vector3(0f, 270f, 0f),
			new Vector3(270f, 0f, 0f),
			new Vector3(90f, 0f, 0f),
			new Vector3(0f, 0f, 0f),
			new Vector3(0f, 180f, 0f)
		};
	}
}
