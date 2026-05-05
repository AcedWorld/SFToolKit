using System;
using UnityEngine.Serialization;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x02000139 RID: 313
	[VolumeComponentMenuForRenderPipeline("Post-processing/Motion Blur", new Type[]
	{
		typeof(HDRenderPipeline)
	})]
	[Serializable]
	public sealed class MotionBlur : VolumeComponentWithQuality, IPostProcessComponent
	{
		// Token: 0x1700018A RID: 394
		// (get) Token: 0x06000ABC RID: 2748 RVA: 0x0005A51C File Offset: 0x0005871C
		// (set) Token: 0x06000ABD RID: 2749 RVA: 0x0005A55A File Offset: 0x0005875A
		public int sampleCount
		{
			get
			{
				if (!base.UsesQualitySettings())
				{
					return this.m_SampleCount.value;
				}
				int item = this.quality.levelAndOverride.Item1;
				return VolumeComponentWithQuality.GetPostProcessingQualitySettings().MotionBlurSampleCount[item];
			}
			set
			{
				this.m_SampleCount.value = value;
			}
		}

		// Token: 0x06000ABE RID: 2750 RVA: 0x0005A568 File Offset: 0x00058768
		public bool IsActive()
		{
			return this.intensity.value > 0f;
		}

		// Token: 0x04000BB7 RID: 2999
		[Tooltip("Sets the intensity of the motion blur effect. Acts as a multiplier for velocities.")]
		public MinFloatParameter intensity = new MinFloatParameter(0f, 0f, false);

		// Token: 0x04000BB8 RID: 3000
		[Tooltip("Controls the maximum velocity, in pixels, that HDRP allows for all sources of motion blur except Camera rotation.")]
		public ClampedFloatParameter maximumVelocity = new ClampedFloatParameter(200f, 0f, 1500f, false);

		// Token: 0x04000BB9 RID: 3001
		[Tooltip("Controls the minimum velocity, in pixels, that a GameObject must have to contribute to the motion blur effect.")]
		public ClampedFloatParameter minimumVelocity = new ClampedFloatParameter(2f, 0f, 64f, false);

		// Token: 0x04000BBA RID: 3002
		[Header("Camera Velocity")]
		[AdditionalProperty]
		[Tooltip("If toggled off, the motion caused by the camera is not considered when doing motion blur.")]
		public BoolParameter cameraMotionBlur = new BoolParameter(true, false);

		// Token: 0x04000BBB RID: 3003
		[AdditionalProperty]
		[Tooltip("Determine if and how the component of the motion vectors coming from the camera is clamped in a special fashion.")]
		public CameraClampModeParameter specialCameraClampMode = new CameraClampModeParameter(CameraClampMode.None, false);

		// Token: 0x04000BBC RID: 3004
		[AdditionalProperty]
		[Tooltip("Sets the maximum length, as a fraction of the screen's full resolution, that the motion vectors resulting from Camera can have.")]
		public ClampedFloatParameter cameraVelocityClamp = new ClampedFloatParameter(0.05f, 0f, 0.3f, false);

		// Token: 0x04000BBD RID: 3005
		[AdditionalProperty]
		[Tooltip("Sets the maximum length, as a fraction of the screen's full resolution, that the motion vectors resulting from Camera can have.")]
		public ClampedFloatParameter cameraTranslationVelocityClamp = new ClampedFloatParameter(0.05f, 0f, 0.3f, false);

		// Token: 0x04000BBE RID: 3006
		[AdditionalProperty]
		[Tooltip("Sets the maximum length, as a fraction of the screen's full resolution, that the motion vectors resulting from Camera rotation can have.")]
		public ClampedFloatParameter cameraRotationVelocityClamp = new ClampedFloatParameter(0.03f, 0f, 0.3f, false);

		// Token: 0x04000BBF RID: 3007
		[AdditionalProperty]
		[Tooltip("Value used for the depth based weighting of samples. Tweak if unwanted leak of background onto foreground or viceversa is detected.")]
		public ClampedFloatParameter depthComparisonExtent = new ClampedFloatParameter(1f, 0f, 20f, false);

		// Token: 0x04000BC0 RID: 3008
		[Tooltip("Sets the maximum number of sample points that HDRP uses to compute motion blur.")]
		[SerializeField]
		[FormerlySerializedAs("sampleCount")]
		private MinIntParameter m_SampleCount = new MinIntParameter(8, 2, false);
	}
}
