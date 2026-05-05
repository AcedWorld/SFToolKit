using System;
using Unity.Collections;

namespace Unity.Netcode
{
	// Token: 0x020000CD RID: 205
	internal class ManagedNetworkSerializableSerializer<T> : INetworkVariableSerializer<!0> where T : class, INetworkSerializable, new()
	{
		// Token: 0x060004D7 RID: 1239 RVA: 0x00015240 File Offset: 0x00013440
		public void Write(FastBufferWriter writer, ref T value)
		{
			BufferSerializer<BufferSerializerWriter> serializer = new BufferSerializer<BufferSerializerWriter>(new BufferSerializerWriter(writer));
			bool flag = value == null;
			serializer.SerializeValue<bool>(ref flag, default(FastBufferWriter.ForPrimitives));
			if (!flag)
			{
				value.NetworkSerialize<BufferSerializerWriter>(serializer);
			}
		}

		// Token: 0x060004D8 RID: 1240 RVA: 0x0001528C File Offset: 0x0001348C
		public void Read(FastBufferReader reader, ref T value)
		{
			BufferSerializer<BufferSerializerReader> serializer = new BufferSerializer<BufferSerializerReader>(new BufferSerializerReader(reader));
			bool flag = false;
			serializer.SerializeValue<bool>(ref flag, default(FastBufferWriter.ForPrimitives));
			if (flag)
			{
				value = default(T);
				return;
			}
			if (value == null)
			{
				value = Activator.CreateInstance<T>();
			}
			value.NetworkSerialize<BufferSerializerReader>(serializer);
		}

		// Token: 0x060004D9 RID: 1241 RVA: 0x000152EA File Offset: 0x000134EA
		public void WriteDelta(FastBufferWriter writer, ref T value, ref T previousValue)
		{
			if (UserNetworkVariableSerialization<T>.WriteDelta != null && UserNetworkVariableSerialization<T>.ReadDelta != null)
			{
				UserNetworkVariableSerialization<T>.WriteDelta(writer, value, previousValue);
				return;
			}
			this.Write(writer, ref value);
		}

		// Token: 0x060004DA RID: 1242 RVA: 0x00015310 File Offset: 0x00013510
		public void ReadDelta(FastBufferReader reader, ref T value)
		{
			if (UserNetworkVariableSerialization<T>.WriteDelta != null && UserNetworkVariableSerialization<T>.ReadDelta != null)
			{
				UserNetworkVariableSerialization<T>.ReadDelta(reader, ref value);
				return;
			}
			this.Read(reader, ref value);
		}

		// Token: 0x060004DB RID: 1243 RVA: 0x0000FE91 File Offset: 0x0000E091
		void INetworkVariableSerializer<!0>.ReadWithAllocator(FastBufferReader reader, out T value, Allocator allocator)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060004DC RID: 1244 RVA: 0x00015338 File Offset: 0x00013538
		public void Duplicate(in T value, ref T duplicatedValue)
		{
			using (FastBufferWriter writer = new FastBufferWriter(256, Allocator.Temp, int.MaxValue))
			{
				T t = value;
				this.Write(writer, ref t);
				using (FastBufferReader reader = new FastBufferReader(writer, Allocator.None, -1, 0, Allocator.Temp))
				{
					this.Read(reader, ref duplicatedValue);
				}
			}
		}

		// Token: 0x060004DE RID: 1246 RVA: 0x000153B4 File Offset: 0x000135B4
		void INetworkVariableSerializer<!0>.Duplicate(in T value, ref T duplicatedValue)
		{
			this.Duplicate(value, ref duplicatedValue);
		}
	}
}
