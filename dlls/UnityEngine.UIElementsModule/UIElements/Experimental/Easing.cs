using System;

namespace UnityEngine.UIElements.Experimental
{
	// Token: 0x020004B2 RID: 1202
	public static class Easing
	{
		// Token: 0x06002544 RID: 9540 RVA: 0x0009DD00 File Offset: 0x0009BF00
		public static float Step(float t)
		{
			return (float)((t < 0.5f) ? 0 : 1);
		}

		// Token: 0x06002545 RID: 9541 RVA: 0x0009DD20 File Offset: 0x0009BF20
		public static float Linear(float t)
		{
			return t;
		}

		// Token: 0x06002546 RID: 9542 RVA: 0x0009DD34 File Offset: 0x0009BF34
		public static float InSine(float t)
		{
			return Mathf.Sin(1.5707964f * (t - 1f)) + 1f;
		}

		// Token: 0x06002547 RID: 9543 RVA: 0x0009DD60 File Offset: 0x0009BF60
		public static float OutSine(float t)
		{
			return Mathf.Sin(t * 1.5707964f);
		}

		// Token: 0x06002548 RID: 9544 RVA: 0x0009DD80 File Offset: 0x0009BF80
		public static float InOutSine(float t)
		{
			return (Mathf.Sin(3.1415927f * (t - 0.5f)) + 1f) * 0.5f;
		}

		// Token: 0x06002549 RID: 9545 RVA: 0x0009DDB0 File Offset: 0x0009BFB0
		public static float InQuad(float t)
		{
			return t * t;
		}

		// Token: 0x0600254A RID: 9546 RVA: 0x0009DDC8 File Offset: 0x0009BFC8
		public static float OutQuad(float t)
		{
			return t * (2f - t);
		}

		// Token: 0x0600254B RID: 9547 RVA: 0x0009DDE4 File Offset: 0x0009BFE4
		public static float InOutQuad(float t)
		{
			t *= 2f;
			bool flag = t < 1f;
			float result;
			if (flag)
			{
				result = t * t * 0.5f;
			}
			else
			{
				result = -0.5f * ((t - 1f) * (t - 3f) - 1f);
			}
			return result;
		}

		// Token: 0x0600254C RID: 9548 RVA: 0x0009DE34 File Offset: 0x0009C034
		public static float InCubic(float t)
		{
			return Easing.InPower(t, 3);
		}

		// Token: 0x0600254D RID: 9549 RVA: 0x0009DE50 File Offset: 0x0009C050
		public static float OutCubic(float t)
		{
			return Easing.OutPower(t, 3);
		}

		// Token: 0x0600254E RID: 9550 RVA: 0x0009DE6C File Offset: 0x0009C06C
		public static float InOutCubic(float t)
		{
			return Easing.InOutPower(t, 3);
		}

		// Token: 0x0600254F RID: 9551 RVA: 0x0009DE88 File Offset: 0x0009C088
		public static float InPower(float t, int power)
		{
			return Mathf.Pow(t, (float)power);
		}

		// Token: 0x06002550 RID: 9552 RVA: 0x0009DEA4 File Offset: 0x0009C0A4
		public static float OutPower(float t, int power)
		{
			int num = (power % 2 == 0) ? -1 : 1;
			return (float)num * (Mathf.Pow(t - 1f, (float)power) + (float)num);
		}

		// Token: 0x06002551 RID: 9553 RVA: 0x0009DED8 File Offset: 0x0009C0D8
		public static float InOutPower(float t, int power)
		{
			t *= 2f;
			bool flag = t < 1f;
			float result;
			if (flag)
			{
				result = Easing.InPower(t, power) * 0.5f;
			}
			else
			{
				int num = (power % 2 == 0) ? -1 : 1;
				result = (float)num * 0.5f * (Mathf.Pow(t - 2f, (float)power) + (float)(num * 2));
			}
			return result;
		}

		// Token: 0x06002552 RID: 9554 RVA: 0x0009DF38 File Offset: 0x0009C138
		public static float InBounce(float t)
		{
			return 1f - Easing.OutBounce(1f - t);
		}

		// Token: 0x06002553 RID: 9555 RVA: 0x0009DF5C File Offset: 0x0009C15C
		public static float OutBounce(float t)
		{
			bool flag = t < 0.36363637f;
			float result;
			if (flag)
			{
				result = 7.5625f * t * t;
			}
			else
			{
				bool flag2 = t < 0.72727275f;
				if (flag2)
				{
					float num;
					t = (num = t - 0.54545456f);
					result = 7.5625f * num * t + 0.75f;
				}
				else
				{
					bool flag3 = t < 0.90909094f;
					if (flag3)
					{
						float num2;
						t = (num2 = t - 0.8181818f);
						result = 7.5625f * num2 * t + 0.9375f;
					}
					else
					{
						float num3;
						t = (num3 = t - 0.95454544f);
						result = 7.5625f * num3 * t + 0.984375f;
					}
				}
			}
			return result;
		}

		// Token: 0x06002554 RID: 9556 RVA: 0x0009DFFC File Offset: 0x0009C1FC
		public static float InOutBounce(float t)
		{
			bool flag = t < 0.5f;
			float result;
			if (flag)
			{
				result = Easing.InBounce(t * 2f) * 0.5f;
			}
			else
			{
				result = Easing.OutBounce((t - 0.5f) * 2f) * 0.5f + 0.5f;
			}
			return result;
		}

		// Token: 0x06002555 RID: 9557 RVA: 0x0009E050 File Offset: 0x0009C250
		public static float InElastic(float t)
		{
			bool flag = t == 0f;
			float result;
			if (flag)
			{
				result = 0f;
			}
			else
			{
				bool flag2 = t == 1f;
				if (flag2)
				{
					result = 1f;
				}
				else
				{
					float num = 0.3f;
					float num2 = num / 4f;
					float num3 = Mathf.Pow(2f, 10f * (t -= 1f));
					result = -(num3 * Mathf.Sin((t - num2) * 6.2831855f / num));
				}
			}
			return result;
		}

		// Token: 0x06002556 RID: 9558 RVA: 0x0009E0CC File Offset: 0x0009C2CC
		public static float OutElastic(float t)
		{
			bool flag = t == 0f;
			float result;
			if (flag)
			{
				result = 0f;
			}
			else
			{
				bool flag2 = t == 1f;
				if (flag2)
				{
					result = 1f;
				}
				else
				{
					float num = 0.3f;
					float num2 = num / 4f;
					result = Mathf.Pow(2f, -10f * t) * Mathf.Sin((t - num2) * 6.2831855f / num) + 1f;
				}
			}
			return result;
		}

		// Token: 0x06002557 RID: 9559 RVA: 0x0009E140 File Offset: 0x0009C340
		public static float InOutElastic(float t)
		{
			bool flag = t < 0.5f;
			float result;
			if (flag)
			{
				result = Easing.InElastic(t * 2f) * 0.5f;
			}
			else
			{
				result = Easing.OutElastic((t - 0.5f) * 2f) * 0.5f + 0.5f;
			}
			return result;
		}

		// Token: 0x06002558 RID: 9560 RVA: 0x0009E194 File Offset: 0x0009C394
		public static float InBack(float t)
		{
			float num = 1.70158f;
			return t * t * ((num + 1f) * t - num);
		}

		// Token: 0x06002559 RID: 9561 RVA: 0x0009E1BC File Offset: 0x0009C3BC
		public static float OutBack(float t)
		{
			return 1f - Easing.InBack(1f - t);
		}

		// Token: 0x0600255A RID: 9562 RVA: 0x0009E1E0 File Offset: 0x0009C3E0
		public static float InOutBack(float t)
		{
			bool flag = t < 0.5f;
			float result;
			if (flag)
			{
				result = Easing.InBack(t * 2f) * 0.5f;
			}
			else
			{
				result = Easing.OutBack((t - 0.5f) * 2f) * 0.5f + 0.5f;
			}
			return result;
		}

		// Token: 0x0600255B RID: 9563 RVA: 0x0009E234 File Offset: 0x0009C434
		public static float InBack(float t, float s)
		{
			return t * t * ((s + 1f) * t - s);
		}

		// Token: 0x0600255C RID: 9564 RVA: 0x0009E258 File Offset: 0x0009C458
		public static float OutBack(float t, float s)
		{
			return 1f - Easing.InBack(1f - t, s);
		}

		// Token: 0x0600255D RID: 9565 RVA: 0x0009E280 File Offset: 0x0009C480
		public static float InOutBack(float t, float s)
		{
			bool flag = t < 0.5f;
			float result;
			if (flag)
			{
				result = Easing.InBack(t * 2f, s) * 0.5f;
			}
			else
			{
				result = Easing.OutBack((t - 0.5f) * 2f, s) * 0.5f + 0.5f;
			}
			return result;
		}

		// Token: 0x0600255E RID: 9566 RVA: 0x0009E2D8 File Offset: 0x0009C4D8
		public static float InCirc(float t)
		{
			return -(Mathf.Sqrt(1f - t * t) - 1f);
		}

		// Token: 0x0600255F RID: 9567 RVA: 0x0009E300 File Offset: 0x0009C500
		public static float OutCirc(float t)
		{
			t -= 1f;
			return Mathf.Sqrt(1f - t * t);
		}

		// Token: 0x06002560 RID: 9568 RVA: 0x0009E32C File Offset: 0x0009C52C
		public static float InOutCirc(float t)
		{
			t *= 2f;
			bool flag = t < 1f;
			float result;
			if (flag)
			{
				result = -0.5f * (Mathf.Sqrt(1f - t * t) - 1f);
			}
			else
			{
				t -= 2f;
				result = 0.5f * (Mathf.Sqrt(1f - t * t) + 1f);
			}
			return result;
		}

		// Token: 0x0400122D RID: 4653
		private const float HalfPi = 1.5707964f;
	}
}
