using System;
using System.Runtime.CompilerServices;
using Unity.Collections.LowLevel.Unsafe;

namespace Unity.Netcode
{
	// Token: 0x020000F8 RID: 248
	public ref struct BitReader
	{
		// Token: 0x17000098 RID: 152
		// (get) Token: 0x0600062B RID: 1579 RVA: 0x0001BDFD File Offset: 0x00019FFD
		private int BytePosition
		{
			get
			{
				return this.m_BitPosition >> 3;
			}
		}

		// Token: 0x17000099 RID: 153
		// (get) Token: 0x0600062C RID: 1580 RVA: 0x0001BE07 File Offset: 0x0001A007
		public bool BitAligned
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return (this.m_BitPosition & 7) == 0;
			}
		}

		// Token: 0x0600062D RID: 1581 RVA: 0x0001BE14 File Offset: 0x0001A014
		internal unsafe BitReader(FastBufferReader reader)
		{
			this.m_Reader = reader;
			this.m_BufferPointer = this.m_Reader.Handle->BufferPointer + this.m_Reader.Handle->Position;
			this.m_Position = this.m_Reader.Handle->Position;
			this.m_BitPosition = 0;
		}

		// Token: 0x0600062E RID: 1582 RVA: 0x0001BE6C File Offset: 0x0001A06C
		public void Dispose()
		{
			int num = this.m_BitPosition >> 3;
			if (!this.BitAligned)
			{
				num++;
			}
			this.m_Reader.CommitBitwiseReads(num);
		}

		// Token: 0x0600062F RID: 1583 RVA: 0x0001BE9C File Offset: 0x0001A09C
		public unsafe bool TryBeginReadBits(uint bitCount)
		{
			long num = (long)this.m_BitPosition + (long)((ulong)bitCount);
			long num2 = num >> 3;
			if ((num & 7L) != 0L)
			{
				num2 += 1L;
			}
			return (long)this.m_Reader.Handle->Position + num2 <= (long)this.m_Reader.Handle->Length;
		}

		// Token: 0x06000630 RID: 1584 RVA: 0x0001BEEC File Offset: 0x0001A0EC
		public unsafe void ReadBits(out ulong value, uint bitCount)
		{
			ulong num = 0UL;
			int num2 = (int)(bitCount / 8U);
			byte* ptr = (byte*)(&num);
			if (this.BitAligned)
			{
				if (num2 != 0)
				{
					this.ReadPartialValue<ulong>(out num, num2, 0);
				}
			}
			else
			{
				for (int i = 0; i < num2; i++)
				{
					this.ReadMisaligned(out ptr[i]);
				}
			}
			num |= (ulong)this.ReadByteBits((int)(bitCount & 7U)) << (int)(bitCount & 4294967288U);
			value = num;
		}

		// Token: 0x06000631 RID: 1585 RVA: 0x0001BF48 File Offset: 0x0001A148
		public void ReadBits(out byte value, uint bitCount)
		{
			value = this.ReadByteBits((int)bitCount);
		}

		// Token: 0x06000632 RID: 1586 RVA: 0x0001BF54 File Offset: 0x0001A154
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe void ReadBit(out bool bit)
		{
			int num = this.m_BitPosition & 7;
			int bytePosition = this.BytePosition;
			bit = (((int)this.m_BufferPointer[bytePosition] & 1 << num) != 0);
			this.m_BitPosition++;
		}

		// Token: 0x06000633 RID: 1587 RVA: 0x0001BF94 File Offset: 0x0001A194
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private unsafe void ReadPartialValue<[IsUnmanaged] T>(out T value, int bytesToRead, int offsetBytes = 0) where T : struct, ValueType
		{
			T t = Activator.CreateInstance<T>();
			void* destination = (void*)((byte*)(&t) + offsetBytes);
			byte* source = this.m_BufferPointer + this.BytePosition;
			UnsafeUtility.MemCpy(destination, (void*)source, (long)bytesToRead);
			this.m_BitPosition += bytesToRead * 8;
			value = t;
		}

		// Token: 0x06000634 RID: 1588 RVA: 0x0001BFDC File Offset: 0x0001A1DC
		private byte ReadByteBits(int bitCount)
		{
			if (bitCount > 8)
			{
				throw new ArgumentOutOfRangeException("bitCount", "Cannot read more than 8 bits into an 8-bit value!");
			}
			if (bitCount < 0)
			{
				throw new ArgumentOutOfRangeException("bitCount", "Cannot read fewer than 0 bits!");
			}
			int num = 0;
			ByteBool byteBool = default(ByteBool);
			for (int i = 0; i < bitCount; i++)
			{
				bool b;
				this.ReadBit(out b);
				num |= (int)byteBool.Collapse(b) << i;
			}
			return (byte)num;
		}

		// Token: 0x06000635 RID: 1589 RVA: 0x0001C044 File Offset: 0x0001A244
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private unsafe void ReadMisaligned(out byte value)
		{
			int num = this.m_BitPosition & 7;
			int num2 = this.m_BitPosition >> 3;
			int num3 = 8 - num;
			value = (byte)(this.m_BufferPointer[num2] >> num | (int)this.m_BufferPointer[(this.m_BitPosition += 8) >> 3] << num3);
		}

		// Token: 0x04000303 RID: 771
		private FastBufferReader m_Reader;

		// Token: 0x04000304 RID: 772
		private unsafe readonly byte* m_BufferPointer;

		// Token: 0x04000305 RID: 773
		private readonly int m_Position;

		// Token: 0x04000306 RID: 774
		private int m_BitPosition;

		// Token: 0x04000307 RID: 775
		private const int k_BitsPerByte = 8;
	}
}
