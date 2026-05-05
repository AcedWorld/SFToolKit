using System;
using System.Runtime.CompilerServices;
using Unity.Collections;

namespace Unity.Netcode
{
	// Token: 0x020000CA RID: 202
	internal class FixedStringArraySerializer<[IsUnmanaged] T> : INetworkVariableSerializer<NativeArray<!0>> where T : struct, ValueType, INativeList<byte>, IUTF8Bytes
	{
		// Token: 0x060004BF RID: 1215 RVA: 0x0001506E File Offset: 0x0001326E
		public void Write(FastBufferWriter writer, ref NativeArray<T> value)
		{
			writer.WriteValueSafe<T>(value);
		}

		// Token: 0x060004C0 RID: 1216 RVA: 0x00015078 File Offset: 0x00013278
		public void Read(FastBufferReader reader, ref NativeArray<T> value)
		{
			value.Dispose();
			reader.ReadValueSafe<T>(out value, Allocator.Persistent);
		}

		// Token: 0x060004C1 RID: 1217 RVA: 0x00014D66 File Offset: 0x00012F66
		public void WriteDelta(FastBufferWriter writer, ref NativeArray<T> value, ref NativeArray<T> previousValue)
		{
			CollectionSerializationUtility.WriteNativeArrayDelta<T>(writer, ref value, ref previousValue);
		}

		// Token: 0x060004C2 RID: 1218 RVA: 0x00014D70 File Offset: 0x00012F70
		public void ReadDelta(FastBufferReader reader, ref NativeArray<T> value)
		{
			CollectionSerializationUtility.ReadNativeArrayDelta<T>(reader, ref value);
		}

		// Token: 0x060004C3 RID: 1219 RVA: 0x00015089 File Offset: 0x00013289
		void INetworkVariableSerializer<NativeArray<!0>>.ReadWithAllocator(FastBufferReader reader, out NativeArray<T> value, Allocator allocator)
		{
			reader.ReadValueSafe<T>(out value, allocator);
		}

		// Token: 0x060004C4 RID: 1220 RVA: 0x00015094 File Offset: 0x00013294
		public void Duplicate(in NativeArray<T> value, ref NativeArray<T> duplicatedValue)
		{
			NativeArray<T> nativeArray;
			if (duplicatedValue.IsCreated)
			{
				int length = duplicatedValue.Length;
				nativeArray = value;
				if (length == nativeArray.Length)
				{
					goto IL_47;
				}
			}
			if (duplicatedValue.IsCreated)
			{
				duplicatedValue.Dispose();
			}
			nativeArray = value;
			duplicatedValue = new NativeArray<T>(nativeArray.Length, Allocator.Persistent, NativeArrayOptions.UninitializedMemory);
			IL_47:
			duplicatedValue.CopyFrom(value);
		}

		// Token: 0x060004C6 RID: 1222 RVA: 0x000150F4 File Offset: 0x000132F4
		void INetworkVariableSerializer<NativeArray<!0>>.Duplicate(in NativeArray<T> value, ref NativeArray<T> duplicatedValue)
		{
			this.Duplicate(value, ref duplicatedValue);
		}
	}
}
