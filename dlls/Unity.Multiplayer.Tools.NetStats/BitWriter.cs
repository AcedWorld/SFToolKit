using System;
using System.Runtime.CompilerServices;
using Unity.Collections.LowLevel.Unsafe;

namespace Unity.Multiplayer.Tools.NetStats
{
	// Token: 0x02000029 RID: 41
	internal ref struct BitWriter
	{
		// Token: 0x17000031 RID: 49
		// (get) Token: 0x060000B1 RID: 177 RVA: 0x00003645 File Offset: 0x00001845
		public bool BitAligned
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return (this.m_BitPosition & 7) == 0;
			}
		}

		// Token: 0x060000B2 RID: 178 RVA: 0x00003652 File Offset: 0x00001852
		internal unsafe BitWriter(FastBufferWriter writer)
		{
			this.m_Writer = writer;
			this.m_BufferPointer = writer.Handle->BufferPointer + writer.Handle->Position;
			this.m_Position = writer.Handle->Position;
			this.m_BitPosition = 0;
		}

		// Token: 0x060000B3 RID: 179 RVA: 0x00003690 File Offset: 0x00001890
		public void Dispose()
		{
			int num = this.m_BitPosition >> 3;
			if (!this.BitAligned)
			{
				num++;
			}
			this.m_Writer.CommitBitwiseWrites(num);
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x000036C0 File Offset: 0x000018C0
		public unsafe bool TryBeginWriteBits(int bitCount)
		{
			int num = this.m_BitPosition + bitCount;
			int num2 = num >> 3;
			if ((num & 7) != 0)
			{
				num2++;
			}
			if (this.m_Position + num2 > this.m_Writer.Handle->Capacity)
			{
				if (this.m_Position + num2 > this.m_Writer.Handle->MaxCapacity)
				{
					return false;
				}
				if (this.m_Writer.Handle->Capacity >= this.m_Writer.Handle->MaxCapacity)
				{
					return false;
				}
				this.m_Writer.Grow(num2);
				this.m_BufferPointer = this.m_Writer.Handle->BufferPointer + this.m_Writer.Handle->Position;
			}
			return true;
		}

		// Token: 0x060000B5 RID: 181 RVA: 0x00003774 File Offset: 0x00001974
		public unsafe void WriteBits(ulong value, uint bitCount)
		{
			int num = (int)(bitCount / 8U);
			byte* ptr = (byte*)(&value);
			if (this.BitAligned)
			{
				if (num != 0)
				{
					this.WritePartialValue<ulong>(value, num, 0);
				}
			}
			else
			{
				for (int i = 0; i < num; i++)
				{
					this.WriteMisaligned(ptr[i]);
				}
			}
			int num2 = num * 8;
			while ((long)num2 < (long)((ulong)bitCount))
			{
				this.WriteBit((value & 1UL << num2) > 0UL);
				num2++;
			}
		}

		// Token: 0x060000B6 RID: 182 RVA: 0x000037D8 File Offset: 0x000019D8
		public void WriteBits(byte value, uint bitCount)
		{
			int num = 0;
			while ((long)num < (long)((ulong)bitCount))
			{
				this.WriteBit((value >> num & 1) != 0);
				num++;
			}
		}

		// Token: 0x060000B7 RID: 183 RVA: 0x00003804 File Offset: 0x00001A04
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe void WriteBit(bool bit)
		{
			int num = this.m_BitPosition & 7;
			int num2 = this.m_BitPosition >> 3;
			this.m_BitPosition++;
			this.m_BufferPointer[num2] = (byte)(bit ? (((int)this.m_BufferPointer[num2] & ~(1 << num)) | 1 << num) : ((int)this.m_BufferPointer[num2] & ~(1 << num)));
		}

		// Token: 0x060000B8 RID: 184 RVA: 0x0000386C File Offset: 0x00001A6C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private unsafe void WritePartialValue<[IsUnmanaged] T>(T value, int bytesToWrite, int offsetBytes = 0) where T : struct, ValueType
		{
			byte* source = (byte*)(&value) + offsetBytes;
			UnsafeUtility.MemCpy((void*)(this.m_BufferPointer + this.m_Position), (void*)source, (long)bytesToWrite);
			this.m_BitPosition += bytesToWrite * 8;
		}

		// Token: 0x060000B9 RID: 185 RVA: 0x000038A4 File Offset: 0x00001AA4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private unsafe void WriteMisaligned(byte value)
		{
			int num = this.m_BitPosition & 7;
			int num2 = this.m_BitPosition >> 3;
			int num3 = 8 - num;
			this.m_BufferPointer[num2 + 1] = (byte)(((int)this.m_BufferPointer[num2 + 1] & 255 << num) | value >> num3);
			this.m_BufferPointer[num2] = (byte)(((int)this.m_BufferPointer[num2] & 255 >> num3) | (int)value << num);
			this.m_BitPosition += 8;
		}

		// Token: 0x0400004A RID: 74
		private FastBufferWriter m_Writer;

		// Token: 0x0400004B RID: 75
		private unsafe byte* m_BufferPointer;

		// Token: 0x0400004C RID: 76
		private readonly int m_Position;

		// Token: 0x0400004D RID: 77
		private int m_BitPosition;

		// Token: 0x0400004E RID: 78
		private const int k_BitsPerByte = 8;
	}
}
