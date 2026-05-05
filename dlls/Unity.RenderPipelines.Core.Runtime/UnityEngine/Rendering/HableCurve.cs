using System;

namespace UnityEngine.Rendering
{
	// Token: 0x020000D7 RID: 215
	public class HableCurve
	{
		// Token: 0x1700011A RID: 282
		// (get) Token: 0x06000744 RID: 1860 RVA: 0x000235FC File Offset: 0x000217FC
		// (set) Token: 0x06000745 RID: 1861 RVA: 0x00023604 File Offset: 0x00021804
		public float whitePoint { get; private set; }

		// Token: 0x1700011B RID: 283
		// (get) Token: 0x06000746 RID: 1862 RVA: 0x0002360D File Offset: 0x0002180D
		// (set) Token: 0x06000747 RID: 1863 RVA: 0x00023615 File Offset: 0x00021815
		public float inverseWhitePoint { get; private set; }

		// Token: 0x1700011C RID: 284
		// (get) Token: 0x06000748 RID: 1864 RVA: 0x0002361E File Offset: 0x0002181E
		// (set) Token: 0x06000749 RID: 1865 RVA: 0x00023626 File Offset: 0x00021826
		public float x0 { get; private set; }

		// Token: 0x1700011D RID: 285
		// (get) Token: 0x0600074A RID: 1866 RVA: 0x0002362F File Offset: 0x0002182F
		// (set) Token: 0x0600074B RID: 1867 RVA: 0x00023637 File Offset: 0x00021837
		public float x1 { get; private set; }

		// Token: 0x0600074C RID: 1868 RVA: 0x00023640 File Offset: 0x00021840
		public HableCurve()
		{
			for (int i = 0; i < 3; i++)
			{
				this.segments[i] = new HableCurve.Segment();
			}
			this.uniforms = new HableCurve.Uniforms(this);
		}

		// Token: 0x0600074D RID: 1869 RVA: 0x00023684 File Offset: 0x00021884
		public float Eval(float x)
		{
			float num = x * this.inverseWhitePoint;
			int num2 = (num < this.x0) ? 0 : ((num < this.x1) ? 1 : 2);
			return this.segments[num2].Eval(num);
		}

		// Token: 0x0600074E RID: 1870 RVA: 0x000236C4 File Offset: 0x000218C4
		public void Init(float toeStrength, float toeLength, float shoulderStrength, float shoulderLength, float shoulderAngle, float gamma)
		{
			HableCurve.DirectParams directParams = default(HableCurve.DirectParams);
			toeLength = Mathf.Pow(Mathf.Clamp01(toeLength), 2.2f);
			toeStrength = Mathf.Clamp01(toeStrength);
			shoulderAngle = Mathf.Clamp01(shoulderAngle);
			shoulderStrength = Mathf.Clamp(shoulderStrength, 1E-05f, 0.99999f);
			shoulderLength = Mathf.Max(0f, shoulderLength);
			gamma = Mathf.Max(1E-05f, gamma);
			float num = toeLength * 0.5f;
			float num2 = (1f - toeStrength) * num;
			float num3 = 1f - num2;
			float num4 = num + num3;
			float num5 = (1f - shoulderStrength) * num3;
			float x = num + num5;
			float y = num2 + num5;
			float num6 = Mathf.Pow(2f, shoulderLength) - 1f;
			float w = num4 + num6;
			directParams.x0 = num;
			directParams.y0 = num2;
			directParams.x1 = x;
			directParams.y1 = y;
			directParams.W = w;
			directParams.gamma = gamma;
			directParams.overshootX = directParams.W * 2f * shoulderAngle * shoulderLength;
			directParams.overshootY = 0.5f * shoulderAngle * shoulderLength;
			this.InitSegments(directParams);
		}

		// Token: 0x0600074F RID: 1871 RVA: 0x000237E0 File Offset: 0x000219E0
		private void InitSegments(HableCurve.DirectParams srcParams)
		{
			HableCurve.DirectParams directParams = srcParams;
			this.whitePoint = srcParams.W;
			this.inverseWhitePoint = 1f / srcParams.W;
			directParams.W = 1f;
			directParams.x0 /= srcParams.W;
			directParams.x1 /= srcParams.W;
			directParams.overshootX = srcParams.overshootX / srcParams.W;
			float num;
			float num2;
			this.AsSlopeIntercept(out num, out num2, directParams.x0, directParams.x1, directParams.y0, directParams.y1);
			float gamma = srcParams.gamma;
			HableCurve.Segment segment = this.segments[1];
			segment.offsetX = -(num2 / num);
			segment.offsetY = 0f;
			segment.scaleX = 1f;
			segment.scaleY = 1f;
			segment.lnA = gamma * Mathf.Log(num);
			segment.B = gamma;
			float m = this.EvalDerivativeLinearGamma(num, num2, gamma, directParams.x0);
			float m2 = this.EvalDerivativeLinearGamma(num, num2, gamma, directParams.x1);
			directParams.y0 = Mathf.Max(1E-05f, Mathf.Pow(directParams.y0, directParams.gamma));
			directParams.y1 = Mathf.Max(1E-05f, Mathf.Pow(directParams.y1, directParams.gamma));
			directParams.overshootY = Mathf.Pow(1f + directParams.overshootY, directParams.gamma) - 1f;
			this.x0 = directParams.x0;
			this.x1 = directParams.x1;
			HableCurve.Segment segment2 = this.segments[0];
			segment2.offsetX = 0f;
			segment2.offsetY = 0f;
			segment2.scaleX = 1f;
			segment2.scaleY = 1f;
			float lnA;
			float b;
			this.SolveAB(out lnA, out b, directParams.x0, directParams.y0, m);
			segment2.lnA = lnA;
			segment2.B = b;
			HableCurve.Segment segment3 = this.segments[2];
			float x = 1f + directParams.overshootX - directParams.x1;
			float y = 1f + directParams.overshootY - directParams.y1;
			float lnA2;
			float b2;
			this.SolveAB(out lnA2, out b2, x, y, m2);
			segment3.offsetX = 1f + directParams.overshootX;
			segment3.offsetY = 1f + directParams.overshootY;
			segment3.scaleX = -1f;
			segment3.scaleY = -1f;
			segment3.lnA = lnA2;
			segment3.B = b2;
			float num3 = this.segments[2].Eval(1f);
			float num4 = 1f / num3;
			this.segments[0].offsetY *= num4;
			this.segments[0].scaleY *= num4;
			this.segments[1].offsetY *= num4;
			this.segments[1].scaleY *= num4;
			this.segments[2].offsetY *= num4;
			this.segments[2].scaleY *= num4;
		}

		// Token: 0x06000750 RID: 1872 RVA: 0x00023AF9 File Offset: 0x00021CF9
		private void SolveAB(out float lnA, out float B, float x0, float y0, float m)
		{
			B = m * x0 / y0;
			lnA = Mathf.Log(y0) - B * Mathf.Log(x0);
		}

		// Token: 0x06000751 RID: 1873 RVA: 0x00023B18 File Offset: 0x00021D18
		private void AsSlopeIntercept(out float m, out float b, float x0, float x1, float y0, float y1)
		{
			float num = y1 - y0;
			float num2 = x1 - x0;
			if (num2 == 0f)
			{
				m = 1f;
			}
			else
			{
				m = num / num2;
			}
			b = y0 - x0 * m;
		}

		// Token: 0x06000752 RID: 1874 RVA: 0x00023B4F File Offset: 0x00021D4F
		private float EvalDerivativeLinearGamma(float m, float b, float g, float x)
		{
			return g * m * Mathf.Pow(m * x + b, g - 1f);
		}

		// Token: 0x040004A0 RID: 1184
		public readonly HableCurve.Segment[] segments = new HableCurve.Segment[3];

		// Token: 0x040004A1 RID: 1185
		public readonly HableCurve.Uniforms uniforms;

		// Token: 0x020001CD RID: 461
		public class Segment
		{
			// Token: 0x06000B5B RID: 2907 RVA: 0x0002FA74 File Offset: 0x0002DC74
			public float Eval(float x)
			{
				float num = (x - this.offsetX) * this.scaleX;
				float num2 = 0f;
				if (num > 0f)
				{
					num2 = Mathf.Exp(this.lnA + this.B * Mathf.Log(num));
				}
				return num2 * this.scaleY + this.offsetY;
			}

			// Token: 0x0400077C RID: 1916
			public float offsetX;

			// Token: 0x0400077D RID: 1917
			public float offsetY;

			// Token: 0x0400077E RID: 1918
			public float scaleX;

			// Token: 0x0400077F RID: 1919
			public float scaleY;

			// Token: 0x04000780 RID: 1920
			public float lnA;

			// Token: 0x04000781 RID: 1921
			public float B;
		}

		// Token: 0x020001CE RID: 462
		private struct DirectParams
		{
			// Token: 0x04000782 RID: 1922
			internal float x0;

			// Token: 0x04000783 RID: 1923
			internal float y0;

			// Token: 0x04000784 RID: 1924
			internal float x1;

			// Token: 0x04000785 RID: 1925
			internal float y1;

			// Token: 0x04000786 RID: 1926
			internal float W;

			// Token: 0x04000787 RID: 1927
			internal float overshootX;

			// Token: 0x04000788 RID: 1928
			internal float overshootY;

			// Token: 0x04000789 RID: 1929
			internal float gamma;
		}

		// Token: 0x020001CF RID: 463
		public class Uniforms
		{
			// Token: 0x06000B5D RID: 2909 RVA: 0x0002FAD0 File Offset: 0x0002DCD0
			internal Uniforms(HableCurve parent)
			{
				this.parent = parent;
			}

			// Token: 0x17000189 RID: 393
			// (get) Token: 0x06000B5E RID: 2910 RVA: 0x0002FADF File Offset: 0x0002DCDF
			public Vector4 curve
			{
				get
				{
					return new Vector4(this.parent.inverseWhitePoint, this.parent.x0, this.parent.x1, 0f);
				}
			}

			// Token: 0x1700018A RID: 394
			// (get) Token: 0x06000B5F RID: 2911 RVA: 0x0002FB0C File Offset: 0x0002DD0C
			public Vector4 toeSegmentA
			{
				get
				{
					return new Vector4(this.parent.segments[0].offsetX, this.parent.segments[0].offsetY, this.parent.segments[0].scaleX, this.parent.segments[0].scaleY);
				}
			}

			// Token: 0x1700018B RID: 395
			// (get) Token: 0x06000B60 RID: 2912 RVA: 0x0002FB66 File Offset: 0x0002DD66
			public Vector4 toeSegmentB
			{
				get
				{
					return new Vector4(this.parent.segments[0].lnA, this.parent.segments[0].B, 0f, 0f);
				}
			}

			// Token: 0x1700018C RID: 396
			// (get) Token: 0x06000B61 RID: 2913 RVA: 0x0002FB9C File Offset: 0x0002DD9C
			public Vector4 midSegmentA
			{
				get
				{
					return new Vector4(this.parent.segments[1].offsetX, this.parent.segments[1].offsetY, this.parent.segments[1].scaleX, this.parent.segments[1].scaleY);
				}
			}

			// Token: 0x1700018D RID: 397
			// (get) Token: 0x06000B62 RID: 2914 RVA: 0x0002FBF6 File Offset: 0x0002DDF6
			public Vector4 midSegmentB
			{
				get
				{
					return new Vector4(this.parent.segments[1].lnA, this.parent.segments[1].B, 0f, 0f);
				}
			}

			// Token: 0x1700018E RID: 398
			// (get) Token: 0x06000B63 RID: 2915 RVA: 0x0002FC2C File Offset: 0x0002DE2C
			public Vector4 shoSegmentA
			{
				get
				{
					return new Vector4(this.parent.segments[2].offsetX, this.parent.segments[2].offsetY, this.parent.segments[2].scaleX, this.parent.segments[2].scaleY);
				}
			}

			// Token: 0x1700018F RID: 399
			// (get) Token: 0x06000B64 RID: 2916 RVA: 0x0002FC86 File Offset: 0x0002DE86
			public Vector4 shoSegmentB
			{
				get
				{
					return new Vector4(this.parent.segments[2].lnA, this.parent.segments[2].B, 0f, 0f);
				}
			}

			// Token: 0x0400078A RID: 1930
			private HableCurve parent;
		}
	}
}
