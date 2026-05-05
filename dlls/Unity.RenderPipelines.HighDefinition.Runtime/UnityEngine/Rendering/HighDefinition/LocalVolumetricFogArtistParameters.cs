using System;
using UnityEngine.Serialization;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x02000053 RID: 83
	[Serializable]
	public struct LocalVolumetricFogArtistParameters
	{
		// Token: 0x1700001C RID: 28
		// (get) Token: 0x0600024C RID: 588 RVA: 0x0000D8B5 File Offset: 0x0000BAB5
		[Obsolete("Never worked correctly due to having engine working in percent. Will be removed soon.")]
		public bool advancedFade
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600024D RID: 589 RVA: 0x0000D8B8 File Offset: 0x0000BAB8
		public LocalVolumetricFogArtistParameters(Color color, float _meanFreePath, float _anisotropy)
		{
			this.albedo = color;
			this.meanFreePath = _meanFreePath;
			this.blendingMode = LocalVolumetricFogBlendingMode.Additive;
			this.priority = 0;
			this.anisotropy = _anisotropy;
			this.volumeMask = null;
			this.materialMask = null;
			this.textureScrollingSpeed = Vector3.zero;
			this.textureTiling = Vector3.one;
			this.textureOffset = this.textureScrollingSpeed;
			this.size = Vector3.one;
			this.positiveFade = Vector3.one * 0.1f;
			this.negativeFade = Vector3.one * 0.1f;
			this.invertFade = false;
			this.distanceFadeStart = 10000f;
			this.distanceFadeEnd = 10000f;
			this.falloffMode = LocalVolumetricFogFalloffMode.Linear;
			this.maskMode = LocalVolumetricFogMaskMode.Texture;
			this.m_EditorPositiveFade = this.positiveFade;
			this.m_EditorNegativeFade = this.negativeFade;
			this.m_EditorUniformFade = 0.1f;
			this.m_EditorAdvancedFade = false;
		}

		// Token: 0x0600024E RID: 590 RVA: 0x0000D9A2 File Offset: 0x0000BBA2
		internal void Update(float time)
		{
			if (this.volumeMask != null)
			{
				this.textureOffset = -(this.textureScrollingSpeed * time);
			}
		}

		// Token: 0x0600024F RID: 591 RVA: 0x0000D9CC File Offset: 0x0000BBCC
		internal void Constrain()
		{
			this.albedo.r = Mathf.Clamp01(this.albedo.r);
			this.albedo.g = Mathf.Clamp01(this.albedo.g);
			this.albedo.b = Mathf.Clamp01(this.albedo.b);
			this.albedo.a = 1f;
			this.meanFreePath = Mathf.Clamp(this.meanFreePath, 0.05f, float.MaxValue);
			this.anisotropy = Mathf.Clamp(this.anisotropy, -1f, 1f);
			this.textureOffset = Vector3.zero;
			this.distanceFadeStart = Mathf.Max(0f, this.distanceFadeStart);
			this.distanceFadeEnd = Mathf.Max(this.distanceFadeStart, this.distanceFadeEnd);
		}

		// Token: 0x06000250 RID: 592 RVA: 0x0000DAA8 File Offset: 0x0000BCA8
		internal LocalVolumetricFogEngineData ConvertToEngineData()
		{
			LocalVolumetricFogEngineData localVolumetricFogEngineData = default(LocalVolumetricFogEngineData);
			localVolumetricFogEngineData.extinction = VolumeRenderingUtils.ExtinctionFromMeanFreePath(this.meanFreePath);
			localVolumetricFogEngineData.scattering = VolumeRenderingUtils.ScatteringFromExtinctionAndAlbedo(localVolumetricFogEngineData.extinction, this.albedo);
			localVolumetricFogEngineData.blendingMode = this.blendingMode;
			localVolumetricFogEngineData.albedo = this.albedo;
			localVolumetricFogEngineData.textureScroll = this.textureOffset;
			localVolumetricFogEngineData.textureTiling = this.textureTiling;
			Vector3 vector = this.positiveFade;
			Vector3 vector2 = this.negativeFade;
			localVolumetricFogEngineData.rcpPosFaceFade.x = Mathf.Min(1f / vector.x, float.MaxValue);
			localVolumetricFogEngineData.rcpPosFaceFade.y = Mathf.Min(1f / vector.y, float.MaxValue);
			localVolumetricFogEngineData.rcpPosFaceFade.z = Mathf.Min(1f / vector.z, float.MaxValue);
			localVolumetricFogEngineData.rcpNegFaceFade.y = Mathf.Min(1f / vector2.y, float.MaxValue);
			localVolumetricFogEngineData.rcpNegFaceFade.x = Mathf.Min(1f / vector2.x, float.MaxValue);
			localVolumetricFogEngineData.rcpNegFaceFade.z = Mathf.Min(1f / vector2.z, float.MaxValue);
			localVolumetricFogEngineData.invertFade = (this.invertFade ? 1 : 0);
			localVolumetricFogEngineData.falloffMode = this.falloffMode;
			float num = Mathf.Max(this.distanceFadeEnd - this.distanceFadeStart, 1.526E-05f);
			localVolumetricFogEngineData.rcpDistFadeLen = 1f / num;
			localVolumetricFogEngineData.endTimesRcpDistFadeLen = this.distanceFadeEnd * localVolumetricFogEngineData.rcpDistFadeLen;
			return localVolumetricFogEngineData;
		}

		// Token: 0x06000251 RID: 593 RVA: 0x0000DC64 File Offset: 0x0000BE64
		internal void MigrateToFixUniformBlendDistanceToBeMetric()
		{
			if (!this.m_EditorAdvancedFade)
			{
				this.m_EditorAdvancedFade = true;
				this.negativeFade = (this.positiveFade = this.m_EditorUniformFade * Vector3.one);
				this.m_EditorUniformFade = 0f;
			}
			this.m_EditorPositiveFade = this.positiveFade;
			this.m_EditorNegativeFade = this.negativeFade;
		}

		// Token: 0x04000249 RID: 585
		[ColorUsage(false)]
		public Color albedo;

		// Token: 0x0400024A RID: 586
		public float meanFreePath;

		// Token: 0x0400024B RID: 587
		public LocalVolumetricFogBlendingMode blendingMode;

		// Token: 0x0400024C RID: 588
		public int priority;

		// Token: 0x0400024D RID: 589
		[FormerlySerializedAs("asymmetry")]
		public float anisotropy;

		// Token: 0x0400024E RID: 590
		public Texture volumeMask;

		// Token: 0x0400024F RID: 591
		public Vector3 textureScrollingSpeed;

		// Token: 0x04000250 RID: 592
		public Vector3 textureTiling;

		// Token: 0x04000251 RID: 593
		[FormerlySerializedAs("m_PositiveFade")]
		public Vector3 positiveFade;

		// Token: 0x04000252 RID: 594
		[FormerlySerializedAs("m_NegativeFade")]
		public Vector3 negativeFade;

		// Token: 0x04000253 RID: 595
		[SerializeField]
		[FormerlySerializedAs("m_UniformFade")]
		internal float m_EditorUniformFade;

		// Token: 0x04000254 RID: 596
		[SerializeField]
		internal Vector3 m_EditorPositiveFade;

		// Token: 0x04000255 RID: 597
		[SerializeField]
		internal Vector3 m_EditorNegativeFade;

		// Token: 0x04000256 RID: 598
		[SerializeField]
		[FormerlySerializedAs("advancedFade")]
		[FormerlySerializedAs("m_AdvancedFade")]
		internal bool m_EditorAdvancedFade;

		// Token: 0x04000257 RID: 599
		public Vector3 size;

		// Token: 0x04000258 RID: 600
		public bool invertFade;

		// Token: 0x04000259 RID: 601
		public float distanceFadeStart;

		// Token: 0x0400025A RID: 602
		public float distanceFadeEnd;

		// Token: 0x0400025B RID: 603
		[SerializeField]
		[FormerlySerializedAs("volumeScrollingAmount")]
		public Vector3 textureOffset;

		// Token: 0x0400025C RID: 604
		public LocalVolumetricFogFalloffMode falloffMode;

		// Token: 0x0400025D RID: 605
		public LocalVolumetricFogMaskMode maskMode;

		// Token: 0x0400025E RID: 606
		public Material materialMask;

		// Token: 0x0400025F RID: 607
		internal const float kMinFogDistance = 0.05f;
	}
}
