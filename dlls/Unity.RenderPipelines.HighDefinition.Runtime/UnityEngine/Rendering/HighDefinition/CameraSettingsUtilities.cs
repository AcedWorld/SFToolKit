using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x02000204 RID: 516
	public static class CameraSettingsUtilities
	{
		// Token: 0x06000F6D RID: 3949 RVA: 0x0007849C File Offset: 0x0007669C
		public unsafe static void ApplySettings(this Camera cam, CameraSettings settings)
		{
			HDAdditionalCameraData hdadditionalCameraData = cam.GetComponent<HDAdditionalCameraData>() ?? cam.gameObject.AddComponent<HDAdditionalCameraData>();
			hdadditionalCameraData.defaultFrameSettings = settings.defaultFrameSettings;
			*hdadditionalCameraData.renderingPathCustomFrameSettings = settings.renderingPathCustomFrameSettings;
			hdadditionalCameraData.renderingPathCustomFrameSettingsOverrideMask = settings.renderingPathCustomFrameSettingsOverrideMask;
			cam.nearClipPlane = settings.frustum.nearClipPlane;
			cam.farClipPlane = settings.frustum.farClipPlane;
			cam.fieldOfView = settings.frustum.fieldOfView;
			cam.aspect = settings.frustum.aspect;
			cam.projectionMatrix = settings.frustum.GetUsedProjectionMatrix();
			cam.useOcclusionCulling = settings.culling.useOcclusionCulling;
			cam.cullingMask = settings.culling.cullingMask;
			cam.overrideSceneCullingMask = settings.culling.sceneCullingMaskOverride;
			hdadditionalCameraData.clearColorMode = settings.bufferClearing.clearColorMode;
			hdadditionalCameraData.backgroundColorHDR = settings.bufferClearing.backgroundColorHDR;
			hdadditionalCameraData.clearDepth = settings.bufferClearing.clearDepth;
			hdadditionalCameraData.volumeLayerMask = settings.volumes.layerMask;
			hdadditionalCameraData.volumeAnchorOverride = settings.volumes.anchorOverride;
			hdadditionalCameraData.customRenderingSettings = settings.customRenderingSettings;
			hdadditionalCameraData.flipYMode = settings.flipYMode;
			hdadditionalCameraData.invertFaceCulling = settings.invertFaceCulling;
			hdadditionalCameraData.probeCustomFixedExposure = settings.probeRangeCompressionFactor;
		}

		// Token: 0x06000F6E RID: 3950 RVA: 0x000785FB File Offset: 0x000767FB
		public static void ApplySettings(this Camera cam, CameraPositionSettings settings)
		{
			cam.transform.position = settings.position;
			cam.transform.rotation = settings.rotation;
			cam.worldToCameraMatrix = settings.GetUsedWorldToCameraMatrix();
		}
	}
}
