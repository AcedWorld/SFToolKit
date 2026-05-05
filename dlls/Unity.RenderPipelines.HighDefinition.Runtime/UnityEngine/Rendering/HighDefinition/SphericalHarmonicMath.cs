using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x020000DA RID: 218
	internal class SphericalHarmonicMath
	{
		// Token: 0x06000945 RID: 2373 RVA: 0x00051CC0 File Offset: 0x0004FEC0
		public static SphericalHarmonicsL2 Convolve(SphericalHarmonicsL2 sh, ZonalHarmonicsL2 zh)
		{
			for (int i = 0; i <= 2; i++)
			{
				float num = Mathf.Sqrt(12.566371f / (float)(2 * i + 1));
				float num2 = zh.coeffs[i];
				float num3 = num * num2;
				for (int j = -i; j <= i; j++)
				{
					int num4 = i * (i + 1) + j;
					for (int k = 0; k < 3; k++)
					{
						ref SphericalHarmonicsL2 ptr = ref sh;
						int rgb = k;
						int coefficient = num4;
						ptr[rgb, coefficient] *= num3;
					}
				}
			}
			return sh;
		}

		// Token: 0x06000946 RID: 2374 RVA: 0x00051D44 File Offset: 0x0004FF44
		public static SphericalHarmonicsL2 UndoCosineRescaling(SphericalHarmonicsL2 sh)
		{
			for (int i = 0; i < 3; i++)
			{
				for (int j = 0; j < 9; j++)
				{
					ref SphericalHarmonicsL2 ptr = ref sh;
					int rgb = i;
					int coefficient = j;
					ptr[rgb, coefficient] *= SphericalHarmonicMath.invNormConsts[j];
				}
			}
			return sh;
		}

		// Token: 0x06000947 RID: 2375 RVA: 0x00051D90 File Offset: 0x0004FF90
		public static SphericalHarmonicsL2 PremultiplyCoefficients(SphericalHarmonicsL2 sh)
		{
			for (int i = 0; i < 3; i++)
			{
				for (int j = 0; j < 9; j++)
				{
					ref SphericalHarmonicsL2 ptr = ref sh;
					int rgb = i;
					int coefficient = j;
					ptr[rgb, coefficient] *= SphericalHarmonicMath.ks[j];
				}
			}
			return sh;
		}

		// Token: 0x06000948 RID: 2376 RVA: 0x00051DDC File Offset: 0x0004FFDC
		public static SphericalHarmonicsL2 RescaleCoefficients(SphericalHarmonicsL2 sh, float scalar)
		{
			for (int i = 0; i < 3; i++)
			{
				for (int j = 0; j < 9; j++)
				{
					ref SphericalHarmonicsL2 ptr = ref sh;
					int rgb = i;
					int coefficient = j;
					ptr[rgb, coefficient] *= scalar;
				}
			}
			return sh;
		}

		// Token: 0x06000949 RID: 2377 RVA: 0x00051E20 File Offset: 0x00050020
		public static void PackCoefficients(Vector4[] packedCoeffs, SphericalHarmonicsL2 sh)
		{
			for (int i = 0; i < 3; i++)
			{
				packedCoeffs[i].Set(sh[i, 3], sh[i, 1], sh[i, 2], sh[i, 0] - sh[i, 6]);
			}
			for (int j = 0; j < 3; j++)
			{
				packedCoeffs[3 + j].Set(sh[j, 4], sh[j, 5], sh[j, 6] * 3f, sh[j, 7]);
			}
			packedCoeffs[6].Set(sh[0, 8], sh[1, 8], sh[2, 8], 1f);
		}

		// Token: 0x0400093E RID: 2366
		private const float c0 = 0.2820948f;

		// Token: 0x0400093F RID: 2367
		private const float c1 = 0.325735f;

		// Token: 0x04000940 RID: 2368
		private const float c2 = 0.27313712f;

		// Token: 0x04000941 RID: 2369
		private const float c3 = 0.07884789f;

		// Token: 0x04000942 RID: 2370
		private const float c4 = 0.13656856f;

		// Token: 0x04000943 RID: 2371
		private static float[] invNormConsts = new float[]
		{
			3.5449076f,
			-3.0699801f,
			3.0699801f,
			-3.0699801f,
			3.6611648f,
			-3.6611648f,
			12.682647f,
			-3.6611648f,
			7.3223295f
		};

		// Token: 0x04000944 RID: 2372
		private const float k0 = 0.2820948f;

		// Token: 0x04000945 RID: 2373
		private const float k1 = 0.48860252f;

		// Token: 0x04000946 RID: 2374
		private const float k2 = 1.0925485f;

		// Token: 0x04000947 RID: 2375
		private const float k3 = 0.31539157f;

		// Token: 0x04000948 RID: 2376
		private const float k4 = 0.54627424f;

		// Token: 0x04000949 RID: 2377
		private static float[] ks = new float[]
		{
			0.2820948f,
			-0.48860252f,
			0.48860252f,
			-0.48860252f,
			1.0925485f,
			-1.0925485f,
			0.31539157f,
			-1.0925485f,
			0.54627424f
		};
	}
}
