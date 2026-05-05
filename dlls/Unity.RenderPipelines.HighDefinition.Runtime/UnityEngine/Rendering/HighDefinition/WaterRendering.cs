using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x02000220 RID: 544
	[VolumeComponentMenuForRenderPipeline("Lighting/WaterRendering", new Type[]
	{
		typeof(HDRenderPipeline)
	})]
	[Serializable]
	public sealed class WaterRendering : VolumeComponent
	{
		// Token: 0x06000FD1 RID: 4049 RVA: 0x0007A7AC File Offset: 0x000789AC
		private WaterRendering()
		{
			base.displayName = "Water Rendering";
		}

		// Token: 0x0400187B RID: 6267
		[Tooltip("When enabled, the water surfaces are rendered.")]
		public BoolParameter enable = new BoolParameter(false, BoolParameter.DisplayType.EnumPopup, false);

		// Token: 0x0400187C RID: 6268
		[Tooltip("Sets the size of the minimum water grids in meters.")]
		public MinFloatParameter minGridSize = new MinFloatParameter(50f, 50f, false);

		// Token: 0x0400187D RID: 6269
		[Tooltip("Sets the size of the maximum water grids in meters.")]
		public MinFloatParameter maxGridSize = new MinFloatParameter(2500f, 250f, false);

		// Token: 0x0400187E RID: 6270
		[Tooltip("Sets the elevation at which the max grid size is reached.")]
		public MinFloatParameter elevationTransition = new MinFloatParameter(1000f, 20f, false);

		// Token: 0x0400187F RID: 6271
		[Tooltip("Controls the number of LOD patches that are rendered.")]
		public ClampedIntParameter numLevelOfDetails = new ClampedIntParameter(3, 1, 4, false);

		// Token: 0x04001880 RID: 6272
		[Tooltip("Sets the maximum tessellation factor for the water surface.")]
		[AdditionalProperty]
		public ClampedFloatParameter maxTessellationFactor = new ClampedFloatParameter(10f, 0f, 15f, false);

		// Token: 0x04001881 RID: 6273
		[Tooltip(" Sets the distance at which the tessellation factor start to lower.")]
		[AdditionalProperty]
		public MinFloatParameter tessellationFactorFadeStart = new MinFloatParameter(150f, 0f, false);

		// Token: 0x04001882 RID: 6274
		[Tooltip("Sets the range at which the tessellation factor reaches zero.")]
		[AdditionalProperty]
		public MinFloatParameter tessellationFactorFadeRange = new MinFloatParameter(1850f, 10f, false);

		// Token: 0x04001883 RID: 6275
		[Tooltip("Controls the influence of the ambient light probe on the water surfaces.")]
		public ClampedFloatParameter ambientProbeDimmer = new ClampedFloatParameter(1f, 0f, 1f, false);

		// Token: 0x0200044E RID: 1102
		public enum WaterGridResolution
		{
			// Token: 0x040029C3 RID: 10691
			VeryLow128 = 128,
			// Token: 0x040029C4 RID: 10692
			Low256 = 256,
			// Token: 0x040029C5 RID: 10693
			Medium512 = 512,
			// Token: 0x040029C6 RID: 10694
			High1024 = 1024,
			// Token: 0x040029C7 RID: 10695
			Ultra2048 = 2048
		}

		// Token: 0x0200044F RID: 1103
		[Serializable]
		public sealed class WaterGridResolutionParameter : VolumeParameter<WaterRendering.WaterGridResolution>
		{
			// Token: 0x06001456 RID: 5206 RVA: 0x00099F07 File Offset: 0x00098107
			public WaterGridResolutionParameter(WaterRendering.WaterGridResolution value, bool overrideState = false) : base(value, overrideState)
			{
			}
		}
	}
}
