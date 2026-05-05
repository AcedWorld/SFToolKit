using System;
using System.Diagnostics;
using UnityEngine.Serialization;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x0200006A RID: 106
	[VolumeComponentMenuForRenderPipeline("Lighting/Indirect Lighting Controller", new Type[]
	{
		typeof(HDRenderPipeline)
	})]
	[Serializable]
	public class IndirectLightingController : VolumeComponent
	{
		// Token: 0x0600058B RID: 1419 RVA: 0x0003FEDC File Offset: 0x0003E0DC
		public uint GetReflectionLightingLayers()
		{
			int value = (int)this.reflectionLightingLayers.GetValue<LightLayerEnum>();
			if (value >= 0)
			{
				return (uint)value;
			}
			return 255U;
		}

		// Token: 0x0600058C RID: 1420 RVA: 0x0003FF00 File Offset: 0x0003E100
		public uint GetIndirectDiffuseLightingLayers()
		{
			int value = (int)this.indirectDiffuseLightingLayers.GetValue<LightLayerEnum>();
			if (value >= 0)
			{
				return (uint)value;
			}
			return 255U;
		}

		// Token: 0x040004CD RID: 1229
		[FormerlySerializedAs("indirectDiffuseIntensity")]
		public MinFloatParameter indirectDiffuseLightingMultiplier = new MinFloatParameter(1f, 0f, false);

		// Token: 0x040004CE RID: 1230
		public IndirectLightingController.LightLayerEnumParameter indirectDiffuseLightingLayers = new IndirectLightingController.LightLayerEnumParameter(LightLayerEnum.Everything, false);

		// Token: 0x040004CF RID: 1231
		public MinFloatParameter reflectionLightingMultiplier = new MinFloatParameter(1f, 0f, false);

		// Token: 0x040004D0 RID: 1232
		public IndirectLightingController.LightLayerEnumParameter reflectionLightingLayers = new IndirectLightingController.LightLayerEnumParameter(LightLayerEnum.Everything, false);

		// Token: 0x040004D1 RID: 1233
		[FormerlySerializedAs("indirectSpecularIntensity")]
		public MinFloatParameter reflectionProbeIntensityMultiplier = new MinFloatParameter(1f, 0f, false);

		// Token: 0x0200031F RID: 799
		[DebuggerDisplay("{m_Value} ({m_OverrideState})")]
		[Serializable]
		public sealed class LightLayerEnumParameter : VolumeParameter<LightLayerEnum>
		{
			// Token: 0x0600126A RID: 4714 RVA: 0x0008D2AB File Offset: 0x0008B4AB
			public LightLayerEnumParameter(LightLayerEnum value, bool overrideState = false) : base(value, overrideState)
			{
			}
		}
	}
}
