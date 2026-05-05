using System;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Mathematics;

namespace Unity.Netcode
{
	// Token: 0x020000C9 RID: 201
	internal class FixedStringSerializer<[IsUnmanaged] T> : INetworkVariableSerializer<!0> where T : struct, ValueType, INativeList<byte>, IUTF8Bytes
	{
		// Token: 0x060004B7 RID: 1207 RVA: 0x00014DF0 File Offset: 0x00012FF0
		public void Write(FastBufferWriter writer, ref T value)
		{
			writer.WriteValueSafe<T>(value, default(FastBufferWriter.ForFixedStrings));
		}

		// Token: 0x060004B8 RID: 1208 RVA: 0x00014E10 File Offset: 0x00013010
		public void Read(FastBufferReader reader, ref T value)
		{
			reader.ReadValueSafeInPlace<T>(ref value, default(FastBufferWriter.ForFixedStrings));
		}

		// Token: 0x060004B9 RID: 1209 RVA: 0x00014E30 File Offset: 0x00013030
		public unsafe void WriteDelta(FastBufferWriter writer, ref T value, ref T previousValue)
		{
			ResizableBitVector resizableBitVector = new ResizableBitVector(Allocator.Temp);
			try
			{
				int num = math.min(value.Length, previousValue.Length);
				int num2 = 0;
				for (int i = 0; i < num; i++)
				{
					byte b = value[i];
					byte b2 = previousValue[i];
					if (b != b2)
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
				if (resizableBitVector.GetSerializedSize() + FastBufferWriter.GetWriteSize<byte>() * num2 > FastBufferWriter.GetWriteSize<byte>() * value.Length)
				{
					writer.WriteByteSafe(1);
					writer.WriteValueSafe<T>(value, default(FastBufferWriter.ForFixedStrings));
				}
				else
				{
					writer.WriteByteSafe(0);
					BytePacker.WriteValuePacked(writer, value.Length);
					writer.WriteValueSafe<ResizableBitVector>(resizableBitVector, default(FastBufferWriter.ForNetworkSerializable));
					byte* unsafePtr = value.GetUnsafePtr();
					for (int k = 0; k < value.Length; k++)
					{
						if (resizableBitVector.IsSet(k))
						{
							writer.WriteByteSafe(unsafePtr[k]);
						}
					}
				}
			}
			finally
			{
				((IDisposable)resizableBitVector).Dispose();
			}
		}

		// Token: 0x060004BA RID: 1210 RVA: 0x00014FAC File Offset: 0x000131AC
		public unsafe void ReadDelta(FastBufferReader reader, ref T value)
		{
			byte b;
			reader.ReadByteSafe(out b);
			if (b == 1)
			{
				reader.ReadValueSafeInPlace<T>(ref value, default(FastBufferWriter.ForFixedStrings));
				return;
			}
			int length;
			ByteUnpacker.ReadValuePacked(reader, out length);
			ResizableBitVector resizableBitVector = new ResizableBitVector(Allocator.Temp);
			using (resizableBitVector)
			{
				reader.ReadNetworkSerializableInPlace<ResizableBitVector>(ref resizableBitVector);
				value.Length = length;
				byte* unsafePtr = value.GetUnsafePtr();
				for (int i = 0; i < value.Length; i++)
				{
					if (resizableBitVector.IsSet(i))
					{
						reader.ReadByteSafe(out unsafePtr[i]);
					}
				}
			}
		}

		// Token: 0x060004BB RID: 1211 RVA: 0x0000FE91 File Offset: 0x0000E091
		void INetworkVariableSerializer<!0>.ReadWithAllocator(FastBufferReader reader, out T value, Allocator allocator)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060004BC RID: 1212 RVA: 0x00014812 File Offset: 0x00012A12
		public void Duplicate(in T value, ref T duplicatedValue)
		{
			duplicatedValue = value;
		}

		// Token: 0x060004BE RID: 1214 RVA: 0x00015064 File Offset: 0x00013264
		void INetworkVariableSerializer<!0>.Duplicate(in T value, ref T duplicatedValue)
		{
			this.Duplicate(value, ref duplicatedValue);
		}
	}
}
