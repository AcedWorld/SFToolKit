using System;
using System.Runtime.CompilerServices;
using Unity.Collections;

namespace Unity.Netcode
{
	// Token: 0x020000C8 RID: 200
	internal class UnmanagedArraySerializer<[IsUnmanaged] T> : INetworkVariableSerializer<NativeArray<T>> where T : struct, ValueType
	{
		// Token: 0x060004AF RID: 1199 RVA: 0x00014D46 File Offset: 0x00012F46
		public void Write(FastBufferWriter writer, ref NativeArray<T> value)
		{
			writer.WriteUnmanagedSafe<T>(value);
		}

		// Token: 0x060004B0 RID: 1200 RVA: 0x00014D55 File Offset: 0x00012F55
		public void Read(FastBufferReader reader, ref NativeArray<T> value)
		{
			value.Dispose();
			reader.ReadUnmanagedSafe<T>(out value, Allocator.Persistent);
		}

		// Token: 0x060004B1 RID: 1201 RVA: 0x00014D66 File Offset: 0x00012F66
		public void WriteDelta(FastBufferWriter writer, ref NativeArray<T> value, ref NativeArray<T> previousValue)
		{
			CollectionSerializationUtility.WriteNativeArrayDelta<T>(writer, ref value, ref previousValue);
		}

		// Token: 0x060004B2 RID: 1202 RVA: 0x00014D70 File Offset: 0x00012F70
		public void ReadDelta(FastBufferReader reader, ref NativeArray<T> value)
		{
			CollectionSerializationUtility.ReadNativeArrayDelta<T>(reader, ref value);
		}

		// Token: 0x060004B3 RID: 1203 RVA: 0x00014D79 File Offset: 0x00012F79
		void INetworkVariableSerializer<NativeArray<!0>>.ReadWithAllocator(FastBufferReader reader, out NativeArray<T> value, Allocator allocator)
		{
			reader.ReadUnmanagedSafe<T>(out value, allocator);
		}

		// Token: 0x060004B4 RID: 1204 RVA: 0x00014D84 File Offset: 0x00012F84
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

		// Token: 0x060004B6 RID: 1206 RVA: 0x00014DE4 File Offset: 0x00012FE4
		void INetworkVariableSerializer<NativeArray<!0>>.Duplicate(in NativeArray<T> value, ref NativeArray<T> duplicatedValue)
		{
			this.Duplicate(value, ref duplicatedValue);
		}
	}
}
