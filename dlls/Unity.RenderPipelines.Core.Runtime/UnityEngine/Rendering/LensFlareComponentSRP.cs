using System;

namespace UnityEngine.Rendering
{
	// Token: 0x020000A1 RID: 161
	[ExecuteAlways]
	[AddComponentMenu("Rendering/Lens Flare (SRP)")]
	public sealed class LensFlareComponentSRP : MonoBehaviour
	{
		// Token: 0x170000CA RID: 202
		// (get) Token: 0x06000535 RID: 1333 RVA: 0x0001B230 File Offset: 0x00019430
		// (set) Token: 0x06000536 RID: 1334 RVA: 0x0001B238 File Offset: 0x00019438
		public LensFlareDataSRP lensFlareData
		{
			get
			{
				return this.m_LensFlareData;
			}
			set
			{
				this.m_LensFlareData = value;
				this.OnValidate();
			}
		}

		// Token: 0x06000537 RID: 1335 RVA: 0x0001B248 File Offset: 0x00019448
		public float celestialProjectedOcclusionRadius(Camera mainCam)
		{
			float num = (float)Math.Tan((double)LensFlareComponentSRP.sCelestialAngularRadius) * mainCam.farClipPlane;
			return this.occlusionRadius * num;
		}

		// Token: 0x06000538 RID: 1336 RVA: 0x0001B271 File Offset: 0x00019471
		private void OnEnable()
		{
			if (this.lensFlareData)
			{
				LensFlareCommonSRP.Instance.AddData(this);
				return;
			}
			LensFlareCommonSRP.Instance.RemoveData(this);
		}

		// Token: 0x06000539 RID: 1337 RVA: 0x0001B297 File Offset: 0x00019497
		private void OnDisable()
		{
			LensFlareCommonSRP.Instance.RemoveData(this);
		}

		// Token: 0x0600053A RID: 1338 RVA: 0x0001B2A4 File Offset: 0x000194A4
		private void OnValidate()
		{
			if (base.isActiveAndEnabled && this.lensFlareData != null)
			{
				LensFlareCommonSRP.Instance.AddData(this);
				return;
			}
			LensFlareCommonSRP.Instance.RemoveData(this);
		}

		// Token: 0x0600053B RID: 1339 RVA: 0x0001B2D4 File Offset: 0x000194D4
		public LensFlareComponentSRP()
		{
			AnimationCurve baseCurve = AnimationCurve.Linear(0f, 0f, 1f, 1f);
			float zeroValue = 1f;
			bool loop = false;
			Vector2 vector = new Vector2(0f, 1f);
			this.occlusionRemapCurve = new TextureCurve(baseCurve, zeroValue, loop, ref vector);
			base..ctor();
		}

		// Token: 0x04000380 RID: 896
		[SerializeField]
		private LensFlareDataSRP m_LensFlareData;

		// Token: 0x04000381 RID: 897
		[Min(0f)]
		public float intensity = 1f;

		// Token: 0x04000382 RID: 898
		[Min(1E-05f)]
		public float maxAttenuationDistance = 100f;

		// Token: 0x04000383 RID: 899
		[Min(1E-05f)]
		public float maxAttenuationScale = 100f;

		// Token: 0x04000384 RID: 900
		public AnimationCurve distanceAttenuationCurve = new AnimationCurve(new Keyframe[]
		{
			new Keyframe(0f, 1f),
			new Keyframe(1f, 0f)
		});

		// Token: 0x04000385 RID: 901
		public AnimationCurve scaleByDistanceCurve = new AnimationCurve(new Keyframe[]
		{
			new Keyframe(0f, 1f),
			new Keyframe(1f, 0f)
		});

		// Token: 0x04000386 RID: 902
		public bool attenuationByLightShape = true;

		// Token: 0x04000387 RID: 903
		public AnimationCurve radialScreenAttenuationCurve = new AnimationCurve(new Keyframe[]
		{
			new Keyframe(0f, 1f),
			new Keyframe(1f, 1f)
		});

		// Token: 0x04000388 RID: 904
		public bool useOcclusion;

		// Token: 0x04000389 RID: 905
		[Min(0f)]
		public float occlusionRadius = 0.1f;

		// Token: 0x0400038A RID: 906
		public bool useBackgroundCloudOcclusion;

		// Token: 0x0400038B RID: 907
		[Range(1f, 64f)]
		public uint sampleCount = 32U;

		// Token: 0x0400038C RID: 908
		public float occlusionOffset = 0.05f;

		// Token: 0x0400038D RID: 909
		[Min(0f)]
		public float scale = 1f;

		// Token: 0x0400038E RID: 910
		public bool allowOffScreen;

		// Token: 0x0400038F RID: 911
		public bool volumetricCloudOcclusion;

		// Token: 0x04000390 RID: 912
		private static float sCelestialAngularRadius = 0.057595868f;

		// Token: 0x04000391 RID: 913
		public TextureCurve occlusionRemapCurve;
	}
}
