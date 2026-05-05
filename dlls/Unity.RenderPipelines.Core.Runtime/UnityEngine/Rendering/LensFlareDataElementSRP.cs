using System;
using UnityEngine.Serialization;

namespace UnityEngine.Rendering
{
	// Token: 0x020000A5 RID: 165
	[Serializable]
	public sealed class LensFlareDataElementSRP
	{
		// Token: 0x0600053D RID: 1341 RVA: 0x0001B438 File Offset: 0x00019638
		public LensFlareDataElementSRP()
		{
			this.visible = true;
			this.localIntensity = 1f;
			this.position = 0f;
			this.positionOffset = new Vector2(0f, 0f);
			this.angularOffset = 0f;
			this.translationScale = new Vector2(1f, 1f);
			this.lensFlareTexture = null;
			this.uniformScale = 1f;
			this.sizeXY = Vector2.one;
			this.allowMultipleElement = false;
			this.count = 5;
			this.rotation = 0f;
			this.tint = new Color(1f, 1f, 1f, 0.5f);
			this.blendMode = SRPLensFlareBlendMode.Additive;
			this.autoRotate = false;
			this.isFoldOpened = true;
			this.flareType = SRPLensFlareType.Circle;
			this.distribution = SRPLensFlareDistribution.Uniform;
			this.lengthSpread = 1f;
			this.colorGradient = new Gradient();
			this.colorGradient.SetKeys(new GradientColorKey[]
			{
				new GradientColorKey(Color.white, 0f),
				new GradientColorKey(Color.white, 1f)
			}, new GradientAlphaKey[]
			{
				new GradientAlphaKey(1f, 0f),
				new GradientAlphaKey(1f, 1f)
			});
			this.positionCurve = new AnimationCurve(new Keyframe[]
			{
				new Keyframe(0f, 0f, 1f, 1f),
				new Keyframe(1f, 1f, 1f, -1f)
			});
			this.scaleCurve = new AnimationCurve(new Keyframe[]
			{
				new Keyframe(0f, 1f),
				new Keyframe(1f, 1f)
			});
			this.uniformAngleCurve = new AnimationCurve(new Keyframe[]
			{
				new Keyframe(0f, 0f),
				new Keyframe(1f, 0f)
			});
			this.seed = 0;
			this.intensityVariation = 0.75f;
			this.positionVariation = new Vector2(1f, 0f);
			this.scaleVariation = 1f;
			this.rotationVariation = 180f;
			this.enableRadialDistortion = false;
			this.targetSizeDistortion = Vector2.one;
			this.distortionCurve = new AnimationCurve(new Keyframe[]
			{
				new Keyframe(0f, 0f, 1f, 1f),
				new Keyframe(1f, 1f, 1f, -1f)
			});
			this.distortionRelativeToCenter = false;
			this.fallOff = 1f;
			this.edgeOffset = 0.1f;
			this.sdfRoundness = 0f;
			this.sideCount = 6;
			this.inverseSDF = false;
		}

		// Token: 0x170000CB RID: 203
		// (get) Token: 0x0600053E RID: 1342 RVA: 0x0001B73B File Offset: 0x0001993B
		// (set) Token: 0x0600053F RID: 1343 RVA: 0x0001B743 File Offset: 0x00019943
		public float localIntensity
		{
			get
			{
				return this.m_LocalIntensity;
			}
			set
			{
				this.m_LocalIntensity = Mathf.Max(0f, value);
			}
		}

		// Token: 0x170000CC RID: 204
		// (get) Token: 0x06000540 RID: 1344 RVA: 0x0001B756 File Offset: 0x00019956
		// (set) Token: 0x06000541 RID: 1345 RVA: 0x0001B75E File Offset: 0x0001995E
		public int count
		{
			get
			{
				return this.m_Count;
			}
			set
			{
				this.m_Count = Mathf.Max(1, value);
			}
		}

		// Token: 0x170000CD RID: 205
		// (get) Token: 0x06000542 RID: 1346 RVA: 0x0001B76D File Offset: 0x0001996D
		// (set) Token: 0x06000543 RID: 1347 RVA: 0x0001B775 File Offset: 0x00019975
		public float intensityVariation
		{
			get
			{
				return this.m_IntensityVariation;
			}
			set
			{
				this.m_IntensityVariation = Mathf.Max(0f, value);
			}
		}

		// Token: 0x170000CE RID: 206
		// (get) Token: 0x06000544 RID: 1348 RVA: 0x0001B788 File Offset: 0x00019988
		// (set) Token: 0x06000545 RID: 1349 RVA: 0x0001B790 File Offset: 0x00019990
		public float fallOff
		{
			get
			{
				return this.m_FallOff;
			}
			set
			{
				this.m_FallOff = Mathf.Clamp01(value);
			}
		}

		// Token: 0x170000CF RID: 207
		// (get) Token: 0x06000546 RID: 1350 RVA: 0x0001B79E File Offset: 0x0001999E
		// (set) Token: 0x06000547 RID: 1351 RVA: 0x0001B7A6 File Offset: 0x000199A6
		public float edgeOffset
		{
			get
			{
				return this.m_EdgeOffset;
			}
			set
			{
				this.m_EdgeOffset = Mathf.Clamp01(value);
			}
		}

		// Token: 0x170000D0 RID: 208
		// (get) Token: 0x06000548 RID: 1352 RVA: 0x0001B7B4 File Offset: 0x000199B4
		// (set) Token: 0x06000549 RID: 1353 RVA: 0x0001B7BC File Offset: 0x000199BC
		public int sideCount
		{
			get
			{
				return this.m_SideCount;
			}
			set
			{
				this.m_SideCount = Mathf.Max(3, value);
			}
		}

		// Token: 0x170000D1 RID: 209
		// (get) Token: 0x0600054A RID: 1354 RVA: 0x0001B7CB File Offset: 0x000199CB
		// (set) Token: 0x0600054B RID: 1355 RVA: 0x0001B7D3 File Offset: 0x000199D3
		public float sdfRoundness
		{
			get
			{
				return this.m_SdfRoundness;
			}
			set
			{
				this.m_SdfRoundness = Mathf.Clamp01(value);
			}
		}

		// Token: 0x0400039F RID: 927
		public bool visible;

		// Token: 0x040003A0 RID: 928
		public float position;

		// Token: 0x040003A1 RID: 929
		public Vector2 positionOffset;

		// Token: 0x040003A2 RID: 930
		public float angularOffset;

		// Token: 0x040003A3 RID: 931
		public Vector2 translationScale;

		// Token: 0x040003A4 RID: 932
		[Min(0f)]
		[SerializeField]
		[FormerlySerializedAs("localIntensity")]
		private float m_LocalIntensity;

		// Token: 0x040003A5 RID: 933
		public Texture lensFlareTexture;

		// Token: 0x040003A6 RID: 934
		public float uniformScale;

		// Token: 0x040003A7 RID: 935
		public Vector2 sizeXY;

		// Token: 0x040003A8 RID: 936
		public bool allowMultipleElement;

		// Token: 0x040003A9 RID: 937
		[Min(1f)]
		[SerializeField]
		[FormerlySerializedAs("count")]
		private int m_Count;

		// Token: 0x040003AA RID: 938
		public bool preserveAspectRatio;

		// Token: 0x040003AB RID: 939
		public float rotation;

		// Token: 0x040003AC RID: 940
		public Color tint;

		// Token: 0x040003AD RID: 941
		public SRPLensFlareBlendMode blendMode;

		// Token: 0x040003AE RID: 942
		public bool autoRotate;

		// Token: 0x040003AF RID: 943
		public SRPLensFlareType flareType;

		// Token: 0x040003B0 RID: 944
		public bool modulateByLightColor;

		// Token: 0x040003B1 RID: 945
		[SerializeField]
		private bool isFoldOpened;

		// Token: 0x040003B2 RID: 946
		public SRPLensFlareDistribution distribution;

		// Token: 0x040003B3 RID: 947
		public float lengthSpread;

		// Token: 0x040003B4 RID: 948
		public AnimationCurve positionCurve;

		// Token: 0x040003B5 RID: 949
		public AnimationCurve scaleCurve;

		// Token: 0x040003B6 RID: 950
		public int seed;

		// Token: 0x040003B7 RID: 951
		public Gradient colorGradient;

		// Token: 0x040003B8 RID: 952
		[Range(0f, 1f)]
		[SerializeField]
		[FormerlySerializedAs("intensityVariation")]
		private float m_IntensityVariation;

		// Token: 0x040003B9 RID: 953
		public Vector2 positionVariation;

		// Token: 0x040003BA RID: 954
		public float scaleVariation;

		// Token: 0x040003BB RID: 955
		public float rotationVariation;

		// Token: 0x040003BC RID: 956
		public bool enableRadialDistortion;

		// Token: 0x040003BD RID: 957
		public Vector2 targetSizeDistortion;

		// Token: 0x040003BE RID: 958
		public AnimationCurve distortionCurve;

		// Token: 0x040003BF RID: 959
		public bool distortionRelativeToCenter;

		// Token: 0x040003C0 RID: 960
		[Range(0f, 1f)]
		[SerializeField]
		[FormerlySerializedAs("fallOff")]
		private float m_FallOff;

		// Token: 0x040003C1 RID: 961
		[Range(0f, 1f)]
		[SerializeField]
		[FormerlySerializedAs("edgeOffset")]
		private float m_EdgeOffset;

		// Token: 0x040003C2 RID: 962
		[Min(3f)]
		[SerializeField]
		[FormerlySerializedAs("sideCount")]
		private int m_SideCount;

		// Token: 0x040003C3 RID: 963
		[Range(0f, 1f)]
		[SerializeField]
		[FormerlySerializedAs("sdfRoundness")]
		private float m_SdfRoundness;

		// Token: 0x040003C4 RID: 964
		public bool inverseSDF;

		// Token: 0x040003C5 RID: 965
		public float uniformAngle;

		// Token: 0x040003C6 RID: 966
		public AnimationCurve uniformAngleCurve;
	}
}
