using System;
using UnityEngine.Serialization;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x02000203 RID: 515
	[Serializable]
	public struct CameraSettings
	{
		// Token: 0x06000F69 RID: 3945 RVA: 0x000780A8 File Offset: 0x000762A8
		public static CameraSettings NewDefault()
		{
			return new CameraSettings
			{
				bufferClearing = CameraSettings.BufferClearing.NewDefault(),
				culling = CameraSettings.Culling.NewDefault(),
				renderingPathCustomFrameSettings = FrameSettings.NewDefaultCamera(),
				frustum = CameraSettings.Frustum.NewDefault(),
				customRenderingSettings = false,
				volumes = CameraSettings.Volumes.NewDefault(),
				flipYMode = HDAdditionalCameraData.FlipYMode.Automatic,
				invertFaceCulling = false,
				probeLayerMask = -1,
				probeRangeCompressionFactor = 1f
			};
		}

		// Token: 0x06000F6A RID: 3946 RVA: 0x0007812C File Offset: 0x0007632C
		public unsafe static CameraSettings From(HDCamera hdCamera)
		{
			CameraSettings result = CameraSettings.defaultCameraSettingsNonAlloc;
			result.culling.cullingMask = hdCamera.camera.cullingMask;
			result.culling.useOcclusionCulling = hdCamera.camera.useOcclusionCulling;
			result.culling.sceneCullingMaskOverride = HDUtils.GetSceneCullingMaskFromCamera(hdCamera.camera);
			result.frustum.aspect = hdCamera.camera.aspect;
			result.frustum.farClipPlaneRaw = hdCamera.camera.farClipPlane;
			result.frustum.nearClipPlaneRaw = hdCamera.camera.nearClipPlane;
			result.frustum.fieldOfView = hdCamera.camera.fieldOfView;
			result.frustum.mode = CameraSettings.Frustum.Mode.UseProjectionMatrixField;
			result.frustum.projectionMatrix = hdCamera.camera.projectionMatrix;
			result.invertFaceCulling = false;
			HDAdditionalCameraData hdadditionalCameraData;
			if (hdCamera.camera.TryGetComponent<HDAdditionalCameraData>(out hdadditionalCameraData))
			{
				result.customRenderingSettings = hdadditionalCameraData.customRenderingSettings;
				result.bufferClearing.backgroundColorHDR = hdadditionalCameraData.backgroundColorHDR;
				result.bufferClearing.clearColorMode = hdadditionalCameraData.clearColorMode;
				result.bufferClearing.clearDepth = hdadditionalCameraData.clearDepth;
				result.flipYMode = hdadditionalCameraData.flipYMode;
				result.renderingPathCustomFrameSettings = *hdadditionalCameraData.renderingPathCustomFrameSettings;
				result.renderingPathCustomFrameSettingsOverrideMask = hdadditionalCameraData.renderingPathCustomFrameSettingsOverrideMask;
				result.volumes = new CameraSettings.Volumes
				{
					anchorOverride = hdadditionalCameraData.volumeAnchorOverride,
					layerMask = hdadditionalCameraData.volumeLayerMask
				};
				result.probeLayerMask = hdadditionalCameraData.probeLayerMask;
				result.invertFaceCulling = hdadditionalCameraData.invertFaceCulling;
			}
			bool flag = hdCamera.camera.worldToCameraMatrix.determinant > 0f;
			bool flag2 = Mathf.Approximately(hdCamera.camera.projectionMatrix.m32, -1f);
			bool flag3 = Mathf.Approximately(hdCamera.camera.projectionMatrix.m00, 1f) && Mathf.Approximately(hdCamera.camera.projectionMatrix.m11, 1f);
			if (flag && flag2 && flag3)
			{
				result.invertFaceCulling = true;
			}
			return result;
		}

		// Token: 0x06000F6B RID: 3947 RVA: 0x00078358 File Offset: 0x00076558
		internal Hash128 GetHash()
		{
			Hash128 result = default(Hash128);
			Hash128 hash = default(Hash128);
			HashUtilities.ComputeHash128<CameraSettings.BufferClearing>(ref this.bufferClearing, ref result);
			HashUtilities.ComputeHash128<CameraSettings.Culling>(ref this.culling, ref hash);
			HashUtilities.AppendHash(ref hash, ref result);
			HashUtilities.ComputeHash128<bool>(ref this.customRenderingSettings, ref hash);
			HashUtilities.AppendHash(ref hash, ref result);
			HashUtilities.ComputeHash128<FrameSettingsRenderType>(ref this.defaultFrameSettings, ref hash);
			HashUtilities.AppendHash(ref hash, ref result);
			HashUtilities.ComputeHash128<HDAdditionalCameraData.FlipYMode>(ref this.flipYMode, ref hash);
			HashUtilities.AppendHash(ref hash, ref result);
			HashUtilities.ComputeHash128<CameraSettings.Frustum>(ref this.frustum, ref hash);
			HashUtilities.AppendHash(ref hash, ref result);
			HashUtilities.ComputeHash128<bool>(ref this.invertFaceCulling, ref hash);
			HashUtilities.AppendHash(ref hash, ref result);
			HashUtilities.ComputeHash128<LayerMask>(ref this.probeLayerMask, ref hash);
			HashUtilities.AppendHash(ref hash, ref result);
			HashUtilities.ComputeHash128<float>(ref this.probeRangeCompressionFactor, ref hash);
			HashUtilities.AppendHash(ref hash, ref result);
			HashUtilities.ComputeHash128<FrameSettings>(ref this.renderingPathCustomFrameSettings, ref hash);
			HashUtilities.AppendHash(ref hash, ref result);
			HashUtilities.ComputeHash128<FrameSettingsOverrideMask>(ref this.renderingPathCustomFrameSettingsOverrideMask, ref hash);
			HashUtilities.AppendHash(ref hash, ref result);
			int hashCode = this.volumes.GetHashCode();
			hash = new Hash128((ulong)((long)hashCode), 0UL);
			HashUtilities.AppendHash(ref hash, ref result);
			return result;
		}

		// Token: 0x040017F6 RID: 6134
		[Obsolete("Since 2019.3, use CameraSettings.defaultCameraSettingsNonAlloc instead.")]
		public static readonly CameraSettings @default = default(CameraSettings);

		// Token: 0x040017F7 RID: 6135
		public static readonly CameraSettings defaultCameraSettingsNonAlloc = CameraSettings.NewDefault();

		// Token: 0x040017F8 RID: 6136
		public bool customRenderingSettings;

		// Token: 0x040017F9 RID: 6137
		public FrameSettings renderingPathCustomFrameSettings;

		// Token: 0x040017FA RID: 6138
		public FrameSettingsOverrideMask renderingPathCustomFrameSettingsOverrideMask;

		// Token: 0x040017FB RID: 6139
		public CameraSettings.BufferClearing bufferClearing;

		// Token: 0x040017FC RID: 6140
		public CameraSettings.Volumes volumes;

		// Token: 0x040017FD RID: 6141
		public CameraSettings.Frustum frustum;

		// Token: 0x040017FE RID: 6142
		public CameraSettings.Culling culling;

		// Token: 0x040017FF RID: 6143
		public bool invertFaceCulling;

		// Token: 0x04001800 RID: 6144
		public HDAdditionalCameraData.FlipYMode flipYMode;

		// Token: 0x04001801 RID: 6145
		public LayerMask probeLayerMask;

		// Token: 0x04001802 RID: 6146
		public FrameSettingsRenderType defaultFrameSettings;

		// Token: 0x04001803 RID: 6147
		internal float probeRangeCompressionFactor;

		// Token: 0x04001804 RID: 6148
		[SerializeField]
		[FormerlySerializedAs("renderingPath")]
		[Obsolete("For data migration")]
		internal int m_ObsoleteRenderingPath;

		// Token: 0x04001805 RID: 6149
		[SerializeField]
		[FormerlySerializedAs("frameSettings")]
		[Obsolete("For data migration")]
		internal ObsoleteFrameSettings m_ObsoleteFrameSettings;

		// Token: 0x0200043A RID: 1082
		[Serializable]
		public struct BufferClearing
		{
			// Token: 0x0600143A RID: 5178 RVA: 0x000992E4 File Offset: 0x000974E4
			public static CameraSettings.BufferClearing NewDefault()
			{
				return new CameraSettings.BufferClearing
				{
					clearColorMode = HDAdditionalCameraData.ClearColorMode.Sky,
					backgroundColorHDR = new Color32(6, 18, 48, 0),
					clearDepth = true
				};
			}

			// Token: 0x0400296A RID: 10602
			[Obsolete("Since 2019.3, use BufferClearing.NewDefault() instead.")]
			public static readonly CameraSettings.BufferClearing @default;

			// Token: 0x0400296B RID: 10603
			public HDAdditionalCameraData.ClearColorMode clearColorMode;

			// Token: 0x0400296C RID: 10604
			[ColorUsage(true, true)]
			public Color backgroundColorHDR;

			// Token: 0x0400296D RID: 10605
			public bool clearDepth;
		}

		// Token: 0x0200043B RID: 1083
		[Serializable]
		public struct Volumes
		{
			// Token: 0x0600143C RID: 5180 RVA: 0x00099324 File Offset: 0x00097524
			public static CameraSettings.Volumes NewDefault()
			{
				return new CameraSettings.Volumes
				{
					layerMask = -1,
					anchorOverride = null
				};
			}

			// Token: 0x0400296E RID: 10606
			[Obsolete("Since 2019.3, use Volumes.NewDefault() instead.")]
			public static readonly CameraSettings.Volumes @default;

			// Token: 0x0400296F RID: 10607
			public LayerMask layerMask;

			// Token: 0x04002970 RID: 10608
			public Transform anchorOverride;
		}

		// Token: 0x0200043C RID: 1084
		[Serializable]
		public struct Frustum
		{
			// Token: 0x0600143E RID: 5182 RVA: 0x00099354 File Offset: 0x00097554
			public static CameraSettings.Frustum NewDefault()
			{
				return new CameraSettings.Frustum
				{
					mode = CameraSettings.Frustum.Mode.ComputeProjectionMatrix,
					aspect = 1f,
					farClipPlaneRaw = 1000f,
					nearClipPlaneRaw = 0.1f,
					fieldOfView = 90f,
					projectionMatrix = Matrix4x4.identity
				};
			}

			// Token: 0x170002A2 RID: 674
			// (get) Token: 0x0600143F RID: 5183 RVA: 0x000993AE File Offset: 0x000975AE
			public float farClipPlane
			{
				get
				{
					return Mathf.Max(this.nearClipPlaneRaw + 0.0001f, this.farClipPlaneRaw);
				}
			}

			// Token: 0x170002A3 RID: 675
			// (get) Token: 0x06001440 RID: 5184 RVA: 0x000993C7 File Offset: 0x000975C7
			public float nearClipPlane
			{
				get
				{
					return Mathf.Max(1E-05f, this.nearClipPlaneRaw);
				}
			}

			// Token: 0x06001441 RID: 5185 RVA: 0x000993D9 File Offset: 0x000975D9
			public Matrix4x4 ComputeProjectionMatrix()
			{
				return Matrix4x4.Perspective(HDUtils.ClampFOV(this.fieldOfView), this.aspect, this.nearClipPlane, this.farClipPlane);
			}

			// Token: 0x06001442 RID: 5186 RVA: 0x00099400 File Offset: 0x00097600
			public Matrix4x4 GetUsedProjectionMatrix()
			{
				CameraSettings.Frustum.Mode mode = this.mode;
				if (mode == CameraSettings.Frustum.Mode.ComputeProjectionMatrix)
				{
					return this.ComputeProjectionMatrix();
				}
				if (mode != CameraSettings.Frustum.Mode.UseProjectionMatrixField)
				{
					throw new ArgumentException();
				}
				return this.projectionMatrix;
			}

			// Token: 0x04002971 RID: 10609
			public const float MinNearClipPlane = 1E-05f;

			// Token: 0x04002972 RID: 10610
			public const float MinFarClipPlane = 0.0001f;

			// Token: 0x04002973 RID: 10611
			[Obsolete("Since 2019.3, use Frustum.NewDefault() instead.")]
			public static readonly CameraSettings.Frustum @default;

			// Token: 0x04002974 RID: 10612
			public CameraSettings.Frustum.Mode mode;

			// Token: 0x04002975 RID: 10613
			public float aspect;

			// Token: 0x04002976 RID: 10614
			[FormerlySerializedAs("farClipPlane")]
			public float farClipPlaneRaw;

			// Token: 0x04002977 RID: 10615
			[FormerlySerializedAs("nearClipPlane")]
			public float nearClipPlaneRaw;

			// Token: 0x04002978 RID: 10616
			[Range(1f, 179f)]
			public float fieldOfView;

			// Token: 0x04002979 RID: 10617
			public Matrix4x4 projectionMatrix;

			// Token: 0x0200047E RID: 1150
			public enum Mode
			{
				// Token: 0x04002A1F RID: 10783
				ComputeProjectionMatrix,
				// Token: 0x04002A20 RID: 10784
				UseProjectionMatrixField
			}
		}

		// Token: 0x0200043D RID: 1085
		[Serializable]
		public struct Culling
		{
			// Token: 0x06001444 RID: 5188 RVA: 0x00099434 File Offset: 0x00097634
			public static CameraSettings.Culling NewDefault()
			{
				return new CameraSettings.Culling
				{
					cullingMask = -1,
					useOcclusionCulling = true,
					sceneCullingMaskOverride = 0UL
				};
			}

			// Token: 0x0400297A RID: 10618
			[Obsolete("Since 2019.3, use Culling.NewDefault() instead.")]
			public static readonly CameraSettings.Culling @default;

			// Token: 0x0400297B RID: 10619
			public bool useOcclusionCulling;

			// Token: 0x0400297C RID: 10620
			public LayerMask cullingMask;

			// Token: 0x0400297D RID: 10621
			public ulong sceneCullingMaskOverride;
		}
	}
}
