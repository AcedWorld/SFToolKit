using System;
using System.Runtime.CompilerServices;
using Unity.Collections.LowLevel.Unsafe;

namespace Unity.Multiplayer.Tools.NetStats
{
	// Token: 0x02000028 RID: 40
	internal ref struct BitReader
	{
		// Token: 0x17000030 RID: 48
		// (get) Token: 0x060000A7 RID: 167 RVA: 0x000033AC File Offset: 0x000015AC
		public bool BitAligned
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return (this.m_BitPosition & 7) == 0;
			}
		}

		// Token: 0x060000A8 RID: 168 RVA: 0x000033BC File Offset: 0x000015BC
		internal unsafe BitReader(FastBufferReader reader)
		{
			this.m_Reader = reader;
			this.m_BufferPointer = this.m_Reader.Handle->BufferPointer + this.m_Reader.Handle->Position;
			this.m_Position = this.m_Reader.Handle->Position;
			this.m_BitPosition = 0;
		}

		// Token: 0x060000A9 RID: 169 RVA: 0x00003414 File Offset: 0x00001614
		public void Dispose()
		{
			int num = this.m_BitPosition >> 3;
			if (!this.BitAligned)
			{
				num++;
			}
			this.m_Reader.CommitBitwiseReads(num);
		}

		// Token: 0x060000AA RID: 170 RVA: 0x00003444 File Offset: 0x00001644
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

		// Token: 0x060000AB RID: 171 RVA: 0x00003494 File Offset: 0x00001694
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

		// Token: 0x060000AC RID: 172 RVA: 0x000034F0 File Offset: 0x000016F0
		public void ReadBits(out byte value, uint bitCount)
		{
			value = this.ReadByteBits((int)bitCount);
		}

		// Token: 0x060000AD RID: 173 RVA: 0x000034FC File Offset: 0x000016FC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe void ReadBit(out bool bit)
		{
			int num = this.m_BitPosition & 7;
			int num2 = this.m_BitPosition >> 3;
			bit = (((int)this.m_BufferPointer[num2] & 1 << num) != 0);
			this.m_BitPosition++;
		}

		// Token: 0x060000AE RID: 174 RVA: 0x00003540 File Offset: 0x00001740
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private unsafe void ReadPartialValue<[IsUnmanaged] T>(out T value, int bytesToRead, int offsetBytes = 0) where T : struct, ValueType
		{
			T t = Activator.CreateInstance<T>();
			void* destination = (void*)((byte*)(&t) + offsetBytes);
			byte* source = this.m_BufferPointer + this.m_Position;
			UnsafeUtility.MemCpy(destination, (void*)source, (long)bytesToRead);
			this.m_BitPosition += bytesToRead * 8;
			value = t;
		}

		// Token: 0x060000AF RID: 175 RVA: 0x00003588 File Offset: 0x00001788
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

		// Token: 0x060000B0 RID: 176 RVA: 0x000035F0 File Offset: 0x000017F0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private unsafe void ReadMisaligned(out byte value)
		{
			int num = this.m_BitPosition & 7;
			int num2 = this.m_BitPosition >> 3;
			int num3 = 8 - num;
			value = (byte)(this.m_BufferPointer[num2] >> num | (int)this.m_BufferPointer[(this.m_BitPosition += 8) >> 3] << num3);
		}

		// Token: 0x04000045 RID: 69
		private FastBufferReader m_Reader;

		// Token: 0x04000046 RID: 70
		private unsafe readonly byte* m_BufferPointer;

		// Token: 0x04000047 RID: 71
		private readonly int m_Position;

		// Token: 0x04000048 RID: 72
		private int m_BitPosition;

		// Token: 0x04000049 RID: 73
		private const int k_BitsPerByte = 8;
	}
}
