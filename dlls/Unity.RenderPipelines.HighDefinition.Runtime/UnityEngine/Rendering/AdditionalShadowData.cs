using System;
using UnityEngine.Rendering.HighDefinition;
using UnityEngine.Serialization;

namespace UnityEngine.Rendering
{
	// Token: 0x02000020 RID: 32
	[RequireComponent(typeof(Light))]
	[Obsolete("This component will be removed in the future, it's content have been moved to HDAdditionalLightData.")]
	[ExecuteAlways]
	internal class AdditionalShadowData : MonoBehaviour
	{
		// Token: 0x04000090 RID: 144
		[SerializeField]
		[Obsolete("Obsolete, use HDAdditionalLightData.customResolution instead.")]
		[FormerlySerializedAs("shadowResolution")]
		internal int customResolution = 512;

		// Token: 0x04000091 RID: 145
		[SerializeField]
		[Range(0f, 1f)]
		[Obsolete("Obsolete, use HDAdditionalLightData.shadowDimmer instead.")]
		internal float shadowDimmer = 1f;

		// Token: 0x04000092 RID: 146
		[SerializeField]
		[Range(0f, 1f)]
		[Obsolete("Obsolete, use HDAdditionalLightData.volumetricShadowDimmer instead.")]
		internal float volumetricShadowDimmer = 1f;

		// Token: 0x04000093 RID: 147
		[SerializeField]
		[Obsolete("Obsolete, use HDAdditionalLightData.shadowFadeDistance instead.")]
		internal float shadowFadeDistance = 10000f;

		// Token: 0x04000094 RID: 148
		[SerializeField]
		[Obsolete("Obsolete, use HDAdditionalLightData.contactShadows instead.")]
		internal bool contactShadows;

		// Token: 0x04000095 RID: 149
		[SerializeField]
		[Obsolete("Obsolete, use HDAdditionalLightData.shadowTint instead.")]
		internal Color shadowTint = Color.black;

		// Token: 0x04000096 RID: 150
		[SerializeField]
		[Obsolete("Obsolete, use HDAdditionalLightData.normalBias instead.")]
		internal float normalBias = 0.75f;

		// Token: 0x04000097 RID: 151
		[SerializeField]
		[Obsolete("Obsolete, use HDAdditionalLightData.shadowUpdateMode instead.")]
		internal ShadowUpdateMode shadowUpdateMode;

		// Token: 0x04000098 RID: 152
		[HideInInspector]
		[SerializeField]
		[Obsolete("Obsolete, use HDAdditionalLightData.shadowCascadeRatios instead.")]
		internal float[] shadowCascadeRatios = new float[]
		{
			0.05f,
			0.2f,
			0.3f
		};

		// Token: 0x04000099 RID: 153
		[HideInInspector]
		[SerializeField]
		[Obsolete("Obsolete, use HDAdditionalLightData.shadowCascadeBorders instead.")]
		internal float[] shadowCascadeBorders = new float[]
		{
			0.2f,
			0.2f,
			0.2f,
			0.2f
		};

		// Token: 0x0400009A RID: 154
		[HideInInspector]
		[SerializeField]
		[Obsolete("Obsolete, use HDAdditionalLightData.shadowAlgorithm instead.")]
		internal int shadowAlgorithm;

		// Token: 0x0400009B RID: 155
		[HideInInspector]
		[SerializeField]
		[Obsolete("Obsolete, use HDAdditionalLightData.shadowVariant instead.")]
		internal int shadowVariant;

		// Token: 0x0400009C RID: 156
		[HideInInspector]
		[SerializeField]
		[Obsolete("Obsolete, use HDAdditionalLightData.shadowPrecision instead.")]
		internal int shadowPrecision;
	}
}
