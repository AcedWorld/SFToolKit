using System;
using System.Collections.Generic;
using Unity.Collections;

namespace Unity.Netcode
{
	// Token: 0x020000C6 RID: 198
	internal class HashSetSerializer<T> : INetworkVariableSerializer<HashSet<T>> where T : IEquatable<T>
	{
		// Token: 0x0600049F RID: 1183 RVA: 0x000149D8 File Offset: 0x00012BD8
		public void Write(FastBufferWriter writer, ref HashSet<T> value)
		{
			bool flag = value == null;
			writer.WriteValueSafe<bool>(flag, default(FastBufferWriter.ForPrimitives));
			if (!flag)
			{
				int count = value.Count;
				writer.WriteValueSafe<int>(count, default(FastBufferWriter.ForPrimitives));
				foreach (T t in value)
				{
					NetworkVariableSerialization<T>.Write(writer, ref t);
				}
			}
		}

		// Token: 0x060004A0 RID: 1184 RVA: 0x00014A60 File Offset: 0x00012C60
		public void Read(FastBufferReader reader, ref HashSet<T> value)
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
				value = new HashSet<T>();
			}
			else
			{
				value.Clear();
			}
			int num;
			reader.ReadValueSafe<int>(out num, default(FastBufferWriter.ForPrimitives));
			for (int i = 0; i < num; i++)
			{
				T item = default(T);
				NetworkVariableSerialization<T>.Read(reader, ref item);
				value.Add(item);
			}
		}

		// Token: 0x060004A1 RID: 1185 RVA: 0x00014AD2 File Offset: 0x00012CD2
		public void WriteDelta(FastBufferWriter writer, ref HashSet<T> value, ref HashSet<T> previousValue)
		{
			CollectionSerializationUtility.WriteHashSetDelta<T>(writer, ref value, ref previousValue);
		}

		// Token: 0x060004A2 RID: 1186 RVA: 0x00014ADC File Offset: 0x00012CDC
		public void ReadDelta(FastBufferReader reader, ref HashSet<T> value)
		{
			CollectionSerializationUtility.ReadHashSetDelta<T>(reader, ref value);
		}

		// Token: 0x060004A3 RID: 1187 RVA: 0x0000FE91 File Offset: 0x0000E091
		void INetworkVariableSerializer<HashSet<!0>>.ReadWithAllocator(FastBufferReader reader, out HashSet<T> value, Allocator allocator)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060004A4 RID: 1188 RVA: 0x00014AE8 File Offset: 0x00012CE8
		public void Duplicate(in HashSet<T> value, ref HashSet<T> duplicatedValue)
		{
			if (duplicatedValue == null)
			{
				duplicatedValue = new HashSet<T>();
			}
			duplicatedValue.Clear();
			foreach (T item in value)
			{
				T t = default(T);
				NetworkVariableSerialization<T>.Duplicate(item, ref t);
				duplicatedValue.Add(item);
			}
		}

		// Token: 0x060004A6 RID: 1190 RVA: 0x00014B5C File Offset: 0x00012D5C
		void INetworkVariableSerializer<HashSet<!0>>.Duplicate(in HashSet<T> value, ref HashSet<T> duplicatedValue)
		{
			this.Duplicate(value, ref duplicatedValue);
		}
	}
}
