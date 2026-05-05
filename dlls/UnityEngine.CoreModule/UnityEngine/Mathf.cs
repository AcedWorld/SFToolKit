using System;
using System.Runtime.CompilerServices;
using Unity.IL2CPP.CompilerServices;
using UnityEngine.Bindings;
using UnityEngine.Internal;
using UnityEngineInternal;

namespace UnityEngine
{
	// Token: 0x020001F3 RID: 499
	[NativeHeader("Runtime/Math/PerlinNoise.h")]
	[NativeHeader("Runtime/Utilities/BitUtility.h")]
	[NativeHeader("Runtime/Math/ColorSpaceConversion.h")]
	[NativeHeader("Runtime/Math/FloatConversion.h")]
	[Il2CppEagerStaticClassConstruction]
	public struct Mathf
	{
		// Token: 0x0600160B RID: 5643
		[FreeFunction(IsThreadSafe = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern int ClosestPowerOfTwo(int value);

		// Token: 0x0600160C RID: 5644
		[FreeFunction(IsThreadSafe = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern bool IsPowerOfTwo(int value);

		// Token: 0x0600160D RID: 5645
		[FreeFunction(IsThreadSafe = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern int NextPowerOfTwo(int value);

		// Token: 0x0600160E RID: 5646
		[FreeFunction(IsThreadSafe = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern float GammaToLinearSpace(float value);

		// Token: 0x0600160F RID: 5647
		[FreeFunction(IsThreadSafe = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern float LinearToGammaSpace(float value);

		// Token: 0x06001610 RID: 5648 RVA: 0x0002305C File Offset: 0x0002125C
		[FreeFunction(IsThreadSafe = true)]
		public static Color CorrelatedColorTemperatureToRGB(float kelvin)
		{
			Color result;
			Mathf.CorrelatedColorTemperatureToRGB_Injected(kelvin, out result);
			return result;
		}

		// Token: 0x06001611 RID: 5649
		[FreeFunction(IsThreadSafe = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern ushort FloatToHalf(float val);

		// Token: 0x06001612 RID: 5650
		[FreeFunction(IsThreadSafe = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern float HalfToFloat(ushort val);

		// Token: 0x06001613 RID: 5651
		[FreeFunction("PerlinNoise::NoiseNormalized", IsThreadSafe = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern float PerlinNoise(float x, float y);

		// Token: 0x06001614 RID: 5652
		[FreeFunction("PerlinNoise::NoiseNormalized", IsThreadSafe = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern float PerlinNoise1D(float x);

		// Token: 0x06001615 RID: 5653 RVA: 0x00023074 File Offset: 0x00021274
		public static float Sin(float f)
		{
			return (float)Math.Sin((double)f);
		}

		// Token: 0x06001616 RID: 5654 RVA: 0x00023090 File Offset: 0x00021290
		public static float Cos(float f)
		{
			return (float)Math.Cos((double)f);
		}

		// Token: 0x06001617 RID: 5655 RVA: 0x000230AC File Offset: 0x000212AC
		public static float Tan(float f)
		{
			return (float)Math.Tan((double)f);
		}

		// Token: 0x06001618 RID: 5656 RVA: 0x000230C8 File Offset: 0x000212C8
		public static float Asin(float f)
		{
			return (float)Math.Asin((double)f);
		}

		// Token: 0x06001619 RID: 5657 RVA: 0x000230E4 File Offset: 0x000212E4
		public static float Acos(float f)
		{
			return (float)Math.Acos((double)f);
		}

		// Token: 0x0600161A RID: 5658 RVA: 0x00023100 File Offset: 0x00021300
		public static float Atan(float f)
		{
			return (float)Math.Atan((double)f);
		}

		// Token: 0x0600161B RID: 5659 RVA: 0x0002311C File Offset: 0x0002131C
		public static float Atan2(float y, float x)
		{
			return (float)Math.Atan2((double)y, (double)x);
		}

		// Token: 0x0600161C RID: 5660 RVA: 0x00023138 File Offset: 0x00021338
		public static float Sqrt(float f)
		{
			return (float)Math.Sqrt((double)f);
		}

		// Token: 0x0600161D RID: 5661 RVA: 0x00023154 File Offset: 0x00021354
		public static float Abs(float f)
		{
			return Math.Abs(f);
		}

		// Token: 0x0600161E RID: 5662 RVA: 0x0002316C File Offset: 0x0002136C
		public static int Abs(int value)
		{
			return Math.Abs(value);
		}

		// Token: 0x0600161F RID: 5663 RVA: 0x00023184 File Offset: 0x00021384
		public static float Min(float a, float b)
		{
			return (a < b) ? a : b;
		}

		// Token: 0x06001620 RID: 5664 RVA: 0x000231A0 File Offset: 0x000213A0
		public static float Min(params float[] values)
		{
			int num = values.Length;
			bool flag = num == 0;
			float result;
			if (flag)
			{
				result = 0f;
			}
			else
			{
				float num2 = values[0];
				for (int i = 1; i < num; i++)
				{
					bool flag2 = values[i] < num2;
					if (flag2)
					{
						num2 = values[i];
					}
				}
				result = num2;
			}
			return result;
		}

		// Token: 0x06001621 RID: 5665 RVA: 0x000231F8 File Offset: 0x000213F8
		public static int Min(int a, int b)
		{
			return (a < b) ? a : b;
		}

		// Token: 0x06001622 RID: 5666 RVA: 0x00023214 File Offset: 0x00021414
		public static int Min(params int[] values)
		{
			int num = values.Length;
			bool flag = num == 0;
			int result;
			if (flag)
			{
				result = 0;
			}
			else
			{
				int num2 = values[0];
				for (int i = 1; i < num; i++)
				{
					bool flag2 = values[i] < num2;
					if (flag2)
					{
						num2 = values[i];
					}
				}
				result = num2;
			}
			return result;
		}

		// Token: 0x06001623 RID: 5667 RVA: 0x00023268 File Offset: 0x00021468
		public static float Max(float a, float b)
		{
			return (a > b) ? a : b;
		}

		// Token: 0x06001624 RID: 5668 RVA: 0x00023284 File Offset: 0x00021484
		public static float Max(params float[] values)
		{
			int num = values.Length;
			bool flag = num == 0;
			float result;
			if (flag)
			{
				result = 0f;
			}
			else
			{
				float num2 = values[0];
				for (int i = 1; i < num; i++)
				{
					bool flag2 = values[i] > num2;
					if (flag2)
					{
						num2 = values[i];
					}
				}
				result = num2;
			}
			return result;
		}

		// Token: 0x06001625 RID: 5669 RVA: 0x000232DC File Offset: 0x000214DC
		public static int Max(int a, int b)
		{
			return (a > b) ? a : b;
		}

		// Token: 0x06001626 RID: 5670 RVA: 0x000232F8 File Offset: 0x000214F8
		public static int Max(params int[] values)
		{
			int num = values.Length;
			bool flag = num == 0;
			int result;
			if (flag)
			{
				result = 0;
			}
			else
			{
				int num2 = values[0];
				for (int i = 1; i < num; i++)
				{
					bool flag2 = values[i] > num2;
					if (flag2)
					{
						num2 = values[i];
					}
				}
				result = num2;
			}
			return result;
		}

		// Token: 0x06001627 RID: 5671 RVA: 0x0002334C File Offset: 0x0002154C
		public static float Pow(float f, float p)
		{
			return (float)Math.Pow((double)f, (double)p);
		}

		// Token: 0x06001628 RID: 5672 RVA: 0x00023368 File Offset: 0x00021568
		public static float Exp(float power)
		{
			return (float)Math.Exp((double)power);
		}

		// Token: 0x06001629 RID: 5673 RVA: 0x00023384 File Offset: 0x00021584
		public static float Log(float f, float p)
		{
			return (float)Math.Log((double)f, (double)p);
		}

		// Token: 0x0600162A RID: 5674 RVA: 0x000233A0 File Offset: 0x000215A0
		public static float Log(float f)
		{
			return (float)Math.Log((double)f);
		}

		// Token: 0x0600162B RID: 5675 RVA: 0x000233BC File Offset: 0x000215BC
		public static float Log10(float f)
		{
			return (float)Math.Log10((double)f);
		}

		// Token: 0x0600162C RID: 5676 RVA: 0x000233D8 File Offset: 0x000215D8
		public static float Ceil(float f)
		{
			return (float)Math.Ceiling((double)f);
		}

		// Token: 0x0600162D RID: 5677 RVA: 0x000233F4 File Offset: 0x000215F4
		public static float Floor(float f)
		{
			return (float)Math.Floor((double)f);
		}

		// Token: 0x0600162E RID: 5678 RVA: 0x00023410 File Offset: 0x00021610
		public static float Round(float f)
		{
			return (float)Math.Round((double)f);
		}

		// Token: 0x0600162F RID: 5679 RVA: 0x0002342C File Offset: 0x0002162C
		public static int CeilToInt(float f)
		{
			return (int)Math.Ceiling((double)f);
		}

		// Token: 0x06001630 RID: 5680 RVA: 0x00023448 File Offset: 0x00021648
		public static int FloorToInt(float f)
		{
			return (int)Math.Floor((double)f);
		}

		// Token: 0x06001631 RID: 5681 RVA: 0x00023464 File Offset: 0x00021664
		public static int RoundToInt(float f)
		{
			return (int)Math.Round((double)f);
		}

		// Token: 0x06001632 RID: 5682 RVA: 0x00023480 File Offset: 0x00021680
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float Sign(float f)
		{
			return (f >= 0f) ? 1f : -1f;
		}

		// Token: 0x06001633 RID: 5683 RVA: 0x000234A8 File Offset: 0x000216A8
		public static float Clamp(float value, float min, float max)
		{
			bool flag = value < min;
			if (flag)
			{
				value = min;
			}
			else
			{
				bool flag2 = value > max;
				if (flag2)
				{
					value = max;
				}
			}
			return value;
		}

		// Token: 0x06001634 RID: 5684 RVA: 0x000234D4 File Offset: 0x000216D4
		public static int Clamp(int value, int min, int max)
		{
			bool flag = value < min;
			if (flag)
			{
				value = min;
			}
			else
			{
				bool flag2 = value > max;
				if (flag2)
				{
					value = max;
				}
			}
			return value;
		}

		// Token: 0x06001635 RID: 5685 RVA: 0x00023500 File Offset: 0x00021700
		public static float Clamp01(float value)
		{
			bool flag = value < 0f;
			float result;
			if (flag)
			{
				result = 0f;
			}
			else
			{
				bool flag2 = value > 1f;
				if (flag2)
				{
					result = 1f;
				}
				else
				{
					result = value;
				}
			}
			return result;
		}

		// Token: 0x06001636 RID: 5686 RVA: 0x0002353C File Offset: 0x0002173C
		public static float Lerp(float a, float b, float t)
		{
			return a + (b - a) * Mathf.Clamp01(t);
		}

		// Token: 0x06001637 RID: 5687 RVA: 0x0002355C File Offset: 0x0002175C
		public static float LerpUnclamped(float a, float b, float t)
		{
			return a + (b - a) * t;
		}

		// Token: 0x06001638 RID: 5688 RVA: 0x00023578 File Offset: 0x00021778
		public static float LerpAngle(float a, float b, float t)
		{
			float num = Mathf.Repeat(b - a, 360f);
			bool flag = num > 180f;
			if (flag)
			{
				num -= 360f;
			}
			return a + num * Mathf.Clamp01(t);
		}

		// Token: 0x06001639 RID: 5689 RVA: 0x000235B8 File Offset: 0x000217B8
		public static float MoveTowards(float current, float target, float maxDelta)
		{
			bool flag = Mathf.Abs(target - current) <= maxDelta;
			float result;
			if (flag)
			{
				result = target;
			}
			else
			{
				result = current + Mathf.Sign(target - current) * maxDelta;
			}
			return result;
		}

		// Token: 0x0600163A RID: 5690 RVA: 0x000235EC File Offset: 0x000217EC
		public static float MoveTowardsAngle(float current, float target, float maxDelta)
		{
			float num = Mathf.DeltaAngle(current, target);
			bool flag = -maxDelta < num && num < maxDelta;
			float result;
			if (flag)
			{
				result = target;
			}
			else
			{
				target = current + num;
				result = Mathf.MoveTowards(current, target, maxDelta);
			}
			return result;
		}

		// Token: 0x0600163B RID: 5691 RVA: 0x00023628 File Offset: 0x00021828
		public static float SmoothStep(float from, float to, float t)
		{
			t = Mathf.Clamp01(t);
			t = -2f * t * t * t + 3f * t * t;
			return to * t + from * (1f - t);
		}

		// Token: 0x0600163C RID: 5692 RVA: 0x00023668 File Offset: 0x00021868
		public static float Gamma(float value, float absmax, float gamma)
		{
			bool flag = value < 0f;
			float num = Mathf.Abs(value);
			bool flag2 = num > absmax;
			float result;
			if (flag2)
			{
				result = (flag ? (-num) : num);
			}
			else
			{
				float num2 = Mathf.Pow(num / absmax, gamma) * absmax;
				result = (flag ? (-num2) : num2);
			}
			return result;
		}

		// Token: 0x0600163D RID: 5693 RVA: 0x000236B4 File Offset: 0x000218B4
		public static bool Approximately(float a, float b)
		{
			return Mathf.Abs(b - a) < Mathf.Max(1E-06f * Mathf.Max(Mathf.Abs(a), Mathf.Abs(b)), Mathf.Epsilon * 8f);
		}

		// Token: 0x0600163E RID: 5694 RVA: 0x000236F8 File Offset: 0x000218F8
		[ExcludeFromDocs]
		public static float SmoothDamp(float current, float target, ref float currentVelocity, float smoothTime, float maxSpeed)
		{
			float deltaTime = Time.deltaTime;
			return Mathf.SmoothDamp(current, target, ref currentVelocity, smoothTime, maxSpeed, deltaTime);
		}

		// Token: 0x0600163F RID: 5695 RVA: 0x0002371C File Offset: 0x0002191C
		[ExcludeFromDocs]
		public static float SmoothDamp(float current, float target, ref float currentVelocity, float smoothTime)
		{
			float deltaTime = Time.deltaTime;
			float positiveInfinity = float.PositiveInfinity;
			return Mathf.SmoothDamp(current, target, ref currentVelocity, smoothTime, positiveInfinity, deltaTime);
		}

		// Token: 0x06001640 RID: 5696 RVA: 0x00023748 File Offset: 0x00021948
		public static float SmoothDamp(float current, float target, ref float currentVelocity, float smoothTime, [DefaultValue("Mathf.Infinity")] float maxSpeed, [DefaultValue("Time.deltaTime")] float deltaTime)
		{
			smoothTime = Mathf.Max(0.0001f, smoothTime);
			float num = 2f / smoothTime;
			float num2 = num * deltaTime;
			float num3 = 1f / (1f + num2 + 0.48f * num2 * num2 + 0.235f * num2 * num2 * num2);
			float num4 = current - target;
			float num5 = target;
			float num6 = maxSpeed * smoothTime;
			num4 = Mathf.Clamp(num4, -num6, num6);
			target = current - num4;
			float num7 = (currentVelocity + num * num4) * deltaTime;
			currentVelocity = (currentVelocity - num * num7) * num3;
			float num8 = target + (num4 + num7) * num3;
			bool flag = num5 - current > 0f == num8 > num5;
			if (flag)
			{
				num8 = num5;
				currentVelocity = (num8 - num5) / deltaTime;
			}
			return num8;
		}

		// Token: 0x06001641 RID: 5697 RVA: 0x00023804 File Offset: 0x00021A04
		[ExcludeFromDocs]
		public static float SmoothDampAngle(float current, float target, ref float currentVelocity, float smoothTime, float maxSpeed)
		{
			float deltaTime = Time.deltaTime;
			return Mathf.SmoothDampAngle(current, target, ref currentVelocity, smoothTime, maxSpeed, deltaTime);
		}

		// Token: 0x06001642 RID: 5698 RVA: 0x00023828 File Offset: 0x00021A28
		[ExcludeFromDocs]
		public static float SmoothDampAngle(float current, float target, ref float currentVelocity, float smoothTime)
		{
			float deltaTime = Time.deltaTime;
			float positiveInfinity = float.PositiveInfinity;
			return Mathf.SmoothDampAngle(current, target, ref currentVelocity, smoothTime, positiveInfinity, deltaTime);
		}

		// Token: 0x06001643 RID: 5699 RVA: 0x00023854 File Offset: 0x00021A54
		public static float SmoothDampAngle(float current, float target, ref float currentVelocity, float smoothTime, [DefaultValue("Mathf.Infinity")] float maxSpeed, [DefaultValue("Time.deltaTime")] float deltaTime)
		{
			target = current + Mathf.DeltaAngle(current, target);
			return Mathf.SmoothDamp(current, target, ref currentVelocity, smoothTime, maxSpeed, deltaTime);
		}

		// Token: 0x06001644 RID: 5700 RVA: 0x00023880 File Offset: 0x00021A80
		public static float Repeat(float t, float length)
		{
			return Mathf.Clamp(t - Mathf.Floor(t / length) * length, 0f, length);
		}

		// Token: 0x06001645 RID: 5701 RVA: 0x000238AC File Offset: 0x00021AAC
		public static float PingPong(float t, float length)
		{
			t = Mathf.Repeat(t, length * 2f);
			return length - Mathf.Abs(t - length);
		}

		// Token: 0x06001646 RID: 5702 RVA: 0x000238D8 File Offset: 0x00021AD8
		public static float InverseLerp(float a, float b, float value)
		{
			bool flag = a != b;
			float result;
			if (flag)
			{
				result = Mathf.Clamp01((value - a) / (b - a));
			}
			else
			{
				result = 0f;
			}
			return result;
		}

		// Token: 0x06001647 RID: 5703 RVA: 0x0002390C File Offset: 0x00021B0C
		public static float DeltaAngle(float current, float target)
		{
			float num = Mathf.Repeat(target - current, 360f);
			bool flag = num > 180f;
			if (flag)
			{
				num -= 360f;
			}
			return num;
		}

		// Token: 0x06001648 RID: 5704 RVA: 0x00023944 File Offset: 0x00021B44
		internal static bool LineIntersection(Vector2 p1, Vector2 p2, Vector2 p3, Vector2 p4, ref Vector2 result)
		{
			float num = p2.x - p1.x;
			float num2 = p2.y - p1.y;
			float num3 = p4.x - p3.x;
			float num4 = p4.y - p3.y;
			float num5 = num * num4 - num2 * num3;
			bool flag = num5 == 0f;
			bool result2;
			if (flag)
			{
				result2 = false;
			}
			else
			{
				float num6 = p3.x - p1.x;
				float num7 = p3.y - p1.y;
				float num8 = (num6 * num4 - num7 * num3) / num5;
				result.x = p1.x + num8 * num;
				result.y = p1.y + num8 * num2;
				result2 = true;
			}
			return result2;
		}

		// Token: 0x06001649 RID: 5705 RVA: 0x00023A00 File Offset: 0x00021C00
		internal static bool LineSegmentIntersection(Vector2 p1, Vector2 p2, Vector2 p3, Vector2 p4, ref Vector2 result)
		{
			float num = p2.x - p1.x;
			float num2 = p2.y - p1.y;
			float num3 = p4.x - p3.x;
			float num4 = p4.y - p3.y;
			float num5 = num * num4 - num2 * num3;
			bool flag = num5 == 0f;
			bool result2;
			if (flag)
			{
				result2 = false;
			}
			else
			{
				float num6 = p3.x - p1.x;
				float num7 = p3.y - p1.y;
				float num8 = (num6 * num4 - num7 * num3) / num5;
				bool flag2 = num8 < 0f || num8 > 1f;
				if (flag2)
				{
					result2 = false;
				}
				else
				{
					float num9 = (num6 * num2 - num7 * num) / num5;
					bool flag3 = num9 < 0f || num9 > 1f;
					if (flag3)
					{
						result2 = false;
					}
					else
					{
						result.x = p1.x + num8 * num;
						result.y = p1.y + num8 * num2;
						result2 = true;
					}
				}
			}
			return result2;
		}

		// Token: 0x0600164A RID: 5706 RVA: 0x00023B10 File Offset: 0x00021D10
		internal static long RandomToLong(Random r)
		{
			byte[] array = new byte[8];
			r.NextBytes(array);
			return (long)(BitConverter.ToUInt64(array, 0) & 9223372036854775807UL);
		}

		// Token: 0x0600164B RID: 5707 RVA: 0x00023B44 File Offset: 0x00021D44
		internal static float ClampToFloat(double value)
		{
			bool flag = double.IsPositiveInfinity(value);
			float result;
			if (flag)
			{
				result = float.PositiveInfinity;
			}
			else
			{
				bool flag2 = double.IsNegativeInfinity(value);
				if (flag2)
				{
					result = float.NegativeInfinity;
				}
				else
				{
					bool flag3 = value < -3.4028234663852886E+38;
					if (flag3)
					{
						result = float.MinValue;
					}
					else
					{
						bool flag4 = value > 3.4028234663852886E+38;
						if (flag4)
						{
							result = float.MaxValue;
						}
						else
						{
							result = (float)value;
						}
					}
				}
			}
			return result;
		}

		// Token: 0x0600164C RID: 5708 RVA: 0x00023BB0 File Offset: 0x00021DB0
		internal static int ClampToInt(long value)
		{
			bool flag = value < -2147483648L;
			int result;
			if (flag)
			{
				result = int.MinValue;
			}
			else
			{
				bool flag2 = value > 2147483647L;
				if (flag2)
				{
					result = int.MaxValue;
				}
				else
				{
					result = (int)value;
				}
			}
			return result;
		}

		// Token: 0x0600164D RID: 5709 RVA: 0x00023BF0 File Offset: 0x00021DF0
		internal static uint ClampToUInt(long value)
		{
			bool flag = value < 0L;
			uint result;
			if (flag)
			{
				result = 0U;
			}
			else
			{
				bool flag2 = value > (long)((ulong)-1);
				if (flag2)
				{
					result = uint.MaxValue;
				}
				else
				{
					result = (uint)value;
				}
			}
			return result;
		}

		// Token: 0x0600164E RID: 5710 RVA: 0x00023C20 File Offset: 0x00021E20
		internal static float RoundToMultipleOf(float value, float roundingValue)
		{
			bool flag = roundingValue == 0f;
			float result;
			if (flag)
			{
				result = value;
			}
			else
			{
				result = Mathf.Round(value / roundingValue) * roundingValue;
			}
			return result;
		}

		// Token: 0x0600164F RID: 5711 RVA: 0x00023C4C File Offset: 0x00021E4C
		internal static float GetClosestPowerOfTen(float positiveNumber)
		{
			bool flag = positiveNumber <= 0f;
			float result;
			if (flag)
			{
				result = 1f;
			}
			else
			{
				result = Mathf.Pow(10f, (float)Mathf.RoundToInt(Mathf.Log10(positiveNumber)));
			}
			return result;
		}

		// Token: 0x06001650 RID: 5712 RVA: 0x00023C8C File Offset: 0x00021E8C
		internal static int GetNumberOfDecimalsForMinimumDifference(float minDifference)
		{
			return Mathf.Clamp(-Mathf.FloorToInt(Mathf.Log10(Mathf.Abs(minDifference))), 0, 15);
		}

		// Token: 0x06001651 RID: 5713 RVA: 0x00023CB8 File Offset: 0x00021EB8
		internal static int GetNumberOfDecimalsForMinimumDifference(double minDifference)
		{
			return (int)Math.Max(0.0, -Math.Floor(Math.Log10(Math.Abs(minDifference))));
		}

		// Token: 0x06001652 RID: 5714 RVA: 0x00023CEC File Offset: 0x00021EEC
		internal static float RoundBasedOnMinimumDifference(float valueToRound, float minDifference)
		{
			bool flag = minDifference == 0f;
			float result;
			if (flag)
			{
				result = Mathf.DiscardLeastSignificantDecimal(valueToRound);
			}
			else
			{
				result = (float)Math.Round((double)valueToRound, Mathf.GetNumberOfDecimalsForMinimumDifference(minDifference), MidpointRounding.AwayFromZero);
			}
			return result;
		}

		// Token: 0x06001653 RID: 5715 RVA: 0x00023D24 File Offset: 0x00021F24
		internal static double RoundBasedOnMinimumDifference(double valueToRound, double minDifference)
		{
			bool flag = minDifference == 0.0;
			double result;
			if (flag)
			{
				result = Mathf.DiscardLeastSignificantDecimal(valueToRound);
			}
			else
			{
				result = Math.Round(valueToRound, Mathf.GetNumberOfDecimalsForMinimumDifference(minDifference), MidpointRounding.AwayFromZero);
			}
			return result;
		}

		// Token: 0x06001654 RID: 5716 RVA: 0x00023D5C File Offset: 0x00021F5C
		internal static float DiscardLeastSignificantDecimal(float v)
		{
			int digits = Mathf.Clamp((int)(5f - Mathf.Log10(Mathf.Abs(v))), 0, 15);
			return (float)Math.Round((double)v, digits, MidpointRounding.AwayFromZero);
		}

		// Token: 0x06001655 RID: 5717 RVA: 0x00023D94 File Offset: 0x00021F94
		internal static double DiscardLeastSignificantDecimal(double v)
		{
			int digits = Math.Max(0, (int)(5.0 - Math.Log10(Math.Abs(v))));
			double result;
			try
			{
				result = Math.Round(v, digits);
			}
			catch (ArgumentOutOfRangeException)
			{
				result = 0.0;
			}
			return result;
		}

		// Token: 0x06001657 RID: 5719
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void CorrelatedColorTemperatureToRGB_Injected(float kelvin, out Color ret);

		// Token: 0x04000811 RID: 2065
		public const float PI = 3.1415927f;

		// Token: 0x04000812 RID: 2066
		public const float Infinity = float.PositiveInfinity;

		// Token: 0x04000813 RID: 2067
		public const float NegativeInfinity = float.NegativeInfinity;

		// Token: 0x04000814 RID: 2068
		public const float Deg2Rad = 0.017453292f;

		// Token: 0x04000815 RID: 2069
		public const float Rad2Deg = 57.29578f;

		// Token: 0x04000816 RID: 2070
		internal const int kMaxDecimals = 15;

		// Token: 0x04000817 RID: 2071
		public static readonly float Epsilon = MathfInternal.IsFlushToZeroEnabled ? MathfInternal.FloatMinNormal : MathfInternal.FloatMinDenormal;
	}
}
