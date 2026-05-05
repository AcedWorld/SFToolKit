using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x020000FF RID: 255
	[Serializable]
	internal class DiffusionProfile : IEquatable<DiffusionProfile>
	{
		// Token: 0x17000172 RID: 370
		// (get) Token: 0x060009E6 RID: 2534 RVA: 0x00055526 File Offset: 0x00053726
		// (set) Token: 0x060009E7 RID: 2535 RVA: 0x0005552E File Offset: 0x0005372E
		public Vector3 shapeParam { get; private set; }

		// Token: 0x17000173 RID: 371
		// (get) Token: 0x060009E8 RID: 2536 RVA: 0x00055537 File Offset: 0x00053737
		// (set) Token: 0x060009E9 RID: 2537 RVA: 0x0005553F File Offset: 0x0005373F
		public float filterRadius { get; private set; }

		// Token: 0x17000174 RID: 372
		// (get) Token: 0x060009EA RID: 2538 RVA: 0x00055548 File Offset: 0x00053748
		// (set) Token: 0x060009EB RID: 2539 RVA: 0x00055550 File Offset: 0x00053750
		public float maxScatteringDistance { get; private set; }

		// Token: 0x060009EC RID: 2540 RVA: 0x00055559 File Offset: 0x00053759
		public DiffusionProfile(bool dontUseDefaultConstructor)
		{
			this.ResetToDefault();
		}

		// Token: 0x060009ED RID: 2541 RVA: 0x00055574 File Offset: 0x00053774
		public void ResetToDefault()
		{
			this.scatteringDistance = Color.grey;
			this.scatteringDistanceMultiplier = 1f;
			this.transmissionTint = Color.white;
			this.texturingMode = DiffusionProfile.TexturingMode.PreAndPostScatter;
			this.transmissionMode = DiffusionProfile.TransmissionMode.ThinObject;
			this.thicknessRemap = new Vector2(0f, 5f);
			this.worldScale = 1f;
			this.ior = 1.4f;
		}

		// Token: 0x060009EE RID: 2542 RVA: 0x000555DC File Offset: 0x000537DC
		internal void Validate()
		{
			this.thicknessRemap.y = Mathf.Max(this.thicknessRemap.y, 0f);
			this.thicknessRemap.x = Mathf.Clamp(this.thicknessRemap.x, 0f, this.thicknessRemap.y);
			this.worldScale = Mathf.Max(this.worldScale, 0.001f);
			this.ior = Mathf.Clamp(this.ior, 1f, 2f);
			this.UpdateKernel();
		}

		// Token: 0x060009EF RID: 2543 RVA: 0x0005566C File Offset: 0x0005386C
		private void UpdateKernel()
		{
			Vector3 vector = this.scatteringDistanceMultiplier * this.scatteringDistance;
			this.shapeParam = new Vector3(Mathf.Min(16777216f, 1f / vector.x), Mathf.Min(16777216f, 1f / vector.y), Mathf.Min(16777216f, 1f / vector.z));
			float u = 0.997f;
			this.maxScatteringDistance = Mathf.Max(new float[]
			{
				vector.x,
				vector.y,
				vector.z
			});
			this.filterRadius = DiffusionProfile.SampleBurleyDiffusionProfile(u, this.maxScatteringDistance);
		}

		// Token: 0x060009F0 RID: 2544 RVA: 0x00055726 File Offset: 0x00053926
		private static float DisneyProfile(float r, float s)
		{
			return s * (Mathf.Exp(-r * s) + Mathf.Exp(-r * s * 0.33333334f)) / (25.132742f * r);
		}

		// Token: 0x060009F1 RID: 2545 RVA: 0x0005574B File Offset: 0x0005394B
		private static float DisneyProfilePdf(float r, float s)
		{
			return r * DiffusionProfile.DisneyProfile(r, s);
		}

		// Token: 0x060009F2 RID: 2546 RVA: 0x00055756 File Offset: 0x00053956
		private static float DisneyProfileCdf(float r, float s)
		{
			return 1f - 0.25f * Mathf.Exp(-r * s) - 0.75f * Mathf.Exp(-r * s * 0.33333334f);
		}

		// Token: 0x060009F3 RID: 2547 RVA: 0x00055783 File Offset: 0x00053983
		private static float DisneyProfileCdfDerivative1(float r, float s)
		{
			return 0.25f * s * Mathf.Exp(-r * s) * (1f + Mathf.Exp(r * s * 0.6666667f));
		}

		// Token: 0x060009F4 RID: 2548 RVA: 0x000557AB File Offset: 0x000539AB
		private static float DisneyProfileCdfDerivative2(float r, float s)
		{
			return -0.083333336f * s * s * Mathf.Exp(-r * s) * (3f + Mathf.Exp(r * s * 0.6666667f));
		}

		// Token: 0x060009F5 RID: 2549 RVA: 0x000557D8 File Offset: 0x000539D8
		private static float DisneyProfileCdfInverse(float p, float s)
		{
			float num = (Mathf.Pow(10f, p) - 1f) / s;
			float num2 = float.MaxValue;
			for (;;)
			{
				float num3 = DiffusionProfile.DisneyProfileCdf(num, s) - p;
				float num4 = DiffusionProfile.DisneyProfileCdfDerivative1(num, s);
				float num5 = DiffusionProfile.DisneyProfileCdfDerivative2(num, s);
				float num6 = num3 / (num4 * (1f - num3 * num5 / (2f * num4 * num4)));
				if (Mathf.Abs(num6) >= num2)
				{
					break;
				}
				num -= num6;
				num2 = Mathf.Abs(num6);
			}
			return num;
		}

		// Token: 0x060009F6 RID: 2550 RVA: 0x00055850 File Offset: 0x00053A50
		private static float SampleBurleyDiffusionProfile(float u, float rcpS)
		{
			u = 1f - u;
			float num = 1f + 4f * u * (2f * u + Mathf.Sqrt(1f + 4f * u * u));
			float num2 = Mathf.Pow(num, -0.33333334f);
			float num3 = num * num2 * num2;
			float num4 = 1f + num3 + num2;
			return 3f * Mathf.Log(num4 / (4f * u)) * rcpS;
		}

		// Token: 0x060009F7 RID: 2551 RVA: 0x000558C4 File Offset: 0x00053AC4
		public bool Equals(DiffusionProfile other)
		{
			return other != null && (this.scatteringDistance == other.scatteringDistance && this.scatteringDistanceMultiplier == other.scatteringDistanceMultiplier && this.transmissionTint == other.transmissionTint && this.texturingMode == other.texturingMode && this.transmissionMode == other.transmissionMode && this.thicknessRemap == other.thicknessRemap && this.worldScale == other.worldScale) && this.ior == other.ior;
		}

		// Token: 0x04000AC2 RID: 2754
		[ColorUsage(false, false)]
		public Color scatteringDistance;

		// Token: 0x04000AC3 RID: 2755
		[Min(0f)]
		public float scatteringDistanceMultiplier = 1f;

		// Token: 0x04000AC4 RID: 2756
		[ColorUsage(false, true)]
		public Color transmissionTint;

		// Token: 0x04000AC5 RID: 2757
		public DiffusionProfile.TexturingMode texturingMode;

		// Token: 0x04000AC6 RID: 2758
		public DiffusionProfile.TransmissionMode transmissionMode;

		// Token: 0x04000AC7 RID: 2759
		public Vector2 thicknessRemap;

		// Token: 0x04000AC8 RID: 2760
		public float worldScale;

		// Token: 0x04000AC9 RID: 2761
		public float ior;

		// Token: 0x04000ACD RID: 2765
		public uint hash;

		// Token: 0x02000382 RID: 898
		public enum TexturingMode : uint
		{
			// Token: 0x04002476 RID: 9334
			PreAndPostScatter,
			// Token: 0x04002477 RID: 9335
			PostScatter
		}

		// Token: 0x02000383 RID: 899
		public enum TransmissionMode : uint
		{
			// Token: 0x04002479 RID: 9337
			Regular,
			// Token: 0x0400247A RID: 9338
			ThinObject
		}
	}
}
