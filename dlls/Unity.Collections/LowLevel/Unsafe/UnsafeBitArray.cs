using System;
using System.Diagnostics;
using Unity.Jobs;
using Unity.Mathematics;

namespace Unity.Collections.LowLevel.Unsafe
{
	// Token: 0x020000F2 RID: 242
	[DebuggerDisplay("Length = {Length}, IsCreated = {IsCreated}")]
	[DebuggerTypeProxy(typeof(UnsafeBitArrayDebugView))]
	[BurstCompatible]
	public struct UnsafeBitArray : INativeDisposable, IDisposable
	{
		// Token: 0x06000972 RID: 2418 RVA: 0x0001D9A8 File Offset: 0x0001BBA8
		public unsafe UnsafeBitArray(void* ptr, int sizeInBytes, AllocatorManager.AllocatorHandle allocator = default(AllocatorManager.AllocatorHandle))
		{
			this.Ptr = (ulong*)ptr;
			this.Length = sizeInBytes * 8;
			this.Allocator = allocator;
		}

		// Token: 0x06000973 RID: 2419 RVA: 0x0001D9C4 File Offset: 0x0001BBC4
		public unsafe UnsafeBitArray(int numBits, AllocatorManager.AllocatorHandle allocator, NativeArrayOptions options = NativeArrayOptions.ClearMemory)
		{
			this.Allocator = allocator;
			int num = Bitwise.AlignUp(numBits, 64) / 8;
			this.Ptr = (ulong*)Memory.Unmanaged.Allocate((long)num, 16, allocator);
			this.Length = numBits;
			if (options == NativeArrayOptions.ClearMemory)
			{
				UnsafeUtility.MemClear((void*)this.Ptr, (long)num);
			}
		}

		// Token: 0x170000F9 RID: 249
		// (get) Token: 0x06000974 RID: 2420 RVA: 0x0001DA0B File Offset: 0x0001BC0B
		public bool IsCreated
		{
			get
			{
				return this.Ptr != null;
			}
		}

		// Token: 0x06000975 RID: 2421 RVA: 0x0001DA1A File Offset: 0x0001BC1A
		public void Dispose()
		{
			if (CollectionHelper.ShouldDeallocate(this.Allocator))
			{
				Memory.Unmanaged.Free<ulong>(this.Ptr, this.Allocator);
				this.Allocator = AllocatorManager.Invalid;
			}
			this.Ptr = null;
			this.Length = 0;
		}

		// Token: 0x06000976 RID: 2422 RVA: 0x0001DA54 File Offset: 0x0001BC54
		[NotBurstCompatible]
		public unsafe JobHandle Dispose(JobHandle inputDeps)
		{
			if (CollectionHelper.ShouldDeallocate(this.Allocator))
			{
				JobHandle result = new UnsafeDisposeJob
				{
					Ptr = (void*)this.Ptr,
					Allocator = this.Allocator
				}.Schedule(inputDeps);
				this.Ptr = null;
				this.Allocator = AllocatorManager.Invalid;
				return result;
			}
			this.Ptr = null;
			return inputDeps;
		}

		// Token: 0x06000977 RID: 2423 RVA: 0x0001DAB4 File Offset: 0x0001BCB4
		public unsafe void Clear()
		{
			int num = Bitwise.AlignUp(this.Length, 64) / 8;
			UnsafeUtility.MemClear((void*)this.Ptr, (long)num);
		}

		// Token: 0x06000978 RID: 2424 RVA: 0x0001DAE0 File Offset: 0x0001BCE0
		public unsafe void Set(int pos, bool value)
		{
			int num = pos >> 6;
			int num2 = pos & 63;
			ulong num3 = 1UL << num2;
			ulong num4 = (this.Ptr[num] & ~num3) | (ulong)((long)(-(long)Bitwise.FromBool(value)) & (long)num3);
			this.Ptr[num] = num4;
		}

		// Token: 0x06000979 RID: 2425 RVA: 0x0001DB28 File Offset: 0x0001BD28
		public unsafe void SetBits(int pos, bool value, int numBits)
		{
			int num = math.min(pos + numBits, this.Length);
			int num2 = pos >> 6;
			int num3 = pos & 63;
			int num4 = num - 1 >> 6;
			int num5 = num & 63;
			ulong num6 = ulong.MaxValue << num3;
			ulong num7 = ulong.MaxValue >> 64 - num5;
			ulong num8 = (ulong)((long)(-(long)Bitwise.FromBool(value)));
			ulong num9 = num6 & num8;
			ulong num10 = num7 & num8;
			ulong num11 = ~num6;
			ulong num12 = ~num7;
			if (num2 == num4)
			{
				ulong num13 = ~(num6 & num7);
				ulong num14 = num9 & num10;
				this.Ptr[num2] = ((this.Ptr[num2] & num13) | num14);
				return;
			}
			this.Ptr[num2] = ((this.Ptr[num2] & num11) | num9);
			for (int i = num2 + 1; i < num4; i++)
			{
				this.Ptr[i] = num8;
			}
			this.Ptr[num4] = ((this.Ptr[num4] & num12) | num10);
		}

		// Token: 0x0600097A RID: 2426 RVA: 0x0001DC1C File Offset: 0x0001BE1C
		public unsafe void SetBits(int pos, ulong value, int numBits = 1)
		{
			int num = pos >> 6;
			int num2 = pos & 63;
			if (num2 + numBits <= 64)
			{
				ulong mask = ulong.MaxValue >> 64 - numBits;
				this.Ptr[num] = Bitwise.ReplaceBits(this.Ptr[num], num2, mask, value);
				return;
			}
			int num3 = math.min(pos + numBits, this.Length);
			int num4 = num3 - 1 >> 6;
			int num5 = num3 & 63;
			ulong mask2 = ulong.MaxValue >> num2;
			this.Ptr[num] = Bitwise.ReplaceBits(this.Ptr[num], num2, mask2, value);
			ulong value2 = value >> 64 - num2;
			ulong mask3 = ulong.MaxValue >> 64 - num5;
			this.Ptr[num4] = Bitwise.ReplaceBits(this.Ptr[num4], 0, mask3, value2);
		}

		// Token: 0x0600097B RID: 2427 RVA: 0x0001DCE4 File Offset: 0x0001BEE4
		public unsafe ulong GetBits(int pos, int numBits = 1)
		{
			int num = pos >> 6;
			int num2 = pos & 63;
			if (num2 + numBits <= 64)
			{
				ulong mask = ulong.MaxValue >> 64 - numBits;
				return Bitwise.ExtractBits(this.Ptr[num], num2, mask);
			}
			int num3 = math.min(pos + numBits, this.Length);
			int num4 = num3 - 1 >> 6;
			int num5 = num3 & 63;
			ulong mask2 = ulong.MaxValue >> num2;
			ulong num6 = Bitwise.ExtractBits(this.Ptr[num], num2, mask2);
			ulong mask3 = ulong.MaxValue >> 64 - num5;
			return Bitwise.ExtractBits(this.Ptr[num4], 0, mask3) << 64 - num2 | num6;
		}

		// Token: 0x0600097C RID: 2428 RVA: 0x0001DD84 File Offset: 0x0001BF84
		public unsafe bool IsSet(int pos)
		{
			int num = pos >> 6;
			int num2 = pos & 63;
			ulong num3 = 1UL << num2;
			return (this.Ptr[num] & num3) > 0UL;
		}

		// Token: 0x0600097D RID: 2429 RVA: 0x0001DDB4 File Offset: 0x0001BFB4
		internal void CopyUlong(int dstPos, ref UnsafeBitArray srcBitArray, int srcPos, int numBits)
		{
			this.SetBits(dstPos, srcBitArray.GetBits(srcPos, numBits), numBits);
		}

		// Token: 0x0600097E RID: 2430 RVA: 0x0001DDC8 File Offset: 0x0001BFC8
		public void Copy(int dstPos, int srcPos, int numBits)
		{
			if (dstPos == srcPos)
			{
				return;
			}
			this.Copy(dstPos, ref this, srcPos, numBits);
		}

		// Token: 0x0600097F RID: 2431 RVA: 0x0001DDDC File Offset: 0x0001BFDC
		public unsafe void Copy(int dstPos, ref UnsafeBitArray srcBitArray, int srcPos, int numBits)
		{
			if (numBits == 0)
			{
				return;
			}
			if (numBits <= 64)
			{
				this.CopyUlong(dstPos, ref srcBitArray, srcPos, numBits);
				return;
			}
			if (numBits <= 128)
			{
				this.CopyUlong(dstPos, ref srcBitArray, srcPos, 64);
				numBits -= 64;
				if (numBits > 0)
				{
					this.CopyUlong(dstPos + 64, ref srcBitArray, srcPos + 64, numBits);
					return;
				}
			}
			else if ((dstPos & 7) == (srcPos & 7))
			{
				int num = CollectionHelper.Align(dstPos, 8) >> 3;
				int num2 = CollectionHelper.Align(srcPos, 8) >> 3;
				int num3 = num * 8 - dstPos;
				if (num3 > 0)
				{
					this.CopyUlong(dstPos, ref srcBitArray, srcPos, num3);
				}
				int num4 = numBits - num3;
				int num5 = num4 / 8;
				if (num5 > 0)
				{
					UnsafeUtility.MemMove((void*)(this.Ptr + num / 8), (void*)(srcBitArray.Ptr + num2 / 8), (long)num5);
				}
				int num6 = num4 & 7;
				if (num6 > 0)
				{
					this.CopyUlong((num + num5) * 8, ref srcBitArray, (num2 + num5) * 8, num6);
					return;
				}
			}
			else
			{
				int num7 = CollectionHelper.Align(dstPos, 64) - dstPos;
				if (num7 > 0)
				{
					this.CopyUlong(dstPos, ref srcBitArray, srcPos, num7);
					numBits -= num7;
					dstPos += num7;
					srcPos += num7;
				}
				while (numBits >= 64)
				{
					this.Ptr[dstPos >> 6] = srcBitArray.GetBits(srcPos, 64);
					numBits -= 64;
					dstPos += 64;
					srcPos += 64;
				}
				if (numBits > 0)
				{
					this.CopyUlong(dstPos, ref srcBitArray, srcPos, numBits);
				}
			}
		}

		// Token: 0x06000980 RID: 2432 RVA: 0x0001DF1C File Offset: 0x0001C11C
		public int Find(int pos, int numBits)
		{
			int count = this.Length - pos;
			return Bitwise.Find(this.Ptr, pos, count, numBits);
		}

		// Token: 0x06000981 RID: 2433 RVA: 0x0001DF40 File Offset: 0x0001C140
		public int Find(int pos, int count, int numBits)
		{
			return Bitwise.Find(this.Ptr, pos, count, numBits);
		}

		// Token: 0x06000982 RID: 2434 RVA: 0x0001DF50 File Offset: 0x0001C150
		public unsafe bool TestNone(int pos, int numBits = 1)
		{
			int num = math.min(pos + numBits, this.Length);
			int num2 = pos >> 6;
			int num3 = pos & 63;
			int num4 = num - 1 >> 6;
			int num5 = num & 63;
			ulong num6 = ulong.MaxValue << num3;
			ulong num7 = ulong.MaxValue >> 64 - num5;
			if (num2 == num4)
			{
				ulong num8 = num6 & num7;
				return (this.Ptr[num2] & num8) == 0UL;
			}
			if ((this.Ptr[num2] & num6) != 0UL)
			{
				return false;
			}
			for (int i = num2 + 1; i < num4; i++)
			{
				if (this.Ptr[i] != 0UL)
				{
					return false;
				}
			}
			return (this.Ptr[num4] & num7) == 0UL;
		}

		// Token: 0x06000983 RID: 2435 RVA: 0x0001DFFC File Offset: 0x0001C1FC
		public unsafe bool TestAny(int pos, int numBits = 1)
		{
			int num = math.min(pos + numBits, this.Length);
			int num2 = pos >> 6;
			int num3 = pos & 63;
			int num4 = num - 1 >> 6;
			int num5 = num & 63;
			ulong num6 = ulong.MaxValue << num3;
			ulong num7 = ulong.MaxValue >> 64 - num5;
			if (num2 == num4)
			{
				ulong num8 = num6 & num7;
				return (this.Ptr[num2] & num8) > 0UL;
			}
			if ((this.Ptr[num2] & num6) != 0UL)
			{
				return true;
			}
			for (int i = num2 + 1; i < num4; i++)
			{
				if (this.Ptr[i] != 0UL)
				{
					return true;
				}
			}
			return (this.Ptr[num4] & num7) > 0UL;
		}

		// Token: 0x06000984 RID: 2436 RVA: 0x0001E0A8 File Offset: 0x0001C2A8
		public unsafe bool TestAll(int pos, int numBits = 1)
		{
			int num = math.min(pos + numBits, this.Length);
			int num2 = pos >> 6;
			int num3 = pos & 63;
			int num4 = num - 1 >> 6;
			int num5 = num & 63;
			ulong num6 = ulong.MaxValue << num3;
			ulong num7 = ulong.MaxValue >> 64 - num5;
			if (num2 == num4)
			{
				ulong num8 = num6 & num7;
				return num8 == (this.Ptr[num2] & num8);
			}
			if (num6 != (this.Ptr[num2] & num6))
			{
				return false;
			}
			for (int i = num2 + 1; i < num4; i++)
			{
				if (18446744073709551615UL != this.Ptr[i])
				{
					return false;
				}
			}
			return num7 == (this.Ptr[num4] & num7);
		}

		// Token: 0x06000985 RID: 2437 RVA: 0x0001E158 File Offset: 0x0001C358
		public unsafe int CountBits(int pos, int numBits = 1)
		{
			int num = math.min(pos + numBits, this.Length);
			int num2 = pos >> 6;
			int num3 = pos & 63;
			int num4 = num - 1 >> 6;
			int num5 = num & 63;
			ulong num6 = ulong.MaxValue << num3;
			ulong num7 = ulong.MaxValue >> 64 - num5;
			if (num2 == num4)
			{
				ulong num8 = num6 & num7;
				return math.countbits(this.Ptr[num2] & num8);
			}
			int num9 = math.countbits(this.Ptr[num2] & num6);
			for (int i = num2 + 1; i < num4; i++)
			{
				num9 += math.countbits(this.Ptr[i]);
			}
			return num9 + math.countbits(this.Ptr[num4] & num7);
		}

		// Token: 0x06000986 RID: 2438 RVA: 0x0001E215 File Offset: 0x0001C415
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private static void CheckSizeMultipleOf8(int sizeInBytes)
		{
			if ((sizeInBytes & 7) != 0)
			{
				throw new ArgumentException(string.Format("BitArray invalid arguments: sizeInBytes {0} (must be multiple of 8-bytes, sizeInBytes: {1}).", sizeInBytes, sizeInBytes));
			}
		}

		// Token: 0x06000987 RID: 2439 RVA: 0x0001E238 File Offset: 0x0001C438
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private void CheckArgs(int pos, int numBits)
		{
			if (pos < 0 || pos >= this.Length || numBits < 1)
			{
				throw new ArgumentException(string.Format("BitArray invalid arguments: pos {0} (must be 0-{1}), numBits {2} (must be greater than 0).", pos, this.Length - 1, numBits));
			}
		}

		// Token: 0x06000988 RID: 2440 RVA: 0x0001E274 File Offset: 0x0001C474
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private void CheckArgsPosCount(int begin, int count, int numBits)
		{
			if (begin < 0 || begin >= this.Length)
			{
				throw new ArgumentException(string.Format("BitArray invalid argument: begin {0} (must be 0-{1}).", begin, this.Length - 1));
			}
			if (count < 0 || count > this.Length)
			{
				throw new ArgumentException(string.Format("BitArray invalid argument: count {0} (must be 0-{1}).", count, this.Length));
			}
			if (numBits < 1 || count < numBits)
			{
				throw new ArgumentException(string.Format("BitArray invalid argument: numBits {0} (must be greater than 0).", numBits));
			}
		}

		// Token: 0x06000989 RID: 2441 RVA: 0x0001E300 File Offset: 0x0001C500
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private void CheckArgsUlong(int pos, int numBits)
		{
			if (numBits < 1 || numBits > 64)
			{
				throw new ArgumentException(string.Format("BitArray invalid arguments: numBits {0} (must be 1-64).", numBits));
			}
			if (pos + numBits > this.Length)
			{
				throw new ArgumentException(string.Format("BitArray invalid arguments: Out of bounds pos {0}, numBits {1}, Length {2}.", pos, numBits, this.Length));
			}
		}

		// Token: 0x0600098A RID: 2442 RVA: 0x0001E360 File Offset: 0x0001C560
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private static void CheckArgsCopy(ref UnsafeBitArray dstBitArray, int dstPos, ref UnsafeBitArray srcBitArray, int srcPos, int numBits)
		{
			if (srcPos + numBits > srcBitArray.Length)
			{
				throw new ArgumentException(string.Format("BitArray invalid arguments: Out of bounds - source position {0}, numBits {1}, source bit array Length {2}.", srcPos, numBits, srcBitArray.Length));
			}
			if (dstPos + numBits > dstBitArray.Length)
			{
				throw new ArgumentException(string.Format("BitArray invalid arguments: Out of bounds - destination position {0}, numBits {1}, destination bit array Length {2}.", dstPos, numBits, dstBitArray.Length));
			}
		}

		// Token: 0x0400034A RID: 842
		[NativeDisableUnsafePtrRestriction]
		public unsafe ulong* Ptr;

		// Token: 0x0400034B RID: 843
		public int Length;

		// Token: 0x0400034C RID: 844
		public AllocatorManager.AllocatorHandle Allocator;
	}
}
