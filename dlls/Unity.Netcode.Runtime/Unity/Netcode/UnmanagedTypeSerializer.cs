using System;
using System.Runtime.CompilerServices;
using Unity.Collections;

namespace Unity.Netcode
{
	// Token: 0x020000C4 RID: 196
	internal class UnmanagedTypeSerializer<[IsUnmanaged] T> : INetworkVariableSerializer<T> where T : struct, ValueType
	{
		// Token: 0x0600048F RID: 1167 RVA: 0x000147EA File Offset: 0x000129EA
		public void Write(FastBufferWriter writer, ref T value)
		{
			writer.WriteUnmanagedSafe<T>(value);
		}

		// Token: 0x06000490 RID: 1168 RVA: 0x000147F4 File Offset: 0x000129F4
		public void Read(FastBufferReader reader, ref T value)
		{
			reader.ReadUnmanagedSafe<T>(out value);
		}

		// Token: 0x06000491 RID: 1169 RVA: 0x000147FE File Offset: 0x000129FE
		public void WriteDelta(FastBufferWriter writer, ref T value, ref T previousValue)
		{
			this.Write(writer, ref value);
		}

		// Token: 0x06000492 RID: 1170 RVA: 0x00014808 File Offset: 0x00012A08
		public void ReadDelta(FastBufferReader reader, ref T value)
		{
			this.Read(reader, ref value);
		}

		// Token: 0x06000493 RID: 1171 RVA: 0x0000FE91 File Offset: 0x0000E091
		void INetworkVariableSerializer<!0>.ReadWithAllocator(FastBufferReader reader, out T value, Allocator allocator)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000494 RID: 1172 RVA: 0x00014812 File Offset: 0x00012A12
		public void Duplicate(in T value, ref T duplicatedValue)
		{
			duplicatedValue = value;
		}

		// Token: 0x06000496 RID: 1174 RVA: 0x00014820 File Offset: 0x00012A20
		void INetworkVariableSerializer<!0>.Duplicate(in T value, ref T duplicatedValue)
		{
			this.Duplicate(value, ref duplicatedValue);
		}
	}
}
