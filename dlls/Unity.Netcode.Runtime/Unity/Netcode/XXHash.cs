using System;
using System.Runtime.CompilerServices;
using System.Text;

namespace Unity.Netcode
{
	// Token: 0x02000048 RID: 72
	internal static class XXHash
	{
		// Token: 0x06000209 RID: 521 RVA: 0x0000AC10 File Offset: 0x00008E10
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static uint Hash32(byte* input, int length, uint seed = 0U)
		{
			uint num = seed + 374761393U;
			if (length >= 16)
			{
				uint num2 = seed + 2654435761U + 2246822519U;
				uint num3 = seed + 2246822519U;
				uint num4 = seed;
				uint num5 = seed - 2654435761U;
				int num6 = length >> 4;
				for (int i = 0; i < num6; i++)
				{
					uint num7 = *(uint*)input;
					uint num8 = *(uint*)(input + 4);
					uint num9 = *(uint*)(input + 8);
					uint num10 = *(uint*)(input + 12);
					num2 += num7 * 2246822519U;
					num2 = (num2 << 13 | num2 >> 19);
					num2 *= 2654435761U;
					num3 += num8 * 2246822519U;
					num3 = (num3 << 13 | num3 >> 19);
					num3 *= 2654435761U;
					num4 += num9 * 2246822519U;
					num4 = (num4 << 13 | num4 >> 19);
					num4 *= 2654435761U;
					num5 += num10 * 2246822519U;
					num5 = (num5 << 13 | num5 >> 19);
					num5 *= 2654435761U;
					input += 16;
				}
				num = (num2 << 1 | num2 >> 31) + (num3 << 7 | num3 >> 25) + (num4 << 12 | num4 >> 20) + (num5 << 18 | num5 >> 14);
			}
			num += (uint)length;
			for (length &= 15; length >= 4; length -= 4)
			{
				num += *(uint*)input * 3266489917U;
				num = (num << 17 | num >> 15) * 668265263U;
				input += 4;
			}
			while (length > 0)
			{
				num += (uint)(*input) * 374761393U;
				num = (num << 11 | num >> 21) * 2654435761U;
				input++;
				length--;
			}
			num ^= num >> 15;
			num *= 2246822519U;
			num ^= num >> 13;
			num *= 3266489917U;
			return num ^ num >> 16;
		}

		// Token: 0x0600020A RID: 522 RVA: 0x0000ADB0 File Offset: 0x00008FB0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static ulong Hash64(byte* input, int length, uint seed = 0U)
		{
			ulong num = (ulong)seed + 2870177450012600261UL;
			if (length >= 32)
			{
				ulong num2 = (ulong)seed + 11400714785074694791UL + 14029467366897019727UL;
				ulong num3 = (ulong)seed + 14029467366897019727UL;
				ulong num4 = (ulong)seed;
				ulong num5 = (ulong)seed - 11400714785074694791UL;
				int num6 = length >> 5;
				for (int i = 0; i < num6; i++)
				{
					ulong num7 = (ulong)(*(long*)input);
					ulong num8 = (ulong)(*(long*)(input + 8));
					ulong num9 = (ulong)(*(long*)(input + 16));
					ulong num10 = (ulong)(*(long*)(input + 24));
					num2 += num7 * 14029467366897019727UL;
					num2 = (num2 << 31 | num2 >> 33);
					num2 *= 11400714785074694791UL;
					num3 += num8 * 14029467366897019727UL;
					num3 = (num3 << 31 | num3 >> 33);
					num3 *= 11400714785074694791UL;
					num4 += num9 * 14029467366897019727UL;
					num4 = (num4 << 31 | num4 >> 33);
					num4 *= 11400714785074694791UL;
					num5 += num10 * 14029467366897019727UL;
					num5 = (num5 << 31 | num5 >> 33);
					num5 *= 11400714785074694791UL;
					input += 32;
				}
				num = (num2 << 1 | num2 >> 63) + (num3 << 7 | num3 >> 57) + (num4 << 12 | num4 >> 52) + (num5 << 18 | num5 >> 46);
				num2 *= 14029467366897019727UL;
				num2 = (num2 << 31 | num2 >> 33);
				num2 *= 11400714785074694791UL;
				num ^= num2;
				num = num * 11400714785074694791UL + 9650029242287828579UL;
				num3 *= 14029467366897019727UL;
				num3 = (num3 << 31 | num3 >> 33);
				num3 *= 11400714785074694791UL;
				num ^= num3;
				num = num * 11400714785074694791UL + 9650029242287828579UL;
				num4 *= 14029467366897019727UL;
				num4 = (num4 << 31 | num4 >> 33);
				num4 *= 11400714785074694791UL;
				num ^= num4;
				num = num * 11400714785074694791UL + 9650029242287828579UL;
				num5 *= 14029467366897019727UL;
				num5 = (num5 << 31 | num5 >> 33);
				num5 *= 11400714785074694791UL;
				num ^= num5;
				num = num * 11400714785074694791UL + 9650029242287828579UL;
			}
			num += (ulong)((long)length);
			for (length &= 31; length >= 8; length -= 8)
			{
				ulong num11 = (ulong)(*(long*)input * -4417276706812531889L);
				num11 = (num11 << 31 | num11 >> 33) * 11400714785074694791UL;
				num ^= num11;
				num = (num << 27 | num >> 37) * 11400714785074694791UL + 9650029242287828579UL;
				input += 8;
			}
			if (length >= 4)
			{
				num ^= (ulong)(*(uint*)input) * 11400714785074694791UL;
				num = (num << 23 | num >> 41) * 14029467366897019727UL + 1609587929392839161UL;
				input += 4;
				length -= 4;
			}
			while (length > 0)
			{
				num ^= (ulong)(*input) * 2870177450012600261UL;
				num = (num << 11 | num >> 53) * 11400714785074694791UL;
				input++;
				length--;
			}
			num ^= num >> 33;
			num *= 14029467366897019727UL;
			num ^= num >> 29;
			num *= 1609587929392839161UL;
			return num ^ num >> 32;
		}

		// Token: 0x0600020B RID: 523 RVA: 0x0000B100 File Offset: 0x00009300
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static uint Hash32(this byte[] buffer)
		{
			int length = buffer.Length;
			byte* input;
			if (buffer == null || buffer.Length == 0)
			{
				input = null;
			}
			else
			{
				input = &buffer[0];
			}
			return XXHash.Hash32(input, length, 0U);
		}

		// Token: 0x0600020C RID: 524 RVA: 0x0000B131 File Offset: 0x00009331
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint Hash32(this string text)
		{
			return Encoding.UTF8.GetBytes(text).Hash32();
		}

		// Token: 0x0600020D RID: 525 RVA: 0x0000B143 File Offset: 0x00009343
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint Hash32(this Type type)
		{
			return type.FullName.Hash32();
		}

		// Token: 0x0600020E RID: 526 RVA: 0x0000B150 File Offset: 0x00009350
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint Hash32<T>()
		{
			return typeof(T).Hash32();
		}

		// Token: 0x0600020F RID: 527 RVA: 0x0000B164 File Offset: 0x00009364
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static ulong Hash64(this byte[] buffer)
		{
			int length = buffer.Length;
			byte* input;
			if (buffer == null || buffer.Length == 0)
			{
				input = null;
			}
			else
			{
				input = &buffer[0];
			}
			return XXHash.Hash64(input, length, 0U);
		}

		// Token: 0x06000210 RID: 528 RVA: 0x0000B195 File Offset: 0x00009395
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ulong Hash64(this string text)
		{
			return Encoding.UTF8.GetBytes(text).Hash64();
		}

		// Token: 0x06000211 RID: 529 RVA: 0x0000B1A7 File Offset: 0x000093A7
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ulong Hash64(this Type type)
		{
			return type.FullName.Hash64();
		}

		// Token: 0x06000212 RID: 530 RVA: 0x0000B1B4 File Offset: 0x000093B4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ulong Hash64<T>()
		{
			return typeof(T).Hash64();
		}
	}
}
