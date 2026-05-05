using System;
using System.Diagnostics;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;

namespace Unity.Networking.Transport
{
	// Token: 0x02000011 RID: 17
	public struct DataStreamWriter
	{
		// Token: 0x17000006 RID: 6
		// (get) Token: 0x0600002E RID: 46 RVA: 0x0000337C File Offset: 0x0000157C
		public unsafe static bool IsLittleEndian
		{
			get
			{
				uint num = 1U;
				byte* ptr = (byte*)(&num);
				return *ptr == 1;
			}
		}

		// Token: 0x0600002F RID: 47 RVA: 0x00003394 File Offset: 0x00001594
		public DataStreamWriter(int length, Allocator allocator)
		{
			DataStreamWriter.Initialize(out this, new NativeArray<byte>(length, allocator, NativeArrayOptions.ClearMemory));
		}

		// Token: 0x06000030 RID: 48 RVA: 0x000033A4 File Offset: 0x000015A4
		public DataStreamWriter(NativeArray<byte> data)
		{
			DataStreamWriter.Initialize(out this, data);
		}

		// Token: 0x06000031 RID: 49 RVA: 0x000033B0 File Offset: 0x000015B0
		public unsafe DataStreamWriter(byte* data, int length)
		{
			NativeArray<byte> data2 = NativeArrayUnsafeUtility.ConvertExistingDataToNativeArray<byte>((void*)data, length, Allocator.Invalid);
			DataStreamWriter.Initialize(out this, data2);
		}

		// Token: 0x06000032 RID: 50 RVA: 0x000033CD File Offset: 0x000015CD
		public unsafe NativeArray<byte> AsNativeArray()
		{
			return NativeArrayUnsafeUtility.ConvertExistingDataToNativeArray<byte>((void*)this.m_Data.buffer, this.Length, Allocator.Invalid);
		}

		// Token: 0x06000033 RID: 51 RVA: 0x000033E8 File Offset: 0x000015E8
		private unsafe static void Initialize(out DataStreamWriter self, NativeArray<byte> data)
		{
			self.m_SendHandleData = IntPtr.Zero;
			self.m_Data.capacity = data.Length;
			self.m_Data.length = 0;
			self.m_Data.buffer = (byte*)data.GetUnsafePtr<byte>();
			self.m_Data.bitBuffer = 0UL;
			self.m_Data.bitIndex = 0;
			self.m_Data.failedWrites = 0;
		}

		// Token: 0x06000034 RID: 52 RVA: 0x00003454 File Offset: 0x00001654
		private static short ByteSwap(short val)
		{
			return (short)((int)(val & 255) << 8 | (val >> 8 & 255));
		}

		// Token: 0x06000035 RID: 53 RVA: 0x0000346A File Offset: 0x0000166A
		private static int ByteSwap(int val)
		{
			return (val & 255) << 24 | (val & 65280) << 8 | (val >> 8 & 65280) | (val >> 24 & 255);
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000036 RID: 54 RVA: 0x00003495 File Offset: 0x00001695
		public bool IsCreated
		{
			get
			{
				return this.m_Data.buffer != null;
			}
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000037 RID: 55 RVA: 0x000034A9 File Offset: 0x000016A9
		public bool HasFailedWrites
		{
			get
			{
				return this.m_Data.failedWrites > 0;
			}
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000038 RID: 56 RVA: 0x000034B9 File Offset: 0x000016B9
		public int Capacity
		{
			get
			{
				return this.m_Data.capacity;
			}
		}

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000039 RID: 57 RVA: 0x000034C6 File Offset: 0x000016C6
		public int Length
		{
			get
			{
				this.SyncBitData();
				return this.m_Data.length + (this.m_Data.bitIndex + 7 >> 3);
			}
		}

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x0600003A RID: 58 RVA: 0x000034E9 File Offset: 0x000016E9
		public int LengthInBits
		{
			get
			{
				this.SyncBitData();
				return this.m_Data.length * 8 + this.m_Data.bitIndex;
			}
		}

		// Token: 0x0600003B RID: 59 RVA: 0x0000350C File Offset: 0x0000170C
		private unsafe void SyncBitData()
		{
			int i = this.m_Data.bitIndex;
			if (i <= 0)
			{
				return;
			}
			ulong num = this.m_Data.bitBuffer;
			int num2 = 0;
			while (i > 0)
			{
				this.m_Data.buffer[this.m_Data.length + num2] = (byte)num;
				i -= 8;
				num >>= 8;
				num2++;
			}
		}

		// Token: 0x0600003C RID: 60 RVA: 0x00003568 File Offset: 0x00001768
		public unsafe void Flush()
		{
			while (this.m_Data.bitIndex > 0)
			{
				ref byte buffer = ref *this.m_Data.buffer;
				int length = this.m_Data.length;
				this.m_Data.length = length + 1;
				*(ref buffer + length) = (byte)this.m_Data.bitBuffer;
				this.m_Data.bitIndex = this.m_Data.bitIndex - 8;
				this.m_Data.bitBuffer = this.m_Data.bitBuffer >> 8;
			}
			this.m_Data.bitIndex = 0;
		}

		// Token: 0x0600003D RID: 61 RVA: 0x000035E0 File Offset: 0x000017E0
		public unsafe bool WriteBytes(byte* data, int bytes)
		{
			if (this.m_Data.length + (this.m_Data.bitIndex + 7 >> 3) + bytes > this.m_Data.capacity)
			{
				this.m_Data.failedWrites = this.m_Data.failedWrites + 1;
				return false;
			}
			this.Flush();
			UnsafeUtility.MemCpy((void*)(this.m_Data.buffer + this.m_Data.length), (void*)data, (long)bytes);
			this.m_Data.length = this.m_Data.length + bytes;
			return true;
		}

		// Token: 0x0600003E RID: 62 RVA: 0x0000365F File Offset: 0x0000185F
		public unsafe bool WriteByte(byte value)
		{
			return this.WriteBytes(&value, 1);
		}

		// Token: 0x0600003F RID: 63 RVA: 0x0000366B File Offset: 0x0000186B
		public unsafe bool WriteBytes(NativeArray<byte> value)
		{
			return this.WriteBytes((byte*)value.GetUnsafeReadOnlyPtr<byte>(), value.Length);
		}

		// Token: 0x06000040 RID: 64 RVA: 0x00003680 File Offset: 0x00001880
		public unsafe bool WriteShort(short value)
		{
			return this.WriteBytes((byte*)(&value), 2);
		}

		// Token: 0x06000041 RID: 65 RVA: 0x00003680 File Offset: 0x00001880
		public unsafe bool WriteUShort(ushort value)
		{
			return this.WriteBytes((byte*)(&value), 2);
		}

		// Token: 0x06000042 RID: 66 RVA: 0x0000368C File Offset: 0x0000188C
		public unsafe bool WriteInt(int value)
		{
			return this.WriteBytes((byte*)(&value), 4);
		}

		// Token: 0x06000043 RID: 67 RVA: 0x0000368C File Offset: 0x0000188C
		public unsafe bool WriteUInt(uint value)
		{
			return this.WriteBytes((byte*)(&value), 4);
		}

		// Token: 0x06000044 RID: 68 RVA: 0x00003698 File Offset: 0x00001898
		public unsafe bool WriteLong(long value)
		{
			return this.WriteBytes((byte*)(&value), 8);
		}

		// Token: 0x06000045 RID: 69 RVA: 0x00003698 File Offset: 0x00001898
		public unsafe bool WriteULong(ulong value)
		{
			return this.WriteBytes((byte*)(&value), 8);
		}

		// Token: 0x06000046 RID: 70 RVA: 0x000036A4 File Offset: 0x000018A4
		public unsafe bool WriteShortNetworkByteOrder(short value)
		{
			short num = DataStreamWriter.IsLittleEndian ? DataStreamWriter.ByteSwap(value) : value;
			return this.WriteBytes((byte*)(&num), 2);
		}

		// Token: 0x06000047 RID: 71 RVA: 0x000036CC File Offset: 0x000018CC
		public bool WriteUShortNetworkByteOrder(ushort value)
		{
			return this.WriteShortNetworkByteOrder((short)value);
		}

		// Token: 0x06000048 RID: 72 RVA: 0x000036D8 File Offset: 0x000018D8
		public unsafe bool WriteIntNetworkByteOrder(int value)
		{
			int num = DataStreamWriter.IsLittleEndian ? DataStreamWriter.ByteSwap(value) : value;
			return this.WriteBytes((byte*)(&num), 4);
		}

		// Token: 0x06000049 RID: 73 RVA: 0x00003700 File Offset: 0x00001900
		public bool WriteUIntNetworkByteOrder(uint value)
		{
			return this.WriteIntNetworkByteOrder((int)value);
		}

		// Token: 0x0600004A RID: 74 RVA: 0x0000370C File Offset: 0x0000190C
		public bool WriteFloat(float value)
		{
			return this.WriteInt((int)new UIntFloat
			{
				floatValue = value
			}.intValue);
		}

		// Token: 0x0600004B RID: 75 RVA: 0x00003738 File Offset: 0x00001938
		private unsafe void FlushBits()
		{
			while (this.m_Data.bitIndex >= 8)
			{
				ref byte buffer = ref *this.m_Data.buffer;
				int length = this.m_Data.length;
				this.m_Data.length = length + 1;
				*(ref buffer + length) = (byte)this.m_Data.bitBuffer;
				this.m_Data.bitIndex = this.m_Data.bitIndex - 8;
				this.m_Data.bitBuffer = this.m_Data.bitBuffer >> 8;
			}
		}

		// Token: 0x0600004C RID: 76 RVA: 0x000037A1 File Offset: 0x000019A1
		private void WriteRawBitsInternal(uint value, int numbits)
		{
			this.m_Data.bitBuffer = (this.m_Data.bitBuffer | (ulong)value << this.m_Data.bitIndex);
			this.m_Data.bitIndex = this.m_Data.bitIndex + numbits;
		}

		// Token: 0x0600004D RID: 77 RVA: 0x000037D4 File Offset: 0x000019D4
		public bool WriteRawBits(uint value, int numbits)
		{
			if (this.m_Data.length + (this.m_Data.bitIndex + numbits + 7 >> 3) > this.m_Data.capacity)
			{
				this.m_Data.failedWrites = this.m_Data.failedWrites + 1;
				return false;
			}
			this.WriteRawBitsInternal(value, numbits);
			this.FlushBits();
			return true;
		}

		// Token: 0x0600004E RID: 78 RVA: 0x0000382C File Offset: 0x00001A2C
		public unsafe bool WritePackedUInt(uint value, NetworkCompressionModel model)
		{
			int num = model.CalculateBucket(value);
			uint num2 = *(ref model.bucketOffsets.FixedElementField + (IntPtr)num * 4);
			int num3 = (int)(*(ref model.bucketSizes.FixedElementField + num));
			ushort num4 = *(ref model.encodeTable.FixedElementField + (IntPtr)num * 2);
			if (this.m_Data.length + (this.m_Data.bitIndex + (int)(num4 & 255) + num3 + 7 >> 3) > this.m_Data.capacity)
			{
				this.m_Data.failedWrites = this.m_Data.failedWrites + 1;
				return false;
			}
			this.WriteRawBitsInternal((uint)(num4 >> 8), (int)(num4 & 255));
			this.WriteRawBitsInternal(value - num2, num3);
			this.FlushBits();
			return true;
		}

		// Token: 0x0600004F RID: 79 RVA: 0x000038DD File Offset: 0x00001ADD
		public bool WritePackedULong(ulong value, NetworkCompressionModel model)
		{
			return this.WritePackedUInt((uint)(value >> 32), model) & this.WritePackedUInt((uint)(value & (ulong)-1), model);
		}

		// Token: 0x06000050 RID: 80 RVA: 0x000038F8 File Offset: 0x00001AF8
		public bool WritePackedInt(int value, NetworkCompressionModel model)
		{
			uint value2 = (uint)(value >> 31 ^ value << 1);
			return this.WritePackedUInt(value2, model);
		}

		// Token: 0x06000051 RID: 81 RVA: 0x00003918 File Offset: 0x00001B18
		public bool WritePackedLong(long value, NetworkCompressionModel model)
		{
			ulong value2 = (ulong)(value >> 63 ^ value << 1);
			return this.WritePackedULong(value2, model);
		}

		// Token: 0x06000052 RID: 82 RVA: 0x00003936 File Offset: 0x00001B36
		public bool WritePackedFloat(float value, NetworkCompressionModel model)
		{
			return this.WritePackedFloatDelta(value, 0f, model);
		}

		// Token: 0x06000053 RID: 83 RVA: 0x00003948 File Offset: 0x00001B48
		public bool WritePackedUIntDelta(uint value, uint baseline, NetworkCompressionModel model)
		{
			int value2 = (int)(baseline - value);
			return this.WritePackedInt(value2, model);
		}

		// Token: 0x06000054 RID: 84 RVA: 0x00003964 File Offset: 0x00001B64
		public bool WritePackedIntDelta(int value, int baseline, NetworkCompressionModel model)
		{
			int value2 = baseline - value;
			return this.WritePackedInt(value2, model);
		}

		// Token: 0x06000055 RID: 85 RVA: 0x00003980 File Offset: 0x00001B80
		public bool WritePackedLongDelta(long value, long baseline, NetworkCompressionModel model)
		{
			long value2 = baseline - value;
			return this.WritePackedLong(value2, model);
		}

		// Token: 0x06000056 RID: 86 RVA: 0x0000399C File Offset: 0x00001B9C
		public bool WritePackedULongDelta(ulong value, ulong baseline, NetworkCompressionModel model)
		{
			long value2 = (long)(baseline - value);
			return this.WritePackedLong(value2, model);
		}

		// Token: 0x06000057 RID: 87 RVA: 0x000039B8 File Offset: 0x00001BB8
		public bool WritePackedFloatDelta(float value, float baseline, NetworkCompressionModel model)
		{
			int num = 0;
			if (value != baseline)
			{
				num = 32;
			}
			if (this.m_Data.length + (this.m_Data.bitIndex + 1 + num + 7 >> 3) > this.m_Data.capacity)
			{
				this.m_Data.failedWrites = this.m_Data.failedWrites + 1;
				return false;
			}
			if (num == 0)
			{
				this.WriteRawBitsInternal(0U, 1);
			}
			else
			{
				this.WriteRawBitsInternal(1U, 1);
				this.WriteRawBitsInternal(new UIntFloat
				{
					floatValue = value
				}.intValue, num);
			}
			this.FlushBits();
			return true;
		}

		// Token: 0x06000058 RID: 88 RVA: 0x00003A48 File Offset: 0x00001C48
		public unsafe bool WriteFixedString32(FixedString32Bytes str)
		{
			int bytes = (int)(*(ushort*)(&str) + 2);
			byte* data = (byte*)(&str);
			return this.WriteBytes(data, bytes);
		}

		// Token: 0x06000059 RID: 89 RVA: 0x00003A68 File Offset: 0x00001C68
		public unsafe bool WriteFixedString64(FixedString64Bytes str)
		{
			int bytes = (int)(*(ushort*)(&str) + 2);
			byte* data = (byte*)(&str);
			return this.WriteBytes(data, bytes);
		}

		// Token: 0x0600005A RID: 90 RVA: 0x00003A88 File Offset: 0x00001C88
		public unsafe bool WriteFixedString128(FixedString128Bytes str)
		{
			int bytes = (int)(*(ushort*)(&str) + 2);
			byte* data = (byte*)(&str);
			return this.WriteBytes(data, bytes);
		}

		// Token: 0x0600005B RID: 91 RVA: 0x00003AA8 File Offset: 0x00001CA8
		public unsafe bool WriteFixedString512(FixedString512Bytes str)
		{
			int bytes = (int)(*(ushort*)(&str) + 2);
			byte* data = (byte*)(&str);
			return this.WriteBytes(data, bytes);
		}

		// Token: 0x0600005C RID: 92 RVA: 0x00003AC8 File Offset: 0x00001CC8
		public unsafe bool WriteFixedString4096(FixedString4096Bytes str)
		{
			int bytes = (int)(*(ushort*)(&str) + 2);
			byte* data = (byte*)(&str);
			return this.WriteBytes(data, bytes);
		}

		// Token: 0x0600005D RID: 93 RVA: 0x00003AE8 File Offset: 0x00001CE8
		public unsafe bool WritePackedFixedString32Delta(FixedString32Bytes str, FixedString32Bytes baseline, NetworkCompressionModel model)
		{
			ushort length = *(ushort*)(&str);
			byte* data = (byte*)(&str) + 2;
			return this.WritePackedFixedStringDelta(data, (uint)length, (byte*)(&baseline) + 2, (uint)(*(ushort*)(&baseline)), model);
		}

		// Token: 0x0600005E RID: 94 RVA: 0x00003B14 File Offset: 0x00001D14
		public unsafe bool WritePackedFixedString64Delta(FixedString64Bytes str, FixedString64Bytes baseline, NetworkCompressionModel model)
		{
			ushort length = *(ushort*)(&str);
			byte* data = (byte*)(&str) + 2;
			return this.WritePackedFixedStringDelta(data, (uint)length, (byte*)(&baseline) + 2, (uint)(*(ushort*)(&baseline)), model);
		}

		// Token: 0x0600005F RID: 95 RVA: 0x00003B40 File Offset: 0x00001D40
		public unsafe bool WritePackedFixedString128Delta(FixedString128Bytes str, FixedString128Bytes baseline, NetworkCompressionModel model)
		{
			ushort length = *(ushort*)(&str);
			byte* data = (byte*)(&str) + 2;
			return this.WritePackedFixedStringDelta(data, (uint)length, (byte*)(&baseline) + 2, (uint)(*(ushort*)(&baseline)), model);
		}

		// Token: 0x06000060 RID: 96 RVA: 0x00003B6C File Offset: 0x00001D6C
		public unsafe bool WritePackedFixedString512Delta(FixedString512Bytes str, FixedString512Bytes baseline, NetworkCompressionModel model)
		{
			ushort length = *(ushort*)(&str);
			byte* data = (byte*)(&str) + 2;
			return this.WritePackedFixedStringDelta(data, (uint)length, (byte*)(&baseline) + 2, (uint)(*(ushort*)(&baseline)), model);
		}

		// Token: 0x06000061 RID: 97 RVA: 0x00003B98 File Offset: 0x00001D98
		public unsafe bool WritePackedFixedString4096Delta(FixedString4096Bytes str, FixedString4096Bytes baseline, NetworkCompressionModel model)
		{
			ushort length = *(ushort*)(&str);
			byte* data = (byte*)(&str) + 2;
			return this.WritePackedFixedStringDelta(data, (uint)length, (byte*)(&baseline) + 2, (uint)(*(ushort*)(&baseline)), model);
		}

		// Token: 0x06000062 RID: 98 RVA: 0x00003BC4 File Offset: 0x00001DC4
		private unsafe bool WritePackedFixedStringDelta(byte* data, uint length, byte* baseData, uint baseLength, NetworkCompressionModel model)
		{
			DataStreamWriter.StreamData data2 = this.m_Data;
			if (!this.WritePackedUIntDelta(length, baseLength, model))
			{
				return false;
			}
			bool flag = false;
			if (length <= baseLength)
			{
				for (uint num = 0U; num < length; num += 1U)
				{
					flag |= !this.WritePackedUIntDelta((uint)data[num], (uint)baseData[num], model);
				}
			}
			else
			{
				for (uint num2 = 0U; num2 < baseLength; num2 += 1U)
				{
					flag |= !this.WritePackedUIntDelta((uint)data[num2], (uint)baseData[num2], model);
				}
				for (uint num3 = baseLength; num3 < length; num3 += 1U)
				{
					flag |= !this.WritePackedUInt((uint)data[num3], model);
				}
			}
			if (flag)
			{
				this.m_Data = data2;
				this.m_Data.failedWrites = this.m_Data.failedWrites + 1;
			}
			return !flag;
		}

		// Token: 0x06000063 RID: 99 RVA: 0x00003C7C File Offset: 0x00001E7C
		public void Clear()
		{
			this.m_Data.length = 0;
			this.m_Data.bitIndex = 0;
			this.m_Data.bitBuffer = 0UL;
			this.m_Data.failedWrites = 0;
		}

		// Token: 0x06000064 RID: 100 RVA: 0x00003CAF File Offset: 0x00001EAF
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private void CheckRead()
		{
		}

		// Token: 0x06000065 RID: 101 RVA: 0x00003CAF File Offset: 0x00001EAF
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private void CheckWrite()
		{
		}

		// Token: 0x06000066 RID: 102 RVA: 0x00003CB1 File Offset: 0x00001EB1
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private static void CheckAllocator(Allocator allocator)
		{
			if (allocator != Allocator.Temp)
			{
				throw new InvalidOperationException("DataStreamWriters can only be created with temp memory");
			}
		}

		// Token: 0x06000067 RID: 103 RVA: 0x00003CC2 File Offset: 0x00001EC2
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private static void CheckBits(uint value, int numbits)
		{
			if (numbits < 0 || numbits > 32)
			{
				throw new ArgumentOutOfRangeException("Invalid number of bits");
			}
			if ((ulong)value >= 1UL << numbits)
			{
				throw new ArgumentOutOfRangeException("Value does not fit in the specified number of bits");
			}
		}

		// Token: 0x04000033 RID: 51
		[NativeDisableUnsafePtrRestriction]
		private DataStreamWriter.StreamData m_Data;

		// Token: 0x04000034 RID: 52
		internal IntPtr m_SendHandleData;

		// Token: 0x02000012 RID: 18
		private struct StreamData
		{
			// Token: 0x04000035 RID: 53
			public unsafe byte* buffer;

			// Token: 0x04000036 RID: 54
			public int length;

			// Token: 0x04000037 RID: 55
			public int capacity;

			// Token: 0x04000038 RID: 56
			public ulong bitBuffer;

			// Token: 0x04000039 RID: 57
			public int bitIndex;

			// Token: 0x0400003A RID: 58
			public int failedWrites;
		}
	}
}
