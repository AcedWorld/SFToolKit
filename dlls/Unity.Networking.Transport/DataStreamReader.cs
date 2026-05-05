using System;
using System.Diagnostics;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;

namespace Unity.Networking.Transport
{
	// Token: 0x02000013 RID: 19
	public struct DataStreamReader
	{
		// Token: 0x06000068 RID: 104 RVA: 0x00003CEE File Offset: 0x00001EEE
		public DataStreamReader(NativeArray<byte> array)
		{
			DataStreamReader.Initialize(out this, array);
		}

		// Token: 0x06000069 RID: 105 RVA: 0x00003CF8 File Offset: 0x00001EF8
		public unsafe DataStreamReader(byte* data, int length)
		{
			NativeArray<byte> array = NativeArrayUnsafeUtility.ConvertExistingDataToNativeArray<byte>((void*)data, length, Allocator.Invalid);
			DataStreamReader.Initialize(out this, array);
		}

		// Token: 0x0600006A RID: 106 RVA: 0x00003D15 File Offset: 0x00001F15
		private unsafe static void Initialize(out DataStreamReader self, NativeArray<byte> array)
		{
			self.m_bufferPtr = (byte*)array.GetUnsafeReadOnlyPtr<byte>();
			self.m_Length = array.Length;
			self.m_Context = default(DataStreamReader.Context);
		}

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x0600006B RID: 107 RVA: 0x00003D3C File Offset: 0x00001F3C
		public bool IsLittleEndian
		{
			get
			{
				return DataStreamWriter.IsLittleEndian;
			}
		}

		// Token: 0x0600006C RID: 108 RVA: 0x00003454 File Offset: 0x00001654
		private static short ByteSwap(short val)
		{
			return (short)((int)(val & 255) << 8 | (val >> 8 & 255));
		}

		// Token: 0x0600006D RID: 109 RVA: 0x0000346A File Offset: 0x0000166A
		private static int ByteSwap(int val)
		{
			return (val & 255) << 24 | (val & 65280) << 8 | (val >> 8 & 65280) | (val >> 24 & 255);
		}

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x0600006E RID: 110 RVA: 0x00003D43 File Offset: 0x00001F43
		public bool HasFailedReads
		{
			get
			{
				return this.m_Context.m_FailedReads > 0;
			}
		}

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x0600006F RID: 111 RVA: 0x00003D53 File Offset: 0x00001F53
		public int Length
		{
			get
			{
				return this.m_Length;
			}
		}

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000070 RID: 112 RVA: 0x00003D5B File Offset: 0x00001F5B
		public bool IsCreated
		{
			get
			{
				return this.m_bufferPtr != null;
			}
		}

		// Token: 0x06000071 RID: 113 RVA: 0x00003D6C File Offset: 0x00001F6C
		public unsafe void ReadBytes(byte* data, int length)
		{
			if (this.GetBytesRead() + length > this.m_Length)
			{
				this.m_Context.m_FailedReads = this.m_Context.m_FailedReads + 1;
				UnsafeUtility.MemClear((void*)data, (long)length);
				return;
			}
			this.m_Context.m_ReadByteIndex = this.m_Context.m_ReadByteIndex - (this.m_Context.m_BitIndex >> 3);
			this.m_Context.m_BitIndex = 0;
			this.m_Context.m_BitBuffer = 0UL;
			UnsafeUtility.MemCpy((void*)data, (void*)(this.m_bufferPtr + this.m_Context.m_ReadByteIndex), (long)length);
			this.m_Context.m_ReadByteIndex = this.m_Context.m_ReadByteIndex + length;
		}

		// Token: 0x06000072 RID: 114 RVA: 0x00003E01 File Offset: 0x00002001
		public unsafe void ReadBytes(NativeArray<byte> array)
		{
			this.ReadBytes((byte*)array.GetUnsafePtr<byte>(), array.Length);
		}

		// Token: 0x06000073 RID: 115 RVA: 0x00003E16 File Offset: 0x00002016
		public int GetBytesRead()
		{
			return this.m_Context.m_ReadByteIndex - (this.m_Context.m_BitIndex >> 3);
		}

		// Token: 0x06000074 RID: 116 RVA: 0x00003E31 File Offset: 0x00002031
		public int GetBitsRead()
		{
			return (this.m_Context.m_ReadByteIndex << 3) - this.m_Context.m_BitIndex;
		}

		// Token: 0x06000075 RID: 117 RVA: 0x00003E4C File Offset: 0x0000204C
		public void SeekSet(int pos)
		{
			if (pos > this.m_Length)
			{
				this.m_Context.m_FailedReads = this.m_Context.m_FailedReads + 1;
				return;
			}
			this.m_Context.m_ReadByteIndex = pos;
			this.m_Context.m_BitIndex = 0;
			this.m_Context.m_BitBuffer = 0UL;
		}

		// Token: 0x06000076 RID: 118 RVA: 0x00003E98 File Offset: 0x00002098
		public unsafe byte ReadByte()
		{
			byte result;
			this.ReadBytes(&result, 1);
			return result;
		}

		// Token: 0x06000077 RID: 119 RVA: 0x00003EB0 File Offset: 0x000020B0
		public unsafe short ReadShort()
		{
			short result;
			this.ReadBytes((byte*)(&result), 2);
			return result;
		}

		// Token: 0x06000078 RID: 120 RVA: 0x00003EC8 File Offset: 0x000020C8
		public unsafe ushort ReadUShort()
		{
			ushort result;
			this.ReadBytes((byte*)(&result), 2);
			return result;
		}

		// Token: 0x06000079 RID: 121 RVA: 0x00003EE0 File Offset: 0x000020E0
		public unsafe int ReadInt()
		{
			int result;
			this.ReadBytes((byte*)(&result), 4);
			return result;
		}

		// Token: 0x0600007A RID: 122 RVA: 0x00003EF8 File Offset: 0x000020F8
		public unsafe uint ReadUInt()
		{
			uint result;
			this.ReadBytes((byte*)(&result), 4);
			return result;
		}

		// Token: 0x0600007B RID: 123 RVA: 0x00003F10 File Offset: 0x00002110
		public unsafe long ReadLong()
		{
			long result;
			this.ReadBytes((byte*)(&result), 8);
			return result;
		}

		// Token: 0x0600007C RID: 124 RVA: 0x00003F28 File Offset: 0x00002128
		public unsafe ulong ReadULong()
		{
			ulong result;
			this.ReadBytes((byte*)(&result), 8);
			return result;
		}

		// Token: 0x0600007D RID: 125 RVA: 0x00003F40 File Offset: 0x00002140
		public unsafe short ReadShortNetworkByteOrder()
		{
			short num;
			this.ReadBytes((byte*)(&num), 2);
			if (!this.IsLittleEndian)
			{
				return num;
			}
			return DataStreamReader.ByteSwap(num);
		}

		// Token: 0x0600007E RID: 126 RVA: 0x00003F67 File Offset: 0x00002167
		public ushort ReadUShortNetworkByteOrder()
		{
			return (ushort)this.ReadShortNetworkByteOrder();
		}

		// Token: 0x0600007F RID: 127 RVA: 0x00003F70 File Offset: 0x00002170
		public unsafe int ReadIntNetworkByteOrder()
		{
			int num;
			this.ReadBytes((byte*)(&num), 4);
			if (!this.IsLittleEndian)
			{
				return num;
			}
			return DataStreamReader.ByteSwap(num);
		}

		// Token: 0x06000080 RID: 128 RVA: 0x00003F97 File Offset: 0x00002197
		public uint ReadUIntNetworkByteOrder()
		{
			return (uint)this.ReadIntNetworkByteOrder();
		}

		// Token: 0x06000081 RID: 129 RVA: 0x00003FA0 File Offset: 0x000021A0
		public float ReadFloat()
		{
			return new UIntFloat
			{
				intValue = (uint)this.ReadInt()
			}.floatValue;
		}

		// Token: 0x06000082 RID: 130 RVA: 0x00003FC8 File Offset: 0x000021C8
		public unsafe uint ReadPackedUInt(NetworkCompressionModel model)
		{
			this.FillBitBuffer();
			uint num = 63U;
			uint num2 = (uint)this.m_Context.m_BitBuffer & num;
			ushort num3 = *(ref model.decodeTable.FixedElementField + (IntPtr)num2 * 2);
			int num4 = num3 >> 8;
			int num5 = (int)(num3 & 255);
			if (this.m_Context.m_BitIndex < num5)
			{
				this.m_Context.m_FailedReads = this.m_Context.m_FailedReads + 1;
				return 0U;
			}
			this.m_Context.m_BitBuffer = this.m_Context.m_BitBuffer >> num5;
			this.m_Context.m_BitIndex = this.m_Context.m_BitIndex - num5;
			uint num6 = *(ref model.bucketOffsets.FixedElementField + (IntPtr)num4 * 4);
			int numbits = (int)(*(ref model.bucketSizes.FixedElementField + num4));
			return this.ReadRawBitsInternal(numbits) + num6;
		}

		// Token: 0x06000083 RID: 131 RVA: 0x00004080 File Offset: 0x00002280
		private unsafe void FillBitBuffer()
		{
			while (this.m_Context.m_BitIndex <= 56 && this.m_Context.m_ReadByteIndex < this.m_Length)
			{
				ulong bitBuffer = this.m_Context.m_BitBuffer;
				int bufferPtr = this.m_bufferPtr;
				int readByteIndex = this.m_Context.m_ReadByteIndex;
				this.m_Context.m_ReadByteIndex = readByteIndex + 1;
				this.m_Context.m_BitBuffer = (bitBuffer | (ulong)(*(bufferPtr + readByteIndex)) << this.m_Context.m_BitIndex);
				this.m_Context.m_BitIndex = this.m_Context.m_BitIndex + 8;
			}
		}

		// Token: 0x06000084 RID: 132 RVA: 0x000040FC File Offset: 0x000022FC
		private uint ReadRawBitsInternal(int numbits)
		{
			if (this.m_Context.m_BitIndex < numbits)
			{
				this.m_Context.m_FailedReads = this.m_Context.m_FailedReads + 1;
				return 0U;
			}
			uint result = (uint)(this.m_Context.m_BitBuffer & (1UL << numbits) - 1UL);
			this.m_Context.m_BitBuffer = this.m_Context.m_BitBuffer >> numbits;
			this.m_Context.m_BitIndex = this.m_Context.m_BitIndex - numbits;
			return result;
		}

		// Token: 0x06000085 RID: 133 RVA: 0x00004163 File Offset: 0x00002363
		public uint ReadRawBits(int numbits)
		{
			this.FillBitBuffer();
			return this.ReadRawBitsInternal(numbits);
		}

		// Token: 0x06000086 RID: 134 RVA: 0x00004172 File Offset: 0x00002372
		public ulong ReadPackedULong(NetworkCompressionModel model)
		{
			return (ulong)this.ReadPackedUInt(model) << 32 | (ulong)this.ReadPackedUInt(model);
		}

		// Token: 0x06000087 RID: 135 RVA: 0x00004188 File Offset: 0x00002388
		public int ReadPackedInt(NetworkCompressionModel model)
		{
			uint num = this.ReadPackedUInt(model);
			return (int)(num >> 1 ^ -(int)(num & 1U));
		}

		// Token: 0x06000088 RID: 136 RVA: 0x000041A8 File Offset: 0x000023A8
		public long ReadPackedLong(NetworkCompressionModel model)
		{
			ulong num = this.ReadPackedULong(model);
			return (long)(num >> 1 ^ -(long)(num & 1UL));
		}

		// Token: 0x06000089 RID: 137 RVA: 0x000041C6 File Offset: 0x000023C6
		public float ReadPackedFloat(NetworkCompressionModel model)
		{
			return this.ReadPackedFloatDelta(0f, model);
		}

		// Token: 0x0600008A RID: 138 RVA: 0x000041D4 File Offset: 0x000023D4
		public int ReadPackedIntDelta(int baseline, NetworkCompressionModel model)
		{
			int num = this.ReadPackedInt(model);
			return baseline - num;
		}

		// Token: 0x0600008B RID: 139 RVA: 0x000041EC File Offset: 0x000023EC
		public uint ReadPackedUIntDelta(uint baseline, NetworkCompressionModel model)
		{
			uint num = (uint)this.ReadPackedInt(model);
			return baseline - num;
		}

		// Token: 0x0600008C RID: 140 RVA: 0x00004204 File Offset: 0x00002404
		public long ReadPackedLongDelta(long baseline, NetworkCompressionModel model)
		{
			long num = this.ReadPackedLong(model);
			return baseline - num;
		}

		// Token: 0x0600008D RID: 141 RVA: 0x0000421C File Offset: 0x0000241C
		public ulong ReadPackedULongDelta(ulong baseline, NetworkCompressionModel model)
		{
			ulong num = (ulong)this.ReadPackedLong(model);
			return baseline - num;
		}

		// Token: 0x0600008E RID: 142 RVA: 0x00004234 File Offset: 0x00002434
		public float ReadPackedFloatDelta(float baseline, NetworkCompressionModel model)
		{
			this.FillBitBuffer();
			if (this.ReadRawBitsInternal(1) == 0U)
			{
				return baseline;
			}
			int numbits = 32;
			return new UIntFloat
			{
				intValue = this.ReadRawBitsInternal(numbits)
			}.floatValue;
		}

		// Token: 0x0600008F RID: 143 RVA: 0x00004274 File Offset: 0x00002474
		public unsafe FixedString32Bytes ReadFixedString32()
		{
			FixedString32Bytes result;
			byte* data = (byte*)(&result) + 2;
			*(short*)(&result) = (short)this.ReadFixedString(data, result.Capacity);
			return result;
		}

		// Token: 0x06000090 RID: 144 RVA: 0x0000429C File Offset: 0x0000249C
		public unsafe FixedString64Bytes ReadFixedString64()
		{
			FixedString64Bytes result;
			byte* data = (byte*)(&result) + 2;
			*(short*)(&result) = (short)this.ReadFixedString(data, result.Capacity);
			return result;
		}

		// Token: 0x06000091 RID: 145 RVA: 0x000042C4 File Offset: 0x000024C4
		public unsafe FixedString128Bytes ReadFixedString128()
		{
			FixedString128Bytes result;
			byte* data = (byte*)(&result) + 2;
			*(short*)(&result) = (short)this.ReadFixedString(data, result.Capacity);
			return result;
		}

		// Token: 0x06000092 RID: 146 RVA: 0x000042EC File Offset: 0x000024EC
		public unsafe FixedString512Bytes ReadFixedString512()
		{
			FixedString512Bytes result;
			byte* data = (byte*)(&result) + 2;
			*(short*)(&result) = (short)this.ReadFixedString(data, result.Capacity);
			return result;
		}

		// Token: 0x06000093 RID: 147 RVA: 0x00004314 File Offset: 0x00002514
		public unsafe FixedString4096Bytes ReadFixedString4096()
		{
			FixedString4096Bytes result;
			byte* data = (byte*)(&result) + 2;
			*(short*)(&result) = (short)this.ReadFixedString(data, result.Capacity);
			return result;
		}

		// Token: 0x06000094 RID: 148 RVA: 0x0000433C File Offset: 0x0000253C
		public unsafe ushort ReadFixedString(byte* data, int maxLength)
		{
			ushort num = this.ReadUShort();
			if ((int)num > maxLength)
			{
				return 0;
			}
			this.ReadBytes(data, (int)num);
			return num;
		}

		// Token: 0x06000095 RID: 149 RVA: 0x00004360 File Offset: 0x00002560
		public unsafe FixedString32Bytes ReadPackedFixedString32Delta(FixedString32Bytes baseline, NetworkCompressionModel model)
		{
			FixedString32Bytes result;
			byte* data = (byte*)(&result) + 2;
			*(short*)(&result) = (short)this.ReadPackedFixedStringDelta(data, result.Capacity, (byte*)(&baseline) + 2, *(ushort*)(&baseline), model);
			return result;
		}

		// Token: 0x06000096 RID: 150 RVA: 0x00004390 File Offset: 0x00002590
		public unsafe FixedString64Bytes ReadPackedFixedString64Delta(FixedString64Bytes baseline, NetworkCompressionModel model)
		{
			FixedString64Bytes result;
			byte* data = (byte*)(&result) + 2;
			*(short*)(&result) = (short)this.ReadPackedFixedStringDelta(data, result.Capacity, (byte*)(&baseline) + 2, *(ushort*)(&baseline), model);
			return result;
		}

		// Token: 0x06000097 RID: 151 RVA: 0x000043C0 File Offset: 0x000025C0
		public unsafe FixedString128Bytes ReadPackedFixedString128Delta(FixedString128Bytes baseline, NetworkCompressionModel model)
		{
			FixedString128Bytes result;
			byte* data = (byte*)(&result) + 2;
			*(short*)(&result) = (short)this.ReadPackedFixedStringDelta(data, result.Capacity, (byte*)(&baseline) + 2, *(ushort*)(&baseline), model);
			return result;
		}

		// Token: 0x06000098 RID: 152 RVA: 0x000043F0 File Offset: 0x000025F0
		public unsafe FixedString512Bytes ReadPackedFixedString512Delta(FixedString512Bytes baseline, NetworkCompressionModel model)
		{
			FixedString512Bytes result;
			byte* data = (byte*)(&result) + 2;
			*(short*)(&result) = (short)this.ReadPackedFixedStringDelta(data, result.Capacity, (byte*)(&baseline) + 2, *(ushort*)(&baseline), model);
			return result;
		}

		// Token: 0x06000099 RID: 153 RVA: 0x00004420 File Offset: 0x00002620
		public unsafe FixedString4096Bytes ReadPackedFixedString4096Delta(FixedString4096Bytes baseline, NetworkCompressionModel model)
		{
			FixedString4096Bytes result;
			byte* data = (byte*)(&result) + 2;
			*(short*)(&result) = (short)this.ReadPackedFixedStringDelta(data, result.Capacity, (byte*)(&baseline) + 2, *(ushort*)(&baseline), model);
			return result;
		}

		// Token: 0x0600009A RID: 154 RVA: 0x00004450 File Offset: 0x00002650
		public unsafe ushort ReadPackedFixedStringDelta(byte* data, int maxLength, byte* baseData, ushort baseLength, NetworkCompressionModel model)
		{
			uint num = this.ReadPackedUIntDelta((uint)baseLength, model);
			if (num > (uint)maxLength)
			{
				return 0;
			}
			if (num <= (uint)baseLength)
			{
				int num2 = 0;
				while ((long)num2 < (long)((ulong)num))
				{
					data[num2] = (byte)this.ReadPackedUIntDelta((uint)baseData[num2], model);
					num2++;
				}
			}
			else
			{
				for (int i = 0; i < (int)baseLength; i++)
				{
					data[i] = (byte)this.ReadPackedUIntDelta((uint)baseData[i], model);
				}
				int num3 = (int)baseLength;
				while ((long)num3 < (long)((ulong)num))
				{
					data[num3] = (byte)this.ReadPackedUInt(model);
					num3++;
				}
			}
			return (ushort)num;
		}

		// Token: 0x0600009B RID: 155 RVA: 0x000044D0 File Offset: 0x000026D0
		public unsafe void* GetUnsafeReadOnlyPtr()
		{
			return (void*)this.m_bufferPtr;
		}

		// Token: 0x0600009C RID: 156 RVA: 0x00003CAF File Offset: 0x00001EAF
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private void CheckRead()
		{
		}

		// Token: 0x0600009D RID: 157 RVA: 0x000044D8 File Offset: 0x000026D8
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private static void CheckBits(int numbits)
		{
			if (numbits < 0 || numbits > 32)
			{
				throw new ArgumentOutOfRangeException("Invalid number of bits");
			}
		}

		// Token: 0x0400003B RID: 59
		[NativeDisableUnsafePtrRestriction]
		private unsafe byte* m_bufferPtr;

		// Token: 0x0400003C RID: 60
		private DataStreamReader.Context m_Context;

		// Token: 0x0400003D RID: 61
		private int m_Length;

		// Token: 0x02000014 RID: 20
		private struct Context
		{
			// Token: 0x0400003E RID: 62
			public int m_ReadByteIndex;

			// Token: 0x0400003F RID: 63
			public int m_BitIndex;

			// Token: 0x04000040 RID: 64
			public ulong m_BitBuffer;

			// Token: 0x04000041 RID: 65
			public int m_FailedReads;
		}
	}
}
