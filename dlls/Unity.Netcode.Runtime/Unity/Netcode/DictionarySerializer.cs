using System;
using System.Collections.Generic;
using Unity.Collections;

namespace Unity.Netcode
{
	// Token: 0x020000C7 RID: 199
	internal class DictionarySerializer<TKey, TVal> : INetworkVariableSerializer<Dictionary<TKey, TVal>> where TKey : IEquatable<TKey>
	{
		// Token: 0x060004A7 RID: 1191 RVA: 0x00014B68 File Offset: 0x00012D68
		public void Write(FastBufferWriter writer, ref Dictionary<TKey, TVal> value)
		{
			bool flag = value == null;
			writer.WriteValueSafe<bool>(flag, default(FastBufferWriter.ForPrimitives));
			if (!flag)
			{
				int count = value.Count;
				writer.WriteValueSafe<int>(count, default(FastBufferWriter.ForPrimitives));
				foreach (KeyValuePair<TKey, TVal> keyValuePair in value)
				{
					TKey key = keyValuePair.Key;
					TVal value2 = keyValuePair.Value;
					TKey tkey = key;
					TVal tval = value2;
					NetworkVariableSerialization<TKey>.Write(writer, ref tkey);
					NetworkVariableSerialization<TVal>.Write(writer, ref tval);
				}
			}
		}

		// Token: 0x060004A8 RID: 1192 RVA: 0x00014C0C File Offset: 0x00012E0C
		public void Read(FastBufferReader reader, ref Dictionary<TKey, TVal> value)
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
				value = new Dictionary<TKey, TVal>();
			}
			else
			{
				value.Clear();
			}
			int num;
			reader.ReadValueSafe<int>(out num, default(FastBufferWriter.ForPrimitives));
			for (int i = 0; i < num; i++)
			{
				TKey key = default(TKey);
				TVal value2 = default(TVal);
				NetworkVariableSerialization<TKey>.Read(reader, ref key);
				NetworkVariableSerialization<TVal>.Read(reader, ref value2);
				value.Add(key, value2);
			}
		}

		// Token: 0x060004A9 RID: 1193 RVA: 0x00014C8F File Offset: 0x00012E8F
		public void WriteDelta(FastBufferWriter writer, ref Dictionary<TKey, TVal> value, ref Dictionary<TKey, TVal> previousValue)
		{
			CollectionSerializationUtility.WriteDictionaryDelta<TKey, TVal>(writer, ref value, ref previousValue);
		}

		// Token: 0x060004AA RID: 1194 RVA: 0x00014C99 File Offset: 0x00012E99
		public void ReadDelta(FastBufferReader reader, ref Dictionary<TKey, TVal> value)
		{
			CollectionSerializationUtility.ReadDictionaryDelta<TKey, TVal>(reader, ref value);
		}

		// Token: 0x060004AB RID: 1195 RVA: 0x0000FE91 File Offset: 0x0000E091
		void INetworkVariableSerializer<Dictionary<!0, !1>>.ReadWithAllocator(FastBufferReader reader, out Dictionary<TKey, TVal> value, Allocator allocator)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060004AC RID: 1196 RVA: 0x00014CA4 File Offset: 0x00012EA4
		public void Duplicate(in Dictionary<TKey, TVal> value, ref Dictionary<TKey, TVal> duplicatedValue)
		{
			if (duplicatedValue == null)
			{
				duplicatedValue = new Dictionary<TKey, TVal>();
			}
			duplicatedValue.Clear();
			foreach (KeyValuePair<TKey, TVal> keyValuePair in value)
			{
				TKey key = default(TKey);
				TVal value2 = default(TVal);
				TKey key2 = keyValuePair.Key;
				NetworkVariableSerialization<TKey>.Duplicate(key2, ref key);
				TVal value3 = keyValuePair.Value;
				NetworkVariableSerialization<TVal>.Duplicate(value3, ref value2);
				duplicatedValue.Add(key, value2);
			}
		}

		// Token: 0x060004AE RID: 1198 RVA: 0x00014D3C File Offset: 0x00012F3C
		void INetworkVariableSerializer<Dictionary<!0, !1>>.Duplicate(in Dictionary<TKey, TVal> value, ref Dictionary<TKey, TVal> duplicatedValue)
		{
			this.Duplicate(value, ref duplicatedValue);
		}
	}
}
