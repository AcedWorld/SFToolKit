using System;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;

namespace Unity.Netcode
{
	// Token: 0x020000DA RID: 218
	internal struct ResizableBitVector : INetworkSerializable, IDisposable
	{
		// Token: 0x0600052A RID: 1322 RVA: 0x00015ABA File Offset: 0x00013CBA
		public ResizableBitVector(Allocator allocator)
		{
			this.m_Bits = new NativeList<byte>(allocator);
		}

		// Token: 0x0600052B RID: 1323 RVA: 0x00015ACD File Offset: 0x00013CCD
		public void Dispose()
		{
			this.m_Bits.Dispose();
		}

		// Token: 0x0600052C RID: 1324 RVA: 0x00015ADA File Offset: 0x00013CDA
		public int GetSerializedSize()
		{
			return 4 + this.m_Bits.Length;
		}

		// Token: 0x0600052D RID: 1325 RVA: 0x00015AEC File Offset: 0x00013CEC
		private ValueTuple<int, int> GetBitData(int i)
		{
			int item = i / 8;
			int item2 = i % 8;
			return new ValueTuple<int, int>(item, item2);
		}

		// Token: 0x0600052E RID: 1326 RVA: 0x00015B08 File Offset: 0x00013D08
		public void Set(int i)
		{
			ValueTuple<int, int> bitData = this.GetBitData(i);
			int item = bitData.Item1;
			int item2 = bitData.Item2;
			if (item >= this.m_Bits.Length)
			{
				this.m_Bits.Resize(item + 1, NativeArrayOptions.ClearMemory);
			}
			ref NativeList<byte> ptr = ref this.m_Bits;
			int index = item;
			ptr[index] |= (byte)(1 << item2);
		}

		// Token: 0x0600052F RID: 1327 RVA: 0x00015B68 File Offset: 0x00013D68
		public void Unset(int i)
		{
			ValueTuple<int, int> bitData = this.GetBitData(i);
			int item = bitData.Item1;
			int item2 = bitData.Item2;
			if (item >= this.m_Bits.Length)
			{
				return;
			}
			ref NativeList<byte> ptr = ref this.m_Bits;
			int index = item;
			ptr[index] &= (byte)(~(byte)(1 << item2));
		}

		// Token: 0x06000530 RID: 1328 RVA: 0x00015BBC File Offset: 0x00013DBC
		public bool IsSet(int i)
		{
			ValueTuple<int, int> bitData = this.GetBitData(i);
			int item = bitData.Item1;
			int item2 = bitData.Item2;
			return item < this.m_Bits.Length && (this.m_Bits[item] & (byte)(1 << item2)) > 0;
		}

		// Token: 0x06000531 RID: 1329 RVA: 0x00015C04 File Offset: 0x00013E04
		public unsafe void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
		{
			int length = this.m_Bits.Length;
			serializer.SerializeValue<int>(ref length, default(FastBufferWriter.ForPrimitives));
			this.m_Bits.ResizeUninitialized(length);
			void* unsafePtr = this.m_Bits.GetUnsafePtr<byte>();
			if (serializer.IsReader)
			{
				serializer.GetFastBufferReader().ReadBytesSafe((byte*)unsafePtr, length, 0);
				return;
			}
			serializer.GetFastBufferWriter().WriteBytesSafe((byte*)unsafePtr, length, 0);
		}

		// Token: 0x0400026C RID: 620
		private NativeList<byte> m_Bits;

		// Token: 0x0400026D RID: 621
		private const int k_Divisor = 8;
	}
}
