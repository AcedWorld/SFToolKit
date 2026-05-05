using System;
using System.Runtime.CompilerServices;
using Unity.Collections;

namespace Unity.Netcode
{
	// Token: 0x020000CC RID: 204
	internal class UnmanagedNetworkSerializableArraySerializer<[IsUnmanaged] T> : INetworkVariableSerializer<NativeArray<!0>> where T : struct, ValueType, INetworkSerializable
	{
		// Token: 0x060004CF RID: 1231 RVA: 0x000151A4 File Offset: 0x000133A4
		public void Write(FastBufferWriter writer, ref NativeArray<T> value)
		{
			writer.WriteNetworkSerializable<T>(value, -1, 0);
		}

		// Token: 0x060004D0 RID: 1232 RVA: 0x000151B5 File Offset: 0x000133B5
		public void Read(FastBufferReader reader, ref NativeArray<T> value)
		{
			value.Dispose();
			reader.ReadNetworkSerializable<T>(out value, Allocator.Persistent);
		}

		// Token: 0x060004D1 RID: 1233 RVA: 0x00014D66 File Offset: 0x00012F66
		public void WriteDelta(FastBufferWriter writer, ref NativeArray<T> value, ref NativeArray<T> previousValue)
		{
			CollectionSerializationUtility.WriteNativeArrayDelta<T>(writer, ref value, ref previousValue);
		}

		// Token: 0x060004D2 RID: 1234 RVA: 0x00014D70 File Offset: 0x00012F70
		public void ReadDelta(FastBufferReader reader, ref NativeArray<T> value)
		{
			CollectionSerializationUtility.ReadNativeArrayDelta<T>(reader, ref value);
		}

		// Token: 0x060004D3 RID: 1235 RVA: 0x000151C6 File Offset: 0x000133C6
		void INetworkVariableSerializer<NativeArray<!0>>.ReadWithAllocator(FastBufferReader reader, out NativeArray<T> value, Allocator allocator)
		{
			reader.ReadNetworkSerializable<T>(out value, allocator);
		}

		// Token: 0x060004D4 RID: 1236 RVA: 0x000151D4 File Offset: 0x000133D4
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

		// Token: 0x060004D6 RID: 1238 RVA: 0x00015234 File Offset: 0x00013434
		void INetworkVariableSerializer<NativeArray<!0>>.Duplicate(in NativeArray<T> value, ref NativeArray<T> duplicatedValue)
		{
			this.Duplicate(value, ref duplicatedValue);
		}
	}
}
