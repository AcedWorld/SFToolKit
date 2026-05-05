using System;
using System.Runtime.CompilerServices;
using Unity.Collections;

namespace Unity.Netcode
{
	// Token: 0x020000CB RID: 203
	internal class UnmanagedNetworkSerializableSerializer<[IsUnmanaged] T> : INetworkVariableSerializer<!0> where T : struct, ValueType, INetworkSerializable
	{
		// Token: 0x060004C7 RID: 1223 RVA: 0x00015100 File Offset: 0x00013300
		public void Write(FastBufferWriter writer, ref T value)
		{
			BufferSerializer<BufferSerializerWriter> serializer = new BufferSerializer<BufferSerializerWriter>(new BufferSerializerWriter(writer));
			value.NetworkSerialize<BufferSerializerWriter>(serializer);
		}

		// Token: 0x060004C8 RID: 1224 RVA: 0x00015128 File Offset: 0x00013328
		public void Read(FastBufferReader reader, ref T value)
		{
			BufferSerializer<BufferSerializerReader> serializer = new BufferSerializer<BufferSerializerReader>(new BufferSerializerReader(reader));
			value.NetworkSerialize<BufferSerializerReader>(serializer);
		}

		// Token: 0x060004C9 RID: 1225 RVA: 0x0001514F File Offset: 0x0001334F
		public void WriteDelta(FastBufferWriter writer, ref T value, ref T previousValue)
		{
			if (UserNetworkVariableSerialization<T>.WriteDelta != null && UserNetworkVariableSerialization<T>.ReadDelta != null)
			{
				UserNetworkVariableSerialization<T>.WriteDelta(writer, value, previousValue);
				return;
			}
			this.Write(writer, ref value);
		}

		// Token: 0x060004CA RID: 1226 RVA: 0x00015175 File Offset: 0x00013375
		public void ReadDelta(FastBufferReader reader, ref T value)
		{
			if (UserNetworkVariableSerialization<T>.WriteDelta != null && UserNetworkVariableSerialization<T>.ReadDelta != null)
			{
				UserNetworkVariableSerialization<T>.ReadDelta(reader, ref value);
				return;
			}
			this.Read(reader, ref value);
		}

		// Token: 0x060004CB RID: 1227 RVA: 0x0000FE91 File Offset: 0x0000E091
		void INetworkVariableSerializer<!0>.ReadWithAllocator(FastBufferReader reader, out T value, Allocator allocator)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060004CC RID: 1228 RVA: 0x00014812 File Offset: 0x00012A12
		public void Duplicate(in T value, ref T duplicatedValue)
		{
			duplicatedValue = value;
		}

		// Token: 0x060004CE RID: 1230 RVA: 0x0001519A File Offset: 0x0001339A
		void INetworkVariableSerializer<!0>.Duplicate(in T value, ref T duplicatedValue)
		{
			this.Duplicate(value, ref duplicatedValue);
		}
	}
}
