using System;
using System.Runtime.CompilerServices;
using Unity.Collections.LowLevel.Unsafe;

namespace Unity.Netcode
{
	// Token: 0x020000F9 RID: 249
	public ref struct BitWriter
	{
		// Token: 0x1700009A RID: 154
		// (get) Token: 0x06000636 RID: 1590 RVA: 0x0001C099 File Offset: 0x0001A299
		public bool BitAligned
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return (this.m_BitPosition & 7) == 0;
			}
		}

		// Token: 0x1700009B RID: 155
		// (get) Token: 0x06000637 RID: 1591 RVA: 0x0001C0A6 File Offset: 0x0001A2A6
		private int BytePosition
		{
			get
			{
				return this.m_BitPosition >> 3;
			}
		}

		// Token: 0x06000638 RID: 1592 RVA: 0x0001C0B0 File Offset: 0x0001A2B0
		internal unsafe BitWriter(FastBufferWriter writer)
		{
			this.m_Writer = writer;
			this.m_BufferPointer = writer.Handle->BufferPointer + writer.Handle->Position;
			this.m_Position = writer.Handle->Position;
			this.m_BitPosition = 0;
		}

		// Token: 0x06000639 RID: 1593 RVA: 0x0001C0F0 File Offset: 0x0001A2F0
		public void Dispose()
		{
			int num = this.m_BitPosition >> 3;
			if (!this.BitAligned)
			{
				num++;
			}
			this.m_Writer.CommitBitwiseWrites(num);
		}

		// Token: 0x0600063A RID: 1594 RVA: 0x0001C120 File Offset: 0x0001A320
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

		// Token: 0x0600063B RID: 1595 RVA: 0x0001C1D4 File Offset: 0x0001A3D4
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

		// Token: 0x0600063C RID: 1596 RVA: 0x0001C238 File Offset: 0x0001A438
		public void WriteBits(byte value, uint bitCount)
		{
			int num = 0;
			while ((long)num < (long)((ulong)bitCount))
			{
				this.WriteBit((value >> num & 1) != 0);
				num++;
			}
		}

		// Token: 0x0600063D RID: 1597 RVA: 0x0001C264 File Offset: 0x0001A464
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe void WriteBit(bool bit)
		{
			int num = this.m_BitPosition & 7;
			int bytePosition = this.BytePosition;
			this.m_BitPosition++;
			this.m_BufferPointer[bytePosition] = (byte)(bit ? (((int)this.m_BufferPointer[bytePosition] & ~(1 << num)) | 1 << num) : ((int)this.m_BufferPointer[bytePosition] & ~(1 << num)));
		}

		// Token: 0x0600063E RID: 1598 RVA: 0x0001C2C8 File Offset: 0x0001A4C8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private unsafe void WritePartialValue<[IsUnmanaged] T>(T value, int bytesToWrite, int offsetBytes = 0) where T : struct, ValueType
		{
			byte* source = (byte*)(&value) + offsetBytes;
			UnsafeUtility.MemCpy((void*)(this.m_BufferPointer + this.BytePosition), (void*)source, (long)bytesToWrite);
			this.m_BitPosition += bytesToWrite * 8;
		}

		// Token: 0x0600063F RID: 1599 RVA: 0x0001C300 File Offset: 0x0001A500
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

		// Token: 0x04000308 RID: 776
		private FastBufferWriter m_Writer;

		// Token: 0x04000309 RID: 777
		private unsafe byte* m_BufferPointer;

		// Token: 0x0400030A RID: 778
		private readonly int m_Position;

		// Token: 0x0400030B RID: 779
		private int m_BitPosition;

		// Token: 0x0400030C RID: 780
		private const int k_BitsPerByte = 8;
	}
}
