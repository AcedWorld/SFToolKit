using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Unity.Netcode
{
	// Token: 0x0200000A RID: 10
	public static class QuaternionCompressor
	{
		// Token: 0x0600001D RID: 29 RVA: 0x00002708 File Offset: 0x00000908
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint CompressQuaternion(ref Quaternion quaternion)
		{
			QuaternionCompressor.s_QuatAbsValues[0] = Mathf.Abs(quaternion[0]);
			QuaternionCompressor.s_QuatAbsValues[1] = Mathf.Abs(quaternion[1]);
			QuaternionCompressor.s_QuatAbsValues[2] = Mathf.Abs(quaternion[2]);
			QuaternionCompressor.s_QuatAbsValues[3] = Mathf.Abs(quaternion[3]);
			float num = Mathf.Max(new float[]
			{
				QuaternionCompressor.s_QuatAbsValues[0],
				QuaternionCompressor.s_QuatAbsValues[1],
				QuaternionCompressor.s_QuatAbsValues[2],
				QuaternionCompressor.s_QuatAbsValues[3]
			});
			ushort num2 = (QuaternionCompressor.s_QuatAbsValues[0] == num) ? 0 : ((QuaternionCompressor.s_QuatAbsValues[1] == num) ? 1 : ((QuaternionCompressor.s_QuatAbsValues[2] == num) ? 2 : 3));
			ushort num3 = (quaternion[(int)num2] < 0f) ? 1 : 0;
			uint num4 = (uint)num2;
			int num5 = 0;
			num4 = ((num5 != (int)num2) ? (num4 << 10 | ((((quaternion[num5] < 0f) ? 1 : 0) != num3) ? 1U : 0U) << 9 | (uint)((ushort)Mathf.Round(722.66315f * QuaternionCompressor.s_QuatAbsValues[num5]))) : num4);
			num5++;
			num4 = ((num5 != (int)num2) ? (num4 << 10 | ((((quaternion[num5] < 0f) ? 1 : 0) != num3) ? 1U : 0U) << 9 | (uint)((ushort)Mathf.Round(722.66315f * QuaternionCompressor.s_QuatAbsValues[num5]))) : num4);
			num5++;
			num4 = ((num5 != (int)num2) ? (num4 << 10 | ((((quaternion[num5] < 0f) ? 1 : 0) != num3) ? 1U : 0U) << 9 | (uint)((ushort)Mathf.Round(722.66315f * QuaternionCompressor.s_QuatAbsValues[num5]))) : num4);
			num5++;
			return (num5 != (int)num2) ? (num4 << 10 | ((((quaternion[num5] < 0f) ? 1 : 0) != num3) ? 1U : 0U) << 9 | (uint)((ushort)Mathf.Round(722.66315f * QuaternionCompressor.s_QuatAbsValues[num5]))) : num4;
		}

		// Token: 0x0600001E RID: 30 RVA: 0x00002928 File Offset: 0x00000B28
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void DecompressQuaternion(ref Quaternion quaternion, uint compressed)
		{
			int num = (int)(compressed >> 30);
			float num2 = 0f;
			for (int i = 3; i >= 0; i--)
			{
				if (i != num)
				{
					quaternion[i] = (((compressed & 512U) > 0U) ? -1f : 1f) * ((compressed & 511U) * 0.0013837706f);
					num2 += quaternion[i] * quaternion[i];
					compressed >>= 10;
				}
			}
			quaternion[num] = Mathf.Sqrt(1f - num2);
		}

		// Token: 0x0400001C RID: 28
		private const ushort k_PrecisionMask = 511;

		// Token: 0x0400001D RID: 29
		private const float k_SqrtTwoOverTwoEncoding = 0.70710677f;

		// Token: 0x0400001E RID: 30
		private const float k_CompressionEcodingMask = 722.66315f;

		// Token: 0x0400001F RID: 31
		private const ushort k_ShiftNegativeBit = 9;

		// Token: 0x04000020 RID: 32
		private const float k_DcompressionDecodingMask = 0.0013837706f;

		// Token: 0x04000021 RID: 33
		private const ushort k_NegShortBit = 512;

		// Token: 0x04000022 RID: 34
		private const ushort k_True = 1;

		// Token: 0x04000023 RID: 35
		private const ushort k_False = 0;

		// Token: 0x04000024 RID: 36
		private static Quaternion s_QuatAbsValues = Quaternion.identity;
	}
}
