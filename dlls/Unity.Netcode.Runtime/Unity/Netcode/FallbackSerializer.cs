using System;
using Unity.Collections;

namespace Unity.Netcode
{
	// Token: 0x020000D4 RID: 212
	internal class FallbackSerializer<T> : INetworkVariableSerializer<!0>
	{
		// Token: 0x060004F4 RID: 1268 RVA: 0x000153C0 File Offset: 0x000135C0
		private void ThrowArgumentError()
		{
			throw new ArgumentException(string.Concat(new string[]
			{
				"Serialization has not been generated for type ",
				typeof(T).FullName,
				". This can be addressed by adding a [GenerateSerializationForGenericParameterAttribute] to your generic class that serializes this value (if you are using one), adding [GenerateSerializationForTypeAttribute(typeof(",
				typeof(T).FullName,
				")] to the class or method that is attempting to serialize it, or creating a field on a NetworkBehaviour of type NetworkVariable. If this error continues to appear after doing one of those things and this is a type you can change, then either implement INetworkSerializable or mark it as serializable by memcpy by adding INetworkSerializeByMemcpy to its interface list to enable automatic serialization generation. If not, assign serialization code to UserNetworkVariableSerialization.WriteValue, UserNetworkVariableSerialization.ReadValue, and UserNetworkVariableSerialization.DuplicateValue, or if it's serializable by memcpy (contains no pointers), wrap it in ",
				typeof(ForceNetworkSerializeByMemcpy<>).Name,
				"."
			}));
		}

		// Token: 0x060004F5 RID: 1269 RVA: 0x00015433 File Offset: 0x00013633
		public void Write(FastBufferWriter writer, ref T value)
		{
			if (UserNetworkVariableSerialization<T>.ReadValue == null || UserNetworkVariableSerialization<T>.WriteValue == null || UserNetworkVariableSerialization<T>.DuplicateValue == null)
			{
				this.ThrowArgumentError();
			}
			UserNetworkVariableSerialization<T>.WriteValue(writer, value);
		}

		// Token: 0x060004F6 RID: 1270 RVA: 0x0001545C File Offset: 0x0001365C
		public void Read(FastBufferReader reader, ref T value)
		{
			if (UserNetworkVariableSerialization<T>.ReadValue == null || UserNetworkVariableSerialization<T>.WriteValue == null || UserNetworkVariableSerialization<T>.DuplicateValue == null)
			{
				this.ThrowArgumentError();
			}
			UserNetworkVariableSerialization<T>.ReadValue(reader, out value);
		}

		// Token: 0x060004F7 RID: 1271 RVA: 0x00015488 File Offset: 0x00013688
		public void WriteDelta(FastBufferWriter writer, ref T value, ref T previousValue)
		{
			if (UserNetworkVariableSerialization<T>.ReadValue == null || UserNetworkVariableSerialization<T>.WriteValue == null || UserNetworkVariableSerialization<T>.DuplicateValue == null)
			{
				this.ThrowArgumentError();
			}
			if (UserNetworkVariableSerialization<T>.WriteDelta == null || UserNetworkVariableSerialization<T>.ReadDelta == null)
			{
				UserNetworkVariableSerialization<T>.WriteValue(writer, value);
				return;
			}
			UserNetworkVariableSerialization<T>.WriteDelta(writer, value, previousValue);
		}

		// Token: 0x060004F8 RID: 1272 RVA: 0x000154D8 File Offset: 0x000136D8
		public void ReadDelta(FastBufferReader reader, ref T value)
		{
			if (UserNetworkVariableSerialization<T>.ReadValue == null || UserNetworkVariableSerialization<T>.WriteValue == null || UserNetworkVariableSerialization<T>.DuplicateValue == null)
			{
				this.ThrowArgumentError();
			}
			if (UserNetworkVariableSerialization<T>.WriteDelta == null || UserNetworkVariableSerialization<T>.ReadDelta == null)
			{
				UserNetworkVariableSerialization<T>.ReadValue(reader, out value);
				return;
			}
			UserNetworkVariableSerialization<T>.ReadDelta(reader, ref value);
		}

		// Token: 0x060004F9 RID: 1273 RVA: 0x0000FE91 File Offset: 0x0000E091
		void INetworkVariableSerializer<!0>.ReadWithAllocator(FastBufferReader reader, out T value, Allocator allocator)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060004FA RID: 1274 RVA: 0x00015527 File Offset: 0x00013727
		public void Duplicate(in T value, ref T duplicatedValue)
		{
			if (UserNetworkVariableSerialization<T>.ReadValue == null || UserNetworkVariableSerialization<T>.WriteValue == null || UserNetworkVariableSerialization<T>.DuplicateValue == null)
			{
				this.ThrowArgumentError();
			}
			UserNetworkVariableSerialization<T>.DuplicateValue(value, ref duplicatedValue);
		}

		// Token: 0x060004FC RID: 1276 RVA: 0x00015550 File Offset: 0x00013750
		void INetworkVariableSerializer<!0>.Duplicate(in T value, ref T duplicatedValue)
		{
			this.Duplicate(value, ref duplicatedValue);
		}
	}
}
