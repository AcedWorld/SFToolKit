using System;
using Rewired.Utils;

namespace Rewired.ControllerExtensions
{
	// Token: 0x020003AB RID: 939
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false)]
	internal static class DualSenseTriggerEffect
	{
		// Token: 0x060025D7 RID: 9687 RVA: 0x0001BD6D File Offset: 0x00019F6D
		internal static bool IsInRange(byte value, byte min, byte max)
		{
			return value >= min && value <= max;
		}

		// Token: 0x060025D8 RID: 9688 RVA: 0x0001BD7C File Offset: 0x00019F7C
		internal static byte Clamp(byte value, byte min, byte max)
		{
			if (value < min)
			{
				DualSenseTriggerEffect.LogValueClamped(value, min);
				return min;
			}
			if (value > max)
			{
				DualSenseTriggerEffect.LogValueClamped(value, max);
				return max;
			}
			return value;
		}

		// Token: 0x060025D9 RID: 9689 RVA: 0x0001BD99 File Offset: 0x00019F99
		internal static float NormalizeStrength(byte value)
		{
			return MathTools.Clamp01((float)value / 8f);
		}

		// Token: 0x060025DA RID: 9690 RVA: 0x0001BDA8 File Offset: 0x00019FA8
		internal static float NormalizePosition(byte value)
		{
			return MathTools.Clamp01((float)value / 9f);
		}

		// Token: 0x060025DB RID: 9691 RVA: 0x0001BD99 File Offset: 0x00019F99
		internal static float NormalizeAmplitude(byte value)
		{
			return MathTools.Clamp01((float)value / 8f);
		}

		// Token: 0x060025DC RID: 9692 RVA: 0x0001BDB7 File Offset: 0x00019FB7
		internal static float NormalizeFrequency(byte value)
		{
			return MathTools.Clamp01((float)value / 255f);
		}

		// Token: 0x060025DD RID: 9693 RVA: 0x0001BDC6 File Offset: 0x00019FC6
		internal static void ThrowArgumentOutOfRange(string name, byte min, byte max)
		{
			throw new ArgumentOutOfRangeException(string.Concat(new string[]
			{
				name,
				" is outside the allowed range of ",
				min.ToString(),
				" - ",
				max.ToString()
			}));
		}

		// Token: 0x060025DE RID: 9694 RVA: 0x0001BE00 File Offset: 0x0001A000
		internal static void LogValueClamped(byte origValue, byte clampedValue)
		{
			Logger.LogWarning("Trigger effect parameter value " + origValue.ToString() + " was outside the allowed range and was clamped to " + clampedValue.ToString(), true);
		}

		// Token: 0x040015AD RID: 5549
		public const byte strengthMin = 0;

		// Token: 0x040015AE RID: 5550
		public const byte strengthMax = 8;

		// Token: 0x040015AF RID: 5551
		public const byte amplitudeMin = 0;

		// Token: 0x040015B0 RID: 5552
		public const byte amplitudeMax = 8;

		// Token: 0x040015B1 RID: 5553
		public const byte frequencyMin = 0;

		// Token: 0x040015B2 RID: 5554
		public const byte frequencyMax = 255;

		// Token: 0x040015B3 RID: 5555
		public const byte positionCount = 10;

		// Token: 0x040015B4 RID: 5556
		public const byte positionMin = 0;

		// Token: 0x040015B5 RID: 5557
		public const byte positionMax = 9;
	}
}
