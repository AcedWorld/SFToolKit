using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Mathematics;

namespace Unity.Netcode
{
	// Token: 0x020000B4 RID: 180
	internal static class CollectionSerializationUtility
	{
		// Token: 0x06000417 RID: 1047 RVA: 0x000132E0 File Offset: 0x000114E0
		public unsafe static void WriteNativeArrayDelta<[IsUnmanaged] T>(FastBufferWriter writer, ref NativeArray<T> value, ref NativeArray<T> previousValue) where T : struct, ValueType
		{
			ResizableBitVector resizableBitVector = new ResizableBitVector(Allocator.Temp);
			try
			{
				int num = math.min(value.Length, previousValue.Length);
				int num2 = 0;
				for (int i = 0; i < num; i++)
				{
					T t = value[i];
					T t2 = previousValue[i];
					if (!NetworkVariableSerialization<T>.AreEqual(ref t, ref t2))
					{
						num2++;
						resizableBitVector.Set(i);
					}
				}
				for (int j = previousValue.Length; j < value.Length; j++)
				{
					num2++;
					resizableBitVector.Set(j);
				}
				if (resizableBitVector.GetSerializedSize() + FastBufferWriter.GetWriteSize<T>() * num2 > FastBufferWriter.GetWriteSize<T>() * value.Length)
				{
					writer.WriteByteSafe(1);
					writer.WriteValueSafe<T>(value, default(FastBufferWriter.ForGeneric));
				}
				else
				{
					writer.WriteByte(0);
					BytePacker.WriteValuePacked(writer, value.Length);
					writer.WriteValueSafe<ResizableBitVector>(resizableBitVector, default(FastBufferWriter.ForNetworkSerializable));
					T* unsafePtr = (T*)value.GetUnsafePtr<T>();
					T* unsafePtr2 = (T*)previousValue.GetUnsafePtr<T>();
					for (int k = 0; k < value.Length; k++)
					{
						if (resizableBitVector.IsSet(k))
						{
							if (k < previousValue.Length)
							{
								NetworkVariableSerialization<T>.WriteDelta(writer, ref unsafePtr[(IntPtr)k * (IntPtr)sizeof(T) / (IntPtr)sizeof(T)], ref unsafePtr2[(IntPtr)k * (IntPtr)sizeof(T) / (IntPtr)sizeof(T)]);
							}
							else
							{
								NetworkVariableSerialization<T>.Write(writer, ref unsafePtr[(IntPtr)k * (IntPtr)sizeof(T) / (IntPtr)sizeof(T)]);
							}
						}
					}
				}
			}
			finally
			{
				((IDisposable)resizableBitVector).Dispose();
			}
		}

		// Token: 0x06000418 RID: 1048 RVA: 0x00013478 File Offset: 0x00011678
		public unsafe static void ReadNativeArrayDelta<[IsUnmanaged] T>(FastBufferReader reader, ref NativeArray<T> value) where T : struct, ValueType
		{
			byte b;
			reader.ReadByteSafe(out b);
			if (b == 1)
			{
				value.Dispose();
				reader.ReadValueSafe<T>(out value, Allocator.Persistent, default(FastBufferWriter.ForGeneric));
				return;
			}
			int num;
			ByteUnpacker.ReadValuePacked(reader, out num);
			ResizableBitVector resizableBitVector = new ResizableBitVector(Allocator.Temp);
			using (resizableBitVector)
			{
				reader.ReadNetworkSerializableInPlace<ResizableBitVector>(ref resizableBitVector);
				int length = value.Length;
				if (num != value.Length)
				{
					NativeArray<T> nativeArray = new NativeArray<T>(num, Allocator.Persistent, NativeArrayOptions.ClearMemory);
					UnsafeUtility.MemCpy(nativeArray.GetUnsafePtr<T>(), value.GetUnsafePtr<T>(), (long)math.min(nativeArray.Length * sizeof(T), value.Length * sizeof(T)));
					value.Dispose();
					value = nativeArray;
				}
				T* unsafePtr = (T*)value.GetUnsafePtr<T>();
				for (int i = 0; i < value.Length; i++)
				{
					if (resizableBitVector.IsSet(i))
					{
						if (i < length)
						{
							NetworkVariableSerialization<T>.ReadDelta(reader, ref unsafePtr[(IntPtr)i * (IntPtr)sizeof(T) / (IntPtr)sizeof(T)]);
						}
						else
						{
							NetworkVariableSerialization<T>.Read(reader, ref unsafePtr[(IntPtr)i * (IntPtr)sizeof(T) / (IntPtr)sizeof(T)]);
						}
					}
				}
			}
		}

		// Token: 0x06000419 RID: 1049 RVA: 0x000135A4 File Offset: 0x000117A4
		public static void WriteListDelta<T>(FastBufferWriter writer, ref List<T> value, ref List<T> previousValue)
		{
			if (value == null || previousValue == null)
			{
				writer.WriteByteSafe(1);
				NetworkVariableSerialization<List<T>>.Write(writer, ref value);
				return;
			}
			ResizableBitVector resizableBitVector = new ResizableBitVector(Allocator.Temp);
			try
			{
				int num = math.min(value.Count, previousValue.Count);
				int num2 = 0;
				for (int i = 0; i < num; i++)
				{
					T t = value[i];
					T t2 = previousValue[i];
					if (!NetworkVariableSerialization<T>.AreEqual(ref t, ref t2))
					{
						num2++;
						resizableBitVector.Set(i);
					}
				}
				for (int j = previousValue.Count; j < value.Count; j++)
				{
					num2++;
					resizableBitVector.Set(j);
				}
				if ((double)num2 >= (double)value.Count * 0.9)
				{
					writer.WriteByteSafe(1);
					NetworkVariableSerialization<List<T>>.Write(writer, ref value);
				}
				else
				{
					writer.WriteByteSafe(0);
					BytePacker.WriteValuePacked(writer, value.Count);
					writer.WriteValueSafe<ResizableBitVector>(resizableBitVector, default(FastBufferWriter.ForNetworkSerializable));
					for (int k = 0; k < value.Count; k++)
					{
						if (resizableBitVector.IsSet(k))
						{
							T t3 = value[k];
							if (k < previousValue.Count)
							{
								T t4 = previousValue[k];
								NetworkVariableSerialization<T>.WriteDelta(writer, ref t3, ref t4);
							}
							else
							{
								NetworkVariableSerialization<T>.Write(writer, ref t3);
							}
						}
					}
				}
			}
			finally
			{
				((IDisposable)resizableBitVector).Dispose();
			}
		}

		// Token: 0x0600041A RID: 1050 RVA: 0x00013720 File Offset: 0x00011920
		public static void ReadListDelta<T>(FastBufferReader reader, ref List<T> value)
		{
			byte b;
			reader.ReadByteSafe(out b);
			if (b == 1)
			{
				NetworkVariableSerialization<List<T>>.Read(reader, ref value);
				return;
			}
			int num;
			ByteUnpacker.ReadValuePacked(reader, out num);
			ResizableBitVector resizableBitVector = new ResizableBitVector(Allocator.Temp);
			using (resizableBitVector)
			{
				reader.ReadNetworkSerializableInPlace<ResizableBitVector>(ref resizableBitVector);
				if (num < value.Count)
				{
					value.RemoveRange(num, value.Count - num);
				}
				for (int i = 0; i < num; i++)
				{
					if (resizableBitVector.IsSet(i))
					{
						if (i < value.Count)
						{
							T value2 = value[i];
							NetworkVariableSerialization<T>.ReadDelta(reader, ref value2);
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
			}
		}

		// Token: 0x0600041B RID: 1051 RVA: 0x000137F8 File Offset: 0x000119F8
		public static void WriteHashSetDelta<T>(FastBufferWriter writer, ref HashSet<T> value, ref HashSet<T> previousValue) where T : IEquatable<T>
		{
			if (value == null || previousValue == null)
			{
				writer.WriteByteSafe(1);
				NetworkVariableSerialization<HashSet<T>>.Write(writer, ref value);
				return;
			}
			List<T> addedList = CollectionSerializationUtility.ListCache<T>.GetAddedList();
			List<T> removedList = CollectionSerializationUtility.ListCache<T>.GetRemovedList();
			foreach (T item in value)
			{
				if (!previousValue.Contains(item))
				{
					addedList.Add(item);
				}
			}
			foreach (T item2 in previousValue)
			{
				if (!value.Contains(item2))
				{
					removedList.Add(item2);
				}
			}
			if (addedList.Count + removedList.Count >= value.Count)
			{
				writer.WriteByteSafe(1);
				NetworkVariableSerialization<HashSet<T>>.Write(writer, ref value);
				return;
			}
			writer.WriteByteSafe(0);
			int count = addedList.Count;
			writer.WriteValueSafe<int>(count, default(FastBufferWriter.ForPrimitives));
			for (int i = 0; i < addedList.Count; i++)
			{
				T t = addedList[i];
				NetworkVariableSerialization<T>.Write(writer, ref t);
			}
			count = removedList.Count;
			writer.WriteValueSafe<int>(count, default(FastBufferWriter.ForPrimitives));
			for (int j = 0; j < removedList.Count; j++)
			{
				T t2 = removedList[j];
				NetworkVariableSerialization<T>.Write(writer, ref t2);
			}
		}

		// Token: 0x0600041C RID: 1052 RVA: 0x00013974 File Offset: 0x00011B74
		public static void ReadHashSetDelta<T>(FastBufferReader reader, ref HashSet<T> value) where T : IEquatable<T>
		{
			byte b;
			reader.ReadByteSafe(out b);
			if (b != 0)
			{
				NetworkVariableSerialization<HashSet<T>>.Read(reader, ref value);
				return;
			}
			int num;
			reader.ReadValueSafe<int>(out num, default(FastBufferWriter.ForPrimitives));
			for (int i = 0; i < num; i++)
			{
				T item = default(T);
				NetworkVariableSerialization<T>.Read(reader, ref item);
				value.Add(item);
			}
			int num2;
			reader.ReadValueSafe<int>(out num2, default(FastBufferWriter.ForPrimitives));
			for (int j = 0; j < num2; j++)
			{
				T item2 = default(T);
				NetworkVariableSerialization<T>.Read(reader, ref item2);
				value.Remove(item2);
			}
		}

		// Token: 0x0600041D RID: 1053 RVA: 0x00013A10 File Offset: 0x00011C10
		public static void WriteDictionaryDelta<TKey, TVal>(FastBufferWriter writer, ref Dictionary<TKey, TVal> value, ref Dictionary<TKey, TVal> previousValue) where TKey : IEquatable<TKey>
		{
			if (value == null || previousValue == null)
			{
				writer.WriteByteSafe(1);
				NetworkVariableSerialization<Dictionary<TKey, TVal>>.Write(writer, ref value);
				return;
			}
			List<KeyValuePair<TKey, TVal>> addedList = CollectionSerializationUtility.ListCache<KeyValuePair<TKey, TVal>>.GetAddedList();
			List<KeyValuePair<TKey, TVal>> removedList = CollectionSerializationUtility.ListCache<KeyValuePair<TKey, TVal>>.GetRemovedList();
			List<KeyValuePair<TKey, TVal>> changedList = CollectionSerializationUtility.ListCache<KeyValuePair<TKey, TVal>>.GetChangedList();
			foreach (KeyValuePair<TKey, TVal> item in value)
			{
				TVal value2 = item.Value;
				TVal tval;
				if (!previousValue.TryGetValue(item.Key, out tval))
				{
					addedList.Add(item);
				}
				else if (!NetworkVariableSerialization<TVal>.AreEqual(ref value2, ref tval))
				{
					removedList.Add(item);
				}
			}
			foreach (KeyValuePair<TKey, TVal> item2 in previousValue)
			{
				if (!value.ContainsKey(item2.Key))
				{
					changedList.Add(item2);
				}
			}
			if (addedList.Count + changedList.Count + removedList.Count >= value.Count)
			{
				writer.WriteByteSafe(1);
				NetworkVariableSerialization<Dictionary<TKey, TVal>>.Write(writer, ref value);
				return;
			}
			writer.WriteByteSafe(0);
			int count = addedList.Count;
			writer.WriteValueSafe<int>(count, default(FastBufferWriter.ForPrimitives));
			for (int i = 0; i < addedList.Count; i++)
			{
				TKey key = addedList[i].Key;
				TVal value3 = addedList[i].Value;
				TKey tkey = key;
				TVal tval2 = value3;
				NetworkVariableSerialization<TKey>.Write(writer, ref tkey);
				NetworkVariableSerialization<TVal>.Write(writer, ref tval2);
			}
			count = changedList.Count;
			writer.WriteValueSafe<int>(count, default(FastBufferWriter.ForPrimitives));
			for (int j = 0; j < changedList.Count; j++)
			{
				TKey key2 = changedList[j].Key;
				NetworkVariableSerialization<TKey>.Write(writer, ref key2);
			}
			count = removedList.Count;
			writer.WriteValueSafe<int>(count, default(FastBufferWriter.ForPrimitives));
			for (int k = 0; k < removedList.Count; k++)
			{
				TKey key = removedList[k].Key;
				TVal value4 = removedList[k].Value;
				TKey tkey2 = key;
				TVal tval3 = value4;
				NetworkVariableSerialization<TKey>.Write(writer, ref tkey2);
				NetworkVariableSerialization<TVal>.Write(writer, ref tval3);
			}
		}

		// Token: 0x0600041E RID: 1054 RVA: 0x00013C64 File Offset: 0x00011E64
		public static void ReadDictionaryDelta<TKey, TVal>(FastBufferReader reader, ref Dictionary<TKey, TVal> value) where TKey : IEquatable<TKey>
		{
			byte b;
			reader.ReadByteSafe(out b);
			if (b != 0)
			{
				NetworkVariableSerialization<Dictionary<TKey, TVal>>.Read(reader, ref value);
				return;
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
			reader.ReadValueSafe<int>(out num, default(FastBufferWriter.ForPrimitives));
			for (int j = 0; j < num; j++)
			{
				TKey key2 = default(TKey);
				NetworkVariableSerialization<TKey>.Read(reader, ref key2);
				value.Remove(key2);
			}
			reader.ReadValueSafe<int>(out num, default(FastBufferWriter.ForPrimitives));
			for (int k = 0; k < num; k++)
			{
				TKey key3 = default(TKey);
				TVal value3 = default(TVal);
				NetworkVariableSerialization<TKey>.Read(reader, ref key3);
				NetworkVariableSerialization<TVal>.Read(reader, ref value3);
				value[key3] = value3;
			}
		}

		// Token: 0x020000B5 RID: 181
		private static class ListCache<T>
		{
			// Token: 0x0600041F RID: 1055 RVA: 0x00013D57 File Offset: 0x00011F57
			public static List<T> GetAddedList()
			{
				CollectionSerializationUtility.ListCache<T>.s_AddedList.Clear();
				return CollectionSerializationUtility.ListCache<T>.s_AddedList;
			}

			// Token: 0x06000420 RID: 1056 RVA: 0x00013D68 File Offset: 0x00011F68
			public static List<T> GetRemovedList()
			{
				CollectionSerializationUtility.ListCache<T>.s_RemovedList.Clear();
				return CollectionSerializationUtility.ListCache<T>.s_RemovedList;
			}

			// Token: 0x06000421 RID: 1057 RVA: 0x00013D79 File Offset: 0x00011F79
			public static List<T> GetChangedList()
			{
				CollectionSerializationUtility.ListCache<T>.s_ChangedList.Clear();
				return CollectionSerializationUtility.ListCache<T>.s_ChangedList;
			}

			// Token: 0x04000247 RID: 583
			private static List<T> s_AddedList = new List<T>();

			// Token: 0x04000248 RID: 584
			private static List<T> s_RemovedList = new List<T>();

			// Token: 0x04000249 RID: 585
			private static List<T> s_ChangedList = new List<T>();
		}
	}
}
