using System;
using System.Collections.Generic;
using Unity.Collections;

namespace Unity.Netcode
{
	// Token: 0x020000C5 RID: 197
	internal class ListSerializer<T> : INetworkVariableSerializer<List<T>>
	{
		// Token: 0x06000497 RID: 1175 RVA: 0x0001482C File Offset: 0x00012A2C
		public void Write(FastBufferWriter writer, ref List<T> value)
		{
			bool flag = value == null;
			writer.WriteValueSafe<bool>(flag, default(FastBufferWriter.ForPrimitives));
			if (!flag)
			{
				BytePacker.WriteValuePacked(writer, value.Count);
				foreach (T t in value)
				{
					NetworkVariableSerialization<T>.Write(writer, ref t);
				}
			}
		}

		// Token: 0x06000498 RID: 1176 RVA: 0x000148A4 File Offset: 0x00012AA4
		public void Read(FastBufferReader reader, ref List<T> value)
		{
			bool flag;
			reader.ReadValueSafe<bool>(out flag, default(FastBufferWriter.ForPrimitives));
			if (flag)
			{
				value = null;
				return;
			}
			if (value == null)
			{
				value = new List<T>();
			}
			int num;
			ByteUnpacker.ReadValuePacked(reader, out num);
			if (num < value.Count)
			{
				value.RemoveRange(num, value.Count - num);
			}
			for (int i = 0; i < num; i++)
			{
				if (i < value.Count)
				{
					T value2 = value[i];
					NetworkVariableSerialization<T>.Read(reader, ref value2);
					value[i] = value2;
				}
				else
				{
					T item = default(T);
					NetworkVariableSerialization<T>.Read(reader, ref item);
					value.Add(item);
				}
			}
		}

		// Token: 0x06000499 RID: 1177 RVA: 0x00014945 File Offset: 0x00012B45
		public void WriteDelta(FastBufferWriter writer, ref List<T> value, ref List<T> previousValue)
		{
			CollectionSerializationUtility.WriteListDelta<T>(writer, ref value, ref previousValue);
		}

		// Token: 0x0600049A RID: 1178 RVA: 0x0001494F File Offset: 0x00012B4F
		public void ReadDelta(FastBufferReader reader, ref List<T> value)
		{
			CollectionSerializationUtility.ReadListDelta<T>(reader, ref value);
		}

		// Token: 0x0600049B RID: 1179 RVA: 0x0000FE91 File Offset: 0x0000E091
		void INetworkVariableSerializer<List<!0>>.ReadWithAllocator(FastBufferReader reader, out List<T> value, Allocator allocator)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600049C RID: 1180 RVA: 0x00014958 File Offset: 0x00012B58
		public void Duplicate(in List<T> value, ref List<T> duplicatedValue)
		{
			if (duplicatedValue == null)
			{
				duplicatedValue = new List<T>();
			}
			duplicatedValue.Clear();
			foreach (T t in value)
			{
				T item = default(T);
				NetworkVariableSerialization<T>.Duplicate(t, ref item);
				duplicatedValue.Add(item);
			}
		}

		// Token: 0x0600049E RID: 1182 RVA: 0x000149CC File Offset: 0x00012BCC
		void INetworkVariableSerializer<List<!0>>.Duplicate(in List<T> value, ref List<T> duplicatedValue)
		{
			this.Duplicate(value, ref duplicatedValue);
		}
	}
}
