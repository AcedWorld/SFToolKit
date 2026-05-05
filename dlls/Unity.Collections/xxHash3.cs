using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Mathematics;

namespace Unity.Collections
{
	// Token: 0x020000D0 RID: 208
	[BurstCompatible]
	[BurstCompile]
	[BurstCompatible]
	[BurstCompatible]
	public static class xxHash3
	{
		// Token: 0x0600084D RID: 2125 RVA: 0x00019FF8 File Offset: 0x000181F8
		internal unsafe static void Avx2HashLongInternalLoop(ulong* acc, byte* input, byte* dest, long length, byte* secret, int isHash64)
		{
			if (X86.Avx2.IsAvx2Supported)
			{
				long num = (length - 1L) / 1024L;
				int num2 = 0;
				while ((long)num2 < num)
				{
					xxHash3.Avx2Accumulate(acc, input + num2 * 1024, (dest == null) ? null : (dest + num2 * 1024), secret, 16L, isHash64);
					xxHash3.Avx2ScrambleAcc(acc, secret + 192 - 64);
					num2++;
				}
				long nbStripes = (length - 1L - 1024L * num) / 64L;
				xxHash3.Avx2Accumulate(acc, input + num * 1024L, (dest == null) ? null : (dest + num * 1024L), secret, nbStripes, isHash64);
				byte* input2 = input + length - 64;
				xxHash3.Avx2Accumulate512(acc, input2, null, secret + 192 - 64 - 7);
				if (dest != null)
				{
					long num3 = length % 64L;
					if (num3 != 0L)
					{
						UnsafeUtility.MemCpy((void*)(dest + length - num3), (void*)(input + length - num3), num3);
					}
				}
			}
		}

		// Token: 0x0600084E RID: 2126 RVA: 0x0001A0E4 File Offset: 0x000182E4
		internal unsafe static void Avx2ScrambleAcc(ulong* acc, byte* secret)
		{
			if (X86.Avx2.IsAvx2Supported)
			{
				v256 b = X86.Avx.mm256_set1_epi32(-1640531535);
				v256 a = *(v256*)acc;
				v256 b2 = X86.Avx2.mm256_srli_epi64(a, 47);
				v256 a2 = X86.Avx2.mm256_xor_si256(a, b2);
				v256 b3 = X86.Avx.mm256_loadu_si256((void*)secret);
				v256 a3 = X86.Avx2.mm256_xor_si256(a2, b3);
				v256 a4 = X86.Avx2.mm256_shuffle_epi32(a3, X86.Sse.SHUFFLE(0, 3, 0, 1));
				v256 a5 = X86.Avx2.mm256_mul_epu32(a3, b);
				v256 a6 = X86.Avx2.mm256_mul_epu32(a4, b);
				*(v256*)acc = X86.Avx2.mm256_add_epi64(a5, X86.Avx2.mm256_slli_epi64(a6, 32));
				v256 a7 = *(v256*)(acc + sizeof(v256) / 8);
				b2 = X86.Avx2.mm256_srli_epi64(a7, 47);
				v256 a8 = X86.Avx2.mm256_xor_si256(a7, b2);
				b3 = X86.Avx.mm256_loadu_si256((void*)(secret + sizeof(v256)));
				v256 a9 = X86.Avx2.mm256_xor_si256(a8, b3);
				a4 = X86.Avx2.mm256_shuffle_epi32(a9, X86.Sse.SHUFFLE(0, 3, 0, 1));
				a5 = X86.Avx2.mm256_mul_epu32(a9, b);
				a6 = X86.Avx2.mm256_mul_epu32(a4, b);
				*(v256*)(acc + sizeof(v256) / 8) = X86.Avx2.mm256_add_epi64(a5, X86.Avx2.mm256_slli_epi64(a6, 32));
			}
		}

		// Token: 0x0600084F RID: 2127 RVA: 0x0001A1DC File Offset: 0x000183DC
		internal unsafe static void Avx2Accumulate(ulong* acc, byte* input, byte* dest, byte* secret, long nbStripes, int isHash64)
		{
			if (X86.Avx2.IsAvx2Supported)
			{
				int num = 0;
				while ((long)num < nbStripes)
				{
					byte* input2 = input + num * 64;
					xxHash3.Avx2Accumulate512(acc, input2, (dest == null) ? null : (dest + num * 64), secret + num * 8);
					num++;
				}
			}
		}

		// Token: 0x06000850 RID: 2128 RVA: 0x0001A220 File Offset: 0x00018420
		internal unsafe static void Avx2Accumulate512(ulong* acc, byte* input, byte* dest, byte* secret)
		{
			if (X86.Avx2.IsAvx2Supported)
			{
				v256 v = X86.Avx.mm256_loadu_si256((void*)input);
				v256 b = X86.Avx.mm256_loadu_si256((void*)secret);
				v256 a = X86.Avx2.mm256_xor_si256(v, b);
				if (dest != null)
				{
					X86.Avx.mm256_storeu_si256((void*)dest, v);
				}
				v256 b2 = X86.Avx2.mm256_shuffle_epi32(a, X86.Sse.SHUFFLE(0, 3, 0, 1));
				v256 a2 = X86.Avx2.mm256_mul_epu32(a, b2);
				v256 b3 = X86.Avx2.mm256_shuffle_epi32(v, X86.Sse.SHUFFLE(1, 0, 3, 2));
				v256 b4 = X86.Avx2.mm256_add_epi64(*(v256*)acc, b3);
				*(v256*)acc = X86.Avx2.mm256_add_epi64(a2, b4);
				v = X86.Avx.mm256_loadu_si256((void*)(input + sizeof(v256)));
				b = X86.Avx.mm256_loadu_si256((void*)(secret + sizeof(v256)));
				v256 a3 = X86.Avx2.mm256_xor_si256(v, b);
				if (dest != null)
				{
					X86.Avx.mm256_storeu_si256((void*)(dest + 32), v);
				}
				b2 = X86.Avx2.mm256_shuffle_epi32(a3, X86.Sse.SHUFFLE(0, 3, 0, 1));
				a2 = X86.Avx2.mm256_mul_epu32(a3, b2);
				b3 = X86.Avx2.mm256_shuffle_epi32(v, X86.Sse.SHUFFLE(1, 0, 3, 2));
				b4 = X86.Avx2.mm256_add_epi64(*(v256*)(acc + sizeof(v256) / 8), b3);
				*(v256*)(acc + sizeof(v256) / 8) = X86.Avx2.mm256_add_epi64(a2, b4);
			}
		}

		// Token: 0x06000851 RID: 2129 RVA: 0x0001A334 File Offset: 0x00018534
		public unsafe static uint2 Hash64(void* input, long length)
		{
			byte[] kSecret;
			void* secret;
			if ((kSecret = xxHashDefaultKey.kSecret) == null || kSecret.Length == 0)
			{
				secret = null;
			}
			else
			{
				secret = (void*)(&kSecret[0]);
			}
			return xxHash3.ToUint2(xxHash3.Hash64Internal((byte*)input, null, length, (byte*)secret, 0UL));
		}

		// Token: 0x06000852 RID: 2130 RVA: 0x0001A36E File Offset: 0x0001856E
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int)
		})]
		public static uint2 Hash64<[IsUnmanaged] T>(in T input) where T : struct, ValueType
		{
			return xxHash3.Hash64(UnsafeUtilityExtensions.AddressOf<T>(input), (long)UnsafeUtility.SizeOf<T>());
		}

		// Token: 0x06000853 RID: 2131 RVA: 0x0001A384 File Offset: 0x00018584
		public unsafe static uint2 Hash64(void* input, long length, ulong seed)
		{
			byte[] kSecret;
			byte* secret;
			if ((kSecret = xxHashDefaultKey.kSecret) == null || kSecret.Length == 0)
			{
				secret = null;
			}
			else
			{
				secret = &kSecret[0];
			}
			return xxHash3.ToUint2(xxHash3.Hash64Internal((byte*)input, null, length, secret, seed));
		}

		// Token: 0x06000854 RID: 2132 RVA: 0x0001A3C0 File Offset: 0x000185C0
		public unsafe static uint4 Hash128(void* input, long length)
		{
			byte[] kSecret;
			void* secret;
			if ((kSecret = xxHashDefaultKey.kSecret) == null || kSecret.Length == 0)
			{
				secret = null;
			}
			else
			{
				secret = (void*)(&kSecret[0]);
			}
			uint4 result;
			xxHash3.Hash128Internal((byte*)input, null, length, (byte*)secret, 0UL, out result);
			return result;
		}

		// Token: 0x06000855 RID: 2133 RVA: 0x0001A3F8 File Offset: 0x000185F8
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int)
		})]
		public static uint4 Hash128<[IsUnmanaged] T>(in T input) where T : struct, ValueType
		{
			return xxHash3.Hash128(UnsafeUtilityExtensions.AddressOf<T>(input), (long)UnsafeUtility.SizeOf<T>());
		}

		// Token: 0x06000856 RID: 2134 RVA: 0x0001A40C File Offset: 0x0001860C
		public unsafe static uint4 Hash128(void* input, void* destination, long length)
		{
			byte[] kSecret;
			byte* secret;
			if ((kSecret = xxHashDefaultKey.kSecret) == null || kSecret.Length == 0)
			{
				secret = null;
			}
			else
			{
				secret = &kSecret[0];
			}
			uint4 result;
			xxHash3.Hash128Internal((byte*)input, (byte*)destination, length, secret, 0UL, out result);
			return result;
		}

		// Token: 0x06000857 RID: 2135 RVA: 0x0001A444 File Offset: 0x00018644
		public unsafe static uint4 Hash128(void* input, long length, ulong seed)
		{
			byte[] kSecret;
			byte* secret;
			if ((kSecret = xxHashDefaultKey.kSecret) == null || kSecret.Length == 0)
			{
				secret = null;
			}
			else
			{
				secret = &kSecret[0];
			}
			uint4 result;
			xxHash3.Hash128Internal((byte*)input, null, length, secret, seed, out result);
			return result;
		}

		// Token: 0x06000858 RID: 2136 RVA: 0x0001A47C File Offset: 0x0001867C
		public unsafe static uint4 Hash128(void* input, void* destination, long length, ulong seed)
		{
			byte[] kSecret;
			byte* secret;
			if ((kSecret = xxHashDefaultKey.kSecret) == null || kSecret.Length == 0)
			{
				secret = null;
			}
			else
			{
				secret = &kSecret[0];
			}
			uint4 result;
			xxHash3.Hash128Internal((byte*)input, (byte*)destination, length, secret, seed, out result);
			return result;
		}

		// Token: 0x06000859 RID: 2137 RVA: 0x0001A4B4 File Offset: 0x000186B4
		internal unsafe static ulong Hash64Internal(byte* input, byte* dest, long length, byte* secret, ulong seed)
		{
			if (length < 16L)
			{
				return xxHash3.Hash64Len0To16(input, length, secret, seed);
			}
			if (length < 128L)
			{
				return xxHash3.Hash64Len17To128(input, length, secret, seed);
			}
			if (length < 240L)
			{
				return xxHash3.Hash64Len129To240(input, length, secret, seed);
			}
			if (seed != 0UL)
			{
				byte* ptr = (byte*)Memory.Unmanaged.Allocate(192L, 64, Allocator.Temp);
				xxHash3.EncodeSecretKey(ptr, secret, seed);
				ulong result = xxHash3.Hash64Long(input, dest, length, ptr);
				Memory.Unmanaged.Free<byte>(ptr, Allocator.Temp);
				return result;
			}
			return xxHash3.Hash64Long(input, dest, length, secret);
		}

		// Token: 0x0600085A RID: 2138 RVA: 0x0001A53C File Offset: 0x0001873C
		internal unsafe static void Hash128Internal(byte* input, byte* dest, long length, byte* secret, ulong seed, out uint4 result)
		{
			if (dest != null && length < 240L)
			{
				UnsafeUtility.MemCpy((void*)dest, (void*)input, length);
			}
			if (length < 16L)
			{
				xxHash3.Hash128Len0To16(input, length, secret, seed, out result);
				return;
			}
			if (length < 128L)
			{
				xxHash3.Hash128Len17To128(input, length, secret, seed, out result);
				return;
			}
			if (length < 240L)
			{
				xxHash3.Hash128Len129To240(input, length, secret, seed, out result);
				return;
			}
			if (seed != 0UL)
			{
				byte* ptr = stackalloc byte[(UIntPtr)223] + 31L & -32L;
				xxHash3.EncodeSecretKey(ptr, secret, seed);
				xxHash3.Hash128Long(input, dest, length, ptr, out result);
				return;
			}
			xxHash3.Hash128Long(input, dest, length, secret, out result);
		}

		// Token: 0x0600085B RID: 2139 RVA: 0x0001A5D8 File Offset: 0x000187D8
		private unsafe static ulong Hash64Len1To3(byte* input, long len, byte* secret, ulong seed)
		{
			ulong num = (ulong)(*input);
			byte b = input[len >> 1];
			byte b2 = input[len - 1L];
			ulong num2 = num << 16 | (ulong)((ulong)b << 24) | (ulong)b2 | (ulong)((ulong)((uint)len) << 8);
			ulong num3 = (ulong)(xxHash3.Read32LE((void*)secret) ^ xxHash3.Read32LE((void*)(secret + 4))) + seed;
			return xxHash3.AvalancheH64(num2 ^ num3);
		}

		// Token: 0x0600085C RID: 2140 RVA: 0x0001A624 File Offset: 0x00018824
		private unsafe static ulong Hash64Len4To8(byte* input, long length, byte* secret, ulong seed)
		{
			seed ^= (ulong)xxHash3.Swap32((uint)seed) << 32;
			uint num = xxHash3.Read32LE((void*)input);
			ulong num2 = (ulong)xxHash3.Read32LE((void*)(input + length - 4));
			ulong num3 = (xxHash3.Read64LE((void*)(secret + 8)) ^ xxHash3.Read64LE((void*)(secret + 16))) - seed;
			return xxHash3.rrmxmx(num2 + ((ulong)num << 32) ^ num3, (ulong)length);
		}

		// Token: 0x0600085D RID: 2141 RVA: 0x0001A678 File Offset: 0x00018878
		private unsafe static ulong Hash64Len9To16(byte* input, long length, byte* secret, ulong seed)
		{
			ulong num = (xxHash3.Read64LE((void*)(secret + 24)) ^ xxHash3.Read64LE((void*)(secret + 32))) + seed;
			ulong num2 = (xxHash3.Read64LE((void*)(secret + 40)) ^ xxHash3.Read64LE((void*)(secret + 48))) - seed;
			ulong num3 = xxHash3.Read64LE((void*)input) ^ num;
			ulong num4 = xxHash3.Read64LE((void*)(input + length - 8)) ^ num2;
			return xxHash3.Avalanche((ulong)(length + (long)xxHash3.Swap64(num3) + (long)num4 + (long)xxHash3.Mul128Fold64(num3, num4)));
		}

		// Token: 0x0600085E RID: 2142 RVA: 0x0001A6E0 File Offset: 0x000188E0
		private unsafe static ulong Hash64Len0To16(byte* input, long length, byte* secret, ulong seed)
		{
			if (length > 8L)
			{
				return xxHash3.Hash64Len9To16(input, length, secret, seed);
			}
			if (length >= 4L)
			{
				return xxHash3.Hash64Len4To8(input, length, secret, seed);
			}
			if (length > 0L)
			{
				return xxHash3.Hash64Len1To3(input, length, secret, seed);
			}
			return xxHash3.AvalancheH64(seed ^ (xxHash3.Read64LE((void*)(secret + 56)) ^ xxHash3.Read64LE((void*)(secret + 64))));
		}

		// Token: 0x0600085F RID: 2143 RVA: 0x0001A734 File Offset: 0x00018934
		private unsafe static ulong Hash64Len17To128(byte* input, long length, byte* secret, ulong seed)
		{
			ulong num = (ulong)(length * -7046029288634856825L);
			if (length > 32L)
			{
				if (length > 64L)
				{
					if (length > 96L)
					{
						num += xxHash3.Mix16(input + 48, secret + 96, seed);
						num += xxHash3.Mix16(input + length - 64, secret + 112, seed);
					}
					num += xxHash3.Mix16(input + 32, secret + 64, seed);
					num += xxHash3.Mix16(input + length - 48, secret + 80, seed);
				}
				num += xxHash3.Mix16(input + 16, secret + 32, seed);
				num += xxHash3.Mix16(input + length - 32, secret + 48, seed);
			}
			num += xxHash3.Mix16(input, secret, seed);
			num += xxHash3.Mix16(input + length - 16, secret + 16, seed);
			return xxHash3.Avalanche(num);
		}

		// Token: 0x06000860 RID: 2144 RVA: 0x0001A7F4 File Offset: 0x000189F4
		private unsafe static ulong Hash64Len129To240(byte* input, long length, byte* secret, ulong seed)
		{
			ulong num = (ulong)(length * -7046029288634856825L);
			int num2 = (int)length / 16;
			for (int i = 0; i < 8; i++)
			{
				num += xxHash3.Mix16(input + 16 * i, secret + 16 * i, seed);
			}
			num = xxHash3.Avalanche(num);
			for (int j = 8; j < num2; j++)
			{
				num += xxHash3.Mix16(input + 16 * j, secret + 16 * (j - 8) + 3, seed);
			}
			num += xxHash3.Mix16(input + length - 16, secret + 136 - 17, seed);
			return xxHash3.Avalanche(num);
		}

		// Token: 0x06000861 RID: 2145 RVA: 0x0001A880 File Offset: 0x00018A80
		[BurstCompile]
		private unsafe static ulong Hash64Long(byte* input, byte* dest, long length, byte* secret)
		{
			return xxHash3.Hash64Long_0000071F$BurstDirectCall.Invoke(input, dest, length, secret);
		}

		// Token: 0x06000862 RID: 2146 RVA: 0x0001A88C File Offset: 0x00018A8C
		private unsafe static void Hash128Len1To3(byte* input, long length, byte* secret, ulong seed, out uint4 result)
		{
			int num = (int)(*input);
			byte b = input[length >> 1];
			byte b2 = input[length - 1L];
			int num2 = (num << 16) + ((int)b << 24) + (int)b2 + (int)((int)((uint)length) << 8);
			uint num3 = xxHash3.RotL32(xxHash3.Swap32((uint)num2), 13);
			ulong num4 = (ulong)(xxHash3.Read32LE((void*)secret) ^ xxHash3.Read32LE((void*)(secret + 4))) + seed;
			ulong num5 = (ulong)(xxHash3.Read32LE((void*)(secret + 8)) ^ xxHash3.Read32LE((void*)(secret + 12))) - seed;
			ulong h = (ulong)num2 ^ num4;
			ulong h2 = (ulong)num3 ^ num5;
			result = xxHash3.ToUint4(xxHash3.AvalancheH64(h), xxHash3.AvalancheH64(h2));
		}

		// Token: 0x06000863 RID: 2147 RVA: 0x0001A91C File Offset: 0x00018B1C
		private unsafe static void Hash128Len4To8(byte* input, long len, byte* secret, ulong seed, out uint4 result)
		{
			seed ^= (ulong)xxHash3.Swap32((uint)seed) << 32;
			ulong num = (ulong)xxHash3.Read32LE((void*)input);
			uint num2 = xxHash3.Read32LE((void*)(input + len - 4));
			ulong num3 = num + ((ulong)num2 << 32);
			ulong num4 = (xxHash3.Read64LE((void*)(secret + 16)) ^ xxHash3.Read64LE((void*)(secret + 24))) + seed;
			ulong num6;
			ulong num5 = Common.umul128(num3 ^ num4, (ulong)(-7046029288634856825L + (len << 2)), out num6);
			num6 += num5 << 1;
			num5 ^= num6 >> 3;
			num5 = xxHash3.XorShift64(num5, 35);
			num5 *= 11507291218515648293UL;
			num5 = xxHash3.XorShift64(num5, 28);
			num6 = xxHash3.Avalanche(num6);
			result = xxHash3.ToUint4(num5, num6);
		}

		// Token: 0x06000864 RID: 2148 RVA: 0x0001A9C0 File Offset: 0x00018BC0
		private unsafe static void Hash128Len9To16(byte* input, long len, byte* secret, ulong seed, out uint4 result)
		{
			ulong num = (xxHash3.Read64LE((void*)(secret + 32)) ^ xxHash3.Read64LE((void*)(secret + 40))) - seed;
			ulong num2 = (xxHash3.Read64LE((void*)(secret + 48)) ^ xxHash3.Read64LE((void*)(secret + 56))) + seed;
			ulong num3 = xxHash3.Read64LE((void*)input);
			ulong num4 = xxHash3.Read64LE((void*)(input + len - 8));
			ulong num6;
			ulong num5 = Common.umul128(num3 ^ num4 ^ num, 11400714785074694791UL, out num6) + (ulong)((ulong)(len - 1L) << 54);
			num4 ^= num2;
			num6 += num4 + xxHash3.Mul32To64((uint)num4, 2246822518U);
			ulong num7;
			ulong h = Common.umul128(num5 ^ xxHash3.Swap64(num6), 14029467366897019727UL, out num7);
			num7 += num6 * 14029467366897019727UL;
			result = xxHash3.ToUint4(xxHash3.Avalanche(h), xxHash3.Avalanche(num7));
		}

		// Token: 0x06000865 RID: 2149 RVA: 0x0001AA80 File Offset: 0x00018C80
		private unsafe static void Hash128Len0To16(byte* input, long length, byte* secret, ulong seed, out uint4 result)
		{
			if (length > 8L)
			{
				xxHash3.Hash128Len9To16(input, length, secret, seed, out result);
				return;
			}
			if (length >= 4L)
			{
				xxHash3.Hash128Len4To8(input, length, secret, seed, out result);
				return;
			}
			if (length > 0L)
			{
				xxHash3.Hash128Len1To3(input, length, secret, seed, out result);
				return;
			}
			ulong num = xxHash3.Read64LE((void*)(secret + 64)) ^ xxHash3.Read64LE((void*)(secret + 72));
			ulong num2 = xxHash3.Read64LE((void*)(secret + 80)) ^ xxHash3.Read64LE((void*)(secret + 88));
			ulong ul = xxHash3.AvalancheH64(seed ^ num);
			ulong ul2 = xxHash3.AvalancheH64(seed ^ num2);
			result = xxHash3.ToUint4(ul, ul2);
		}

		// Token: 0x06000866 RID: 2150 RVA: 0x0001AB08 File Offset: 0x00018D08
		private unsafe static void Hash128Len17To128(byte* input, long length, byte* secret, ulong seed, out uint4 result)
		{
			xxHash3.ulong2 @ulong = new xxHash3.ulong2((ulong)(length * -7046029288634856825L), 0UL);
			if (length > 32L)
			{
				if (length > 64L)
				{
					if (length > 96L)
					{
						@ulong = xxHash3.Mix32(@ulong, input + 48, input + length - 64, secret + 96, seed);
					}
					@ulong = xxHash3.Mix32(@ulong, input + 32, input + length - 48, secret + 64, seed);
				}
				@ulong = xxHash3.Mix32(@ulong, input + 16, input + length - 32, secret + 32, seed);
			}
			@ulong = xxHash3.Mix32(@ulong, input, input + length - 16, secret, seed);
			ulong h = @ulong.x + @ulong.y;
			ulong h2 = @ulong.x * 11400714785074694791UL + @ulong.y * 9650029242287828579UL + (ulong)((length - (long)seed) * -4417276706812531889L);
			result = xxHash3.ToUint4(xxHash3.Avalanche(h), 0UL - xxHash3.Avalanche(h2));
		}

		// Token: 0x06000867 RID: 2151 RVA: 0x0001ABEC File Offset: 0x00018DEC
		private unsafe static void Hash128Len129To240(byte* input, long length, byte* secret, ulong seed, out uint4 result)
		{
			xxHash3.ulong2 @ulong = new xxHash3.ulong2((ulong)(length * -7046029288634856825L), 0UL);
			long num = length / 32L;
			int i;
			for (i = 0; i < 4; i++)
			{
				@ulong = xxHash3.Mix32(@ulong, input + 32 * i, input + 32 * i + 16, secret + 32 * i, seed);
			}
			@ulong.x = xxHash3.Avalanche(@ulong.x);
			@ulong.y = xxHash3.Avalanche(@ulong.y);
			i = 4;
			while ((long)i < num)
			{
				@ulong = xxHash3.Mix32(@ulong, input + 32 * i, input + 32 * i + 16, secret + 3 + 32 * (i - 4), seed);
				i++;
			}
			@ulong = xxHash3.Mix32(@ulong, input + length - 16, input + length - 32, secret + 136 - 17 - 16, 0UL - seed);
			ulong h = @ulong.x + @ulong.y;
			ulong h2 = @ulong.x * 11400714785074694791UL + @ulong.y * 9650029242287828579UL + (ulong)((length - (long)seed) * -4417276706812531889L);
			result = xxHash3.ToUint4(xxHash3.Avalanche(h), 0UL - xxHash3.Avalanche(h2));
		}

		// Token: 0x06000868 RID: 2152 RVA: 0x0001AD0F File Offset: 0x00018F0F
		[BurstCompile]
		private unsafe static void Hash128Long(byte* input, byte* dest, long length, byte* secret, out uint4 result)
		{
			xxHash3.Hash128Long_00000726$BurstDirectCall.Invoke(input, dest, length, secret, out result);
		}

		// Token: 0x06000869 RID: 2153 RVA: 0x0001AD1C File Offset: 0x00018F1C
		internal static uint2 ToUint2(ulong u)
		{
			return new uint2((uint)(u & (ulong)-1), (uint)(u >> 32));
		}

		// Token: 0x0600086A RID: 2154 RVA: 0x0001AD2D File Offset: 0x00018F2D
		internal static uint4 ToUint4(ulong ul0, ulong ul1)
		{
			return new uint4((uint)(ul0 & (ulong)-1), (uint)(ul0 >> 32), (uint)(ul1 & (ulong)-1), (uint)(ul1 >> 32));
		}

		// Token: 0x0600086B RID: 2155 RVA: 0x0001AD48 File Offset: 0x00018F48
		internal unsafe static void EncodeSecretKey(byte* dst, byte* secret, ulong seed)
		{
			int num = 12;
			for (int i = 0; i < num; i++)
			{
				xxHash3.Write64LE((void*)(dst + 16 * i), xxHash3.Read64LE((void*)(secret + 16 * i)) + seed);
				xxHash3.Write64LE((void*)(dst + 16 * i + 8), xxHash3.Read64LE((void*)(secret + 16 * i + 8)) - seed);
			}
		}

		// Token: 0x0600086C RID: 2156 RVA: 0x0001AD98 File Offset: 0x00018F98
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private unsafe static ulong Read64LE(void* addr)
		{
			return (ulong)(*(long*)addr);
		}

		// Token: 0x0600086D RID: 2157 RVA: 0x0001AD9C File Offset: 0x00018F9C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private unsafe static uint Read32LE(void* addr)
		{
			return *(uint*)addr;
		}

		// Token: 0x0600086E RID: 2158 RVA: 0x0001ADA0 File Offset: 0x00018FA0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private unsafe static void Write64LE(void* addr, ulong value)
		{
			*(long*)addr = (long)value;
		}

		// Token: 0x0600086F RID: 2159 RVA: 0x0001ADA5 File Offset: 0x00018FA5
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private unsafe static void Read32LE(void* addr, uint value)
		{
			*(int*)addr = (int)value;
		}

		// Token: 0x06000870 RID: 2160 RVA: 0x0001ADAA File Offset: 0x00018FAA
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static ulong Mul32To64(uint x, uint y)
		{
			return (ulong)x * (ulong)y;
		}

		// Token: 0x06000871 RID: 2161 RVA: 0x0001ADB4 File Offset: 0x00018FB4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static ulong Swap64(ulong x)
		{
			return (x << 56 & 18374686479671623680UL) | (x << 40 & 71776119061217280UL) | (x << 24 & 280375465082880UL) | (x << 8 & 1095216660480UL) | (x >> 8 & (ulong)-16777216) | (x >> 24 & 16711680UL) | (x >> 40 & 65280UL) | (x >> 56 & 255UL);
		}

		// Token: 0x06000872 RID: 2162 RVA: 0x0001AE2A File Offset: 0x0001902A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static uint Swap32(uint x)
		{
			return (x << 24 & 4278190080U) | (x << 8 & 16711680U) | (x >> 8 & 65280U) | (x >> 24 & 255U);
		}

		// Token: 0x06000873 RID: 2163 RVA: 0x0001AE55 File Offset: 0x00019055
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static uint RotL32(uint x, int r)
		{
			return x << r | x >> 32 - r;
		}

		// Token: 0x06000874 RID: 2164 RVA: 0x0001AE67 File Offset: 0x00019067
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static ulong RotL64(ulong x, int r)
		{
			return x << r | x >> 64 - r;
		}

		// Token: 0x06000875 RID: 2165 RVA: 0x0001AE79 File Offset: 0x00019079
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static ulong XorShift64(ulong v64, int shift)
		{
			return v64 ^ v64 >> shift;
		}

		// Token: 0x06000876 RID: 2166 RVA: 0x0001AE84 File Offset: 0x00019084
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static ulong Mul128Fold64(ulong lhs, ulong rhs)
		{
			ulong num;
			return Common.umul128(lhs, rhs, out num) ^ num;
		}

		// Token: 0x06000877 RID: 2167 RVA: 0x0001AE9C File Offset: 0x0001909C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private unsafe static ulong Mix16(byte* input, byte* secret, ulong seed)
		{
			ulong num = xxHash3.Read64LE((void*)input);
			ulong num2 = xxHash3.Read64LE((void*)(input + 8));
			return xxHash3.Mul128Fold64(num ^ xxHash3.Read64LE((void*)secret) + seed, num2 ^ xxHash3.Read64LE((void*)(secret + 8)) - seed);
		}

		// Token: 0x06000878 RID: 2168 RVA: 0x0001AED4 File Offset: 0x000190D4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private unsafe static xxHash3.ulong2 Mix32(xxHash3.ulong2 acc, byte* input_1, byte* input_2, byte* secret, ulong seed)
		{
			ulong x = acc.x + xxHash3.Mix16(input_1, secret, seed) ^ xxHash3.Read64LE((void*)input_2) + xxHash3.Read64LE((void*)(input_2 + 8));
			ulong num = acc.y + xxHash3.Mix16(input_2, secret + 16, seed);
			num ^= xxHash3.Read64LE((void*)input_1) + xxHash3.Read64LE((void*)(input_1 + 8));
			return new xxHash3.ulong2(x, num);
		}

		// Token: 0x06000879 RID: 2169 RVA: 0x0001AF2D File Offset: 0x0001912D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static ulong Avalanche(ulong h64)
		{
			h64 = xxHash3.XorShift64(h64, 37);
			h64 *= 1609587791953885689UL;
			h64 = xxHash3.XorShift64(h64, 32);
			return h64;
		}

		// Token: 0x0600087A RID: 2170 RVA: 0x0001AF51 File Offset: 0x00019151
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static ulong AvalancheH64(ulong h64)
		{
			h64 ^= h64 >> 33;
			h64 *= 14029467366897019727UL;
			h64 ^= h64 >> 29;
			h64 *= 1609587929392839161UL;
			h64 ^= h64 >> 32;
			return h64;
		}

		// Token: 0x0600087B RID: 2171 RVA: 0x0001AF88 File Offset: 0x00019188
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static ulong rrmxmx(ulong h64, ulong length)
		{
			h64 ^= (xxHash3.RotL64(h64, 49) ^ xxHash3.RotL64(h64, 24));
			h64 *= 11507291218515648293UL;
			h64 ^= (h64 >> 35) + length;
			h64 *= 11507291218515648293UL;
			return xxHash3.XorShift64(h64, 28);
		}

		// Token: 0x0600087C RID: 2172 RVA: 0x0001AFD6 File Offset: 0x000191D6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private unsafe static ulong Mix2Acc(ulong acc0, ulong acc1, byte* secret)
		{
			return xxHash3.Mul128Fold64(acc0 ^ xxHash3.Read64LE((void*)secret), acc1 ^ xxHash3.Read64LE((void*)(secret + 8)));
		}

		// Token: 0x0600087D RID: 2173 RVA: 0x0001AFF0 File Offset: 0x000191F0
		internal unsafe static ulong MergeAcc(ulong* acc, byte* secret, ulong start)
		{
			return xxHash3.Avalanche(start + xxHash3.Mix2Acc(*acc, acc[1], secret) + xxHash3.Mix2Acc(acc[2], acc[3], secret + 16) + xxHash3.Mix2Acc(acc[4], acc[5], secret + 32) + xxHash3.Mix2Acc(acc[6], acc[7], secret + 48));
		}

		// Token: 0x0600087E RID: 2174 RVA: 0x0001B058 File Offset: 0x00019258
		private unsafe static void DefaultHashLongInternalLoop(ulong* acc, byte* input, byte* dest, long length, byte* secret, int isHash64)
		{
			long num = (length - 1L) / 1024L;
			int num2 = 0;
			while ((long)num2 < num)
			{
				xxHash3.DefaultAccumulate(acc, input + num2 * 1024, (dest == null) ? null : (dest + num2 * 1024), secret, 16L, isHash64);
				xxHash3.DefaultScrambleAcc(acc, secret + 192 - 64);
				num2++;
			}
			long nbStripes = (length - 1L - 1024L * num) / 64L;
			xxHash3.DefaultAccumulate(acc, input + num * 1024L, (dest == null) ? null : (dest + num * 1024L), secret, nbStripes, isHash64);
			byte* input2 = input + length - 64;
			xxHash3.DefaultAccumulate512(acc, input2, null, secret + 192 - 64 - 7, isHash64);
			if (dest != null)
			{
				long num3 = length % 64L;
				if (num3 != 0L)
				{
					UnsafeUtility.MemCpy((void*)(dest + length - num3), (void*)(input + length - num3), num3);
				}
			}
		}

		// Token: 0x0600087F RID: 2175 RVA: 0x0001B13C File Offset: 0x0001933C
		internal unsafe static void DefaultAccumulate(ulong* acc, byte* input, byte* dest, byte* secret, long nbStripes, int isHash64)
		{
			int num = 0;
			while ((long)num < nbStripes)
			{
				xxHash3.DefaultAccumulate512(acc, input + num * 64, (dest == null) ? null : (dest + num * 64), secret + num * 8, isHash64);
				num++;
			}
		}

		// Token: 0x06000880 RID: 2176 RVA: 0x0001B17C File Offset: 0x0001937C
		internal unsafe static void DefaultAccumulate512(ulong* acc, byte* input, byte* dest, byte* secret, int isHash64)
		{
			int num = 8;
			for (int i = 0; i < num; i++)
			{
				ulong num2 = xxHash3.Read64LE((void*)(input + 8 * i));
				ulong num3 = num2 ^ xxHash3.Read64LE((void*)(secret + i * 8));
				if (dest != null)
				{
					xxHash3.Write64LE((void*)(dest + 8 * i), num2);
				}
				acc[i ^ 1] += num2;
				acc[i] += xxHash3.Mul32To64((uint)(num3 & (ulong)-1), (uint)(num3 >> 32));
			}
		}

		// Token: 0x06000881 RID: 2177 RVA: 0x0001B1E8 File Offset: 0x000193E8
		internal unsafe static void DefaultScrambleAcc(ulong* acc, byte* secret)
		{
			for (int i = 0; i < 8; i++)
			{
				ulong num = xxHash3.Read64LE((void*)(secret + 8 * i));
				ulong num2 = acc[i];
				num2 = xxHash3.XorShift64(num2, 47);
				num2 ^= num;
				num2 *= (ulong)-1640531535;
				acc[i] = num2;
			}
		}

		// Token: 0x06000882 RID: 2178 RVA: 0x0001B234 File Offset: 0x00019434
		[BurstCompile]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static ulong Hash64Long$BurstManaged(byte* input, byte* dest, long length, byte* secret)
		{
			ulong* ptr = stackalloc ulong[(UIntPtr)95] + 31L / 8L & -32L;
			*ptr = (ulong)-1028477379;
			ptr[1] = 11400714785074694791UL;
			ptr[2] = 14029467366897019727UL;
			ptr[3] = 1609587929392839161UL;
			ptr[4] = 9650029242287828579UL;
			ptr[5] = (ulong)-2048144777;
			ptr[6] = 2870177450012600261UL;
			ptr[7] = (ulong)-1640531535;
			if (X86.Avx2.IsAvx2Supported)
			{
				xxHash3.Avx2HashLongInternalLoop(ptr, input, dest, length, secret, 1);
			}
			else
			{
				xxHash3.DefaultHashLongInternalLoop(ptr, input, dest, length, secret, 1);
			}
			return xxHash3.MergeAcc(ptr, secret + 11, (ulong)(length * -7046029288634856825L));
		}

		// Token: 0x06000883 RID: 2179 RVA: 0x0001B2F4 File Offset: 0x000194F4
		[BurstCompile]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static void Hash128Long$BurstManaged(byte* input, byte* dest, long length, byte* secret, out uint4 result)
		{
			ulong* ptr = stackalloc ulong[(UIntPtr)95] + 31L / 8L & -32L;
			*ptr = (ulong)-1028477379;
			ptr[1] = 11400714785074694791UL;
			ptr[2] = 14029467366897019727UL;
			ptr[3] = 1609587929392839161UL;
			ptr[4] = 9650029242287828579UL;
			ptr[5] = (ulong)-2048144777;
			ptr[6] = 2870177450012600261UL;
			ptr[7] = (ulong)-1640531535;
			if (X86.Avx2.IsAvx2Supported)
			{
				xxHash3.Avx2HashLongInternalLoop(ptr, input, dest, length, secret, 0);
			}
			else
			{
				xxHash3.DefaultHashLongInternalLoop(ptr, input, dest, length, secret, 0);
			}
			ulong ul = xxHash3.MergeAcc(ptr, secret + 11, (ulong)(length * -7046029288634856825L));
			ulong ul2 = xxHash3.MergeAcc(ptr, secret + 192 - 64 - 11, (ulong)(~(ulong)(length * -4417276706812531889L)));
			result = xxHash3.ToUint4(ul, ul2);
		}

		// Token: 0x040002E8 RID: 744
		private const int STRIPE_LEN = 64;

		// Token: 0x040002E9 RID: 745
		private const int ACC_NB = 8;

		// Token: 0x040002EA RID: 746
		private const int SECRET_CONSUME_RATE = 8;

		// Token: 0x040002EB RID: 747
		private const int SECRET_KEY_SIZE = 192;

		// Token: 0x040002EC RID: 748
		private const int SECRET_KEY_MIN_SIZE = 136;

		// Token: 0x040002ED RID: 749
		private const int SECRET_LASTACC_START = 7;

		// Token: 0x040002EE RID: 750
		private const int NB_ROUNDS = 16;

		// Token: 0x040002EF RID: 751
		private const int BLOCK_LEN = 1024;

		// Token: 0x040002F0 RID: 752
		private const uint PRIME32_1 = 2654435761U;

		// Token: 0x040002F1 RID: 753
		private const uint PRIME32_2 = 2246822519U;

		// Token: 0x040002F2 RID: 754
		private const uint PRIME32_3 = 3266489917U;

		// Token: 0x040002F3 RID: 755
		private const uint PRIME32_5 = 374761393U;

		// Token: 0x040002F4 RID: 756
		private const ulong PRIME64_1 = 11400714785074694791UL;

		// Token: 0x040002F5 RID: 757
		private const ulong PRIME64_2 = 14029467366897019727UL;

		// Token: 0x040002F6 RID: 758
		private const ulong PRIME64_3 = 1609587929392839161UL;

		// Token: 0x040002F7 RID: 759
		private const ulong PRIME64_4 = 9650029242287828579UL;

		// Token: 0x040002F8 RID: 760
		private const ulong PRIME64_5 = 2870177450012600261UL;

		// Token: 0x040002F9 RID: 761
		private const int MIDSIZE_MAX = 240;

		// Token: 0x040002FA RID: 762
		private const int MIDSIZE_STARTOFFSET = 3;

		// Token: 0x040002FB RID: 763
		private const int MIDSIZE_LASTOFFSET = 17;

		// Token: 0x040002FC RID: 764
		private const int SECRET_MERGEACCS_START = 11;

		// Token: 0x020000D1 RID: 209
		private struct ulong2
		{
			// Token: 0x06000884 RID: 2180 RVA: 0x0001B3E3 File Offset: 0x000195E3
			public ulong2(ulong x, ulong y)
			{
				this.x = x;
				this.y = y;
			}

			// Token: 0x040002FD RID: 765
			public ulong x;

			// Token: 0x040002FE RID: 766
			public ulong y;
		}

		// Token: 0x020000D2 RID: 210
		[BurstCompatible]
		public struct StreamingState
		{
			// Token: 0x06000885 RID: 2181 RVA: 0x0001B3F3 File Offset: 0x000195F3
			public StreamingState(bool isHash64, ulong seed = 0UL)
			{
				this.State = default(xxHash3.StreamingState.StreamingStateData);
				this.Reset(isHash64, seed);
			}

			// Token: 0x06000886 RID: 2182 RVA: 0x0001B40C File Offset: 0x0001960C
			public unsafe void Reset(bool isHash64, ulong seed = 0UL)
			{
				int num = UnsafeUtility.SizeOf<xxHash3.StreamingState.StreamingStateData>();
				UnsafeUtility.MemClear(UnsafeUtility.AddressOf<xxHash3.StreamingState.StreamingStateData>(ref this.State), (long)num);
				this.State.IsHash64 = (isHash64 ? 1 : 0);
				ulong* acc = this.Acc;
				*acc = (ulong)-1028477379;
				acc[1] = 11400714785074694791UL;
				acc[2] = 14029467366897019727UL;
				acc[3] = 1609587929392839161UL;
				acc[4] = 9650029242287828579UL;
				acc[5] = (ulong)-2048144777;
				acc[6] = 2870177450012600261UL;
				acc[7] = (ulong)-1640531535;
				this.State.Seed = seed;
				byte[] array;
				byte* ptr;
				if ((array = xxHashDefaultKey.kSecret) == null || array.Length == 0)
				{
					ptr = null;
				}
				else
				{
					ptr = &array[0];
				}
				if (seed != 0UL)
				{
					xxHash3.EncodeSecretKey(this.SecretKey, ptr, seed);
				}
				else
				{
					UnsafeUtility.MemCpy((void*)this.SecretKey, (void*)ptr, 192L);
				}
				array = null;
			}

			// Token: 0x06000887 RID: 2183 RVA: 0x0001B508 File Offset: 0x00019708
			public unsafe void Update(void* input, int length)
			{
				byte* ptr = (byte*)input;
				byte* ptr2 = ptr + length;
				int isHash = this.State.IsHash64;
				byte* secretKey = this.SecretKey;
				this.State.TotalLength = this.State.TotalLength + (long)length;
				if (this.State.BufferedSize + length <= xxHash3.StreamingState.INTERNAL_BUFFER_SIZE)
				{
					UnsafeUtility.MemCpy((void*)(this.Buffer + this.State.BufferedSize), (void*)ptr, (long)length);
					this.State.BufferedSize = this.State.BufferedSize + length;
					return;
				}
				if (this.State.BufferedSize != 0)
				{
					int num = xxHash3.StreamingState.INTERNAL_BUFFER_SIZE - this.State.BufferedSize;
					UnsafeUtility.MemCpy((void*)(this.Buffer + this.State.BufferedSize), (void*)ptr, (long)num);
					ptr += num;
					this.ConsumeStripes(this.Acc, ref this.State.NbStripesSoFar, this.Buffer, (long)xxHash3.StreamingState.INTERNAL_BUFFER_STRIPES, secretKey, isHash);
					this.State.BufferedSize = 0;
				}
				if (ptr + xxHash3.StreamingState.INTERNAL_BUFFER_SIZE < ptr2)
				{
					byte* ptr3 = ptr2 - xxHash3.StreamingState.INTERNAL_BUFFER_SIZE;
					do
					{
						this.ConsumeStripes(this.Acc, ref this.State.NbStripesSoFar, ptr, (long)xxHash3.StreamingState.INTERNAL_BUFFER_STRIPES, secretKey, isHash);
						ptr += xxHash3.StreamingState.INTERNAL_BUFFER_SIZE;
					}
					while (ptr < ptr3);
					UnsafeUtility.MemCpy((void*)(this.Buffer + xxHash3.StreamingState.INTERNAL_BUFFER_SIZE - 64), (void*)(ptr - 64), 64L);
				}
				if (ptr < ptr2)
				{
					long num2 = (long)(ptr2 - ptr);
					UnsafeUtility.MemCpy((void*)this.Buffer, (void*)ptr, num2);
					this.State.BufferedSize = (int)num2;
				}
			}

			// Token: 0x06000888 RID: 2184 RVA: 0x0001B672 File Offset: 0x00019872
			[BurstCompatible(GenericTypeArguments = new Type[]
			{
				typeof(int)
			})]
			public void Update<[IsUnmanaged] T>(in T input) where T : struct, ValueType
			{
				this.Update(UnsafeUtilityExtensions.AddressOf<T>(input), UnsafeUtility.SizeOf<T>());
			}

			// Token: 0x06000889 RID: 2185 RVA: 0x0001B688 File Offset: 0x00019888
			public unsafe uint4 DigestHash128()
			{
				byte* secretKey = this.SecretKey;
				uint4 result;
				if (this.State.TotalLength > 240L)
				{
					ulong* acc = stackalloc ulong[(UIntPtr)64];
					this.DigestLong(acc, secretKey, 0);
					ulong ul = xxHash3.MergeAcc(acc, secretKey + 11, (ulong)(this.State.TotalLength * -7046029288634856825L));
					ulong ul2 = xxHash3.MergeAcc(acc, secretKey + xxHash3.StreamingState.SECRET_LIMIT - 11, (ulong)(~(ulong)(this.State.TotalLength * -4417276706812531889L)));
					result = xxHash3.ToUint4(ul, ul2);
				}
				else
				{
					result = xxHash3.Hash128((void*)this.Buffer, this.State.TotalLength, this.State.Seed);
				}
				this.Reset(this.State.IsHash64 == 1, this.State.Seed);
				return result;
			}

			// Token: 0x0600088A RID: 2186 RVA: 0x0001B750 File Offset: 0x00019950
			public unsafe uint2 DigestHash64()
			{
				byte* secretKey = this.SecretKey;
				uint2 result;
				if (this.State.TotalLength > 240L)
				{
					ulong* acc = stackalloc ulong[(UIntPtr)64];
					this.DigestLong(acc, secretKey, 1);
					result = xxHash3.ToUint2(xxHash3.MergeAcc(acc, secretKey + 11, (ulong)(this.State.TotalLength * -7046029288634856825L)));
				}
				else
				{
					result = xxHash3.Hash64((void*)this.Buffer, this.State.TotalLength, this.State.Seed);
				}
				this.Reset(this.State.IsHash64 == 1, this.State.Seed);
				return result;
			}

			// Token: 0x170000E5 RID: 229
			// (get) Token: 0x0600088B RID: 2187 RVA: 0x0001B7EF File Offset: 0x000199EF
			private unsafe ulong* Acc
			{
				[DebuggerStepThrough]
				get
				{
					return (ulong*)UnsafeUtility.AddressOf<ulong>(ref this.State.Acc);
				}
			}

			// Token: 0x170000E6 RID: 230
			// (get) Token: 0x0600088C RID: 2188 RVA: 0x0001B801 File Offset: 0x00019A01
			private unsafe byte* Buffer
			{
				[DebuggerStepThrough]
				get
				{
					return (byte*)UnsafeUtility.AddressOf<byte>(ref this.State.Buffer);
				}
			}

			// Token: 0x170000E7 RID: 231
			// (get) Token: 0x0600088D RID: 2189 RVA: 0x0001B813 File Offset: 0x00019A13
			private unsafe byte* SecretKey
			{
				[DebuggerStepThrough]
				get
				{
					return (byte*)UnsafeUtility.AddressOf<byte>(ref this.State.SecretKey);
				}
			}

			// Token: 0x0600088E RID: 2190 RVA: 0x0001B828 File Offset: 0x00019A28
			private unsafe void DigestLong(ulong* acc, byte* secret, int isHash64)
			{
				UnsafeUtility.MemCpy((void*)acc, (void*)this.Acc, 64L);
				if (this.State.BufferedSize >= 64)
				{
					int num = (this.State.BufferedSize - 1) / 64;
					this.ConsumeStripes(acc, ref this.State.NbStripesSoFar, this.Buffer, (long)num, secret, isHash64);
					if (X86.Avx2.IsAvx2Supported)
					{
						xxHash3.Avx2Accumulate512(acc, this.Buffer + this.State.BufferedSize - 64, null, secret + xxHash3.StreamingState.SECRET_LIMIT - 7);
						return;
					}
					xxHash3.DefaultAccumulate512(acc, this.Buffer + this.State.BufferedSize - 64, null, secret + xxHash3.StreamingState.SECRET_LIMIT - 7, isHash64);
					return;
				}
				else
				{
					byte* ptr = stackalloc byte[(UIntPtr)64];
					int num2 = 64 - this.State.BufferedSize;
					UnsafeUtility.MemCpy((void*)ptr, (void*)(this.Buffer + xxHash3.StreamingState.INTERNAL_BUFFER_SIZE - num2), (long)num2);
					UnsafeUtility.MemCpy((void*)(ptr + num2), (void*)this.Buffer, (long)this.State.BufferedSize);
					if (X86.Avx2.IsAvx2Supported)
					{
						xxHash3.Avx2Accumulate512(acc, ptr, null, secret + xxHash3.StreamingState.SECRET_LIMIT - 7);
						return;
					}
					xxHash3.DefaultAccumulate512(acc, ptr, null, secret + xxHash3.StreamingState.SECRET_LIMIT - 7, isHash64);
					return;
				}
			}

			// Token: 0x0600088F RID: 2191 RVA: 0x0001B94C File Offset: 0x00019B4C
			private unsafe void ConsumeStripes(ulong* acc, ref int nbStripesSoFar, byte* input, long totalStripes, byte* secret, int isHash64)
			{
				if ((long)(xxHash3.StreamingState.NB_STRIPES_PER_BLOCK - nbStripesSoFar) <= totalStripes)
				{
					int num = xxHash3.StreamingState.NB_STRIPES_PER_BLOCK - nbStripesSoFar;
					if (X86.Avx2.IsAvx2Supported)
					{
						xxHash3.Avx2Accumulate(acc, input, null, secret + nbStripesSoFar * 8, (long)num, isHash64);
						xxHash3.Avx2ScrambleAcc(acc, secret + xxHash3.StreamingState.SECRET_LIMIT);
						xxHash3.Avx2Accumulate(acc, input + num * 64, null, secret, totalStripes - (long)num, isHash64);
					}
					else
					{
						xxHash3.DefaultAccumulate(acc, input, null, secret + nbStripesSoFar * 8, (long)num, isHash64);
						xxHash3.DefaultScrambleAcc(acc, secret + xxHash3.StreamingState.SECRET_LIMIT);
						xxHash3.DefaultAccumulate(acc, input + num * 64, null, secret, totalStripes - (long)num, isHash64);
					}
					nbStripesSoFar = (int)totalStripes - num;
					return;
				}
				if (X86.Avx2.IsAvx2Supported)
				{
					xxHash3.Avx2Accumulate(acc, input, null, secret + nbStripesSoFar * 8, totalStripes, isHash64);
				}
				else
				{
					xxHash3.DefaultAccumulate(acc, input, null, secret + nbStripesSoFar * 8, totalStripes, isHash64);
				}
				nbStripesSoFar += (int)totalStripes;
			}

			// Token: 0x06000890 RID: 2192 RVA: 0x0001BA30 File Offset: 0x00019C30
			[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
			[BurstDiscard]
			private void CheckKeySize(int isHash64)
			{
				if (this.State.IsHash64 != isHash64)
				{
					string str = (this.State.IsHash64 != 0) ? "64" : "128";
					throw new InvalidOperationException("The streaming state was create for " + str + " bits hash key, the calling method doesn't support this key size, please use the appropriate API");
				}
			}

			// Token: 0x040002FF RID: 767
			private static readonly int SECRET_LIMIT = 128;

			// Token: 0x04000300 RID: 768
			private static readonly int NB_STRIPES_PER_BLOCK = xxHash3.StreamingState.SECRET_LIMIT / 8;

			// Token: 0x04000301 RID: 769
			private static readonly int INTERNAL_BUFFER_SIZE = 256;

			// Token: 0x04000302 RID: 770
			private static readonly int INTERNAL_BUFFER_STRIPES = xxHash3.StreamingState.INTERNAL_BUFFER_SIZE / 64;

			// Token: 0x04000303 RID: 771
			private xxHash3.StreamingState.StreamingStateData State;

			// Token: 0x020000D3 RID: 211
			[StructLayout(LayoutKind.Explicit)]
			private struct StreamingStateData
			{
				// Token: 0x04000304 RID: 772
				[FieldOffset(0)]
				public ulong Acc;

				// Token: 0x04000305 RID: 773
				[FieldOffset(64)]
				public byte Buffer;

				// Token: 0x04000306 RID: 774
				[FieldOffset(320)]
				public int IsHash64;

				// Token: 0x04000307 RID: 775
				[FieldOffset(324)]
				public int BufferedSize;

				// Token: 0x04000308 RID: 776
				[FieldOffset(328)]
				public int NbStripesSoFar;

				// Token: 0x04000309 RID: 777
				[FieldOffset(336)]
				public long TotalLength;

				// Token: 0x0400030A RID: 778
				[FieldOffset(344)]
				public ulong Seed;

				// Token: 0x0400030B RID: 779
				[FieldOffset(352)]
				public byte SecretKey;

				// Token: 0x0400030C RID: 780
				[FieldOffset(540)]
				public byte _PadEnd;
			}
		}

		// Token: 0x020000D4 RID: 212
		// (Invoke) Token: 0x06000893 RID: 2195
		public unsafe delegate ulong Hash64Long_0000071F$PostfixBurstDelegate(byte* input, byte* dest, long length, byte* secret);

		// Token: 0x020000D5 RID: 213
		internal static class Hash64Long_0000071F$BurstDirectCall
		{
			// Token: 0x06000896 RID: 2198 RVA: 0x0001BAAA File Offset: 0x00019CAA
			[BurstDiscard]
			private unsafe static void GetFunctionPointerDiscard(ref IntPtr A_0)
			{
				if (xxHash3.Hash64Long_0000071F$BurstDirectCall.Pointer == 0)
				{
					xxHash3.Hash64Long_0000071F$BurstDirectCall.Pointer = BurstCompiler.GetILPPMethodFunctionPointer2(xxHash3.Hash64Long_0000071F$BurstDirectCall.DeferredCompilation, methodof(xxHash3.Hash64Long$BurstManaged(byte*, byte*, long, byte*)).MethodHandle, typeof(xxHash3.Hash64Long_0000071F$PostfixBurstDelegate).TypeHandle);
				}
				A_0 = xxHash3.Hash64Long_0000071F$BurstDirectCall.Pointer;
			}

			// Token: 0x06000897 RID: 2199 RVA: 0x0001BAD8 File Offset: 0x00019CD8
			private static IntPtr GetFunctionPointer()
			{
				IntPtr result = (IntPtr)0;
				xxHash3.Hash64Long_0000071F$BurstDirectCall.GetFunctionPointerDiscard(ref result);
				return result;
			}

			// Token: 0x06000898 RID: 2200 RVA: 0x0001BAF0 File Offset: 0x00019CF0
			public unsafe static void Constructor()
			{
				xxHash3.Hash64Long_0000071F$BurstDirectCall.DeferredCompilation = BurstCompiler.CompileILPPMethod2(methodof(xxHash3.Hash64Long(byte*, byte*, long, byte*)).MethodHandle);
			}

			// Token: 0x06000899 RID: 2201 RVA: 0x000024A3 File Offset: 0x000006A3
			public static void Initialize()
			{
			}

			// Token: 0x0600089A RID: 2202 RVA: 0x0001BB01 File Offset: 0x00019D01
			// Note: this type is marked as 'beforefieldinit'.
			static Hash64Long_0000071F$BurstDirectCall()
			{
				xxHash3.Hash64Long_0000071F$BurstDirectCall.Constructor();
			}

			// Token: 0x0600089B RID: 2203 RVA: 0x0001BB08 File Offset: 0x00019D08
			public unsafe static ulong Invoke(byte* input, byte* dest, long length, byte* secret)
			{
				if (BurstCompiler.IsEnabled)
				{
					IntPtr functionPointer = xxHash3.Hash64Long_0000071F$BurstDirectCall.GetFunctionPointer();
					if (functionPointer != 0)
					{
						return calli(System.UInt64(System.Byte*,System.Byte*,System.Int64,System.Byte*), input, dest, length, secret, functionPointer);
					}
				}
				return xxHash3.Hash64Long$BurstManaged(input, dest, length, secret);
			}

			// Token: 0x0400030D RID: 781
			private static IntPtr Pointer;

			// Token: 0x0400030E RID: 782
			private static IntPtr DeferredCompilation;
		}

		// Token: 0x020000D6 RID: 214
		// (Invoke) Token: 0x0600089D RID: 2205
		public unsafe delegate void Hash128Long_00000726$PostfixBurstDelegate(byte* input, byte* dest, long length, byte* secret, out uint4 result);

		// Token: 0x020000D7 RID: 215
		internal static class Hash128Long_00000726$BurstDirectCall
		{
			// Token: 0x060008A0 RID: 2208 RVA: 0x0001BB3F File Offset: 0x00019D3F
			[BurstDiscard]
			private unsafe static void GetFunctionPointerDiscard(ref IntPtr A_0)
			{
				if (xxHash3.Hash128Long_00000726$BurstDirectCall.Pointer == 0)
				{
					xxHash3.Hash128Long_00000726$BurstDirectCall.Pointer = BurstCompiler.GetILPPMethodFunctionPointer2(xxHash3.Hash128Long_00000726$BurstDirectCall.DeferredCompilation, methodof(xxHash3.Hash128Long$BurstManaged(byte*, byte*, long, byte*, uint4*)).MethodHandle, typeof(xxHash3.Hash128Long_00000726$PostfixBurstDelegate).TypeHandle);
				}
				A_0 = xxHash3.Hash128Long_00000726$BurstDirectCall.Pointer;
			}

			// Token: 0x060008A1 RID: 2209 RVA: 0x0001BB6C File Offset: 0x00019D6C
			private static IntPtr GetFunctionPointer()
			{
				IntPtr result = (IntPtr)0;
				xxHash3.Hash128Long_00000726$BurstDirectCall.GetFunctionPointerDiscard(ref result);
				return result;
			}

			// Token: 0x060008A2 RID: 2210 RVA: 0x0001BB84 File Offset: 0x00019D84
			public unsafe static void Constructor()
			{
				xxHash3.Hash128Long_00000726$BurstDirectCall.DeferredCompilation = BurstCompiler.CompileILPPMethod2(methodof(xxHash3.Hash128Long(byte*, byte*, long, byte*, uint4*)).MethodHandle);
			}

			// Token: 0x060008A3 RID: 2211 RVA: 0x000024A3 File Offset: 0x000006A3
			public static void Initialize()
			{
			}

			// Token: 0x060008A4 RID: 2212 RVA: 0x0001BB95 File Offset: 0x00019D95
			// Note: this type is marked as 'beforefieldinit'.
			static Hash128Long_00000726$BurstDirectCall()
			{
				xxHash3.Hash128Long_00000726$BurstDirectCall.Constructor();
			}

			// Token: 0x060008A5 RID: 2213 RVA: 0x0001BB9C File Offset: 0x00019D9C
			public unsafe static void Invoke(byte* input, byte* dest, long length, byte* secret, out uint4 result)
			{
				if (BurstCompiler.IsEnabled)
				{
					IntPtr functionPointer = xxHash3.Hash128Long_00000726$BurstDirectCall.GetFunctionPointer();
					if (functionPointer != 0)
					{
						calli(System.Void(System.Byte*,System.Byte*,System.Int64,System.Byte*,Unity.Mathematics.uint4&), input, dest, length, secret, ref result, functionPointer);
						return;
					}
				}
				xxHash3.Hash128Long$BurstManaged(input, dest, length, secret, out result);
			}

			// Token: 0x0400030F RID: 783
			private static IntPtr Pointer;

			// Token: 0x04000310 RID: 784
			private static IntPtr DeferredCompilation;
		}
	}
}
